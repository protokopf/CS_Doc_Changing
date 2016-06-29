using System.Collections.Generic;

namespace DocFilesFillingProgrammLogick.Entities
{
    /// <summary>
    /// Interface that represent any filling info with any pars "field->value".
    /// </summary>
    interface IFillingInfo
    {
        /// <summary>
        /// Dictionary with all fields and their values.
        /// </summary>
        Dictionary<string, string> Fields { get; set; }
    }
}
