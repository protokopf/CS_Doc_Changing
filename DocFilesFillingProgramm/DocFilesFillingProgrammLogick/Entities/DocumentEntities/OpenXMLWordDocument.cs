using System.Collections.Generic;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;



namespace DocFilesFillingProgrammLogick.Entities.DocumentEntities
{
    public class OpenXMLWordDocument : IDocument
    {
        private string _name;
        private string _path;

        private WordprocessingDocument _document;
        private IEnumerable<Text> _elements;


        public OpenXMLWordDocument(string fullPath, string name)
        {
            _name = name;
            _path = fullPath;
        }

        #region IDocument implementation

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        public void Open()
        {
            if(_document == null)
            {
                _document = WordprocessingDocument.Open(_path,true);
                _elements = _document.MainDocumentPart.Document.Descendants<Text>();
            }
        }

        public void Close()
        {
            if (_document != null)
            {
                Save();
                _document.Close();
                _document = null;
            }
        }

        public void Save()
        {

        }
        public void ReplaceTextInPosition(string newText, string oldText)
        {
            foreach (var text in _elements)
            {
                if (text.Text.Contains(oldText))
                {
                    text.Text = text.Text.Replace(oldText, newText);
                }
            }
        }


        #endregion
    }
}
