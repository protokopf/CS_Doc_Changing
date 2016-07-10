using DocFilesFillingProgrammLogick.Entities.DocumentEntities;
using DocFilesFillingProgrammLogick.Entities.InfoEntites;

namespace DocFilesFillingProgrammLogick.Entities
{
    public class DocumentAndInfoEntity
    {
        public IFillingInfo Info { get; set; }
        public IDocument Document { get; set; }
    }
}
