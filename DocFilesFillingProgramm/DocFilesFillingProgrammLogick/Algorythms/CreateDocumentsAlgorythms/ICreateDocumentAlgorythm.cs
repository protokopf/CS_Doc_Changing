using DocFilesFillingProgrammLogick.Entities.DocumentEntities;
using DocFilesFillingProgrammLogick.Entities.InfoEntites;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms
{
    /// <summary>
    /// Interface to algorythms, that incapsulate logick for creating documents, using or not filling info.
    /// </summary>
    public interface ICreateDocumentAlgorythm
    {
        /// <summary>
        /// Creates and returns list of documents.
        /// </summary>
        /// <param name="documents"></param>
        IDocument CreateDocument(IFillingInfo info);
    }
}
