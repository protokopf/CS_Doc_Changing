using System.IO;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms.CopyAlgorythms
{
    class SillyCopyAlgorythm : ICopyAlgorythm
    {
        public void MakeCopy(string fromPath, string toPath)
        {
            File.Copy(fromPath, toPath);
        }
    }
}
