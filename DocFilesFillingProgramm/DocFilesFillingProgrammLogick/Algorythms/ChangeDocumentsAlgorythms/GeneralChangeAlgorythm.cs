using DocFilesFillingProgrammLogick.Entities.InfoEntites;
using DocFilesFillingProgrammLogick.Entities.DocumentEntities;

namespace DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms
{
    public class GeneralChangeAlgorythm : IChangeDocumentAlgorythm
    {
        public void ChangeDocuments(IDocument document, IFillingInfo info)
        {
            document.Open();
            foreach (var fillingPart in info.Fields)
                document.ReplaceTextInPosition(fillingPart.Value, fillingPart.Key);
            SetCursAlgorythm(document, info);
        }

        private void SetCursAlgorythm(IDocument document, IFillingInfo info)
        {
            string curs = (info.Fields["<dn>"] + info.Fields["<dl>"]).ToLower();
            for(char i = 'a'; i < 'd'; ++i)
            {
                for(int j = 1; j < 3; ++j)
                {
                    string currentCurs = j.ToString() + i.ToString();
                    if (currentCurs == curs)
                        document.ReplaceTextInPosition("X", currentCurs);
                    else
                        document.ReplaceTextInPosition(" ", currentCurs);
                }
            }
        }
    }
}
