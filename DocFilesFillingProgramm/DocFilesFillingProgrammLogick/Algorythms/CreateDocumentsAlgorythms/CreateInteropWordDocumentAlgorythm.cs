using DocFilesFillingProgrammLogick.Entities.DocumentEntities;
using DocFilesFillingProgrammLogick.Entities.InfoEntites;
using DocFilesFillingProgrammLogick.Entities.ManagetEntities;


using System;
using System.IO;
using DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms.CopyAlgorythms;


namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms
{
    public class CreateInteropWordDocumentAlgorythm : ICreateDocumentAlgorythm
    {
        private string _pathToStorageFolder;
        private string _pathToExcelDocument;
        private ICopyAlgorythm _copyAlgorythm;


        public CreateInteropWordDocumentAlgorythm(string folder)
        {
            _pathToStorageFolder =  folder;
            _copyAlgorythm = new CopyWithReplacementAlgorythm();
        }

        public IDocument CreateDocument(IFillingInfo info)
        {
            _pathToExcelDocument = AppConfigManager.Instance().GetStorage();

            string name = (GenerateFileName(info)).Trim();
            string fullPath = (Path.Combine(_pathToStorageFolder, name)).Trim();
            string templatePath = null;
            switch (info.Fields["<gender>"])
            {
                case "male":
                    templatePath = AppConfigManager.Instance().GetMaleTemplate();
                    break;
                case "female":
                    templatePath = AppConfigManager.Instance().GetFemaleTemplate();
                    break;
            }
            _copyAlgorythm.MakeCopy(templatePath, fullPath);
            return new InteropWordDocument(name, fullPath);
        }

        private string GenerateFileName(IFillingInfo info)
        {
            return String.Format("{0}.{1}_{2}{3}", info.Fields["<id>"], info.Fields["<NAME>"], info.Fields["<LASTNAME>"], AppConfigManager.Instance().GetExtention());
        }
    }
}
