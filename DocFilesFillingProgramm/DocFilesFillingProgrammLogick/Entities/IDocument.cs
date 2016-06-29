namespace DocFilesFillingProgrammLogick.Entities
{
    /// <summary>
    /// Interface to all kind of documents, that can be changing by using filling info.
    /// </summary>
    interface IDocument
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
        /// Replace replaced text with replaceable text in document.
        /// </summary>
        /// <param name="repleaceableText"></param>
        /// <param name="replacedText"></param>
        void ReplaceTextInPosition(string repleaceableText, string replacedText);

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
