using System;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Timers;
using Chaincase.Common;
using Chaincase.Common.Services;
using ReactiveUI;
using WalletWasabi.Blockchain.Keys;
using WalletWasabi.Logging;

namespace Chaincase.UI.ViewModels
{
    public class ReceiveViewModel : ReactiveObject, INotifyPropertyChanged
    {
        protected Global Global { get; }
        public string PayJoinValue = "pj";
        public string DefaultRecieveAddress = "default";

        private string _proposedLabel;
        private int _propsedAmount;
        private bool[,] _qrCode;
        private string _requestAmount;
        private bool _isPayJoining = true;
        private string _receiveType = "pj";
        private string _p2epAddress;
        private string _hiddenServiceExpiration;

        public ReceiveViewModel(Global global)
        {
            Global = global;
            Observable.Interval(TimeSpan.FromSeconds(1))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(_ =>
                {
                    TimeSpan t = TimeSpan.FromMilliseconds(TimeLeft);
                    HiddenServiceTimeLeft = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                 t.Hours,
                                 t.Minutes,
                                 t.Seconds,
                                 t.Milliseconds);
                });
        }

        public void InitNextReceiveKey()
        {
            if (ProposedLabel == null) ProposedLabel = "";
            ReceivePubKey = Global.Wallet.KeyManager.GetNextReceiveKey(ProposedLabel, out bool minGapLimitIncreased);
            ProposedLabel = "";
        }
 
        public string Address => ReceivePubKey.GetP2wpkhAddress(Global.Network).ToString();

        public string AppliedLabel => ReceivePubKey.Label ?? "";
        public string Pubkey => ReceivePubKey.PubKey.ToString();
        public string KeyPath => ReceivePubKey.FullKeyPath.ToString();

        public HdPubKey ReceivePubKey { get; set; }

        public string BitcoinUri => $"bitcoin:{Address}";

        public string P2EPUri => $"bitcoin:{Address}?pj={Global.P2EPServer.PaymentEndpoint}&amount={ProposedAmount}";

        private double TimeLeft => Global.P2EPTimer.GetTimeLeft();

        public void GenerateP2EP() {
            if (!Global.P2EPServer.HiddenServiceIsOn) {
                StartPayjoin();
                Global.P2EPTimer.StartTimer(180000); // 3 min
            }
            P2EPAddress = Global.P2EPServer.PaymentEndpoint;
        }

        public void StartPayjoin() {
            var cts = new CancellationToken();
            Global.P2EPServer.StartAsync(cts);
            Logger.LogInfo($"P2EP Server listening created: {Global.P2EPServer.PaymentEndpoint}");
        }

        public string ProposedLabel
        {
            get => _proposedLabel;
            set => this.RaiseAndSetIfChanged(ref _proposedLabel, value);
        }

        public int ProposedAmount
        {
            get => _propsedAmount;
            set => this.RaiseAndSetIfChanged(ref _propsedAmount, value);
        }

        public bool[,] QrCode
        {
            get => _qrCode;
            set => this.RaiseAndSetIfChanged(ref _qrCode, value);
        }

        public string RequestAmount
        {
            get => _requestAmount;
            set => this.RaiseAndSetIfChanged(ref _requestAmount, value);
        }

        public bool IsPayJoining
        {
            get => _isPayJoining;
            set => this.RaiseAndSetIfChanged(ref _isPayJoining, value);
        }   

        public string P2EPAddress
        {
            get => _p2epAddress;
            set => this.RaiseAndSetIfChanged(ref _p2epAddress, value);
        }

        public string ReceiveType
        {
            get => _receiveType;
            set => this.RaiseAndSetIfChanged(ref _receiveType, value);
        }

        public string HiddenServiceTimeLeft
        {
            get => _hiddenServiceExpiration;
            set => this.RaiseAndSetIfChanged(ref _hiddenServiceExpiration, value);
        }
    }
}
