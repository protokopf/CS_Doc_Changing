using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
using DocFilesFillingProgrammLogick.Entities;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocFilesFillingProgrammLogick.Model;
using DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms;

namespace DocFilesFillingProgrammConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string storageFolder = @"C:\Users\Константин\Desktop\Documents";
            string excelPath = @"Storage\excelStorage.xlsx";


            IDocumentChangeModel model = new CreateAndChangeDocumentsWithStudentInfoModel(storageFolder,excelPath);

            model.RetrieveInfoAlgorythm = new RetrieveInfoFromExcelUsingOpenXML(excelPath, "ListSheet");
            model.CreateAlgorythm = new CreateDocumentUsingFileCopy(storageFolder,excelPath);
            model.ChangeAlgorythm = new ChangeDocumentUsingExcelAlgorythm();

            model.RetrieveFillingInfo();
            model.CreateDocuments();
            model.ChangeDocuments();
            model.SaveDocuments();
        }
    }
}
