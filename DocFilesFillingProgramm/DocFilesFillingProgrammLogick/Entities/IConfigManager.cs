﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFilesFillingProgrammLogick.Entities
{
    public interface IConfigManager
    {
        string this[string key]
        {
            get;
        }
    }
}
