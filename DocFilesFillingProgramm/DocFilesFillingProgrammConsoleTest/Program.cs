
using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
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
            model.CreateAlgorythm = new CreateOpenXMLDocumentAlgorythm(storageFolder,excelPath);
            model.ChangeAlgorythm = new GeneralChangeAlgorythm();

            model.RetrieveFillingInfo();
            model.CreateDocuments();
            //model.ChangeDocuments();
            //model.SaveDocuments();
        }
    }
}
