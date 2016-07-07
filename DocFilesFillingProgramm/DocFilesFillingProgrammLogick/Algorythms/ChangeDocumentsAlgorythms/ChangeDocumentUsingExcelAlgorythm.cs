using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocFilesFillingProgrammLogick.Entities;

namespace DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms
{
    public class ChangeDocumentUsingExcelAlgorythm : IChangeDocumentsAlgorythm
    {
        public void ChangeDocuments(ref IList<DocumentAndInfoEntity> docAndInfoList)
        {
            foreach(var pair in docAndInfoList)
            {
                pair.Document.Open();
                foreach (var fillingPart in pair.Info.Fields)
                    pair.Document.ReplaceTextInPosition(fillingPart.Value, fillingPart.Key);
                pair.Document.Close();
            }
        }
    }
}
