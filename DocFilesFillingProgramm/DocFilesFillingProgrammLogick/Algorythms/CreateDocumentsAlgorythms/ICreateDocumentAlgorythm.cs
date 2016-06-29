using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocFilesFillingProgrammLogick.Entities;

namespace DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms
{
    /// <summary>
    /// Interface to algorythms, that incapsulate logick for creating documents, using or not filling info.
    /// </summary>
    interface ICreateDocumentsAlgorythm
    {
        /// <summary>
        /// Creates and returns list of documents.
        /// </summary>
        /// <param name="fillingInfoForDocuments"></param>
        /// <returns>List of documents is creation has been succesfull, otherwise null.</returns>
        List<IDocument> CreateDocuments(IList<IFillingInfo> fillingInfoForDocuments);
    }
}
