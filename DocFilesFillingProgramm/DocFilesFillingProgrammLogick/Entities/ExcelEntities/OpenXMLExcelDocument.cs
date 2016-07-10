using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.IO;
using System.Linq;

namespace DocFilesFillingProgrammLogick.Entities.ExcelEntities
{
    public class OpenXMLExcelDocument : IExcelDocument
    {
        private string _currentSheet;
        private string _path;

        private FileStream _fileStream;

        private SpreadsheetDocument _excelDocument;
        private WorkbookPart _wbPart;


        public OpenXMLExcelDocument(string path, string sheetName)
        {
            _path = path;
            _currentSheet = sheetName;
        }

        public string CurrentSheet
        {
            get
            {
                return _currentSheet;
            }
            set
            {
                _currentSheet = value;
            }
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {

        }

        public string GetCellData(string letter, int number)
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            _fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            _excelDocument = SpreadsheetDocument.Open(_fileStream, false);
            _wbPart = _excelDocument.WorkbookPart;
        }

        public void SetCellData(string letter, int number, string data)
        {
            throw new NotImplementedException();
        }

        private Cell GetCell(Worksheet ws, string addresName)
        {
            SheetData sheetData = ws.GetFirstChild<SheetData>();

            UInt32 rowNumber = GetRowIndex(addresName);
            Row row = GetRow(sheetData,rowNumber);

            Cell refCell = row.Elements<Cell>().Where(c => c.CellReference.Value == addresName).FirstOrDefault();

            return refCell;
        }

        private UInt32 GetRowIndex(string address)
        {
            string rowPart;
            UInt32 l;
            UInt32 result = 0;

            for (int i = 0; i < address.Length; i++)
            {
                if (UInt32.TryParse(address.Substring(i, 1), out l))
                {
                    rowPart = address.Substring(i, address.Length - i);
                    if (UInt32.TryParse(rowPart, out l))
                    {
                        result = l;
                        break;
                    }
                }
            }
            return result;
        }
        private Row GetRow(SheetData wsData, UInt32 rowIndex)
        {
            var row = wsData.Elements<Row>().Where(r => r.RowIndex.Value == rowIndex).FirstOrDefault();
            return row;
        }
        private string GetValue(string sheetName, string addressName)
        {
            Sheet sheet = _wbPart.Workbook.Descendants<Sheet>().Where(sh => sh.Name == sheetName).FirstOrDefault();
            if(sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(_wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = GetCell(ws, addressName);
            }
            return null;
        }
        
    }
}
