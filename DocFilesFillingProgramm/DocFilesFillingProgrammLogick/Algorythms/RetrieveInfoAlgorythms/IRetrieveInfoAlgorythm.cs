using DocFilesFillingProgrammLogick.Entities;
using System.Collections.Generic;

namespace DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms
{
    /// <summary>
    /// Interface to algorythms, that incapsulate logick for retrieving filling info from different sources (xls, xml, ect.).
    /// </summary>
    interface IRetrieveInfoAlgorythm
    {
        /// <summary>
        /// Retrieves and returns filling info for documents.
        /// </summary>
        /// <returns>List of IFillingInfo instances if retrieving has been succesfull, otherwise null.</returns>
        void RetrieveFillingInfo(ref Dictionary<IFillingInfo, IDocument> fillinInfos);
    }
}
