using System.Collections.Generic;

namespace DocFilesFillingProgrammLogick.Entities.InfoEntites
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
