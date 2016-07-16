using System.IO;
using DocFilesFillingProgrammLogick.Entities.DocumentEntities;
using DocFilesFillingProgrammLogick.Entities.InfoEntites;
using DocFilesFillingProgrammLogick.Entities.ManagetEntities;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms
{
    public class CreateOpenXMLDocumentAlgorythm : ICreateDocumentAlgorythm
    {

        private string _pathToStorageFolder;
        private string _pathToExcelDocument;

        public CreateOpenXMLDocumentAlgorythm(string storageFolder, string dataFilePath)
        {
            _pathToExcelDocument = dataFilePath;
            _pathToStorageFolder = storageFolder;
        }

        public IDocument CreateDocument(IFillingInfo info)
        {
            return FormDocument(info);
        }


        private IDocument FormDocument(IFillingInfo info)
        {
            string name = (GenerateFileName(info)).Trim();
            string fullPath = (Path.Combine(_pathToStorageFolder, name)).Trim();
            string templatePath = null;
            switch (info.Fields["<gender>"])
            {
                case "male":
                    templatePath = AppConfigManager.Instance()["maleTemplate"];
                    break;
                case "female":
                    templatePath = AppConfigManager.Instance()["femaleTemplate"];
                    break;
            }
            File.Copy(templatePath, fullPath);
            return new OpenXMLWordDocument(fullPath,name);
        }
        private string GenerateFileName(IFillingInfo info)
        {
            return string.Format("{0}.{1}_{2}{3}", info.Fields["<id>"], info.Fields["<NAME>"], info.Fields["<LASTNAME>"], AppConfigManager.Instance()["fileExtention"]);
        }  
    }
}
