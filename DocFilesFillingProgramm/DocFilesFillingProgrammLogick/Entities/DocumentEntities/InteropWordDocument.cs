using System;

namespace DocFilesFillingProgrammLogick.Entities.DocumentEntities
{
    class InteropWordDocument : IDocument
    {
        private string _name;
        private string _path;



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

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void ReplaceTextInPosition(string newText, string oldText)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
