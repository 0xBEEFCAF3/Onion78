using System.Threading;
using Chaincase.Common;
using Chaincase.Common.Services;
using ReactiveUI;
using WalletWasabi.Blockchain.Keys;
using WalletWasabi.Logging;

namespace Chaincase.UI.ViewModels
{
    public class ReceiveViewModel : ReactiveObject
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
        public P2EPServer P2EPServer { get; private set; }


        public ReceiveViewModel(Global global)
        {
            Global = global;
            P2EPServer = new P2EPServer(global);
            GenerateP2EP();
        }

        public void InitNextReceiveKey()
        {
            ReceivePubKey = Global.Wallet.KeyManager.GetNextReceiveKey(ProposedLabel, out bool minGapLimitIncreased);
            ProposedLabel = "";
        }

        public string Address => ReceivePubKey.GetP2wpkhAddress(Global.Network).ToString();

        public string AppliedLabel => ReceivePubKey.Label ?? "";
        public string Pubkey => ReceivePubKey.PubKey.ToString();
        public string KeyPath => ReceivePubKey.FullKeyPath.ToString();

        public HdPubKey ReceivePubKey { get; set; }

        public string BitcoinUri => $"bitcoin:{Address}";

        public string P2EPUri => $"bitcoin:{Address}?pj={P2EPServer.PaymentEndpoint}&amountparam={ProposedAmount}&message={ProposedLabel}";

        public void Dispose() {
            if (P2EPServer.HiddenServiceIsOn) {
                var cts = new CancellationToken();
                P2EPServer.StopAsync(cts);
            }
        }

        public void GenerateP2EP() {
            StartPayjoin();
            if (P2EPServer.HiddenServiceIsOn) {
                P2EPAddress = P2EPServer.PaymentEndpoint;
            }
        }

        public void StartPayjoin() {
            var cts = new CancellationToken();
            P2EPServer.StartAsync(cts);
            Logger.LogInfo($"P2EP Server listening created: {P2EPServer.PaymentEndpoint}");
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
    }
}
