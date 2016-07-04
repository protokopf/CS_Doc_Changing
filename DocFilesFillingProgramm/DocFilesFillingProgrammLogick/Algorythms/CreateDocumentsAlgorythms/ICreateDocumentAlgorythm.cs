using System.Collections.Generic;

using DocFilesFillingProgrammLogick.Entities;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms
{
    /// <summary>
    /// Interface to algorythms, that incapsulate logick for creating documents, using or not filling info.
    /// </summary>
    public interface ICreateDocumentsAlgorythm
    {
        /// <summary>
        /// Creates and returns list of documents.
        /// </summary>
        /// <param name="documents"></param>
        void CreateDocuments(ref Dictionary<IFillingInfo,IDocument> documents);
    }
}
