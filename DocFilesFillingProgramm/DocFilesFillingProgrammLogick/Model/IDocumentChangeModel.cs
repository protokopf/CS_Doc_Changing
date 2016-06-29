
using DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms;


namespace DocFilesFillingProgrammLogick.Model
{
    /// <summary>
    /// Interface for model, that change documents with specific info.
    /// </summary>
    interface IDocumentChangeModel
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
        void StartChangingDocuments();

        /// <summary>
        /// Stops changing documents.
        /// </summary>
        void StopChangingDocuments();
       
        /// <summary>
        /// Saves all created documents.
        /// </summary>
        void SaveDocuments();

        /// <summary>
        /// Path to storage, where created and changed documents will be storaged.
        /// </summary>
        string StoragePath { get; set; }

        IRetrieveInfoAlgorythm RetrieveInfoAlgorythm { get; set; }
        ICreateDocumentsAlgorythm CreateAlgorythm { get; set; }
        IChangeDocumentsAlgorythm ChangeAlgorythm { get; set; }
    }
}
