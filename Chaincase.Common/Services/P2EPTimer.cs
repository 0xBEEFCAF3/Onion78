using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using WalletWasabi.Logging;

namespace Chaincase.Common.Services
{
    public class P2EPTimer
    {
        private Global Global;
        //public System.Diagnostics.StopWatch StopWatch { get; private set; }
        private Stopwatch _stopwatch;
        private double _interval;
        public P2EPTimer(Global global)
        {
            Global = global;
        }

        public void StartTimer(double interval) {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            _interval = interval;
            _stopwatch = new Stopwatch();

            timer.Elapsed += new ElapsedEventHandler(DestroyP2EPServiceEvent);
            timer.Enabled = true;
            timer.AutoReset = false;
            _stopwatch.Start();
        }

        public void DestroyP2EPServiceEvent(object source, ElapsedEventArgs e)
        {
            if (Global.P2EPServer.HiddenServiceIsOn)
            {
                var cts = new CancellationToken();
                Global.P2EPServer.StopAsync(cts);
                Logger.LogInfo("P2EPTimer.DestroyP2EPServiceEvent(): Destorying P2EP service");
                _stopwatch.Stop();
            }
        }

        public double GetTimeLeft() {
            if (_stopwatch == null) return 0;
            if (!_stopwatch.IsRunning) return 0;
            if (_stopwatch.ElapsedMilliseconds > _interval) return 0;
            return _interval - _stopwatch.ElapsedMilliseconds;
        }
    }
}
