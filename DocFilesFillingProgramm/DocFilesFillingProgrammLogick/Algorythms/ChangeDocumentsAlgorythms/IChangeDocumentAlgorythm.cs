using DocFilesFillingProgrammLogick.Entities.DocumentEntities;
using DocFilesFillingProgrammLogick.Entities.InfoEntites;

namespace DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms
{
    /// <summary>
    /// Interface to algorythms, that incapsulate logick for changing documents with filling info.
    /// </summary>
    public interface IChangeDocumentAlgorythm
    {
        /// <summary>
        /// Change list of documents using filling info.
        /// </summary>
        /// <param name="dictionary"></param>
        void ChangeDocuments(IDocument document, IFillingInfo info);
    }
}
