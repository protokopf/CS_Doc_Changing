using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;

using DocFilesFillingProgrammLogick.Entities;
using DocumentFormat.OpenXml.Packaging;
using DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms;

namespace DocFilesFillingProgrammLogick.Model
{
    class CreateAndChangeDocumentsWithStudentInfoModel : IDocumentChangeModel
    {
        private string _folderPath;

        private ICreateDocumentsAlgorythm _createAlg;
        private IChangeDocumentsAlgorythm _changeAlg;
        private IRetrieveInfoAlgorythm _retrieveAlg;

        #region IDocumentChangeModel implementation

        public ICreateDocumentsAlgorythm CreateAlgorythm
        {
            get
            {
                return _createAlg;
            }
            set
            {
                _createAlg = value;
            }
        }
        public IRetrieveInfoAlgorythm RetrieveInfoAlgorythm
        {
            get
            {
                return _retrieveAlg;
            }
            set
            {
                _retrieveAlg = value;
            }
        }
        public IChangeDocumentsAlgorythm ChangeAlgorythm
        {
            get
            {
                return _changeAlg;
            }
            set
            {
                _changeAlg = value;
            }

        }

        public string StoragePath
        {
            get
            {
                return _folderPath;
            }
            set
            {
                _folderPath = value;
            }
        }

        public void RetrieveFillingInfo()
        {
            throw new NotImplementedException();
        }

        public void CreateDocuments()
        {
            throw new NotImplementedException();
        }

        public void SaveDocuments()
        {
            throw new NotImplementedException();
        }

        public void StartChangingDocuments()
        {
            throw new NotImplementedException();
        }

        public void StopChangingDocuments()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
