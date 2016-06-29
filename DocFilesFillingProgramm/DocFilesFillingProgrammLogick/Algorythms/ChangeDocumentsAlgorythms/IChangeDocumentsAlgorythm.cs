using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocFilesFillingProgrammLogick.Entities;

namespace DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms
{
    /// <summary>
    /// Interface to algorythms, that incapsulate logick for changing documents with filling info.
    /// </summary>
    interface IChangeDocumentsAlgorythm
    {
        /// <summary>
        /// Change list of documents using filling info.
        /// </summary>
        /// <param name="fillingInfo"></param>
        /// <param name="documents"></param>
        void ChangeDocuments(IList<IFillingInfo> fillingInfo, ref IList<IDocument> documents);
    }
}
