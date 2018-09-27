// <copyright file="PluginImporter.cs" company="David Wallis">
// Copyright (c) David Wallis. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using NLog;
using Plugin.Interface;

namespace Plugin.Host
{
    public class PluginImporter
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        [ImportMany(typeof(IPlugin))]

        // private IEnumerable<Lazy<IPlugin>> plugins;
        private IEnumerable<IPlugin> plugins;

        [Export(typeof(ISomething))]
        public ISomething Something = new Test();

        public int AvailableNumberOfPlugins => this.plugins?.Count() ?? 0;

        public void DoImport()
        {
            // An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            var pluginFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            if (!Directory.Exists(pluginFolder))
            {
                log.Debug("Creating plugins folder {0}", pluginFolder);
                Directory.CreateDirectory(pluginFolder);
            }

            log.Debug("Looking for plugins in folder {0}", pluginFolder);

            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly())); // Add this assembly
            catalog.Catalogs.Add(new DirectoryCatalog(pluginFolder));

            // Create the CompositionContainer with the parts in the catalog.
            var container = new CompositionContainer(catalog);

            // Fill the imports of this object
            container.ComposeParts(this);
        }

        public List<string> CallAllComponents(params double[] args)
        {
            var result = new List<string>();

            // foreach (Lazy<IPlugin> com in plugins)
            foreach (var com in this.plugins)
            {
                log.Info("Plugin Description: {0} Plugin Version {1}", com.Description, Assembly.GetAssembly(com.GetType()).GetName().Version.ToString());

                com.Start($"test from host {com.Description}");

                // result.Add(com.Value.ManipulateOperation(args));
            }

            return result;
        }
    }
}
