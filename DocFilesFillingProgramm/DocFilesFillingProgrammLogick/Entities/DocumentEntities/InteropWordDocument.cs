using DocFilesFillingProgrammLogick.Entities.ManagerEntities;
using Microsoft.Office.Interop.Word;

namespace DocFilesFillingProgrammLogick.Entities.DocumentEntities
{
    class InteropWordDocument : IDocument
    {
        private string _name;
        private string _path;
        private Document _document = null;

        public InteropWordDocument(string name, string path)
        {
            _name = name;
            _path = path;
        }

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
            _document = InteropApplicationManager.GetDocument(Path);
        }

        public void Close()
        {
            _document.Close();
        }

        public void ReplaceTextInPosition(string newText, string oldText)
        {
            foreach(Range range in _document.StoryRanges)
            {
                range.Find.Text = oldText;
                range.Find.Replacement.Text = newText;
                range.Find.Replacement.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

                range.Find.Wrap = WdFindWrap.wdFindContinue;
                object replaceAll = WdReplace.wdReplaceAll;

                range.Find.Execute(Replace: replaceAll);
            }
            Save();
        }

        public void Save()
        {
            _document.Save();
        }
    }
}
