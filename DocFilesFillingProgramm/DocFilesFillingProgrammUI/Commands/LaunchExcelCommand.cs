using DocFilesFillingProgrammLogick.Entities.ManagetEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DocFilesFillingProgrammUI.Commands
{
    class LaunchExcelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Process excelProcess = new Process();
            excelProcess.StartInfo.FileName = AppConfigManager.Instance()["excelStorage"];
            excelProcess.Start();
            excelProcess.WaitForExit();
        }
    }
}
