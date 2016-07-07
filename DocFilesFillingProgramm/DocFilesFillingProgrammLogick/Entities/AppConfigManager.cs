using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFilesFillingProgrammLogick.Entities
{
    public class AppConfigManager : IConfigManager
    {
        public string this[string key]
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings[key];
            }
        }
    }
}
