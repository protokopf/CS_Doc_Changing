using DocFilesFillingProgrammLogick.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocFilesFillingProgrammLogick.Algorythms.ChangeDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.CreateDocumentsAlgorythms;
using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
using System.ComponentModel;
using System.Windows.Input;
using DocFilesFillingProgrammUI.Commands;
using System.IO;
using DocFilesFillingProgrammUI.ViewModel.Entities;
using System.Windows.Controls.Primitives;

namespace DocFilesFillingProgrammUI.ViewModel
{
   public class ChangeDocumentViewModel : INotifyPropertyChanged
    {
        private IDocumentChangeModel _model;
        private IVerifier _verifier;

        public ICommand StartCommand { get; set; }
        public ICommand ChooseCommand { get; set; }

        public ChangeDocumentViewModel(IDocumentChangeModel model)
        {
            _model = model;

            StartCommand = new StartCommand(this);
            ChooseCommand = new ChooseCommand(this);

            _verifier = new DirectoryVerifier();
        }

        public string Storage
        {
            get { return _model.StoragePath; }
            set
            {
                _model.StoragePath = value;
                OnPropertyChanged("Storage");
            }
        }

        public int FilesCount
        {
            get { return _model.FilesCount; }
            set
            {
                OnPropertyChanged("FilesCount");
                _model.FilesCount = value;
            }
        }
        public int ProcessedFiles
        {
            get { return _model.ProcessedFiles; }
            set
            {
                OnPropertyChanged("ProcessedFiles");
                _model.ProcessedFiles = value;
            }
        }

        public void Start()
        {
            Task.Run(() =>
            {
                _model.RetrieveFillingInfo();
                _model.CreateDocuments();
                _model.ChangeDocuments();
            });

        }
        public bool Verify()
        {
            return _verifier.Verify(Storage);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
