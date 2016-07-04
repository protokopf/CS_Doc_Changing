﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocFilesFillingProgrammLogick.Entities;
using System.IO;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

using DocFilesFillingProgrammLogick.Entities;

namespace DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms
{
    public class RetrieveInfoFromExcelUsingOpenXML:IRetrieveInfoAlgorythm
    {
        private string _pathToFile;
        private string _sheetName;

        private FileStream _fileStream;
        private SpreadsheetDocument _excelDocument;
        private WorkbookPart _wbPart;

        private StringBuilder _builder = new StringBuilder();
        private List<string> _fields = new List<string>();


        public RetrieveInfoFromExcelUsingOpenXML(string path, string sheetName)
        {
            _pathToFile = path;
            _sheetName = sheetName;
        }


        public void RetrieveFillingInfo(ref Dictionary<IFillingInfo, IDocument> documents)
        {
            OpenDocument();

            SharedStringTablePart sstpart = _wbPart.GetPartsOfType<SharedStringTablePart>().First();
            SharedStringTable sst = sstpart.SharedStringTable;

            Sheet theSheet = _wbPart.Workbook.Descendants<Sheet>().Where(s => s.Name == _sheetName).FirstOrDefault();
            WorksheetPart wsPart = (WorksheetPart)(_wbPart.GetPartById(theSheet.Id));

            var rows = wsPart.Worksheet.Descendants<Row>();
            bool isFirstEnter = true;
            IFillingInfo fillingInfo = new StudentInfo();
            int counter = 0;

            foreach (Row row in rows)
            {
                if (!isFirstEnter)
                    fillingInfo = new StudentInfo();
                counter = 0;
                foreach (Cell c in row.Elements<Cell>())
                {
                    //int ssid = int.parse(c.cellvalue.text);
                    //string str = sst.childelements[ssid].innertext;
                    if (c != null)
                    {
                        string str = null;
                        if (c.DataType != null)
                        {
                            switch (c.DataType.Value)
                            {
                                case CellValues.SharedString:
                                    str = sstpart.SharedStringTable.ElementAt(int.Parse(c.InnerText)).InnerText;
                                    break;
                                case CellValues.String:
                                    break;
                                case CellValues.Number:
                                    break;
                                case CellValues.Date:
                                    break;
                            }

                        }
                        else
                            str = c.CellValue.Text;
                        if (isFirstEnter)
                            FillListOfFields(str);
                        else
                            fillingInfo.Fields.Add(_fields[counter++], str);
                    }
                }

                if (isFirstEnter == true)
                    isFirstEnter = false;
                else
                {
                    documents.Add(fillingInfo, null);
                }
            }

            CloseDocument();
        }

        private void OpenDocument()
        {
            _fileStream = new FileStream(_pathToFile, FileMode.Open, FileAccess.Read);
            _excelDocument = SpreadsheetDocument.Open(_fileStream, false);
            _wbPart = _excelDocument.WorkbookPart;
        }

        private void FillListOfFields(string fieldName)
        {
            _fields.Add(_builder.Append("*").Append(fieldName).Append("*").ToString());
            _builder.Clear();
        }

        private void CloseDocument()
        {
            if (_fileStream != null && _excelDocument != null)
            {
                _excelDocument.Close();
                _fileStream.Close();
            }
        }
    }
}