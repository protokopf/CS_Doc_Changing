using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    MessageBox.Show("Storage does not exist.Choose right folder!", "Folder error.", MessageBoxButton.OK);
                    return false;
                }
            }
            return false;
        }
    }
}
