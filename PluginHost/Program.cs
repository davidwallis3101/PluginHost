// <copyright file="Program.cs" company="David Wallis">
// Copyright (c) David Wallis. All rights reserved.
// </copyright>

using System;
using NLog;

namespace Plugin.Host
{
    internal static class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static void Main()
        {
            logger.Info("Starting");

            var pluginImporter = new PluginImporter();
            pluginImporter.DoImport();
            pluginImporter.CallAllComponents();


            // Some tests might be possible with this:
            // http://dotnetbyexample.blogspot.com/2010/04/very-basic-mef-sample-using-importmany.html

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
