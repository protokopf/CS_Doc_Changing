using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocFilesFillingProgrammLogick.Entities;
using System.IO;
using DocumentFormat.OpenXml.Packaging;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms
{
    class CreateFromExcelAlgorythm : ICreateDocumentsAlgorythm
    {
        private Stream _fstream;
        private SpreadsheetDocument _xmlDoc;
        private string _pathToFile;
        private string _sheetName;


        public CreateFromExcelAlgorythm(string path, string sheetName)
        {
            _pathToFile = path;
            _sheetName = sheetName;
        }
        public void CreateDocuments(ref Dictionary<IFillingInfo, IDocument> documents)
        {
            //using (_fstream = file.open(_pathtofile, filemode.open))
            //{
            //    using (_xmldoc = spreadsheetdocument.open(_pathtofile, false))
            //    {

            //    }
            //}
        }
    }
}
