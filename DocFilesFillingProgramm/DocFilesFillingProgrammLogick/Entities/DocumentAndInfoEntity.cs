using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFilesFillingProgrammLogick.Entities
{
    public class DocumentAndInfoEntity
    {
        public IFillingInfo Info { get; set; }
        public IDocument Document { get; set; }
    }
}
