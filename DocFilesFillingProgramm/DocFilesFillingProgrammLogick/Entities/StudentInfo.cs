using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFilesFillingProgrammLogick.Entities
{
    class StudentInfo : IFillingInfo
    {
        private Dictionary<string, string> _fields = new Dictionary<string, string>();

        public Dictionary<string, string> Fields
        {
            get
            {
                return _fields;
            }
            set
            {
                _fields = value;
            }
        }
    }
}
