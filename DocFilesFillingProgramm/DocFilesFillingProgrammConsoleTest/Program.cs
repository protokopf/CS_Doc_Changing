
using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
using DocFilesFillingProgrammLogick.Model;
using DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Entities.ManagetEntities;

namespace DocFilesFillingProgrammConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string storageFolder = @"C:\Users\Константин\Desktop\Documents";


            IDocumentChangeModel model = new CreateAndChangeDocumentsWithStudentInfoModel(storageFolder,AppConfigManager.Instance()["excelStorage"]);

            model.RetrieveInfoAlgorythm = new RetrieveInfoFromExcelUsingOpenXML(AppConfigManager.Instance()["excelStorage"], AppConfigManager.Instance()["excelSheet"]);
            model.CreateAlgorythm = new CreateInteropWordDocumentAlgorythm(storageFolder, AppConfigManager.Instance()["excelStorage"]);
            model.ChangeAlgorythm = new GeneralChangeAlgorythm();

            model.RetrieveFillingInfo();
            model.CreateDocuments();
            model.ChangeDocuments();
        }
    }
}
