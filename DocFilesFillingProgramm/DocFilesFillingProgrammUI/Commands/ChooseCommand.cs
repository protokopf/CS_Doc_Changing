using DocFilesFillingProgrammUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;

namespace DocFilesFillingProgrammUI.Commands
{
    class ChooseCommand : ICommand
    {
        private ChangeDocumentViewModel _model;


        public ChooseCommand(ChangeDocumentViewModel model)
        {
            _model = model;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            DialogResult result = dlg.ShowDialog();
            if(result == DialogResult.OK)
            {
                _model.StoragePath = dlg.SelectedPath;
            }
        }
    }
}
