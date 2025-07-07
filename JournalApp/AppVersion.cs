using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JournalApp
{
    internal class AppVersion
    {
        public static string GetVersion()
        {
            //var version = Application.ProductVersion;
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            //var parts = version?.Split('+') ?? ["1.0.0.*"];
            return version?.ToString()??"1.0.0.*";//parts[0];
        }
    }
}
