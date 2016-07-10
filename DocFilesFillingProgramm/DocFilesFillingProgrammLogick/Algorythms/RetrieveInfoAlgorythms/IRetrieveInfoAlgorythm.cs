using DocFilesFillingProgrammLogick.Entities.InfoEntites;
using System.Collections.Generic;

namespace DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms
{
    /// <summary>
    /// Interface to algorythms, that incapsulate logick for retrieving filling info from different sources (xls, xml, ect.).
    /// </summary>
    public interface IRetrieveInfoAlgorythm
    {
        /// <summary>
        /// Retrieves and returns filling info for documents.
        /// </summary>
        /// <returns>List of IFillingInfo instances if retrieving has been succesfull, otherwise null.</returns>
        List<IFillingInfo> RetrieveFillingInfo();
    }
}
