namespace DocFilesFillingProgrammLogick.Entities.DocumentEntities
{
    /// <summary>
    /// Interface to all kind of documents, that can be changing by using filling info.
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Create in memory and open document.
        /// </summary>
        void Open();

        /// <summary>
        /// Close document.
        /// </summary>
        void Close();

        /// <summary>
        /// Saves document.
        /// </summary>
        void Save();
        
        /// <summary>
        /// Replace replaced text with replaceable text in document.
        /// </summary>
        void ReplaceTextInPosition(string newText, string oldText);

        /// <summary>
        /// Path to document file in file system.
        /// </summary>
        string Path { get; set; }

        /// <summary>
        /// Name of document.
        /// </summary>
        string Name { get; set; }
    }
}
