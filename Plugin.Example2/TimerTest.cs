using System;
using System.Reactive.Linq;
using Plugin.Example2.Logging;

namespace Plugin.Example2
{
    internal class TimerTest
    {
        private static readonly ILog Logger = LogProvider.For<TimerTest>();

        public void StartTimer()
        {
            Observable
                .Interval(TimeSpan.FromSeconds(0.5))
                .Subscribe(x => Logger.Info(x.ToString));
        }
    }
}
