using System;

namespace DocFilesFillingProgrammLogick.Model.ModelEntities
{
    public class FileProcessedEventArgs : EventArgs
    {
        public int FilesCount { get; set; }
        public int ProcessedFilse { get; set; }
    }
}
