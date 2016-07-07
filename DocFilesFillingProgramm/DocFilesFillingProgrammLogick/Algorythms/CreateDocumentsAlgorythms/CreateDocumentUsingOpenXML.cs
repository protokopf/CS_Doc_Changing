using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocFilesFillingProgrammLogick.Entities;
using System.IO;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms
{
    public class CreateDocumentUsingFileCopy : ICreateDocumentsAlgorythm
    {
        private const string pathToMaleTemplate = @"Templates\maleTemplate.docx";
        private const string pathToFemaleTemplate = @"Templates\femaleTemplate.docx";
        private const string fileExtention = ".docx";

        private string _pathToStorageFolder;
        private string _pathToExcelDocument;

        public CreateDocumentUsingFileCopy(string storageFolder, string dataFilePath)
        {
            _pathToExcelDocument = dataFilePath;
            _pathToStorageFolder = storageFolder;
        }

        public void CreateDocuments(ref IList<DocumentAndInfoEntity> documents)
        {
            foreach(DocumentAndInfoEntity pair in documents)
                FormDocument(pair);
        }


        private void FormDocument(DocumentAndInfoEntity document)
        {
            string name = (GenerateFileName(document)).Trim();
            string fullPath = (Path.Combine(_pathToStorageFolder, name)).Trim();
            string templatePath = null;
            switch (document.Info.Fields["XGENDERX"])
            {
                case "male":
                    templatePath = pathToMaleTemplate;
                    break;
                case "female":
                    templatePath = pathToFemaleTemplate;
                    break;
            }
            File.Copy(templatePath, fullPath);
            document.Document = new OpenXMLWordDocument(fullPath,name);
        }
        private string GenerateFileName(DocumentAndInfoEntity document)
        {
            string fileName = String.Format("{0}.{1}_{2}{3}", document.Info.Fields["XIDX"], document.Info.Fields["XNAMEX"], document.Info.Fields["XLASTNAMEX"],  fileExtention);
            return fileName;
        }
    }
}
