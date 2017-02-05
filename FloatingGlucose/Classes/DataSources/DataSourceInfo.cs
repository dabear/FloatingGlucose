using System;
using System.Linq;
using System.Text;

namespace FloatingGlucose.Classes.DataSources
{
    public class DataSourceInfo
    {
        public Type Type { get; set; }
        public string DataSourceShortName { get; set; }
        public string FullName { get; set; }
        public IDataSourcePlugin Instance { get; set; }

        public DataSourceInfo(Type plugin)
        {
            this.Type = plugin;
            this.Instance = (IDataSourcePlugin)Activator.CreateInstance(plugin);
            this.DataSourceShortName = this.Instance.DataSourceShortName;
            this.FullName = plugin.FullName;
        }

        public DataSourceInfo(IDataSourcePlugin plugin)
        {
            this.Type = plugin.GetType();
            this.Instance = plugin;
            this.DataSourceShortName = this.Instance.DataSourceShortName;
            this.FullName = this.Type.FullName;
        }

        public override string ToString()
        {
            return this.DataSourceShortName;
        }
    }
}