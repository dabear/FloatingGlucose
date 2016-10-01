using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes.DataSources
{
    class DataSourceInfo
    {
        public Type Type { get; set; }
        public string DataSourceName { get; set; }
        public string FullName { get; set; }
        public dynamic Instance { get; set; }

        public DataSourceInfo(Type plugin)
        {
            this.Type = plugin;
            this.Instance = Activator.CreateInstance(plugin);
            this.DataSourceName = this.Instance.DataSourceName;
            this.FullName = plugin.FullName;
        }

        public override string ToString()
        {
            return DataSourceName;
        }
    }
}
