using DocFilesFillingProgrammUI.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace DocFilesFillingProgrammUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MyMainWindow : Window
    {
        ChangeDocumentViewModel _viewModel;
        BackgroundWorker worker;

        public MyMainWindow(ChangeDocumentViewModel viewModel)
        {
            _viewModel = viewModel;
            this.DataContext = _viewModel;
            InitializeComponent();
        }

        private void startFeedingButton_Click(object sender, RoutedEventArgs e)
        {
            this.startFeedingButton.IsEnabled = false;
        }
    }
}
