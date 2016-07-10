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
            document.Close();
        }
    }
}
