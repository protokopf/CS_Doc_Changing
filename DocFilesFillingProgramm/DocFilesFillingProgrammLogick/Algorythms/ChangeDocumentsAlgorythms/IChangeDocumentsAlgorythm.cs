﻿using System.Collections.Generic;

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
        /// <param name="dictionary"></param>
        void ChangeDocuments(ref Dictionary<IFillingInfo, IDocument> dictionary);
    }
}
