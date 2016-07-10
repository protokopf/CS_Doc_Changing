using System.Configuration;

namespace DocFilesFillingProgrammLogick.Entities.ManagetEntities
{

    public class AppConfigManager : IConfigManager
    {
        private static AppConfigManager _manager;
        public AppConfigManager()
        {
           
        }

        public static AppConfigManager Instance()
        {
            return _manager ?? new AppConfigManager();
        }

        public string this[string key]
        {
            get
            {
               return ConfigurationSettings.AppSettings[key];
            }
        }
    }
}
