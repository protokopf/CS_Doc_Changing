using DocFilesFillingProgrammUI.ViewModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace DocFilesFillingProgrammUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MyMainWindow : Window
    {
        private ChangeDocumentViewModel _viewModel;
        private object locker = new object();

        public MyMainWindow(ChangeDocumentViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.StartProcessing += ViewModelStartProcessing;
            _viewModel.FinishProcessing += ViewModelFinishProcessing;

            DataContext = _viewModel;

            InitializeComponent();
        }

        private void ViewModelFinishProcessing(object sender, System.EventArgs e)
        {
            chooseFolderButton.IsEnabled = true;
            startFeedingButton.IsEnabled = true;         
        }

        private void ViewModelStartProcessing(object sender, System.EventArgs e)
        {
            chooseFolderButton.IsEnabled = false;
            startFeedingButton.IsEnabled = false;
        }
    }
}
