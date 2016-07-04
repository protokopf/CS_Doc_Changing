using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocFilesFillingProgrammLogick.Entities;
using System.IO;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms
{
    class CreateDocumentUsingOpenXML : ICreateDocumentsAlgorythm
    {
        private string _pathToStorageFolder;
        private IConfigManager _configManager;
        private Random _randomizer;

        public CreateDocumentUsingOpenXML(string storageFolder)
        {
            _pathToStorageFolder = storageFolder;
            _configManager = new AppConfigManager();
            _randomizer = new Random();
        }

        public void CreateDocuments(ref Dictionary<IFillingInfo, IDocument> documents)
        {
            foreach(var pair in documents)
            {
                FormDocument(ref pair.Key, ref pair.Value);
            }
        }

        private void FormDocument(ref IFillingInfo info, ref IDocument document)
        {
            string pathToFile = CreateDocumentInFileSystem(info);

        }
        private string CreateDocumentInFileSystem(IFillingInfo info)
        {
            string copyPath = null;
            switch(info.Fields["*GENDER*"])
            {
                case "male":
                    copyPath = _configManager["maleTemplate"];
                    break;
                case "female":
                    copyPath = _configManager["femaleTemplate"];
                    break;
            }
            string newName =_pathToStorageFolder + info.Fields["*NAME*"] + info.Fields["*LASTNAME*"] + _randomizer.Next().ToString();
            File.Copy(copyPath, newName);
            return newName;
        }
    }
}
