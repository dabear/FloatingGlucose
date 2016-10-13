using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;

using System.IO;
using static FloatingGlucose.Properties.Settings;
using FloatingGlucose.Classes.DataSources;

namespace FloatingGlucose.Classes.DataSources
{
   
    public class PluginLoader
    {
        private static readonly PluginLoader instance = new PluginLoader();
        private IDataSourcePlugin plugin;
        private List<DataSourceInfo> loadedPlugins;

        public List<DataSourceInfo> GetAllPlugins(bool forceReload = false)
        {
            if(forceReload || loadedPlugins == null)
            {
                var list = new List<DataSourceInfo>();

                // Fill the list of plugins, these are fairly static and won't change during runtime
                var type = typeof(IDataSourcePlugin);
                var allPlugins = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany((x) => x.GetTypes().Where((y) => type.IsAssignableFrom(y) && !y.IsInterface));

                foreach (Type plugin in allPlugins)
                {
                    list.Add(new DataSourceInfo(plugin));
                }
                this.loadedPlugins = list;
            }
            

            return this.loadedPlugins;

        }
        public IDataSourcePlugin GetActivePlugin()
        {
            if(this.plugin != null)
            {
                return this.plugin;
            }
            //use default plugin from config file
            // this can change between run
            var fullname = Default.DataSourceFullName;
            return this.SetActivePlugin(fullname);

        }

        public IDataSourcePlugin SetActivePlugin(string dataSourceFullName)
        {
            this.plugin = this.GetAllPlugins().Where((x) => x.FullName == dataSourceFullName).First().Instance;
            return this.plugin;
        }


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static PluginLoader()
        {
        }

        private PluginLoader()
        {
        }

        public static PluginLoader Instance
        {
            get
            {
                return instance;
            }
        }
        
    }
}
