using System.Windows;
using DocFilesFillingProgrammUI.View;
using DocFilesFillingProgrammLogick.Model;
using DocFilesFillingProgrammUI.ViewModel;

namespace DocFilesFillingProgrammUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IDocumentChangeModel model = new CreateAndChangeDocumentsWithStudentInfoModel();

            ChangeDocumentViewModel viewModel = new ChangeDocumentViewModel(model);
            MyMainWindow view = new MyMainWindow();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
