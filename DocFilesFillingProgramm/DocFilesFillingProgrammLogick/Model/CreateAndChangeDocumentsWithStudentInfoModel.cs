using System;
using System.Collections.Generic;

using DocFilesFillingProgrammLogick.Entities;
using DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms;
using System.Threading;
using System.Threading.Tasks;

namespace DocFilesFillingProgrammLogick.Model
{
    class CreateAndChangeDocumentsWithStudentInfoModel : IDocumentChangeModel
    {
        private string _folderPath;

        private ICreateDocumentsAlgorythm _createAlg;
        private IChangeDocumentsAlgorythm _changeAlg;
        private IRetrieveInfoAlgorythm _retrieveAlg;

        private Dictionary<IFillingInfo, IDocument> _infoAndDocuments;

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
            if (RetrieveInfoAlgorythm != null)
            {
                RetrieveInfoAlgorythm.RetrieveFillingInfo(ref _infoAndDocuments);
            }
        }

        public void CreateDocuments()
        {
            if (_infoAndDocuments != null && CreateAlgorythm != null)
            {
                CreateAlgorythm.CreateDocuments(ref _infoAndDocuments);
            }
        }

        public void SaveDocuments()
        {
            if (_infoAndDocuments != null)
            {
                foreach (KeyValuePair<IFillingInfo,IDocument> doc in _infoAndDocuments)
                {
                    doc.Value.Close();
                }
                _infoAndDocuments = null;
            }
        }

        public void StartChangingDocuments()
        {
            _infoAndDocuments = new Dictionary<IFillingInfo, IDocument>();
            RetrieveFillingInfo();
            CreateDocuments();
            ChangeAlgorythm.ChangeDocuments(ref _infoAndDocuments);
            SaveDocuments();
        }

        public void StopChangingDocuments()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
