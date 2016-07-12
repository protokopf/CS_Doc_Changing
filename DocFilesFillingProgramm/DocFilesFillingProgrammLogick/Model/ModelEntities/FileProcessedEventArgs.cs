using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFilesFillingProgrammLogick.Model.ModelEntities
{
    public class FileProcessedEventArgs : EventArgs
    {
        public int FilesCount { get; set; }
        public int ProcessedFilse { get; set; }
    }
}
