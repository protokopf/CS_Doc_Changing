using System;

namespace DocFilesFillingProgrammLogick.Entities.ExcelEntities
{
    public interface IExcelDocument : IDisposable
    {
        void Open();

        void Close();

        void SetCellData(string letter, int number, string data);
        string GetCellData(string letter, int number);

        string CurrentSheet { get; set; }
    }
}
