using System.Collections.Generic;
using DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Entities.DocumentEntities;
using DocFilesFillingProgrammLogick.Entities.InfoEntites;
using DocFilesFillingProgrammLogick.Entities.ManagetEntities;
using System;
using DocFilesFillingProgrammLogick.Model.ModelEntities;
using DocFilesFillingProgrammLogick.Entities.ManagerEntities;

namespace DocFilesFillingProgrammLogick.Model
{

    public class CreateAndChangeDocumentsWithStudentInfoModel : IDocumentChangeModel
    {
        private object locker = new object();

        private string _folderPath;
        private string _excelDocumentFilePath;

        private int _filesCount;
        private int _processedFiles;

        private ICreateDocumentAlgorythm _createAlg;
        private IChangeDocumentAlgorythm _changeAlg;
        private IRetrieveInfoAlgorythm _retrieveAlg;

        private List<IDocument> _documents;
        private List<IFillingInfo> _information;

        public CreateAndChangeDocumentsWithStudentInfoModel()
        {
            _excelDocumentFilePath = AppConfigManager.Instance()["excelStorage"];
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

        public event EventHandler FileHasBeenProcessed;

        public int FilesCount
        {
            get
            {
                lock (locker)
                {
                    return _filesCount;
                }
            }
            set
            {
                lock (locker)
                {
                    _filesCount = value;
                }
            }
        }
        public int ProcessedFiles
        {
            get {
                lock (locker)
                {
                    return _processedFiles;
                }
            }
            set {
                lock (locker)
                {
                    _processedFiles = value;
                }
            }
        }

        public string StoragePath
        {
            get
            {
                lock (locker)
                {
                    return _folderPath;
                }
            }
            set
            {
                lock (locker)
                {
                    _folderPath = value;
                }
            }
        }

        public string DataFilePath
        {
            get {
                lock (locker)
                {
                    return _excelDocumentFilePath;
                }
            }
            set {
                lock (locker)
                {
                    _excelDocumentFilePath = value;
                }
            }
        }

        public void RetrieveFillingInfo()
        {
            if (_retrieveAlg == null)
                _retrieveAlg = new RetrieveInfoFromExcelUsingOpenXML(_excelDocumentFilePath, AppConfigManager.Instance()["excelSheet"]);
            _information = _retrieveAlg.RetrieveFillingInfo();
            
        }

        public void CreateDocuments()
        {
            if(_createAlg == null)
                _createAlg = new CreateInteropWordDocumentAlgorythm(_folderPath, _excelDocumentFilePath);

            foreach(IFillingInfo info in _information)
                _documents.Add(_createAlg.CreateDocument(info));
            _filesCount = _documents.Count;
        }

        public void CloseDocuments()
        {
            if (_documents != null)
            {
                foreach (var doc in _documents)
                {
                    doc.Close();
                }
            }
            InteropApplicationManager.Quit();
        }

        public void ChangeDocuments()
        {
            if(_changeAlg == null)
                _changeAlg = new GeneralChangeAlgorythm();

            _processedFiles = 0;
            if (_documents != null && _information != null)
                for (int i = 0; i < _information.Count; ++i)
                {
                    _changeAlg.ChangeDocuments(_documents[i], _information[i]);
                    OnFileHasProcessed(new FileProcessedEventArgs() { FilesCount = _filesCount, ProcessedFilse = ++_processedFiles });
                }
        }

        #endregion

        protected virtual void OnFileHasProcessed(FileProcessedEventArgs args)
        {
            if(FileHasBeenProcessed != null)
            {
                FileHasBeenProcessed.Invoke(this, args);
            }
        }
    }
}
