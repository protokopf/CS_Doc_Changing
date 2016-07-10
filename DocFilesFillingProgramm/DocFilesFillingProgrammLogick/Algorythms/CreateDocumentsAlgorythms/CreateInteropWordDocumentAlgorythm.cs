using DocFilesFillingProgrammLogick.Entities.DocumentEntities;
using DocFilesFillingProgrammLogick.Entities.InfoEntites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms
{
    public class CreateInteropWordDocumentAlgorythm : ICreateDocumentAlgorythm
    {
        private const string pathToMaleTemplate = @"Templates\maleTemplate.docx";
        private const string pathToFemaleTemplate = @"Templates\femaleTemplate.docx";
        private const string fileExtention = ".docx";

        private string _pathToStorageFolder;
        private string _pathToExcelDocument;

        public CreateInteropWordDocumentAlgorythm(string storageFolder, string dataFilePath)
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
                    templatePath = pathToMaleTemplate;
                    break;
                case "female":
                    templatePath = pathToFemaleTemplate;
                    break;
            }
            File.Copy(templatePath, fullPath);
            return new InteropWordDocument(name, fullPath);
        }
        private string GenerateFileName(IFillingInfo info)
        {
            string fileName = String.Format("{0}.{1}_{2}{3}", info.Fields["<id>"], info.Fields["<NAME>"], info.Fields["<LASTNAME>"], fileExtention);
            return fileName;
        }
    }
}
