using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DocFilesFillingProgrammLogick.Entities
{
    public class OpenXMLWordDocument : IDocument
    {
        private string _name;
        private string _path;
        private WordprocessingDocument _document;

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
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void ReplaceTextInPosition(string repleaceableText, string replacedText)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
