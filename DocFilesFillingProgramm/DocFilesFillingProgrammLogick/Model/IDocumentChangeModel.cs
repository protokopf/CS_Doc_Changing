
using DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms;


namespace DocFilesFillingProgrammLogick.Model
{
    /// <summary>
    /// Interface for model, that change documents with specific info.
    /// </summary>
    public interface IDocumentChangeModel
    {
        /// <summary>
        /// Retrieves filling info from anywhere.
        /// </summary>
        void RetrieveFillingInfo();

        /// <summary>
        /// Creates document.
        /// </summary>
        void CreateDocuments();

        /// <summary>
        /// Starts changing documents (in separate thread, maybe).
        /// </summary>
        void ChangeDocuments();
    
        /// <summary>
        /// Saves all created documents.
        /// </summary>
        void SaveDocuments();

        /// <summary>
        /// Path to storage, where created and changed documents will be storaged.
        /// </summary>
        string StoragePath { get; set; }

        /// <summary>
        /// Path to file, that contains all changing information
        /// </summary>
        string DataFilePath { get; set; }

        IRetrieveInfoAlgorythm RetrieveInfoAlgorythm { get; set; }
        ICreateDocumentAlgorythm CreateAlgorythm { get; set; }
        IChangeDocumentAlgorythm ChangeAlgorythm { get; set; }
    }
}
