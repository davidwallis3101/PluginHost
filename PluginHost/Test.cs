using System;
using System.ComponentModel.Composition;
using Plugin.Interface;

namespace Plugin.Host
{
    public class Test : ISomething
    {
        [Export(typeof(ISomething))]
        public void DoSomething(string value)
        {
            Console.WriteLine("Doing something with the value: {0}", value);
        }
    }
}
