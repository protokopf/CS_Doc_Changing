namespace DocFilesFillingProgrammLogick.Entities.ManagetEntities
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
