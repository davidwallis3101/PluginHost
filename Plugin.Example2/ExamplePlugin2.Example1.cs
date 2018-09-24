// <copyright file="Plugin.Example.cs" company="David Wallis">
// Copyright (c) David Wallis. All rights reserved.
// </copyright>

using System.ComponentModel.Composition;
using Plugin.Example2.Logging;
using Plugin.Interface;

namespace Plugin.Example2
{

    [Export(typeof(IPlugin))]
    public class ExamplePlugin2 : IPlugin
    {
        private static readonly ILog Logger = LogProvider.For<ExamplePlugin2>();

        public string Description => "Second Plugin Example";

        public Status Status { get; set; }

        [Import]
        public ISomething something { get; set; }

        public void Start(string message)
        {
            Logger.Info("Plugin 2 Starting");

            var test = new TimerTest();
            test.StartTimer();

            this.something.DoSomething("a value from plugin2");
        }
    }
}
