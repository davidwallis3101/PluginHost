using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Castle.Core.Logging;
using Microsoft.Reactive.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Plugin.Example.Tests
{
    [TestClass]
    public class SampleTests
    {
        // Example from http://blogs.microsoft.co.il/bnaya/2010/07/09/testing-and-debugging-mef-tips-part-1/
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var logic = new TimerTest();
            var container = new CompositionContainer();
            // var loggerMock = new Mock<ILogger>();
            //container.ComposeExportedValue<ILogger>(loggerMock.Object);
            container.ComposeParts(logic);

            // Test
            logic.StartTimer();

            // Validate
            //loggerMock.Verify(logger => logger.Write(It.IsAny<string>()), Times.Once());
        }


        // http://awkwardcoder.blogspot.com/2012/10/testing-time-based-observable-in-rx-is.html
        [TestMethod]
        public void should_tick_twice_in_three_minutes()
        {
            // Setup
            // a minute in ticks...
            long _minuteInTicks = new TimeSpan(0, 0, 1, 0).Ticks;

            // this is the important bit...
            TestScheduler _scheduler = new TestScheduler();

            // ARRANGE
            // var ticker = new MyTicker(_scheduler);
            var tickInternval = TimeSpan.FromMinutes(1);
            var count = 0;
                  
            // ACT
            //using (ticker.TickEvery(tickInternval)
            //    .Subscribe(_ => count++))
            //{
            //    _scheduler.AdvanceBy(_minuteInTicks);
            //    _scheduler.AdvanceBy(_minuteInTicks);
            //}
       
            _scheduler.AdvanceBy(_minuteInTicks);
       
            // ASSERT
            Assert.AreEqual(count, 2, "the count should have only been incremented twice...");
        }
      

    }
}
