using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms.CopyAlgorythms
{
    class SkipExistingFileCopyAlgorythm : ICopyAlgorythm
    {
        public void MakeCopy(string fromPath, string toPath)
        {
            if (!File.Exists(toPath))
                File.Copy(fromPath, toPath);
        }
    }
}
