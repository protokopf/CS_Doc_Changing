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

    public class CreateAndChangeDocumentsWithStudentInfoModel : IDocumentChangeModel
    {
        private string _folderPath;
        private string _excelDocumentFilePath;

        private ICreateDocumentsAlgorythm _createAlg;
        private IChangeDocumentsAlgorythm _changeAlg;
        private IRetrieveInfoAlgorythm _retrieveAlg;

        private IList<DocumentAndInfoEntity> _infoAndDocuments;

        public CreateAndChangeDocumentsWithStudentInfoModel(string folderPath, string excelFilePath)
        {
            _folderPath = folderPath;
            _excelDocumentFilePath = excelFilePath;
            _infoAndDocuments = new List<DocumentAndInfoEntity>();
        }


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

        public string DataFilePath
        {
            get { return _excelDocumentFilePath; }
            set { _excelDocumentFilePath = value; }
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
                foreach (var doc in _infoAndDocuments)
                {
                    doc.Document.Close();
                }
                _infoAndDocuments = null;
            }
        }

        public void ChangeDocuments()
        {
            if (_changeAlg != null && _infoAndDocuments != null)
            {
                ChangeAlgorythm.ChangeDocuments(ref _infoAndDocuments);
            }
        }


        #endregion
    }
}
