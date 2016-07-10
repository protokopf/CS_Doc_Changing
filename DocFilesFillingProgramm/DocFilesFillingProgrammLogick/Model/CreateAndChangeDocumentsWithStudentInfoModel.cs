using System.Collections.Generic;

using DocFilesFillingProgrammLogick.Entities;
using DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Entities.DocumentEntities;
using DocFilesFillingProgrammLogick.Entities.InfoEntites;

namespace DocFilesFillingProgrammLogick.Model
{

    public class CreateAndChangeDocumentsWithStudentInfoModel : IDocumentChangeModel
    {
        private string _folderPath;
        private string _excelDocumentFilePath;

        private ICreateDocumentAlgorythm _createAlg;
        private IChangeDocumentAlgorythm _changeAlg;
        private IRetrieveInfoAlgorythm _retrieveAlg;

        private List<IDocument> _documents;
        private List<IFillingInfo> _information;

        public CreateAndChangeDocumentsWithStudentInfoModel(string folderPath, string excelFilePath)
        {
            _folderPath = folderPath;
            _excelDocumentFilePath = excelFilePath;
            _documents = new List<IDocument>();
        }


        #region IDocumentChangeModel implementation

        public ICreateDocumentAlgorythm CreateAlgorythm
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
        public IChangeDocumentAlgorythm ChangeAlgorythm
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
                _information = _retrieveAlg.RetrieveFillingInfo();
            }
        }

        public void CreateDocuments()
        {
            if (CreateAlgorythm != null && _information != null)
            {
                foreach(IFillingInfo info in _information)
                {
                    _documents.Add(_createAlg.CreateDocument(info));
                }
            }
        }

        public void SaveDocuments()
        {
            if (_documents != null)
            {
                foreach (var doc in _documents)
                {
                    doc.Close();
                }
                _documents = null;
            }
        }

        public void ChangeDocuments()
        {
            if (_changeAlg != null && _documents != null && _information != null)
            {
                for (int i = 0; i < _information.Count; ++i)
                    _changeAlg.ChangeDocuments(_documents[i], _information[i]);
            }
        }


        #endregion
    }
}
