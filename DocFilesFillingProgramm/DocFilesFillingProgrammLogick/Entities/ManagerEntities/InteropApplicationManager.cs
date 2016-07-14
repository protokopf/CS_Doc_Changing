using Microsoft.Office.Interop.Word;
using System;
using System.Runtime.InteropServices;

namespace DocFilesFillingProgrammLogick.Entities.ManagerEntities
{
    public class InteropApplicationManager
    {
        private static Application _application;

        static InteropApplicationManager()
        {
            _application = new Application();
        }

        public static Document GetDocument(string fileName)
        {
            return _application.Documents.Open(fileName);
        }
        public static void Quit()
        {
            _application.Quit();
        }

    }
}
