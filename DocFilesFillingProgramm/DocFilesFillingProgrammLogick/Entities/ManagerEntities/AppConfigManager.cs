using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace DocFilesFillingProgrammLogick.Entities.ManagetEntities
{

    public class AppConfigManager : IConfigManager
    {

        private static AppConfigManager _manager;

        private const string male = "maleTemplate";
        private const string female = "femaleTemplate";
        private const string extention = "fileExtention";
        private const string storage = "excelStorage";
        private const string sheet = "excelSheet";

        private AppConfigManager()
        {
           
        }

        public static AppConfigManager Instance()
        {
            return _manager ?? (_manager = new AppConfigManager());
        }

        public string GetExtention()
        {
            return ConfigurationSettings.AppSettings[extention];
        }

        public string GetFemaleTemplate()
        {
            string pathToFile = ConfigurationSettings.AppSettings[female];
            CheckIfFileExists(pathToFile);
            return pathToFile;
        }

        public string GetMaleTemplate()
        {
            string pathToFile = ConfigurationSettings.AppSettings[male];
            CheckIfFileExists(pathToFile);
            return pathToFile;
        }

        public string GetSheet()
        {
            return ConfigurationSettings.AppSettings[sheet];
        }

        public string GetStorage()
        {
            string pathToStorage =  ConfigurationSettings.AppSettings[storage];
            CheckIfFileExists(pathToStorage);
            return pathToStorage;
        }

        
        private void CheckIfFileExists(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                string folderPath = Path.GetDirectoryName(pathToFile);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
               CreateFile(pathToFile);
            }
        }
        private void CreateFile(string pathToFile)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string assName = currentAssembly.FullName;
            string fullPathToSource = assName.Substring(0, assName.IndexOf(',')) + ".NesessaryResources." + Path.GetFileName(pathToFile);
            Stream fileStream = currentAssembly.GetManifestResourceStream(fullPathToSource);
            FileStream file = File.Create(pathToFile);
            fileStream.CopyTo(file);

            fileStream.Close();
            file.Close();
        }
    }
}
