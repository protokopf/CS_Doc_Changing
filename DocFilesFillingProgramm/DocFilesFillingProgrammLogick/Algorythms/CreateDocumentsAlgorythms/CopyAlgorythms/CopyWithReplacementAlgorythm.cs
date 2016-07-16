using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms.CopyAlgorythms
{
    class CopyWithReplacementAlgorythm : ICopyAlgorythm
    {
        public void MakeCopy(string fromPath, string toPath)
        {
            File.Copy(fromPath, toPath, true);
        }
    }
}
