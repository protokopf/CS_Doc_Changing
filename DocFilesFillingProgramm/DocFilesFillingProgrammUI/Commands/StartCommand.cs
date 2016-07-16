using DocFilesFillingProgrammUI.ViewModel;
using System;
using System.Windows.Input;

namespace DocFilesFillingProgrammUI.Commands
{
    class StartCommand : ICommand
    {
        private ChangeDocumentViewModel _viewModel;
        public event EventHandler CanExecuteChanged;

        public StartCommand(ChangeDocumentViewModel viewModel)
        {
            _viewModel = viewModel;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_viewModel != null)
                if (_viewModel.Verify())
                    _viewModel.Start();
        }
    }
}
