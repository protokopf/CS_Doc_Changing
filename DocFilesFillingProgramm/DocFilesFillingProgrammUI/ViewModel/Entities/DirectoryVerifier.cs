using System.IO;
using System.Windows;

namespace DocFilesFillingProgrammUI.ViewModel.Entities
{
    class DirectoryVerifier : IVerifier
    {
        public bool Verify(object obj)
        {
            string path = obj as string;
            if(path != null)
            {
                if (Directory.Exists(path))
                    return true;
                else
                {
                    MessageBox.Show("Storage does not exist.Choose right folder!", "Folder error", MessageBoxButton.OK,MessageBoxImage.Information);
                    return false;
                }
            }
            MessageBox.Show("Choose storage for files!", "Missing field", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;
        }
    }
}
