using Microsoft.Office.Interop.Word;


namespace DocFilesFillingProgrammLogick.Entities.ManagerEntities
{
    public class InteropApplicationManager
    {
        private static InteropApplicationManager _manager = null;
        private Application _application;

        private InteropApplicationManager()
        {
            _application = new Application();
        }

        public static InteropApplicationManager Instance()
        {
            return _manager ?? new InteropApplicationManager();
        }
        public Document GetDocument(string fileName)
        {
            return _application.Documents.Open(fileName);
        }
    }
}
