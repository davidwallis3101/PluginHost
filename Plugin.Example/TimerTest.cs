using System;
using System.Reactive.Linq;
using Plugin.Example.Logging;

namespace Plugin.Example
{
    public class TimerTest
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
