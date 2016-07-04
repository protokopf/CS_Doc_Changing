using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocFilesFillingProgrammLogick.Algorythms.RetrieveInfoAlgorythms;
using DocFilesFillingProgrammLogick.Entities;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DocFilesFillingProgrammConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "FillingInfo.xlsx";
            string sheet = "ListSheet";
            IRetrieveInfoAlgorythm alg = new RetrieveInfoFromExcelUsingOpenXML(path, sheet);

            Dictionary<IFillingInfo, IDocument> dummy = new Dictionary<IFillingInfo, IDocument>();

            alg.RetrieveFillingInfo(ref dummy);
            PrintDummDictionaryKeys(dummy);

        }

        public static void PrintDummDictionaryKeys(Dictionary<IFillingInfo, IDocument> dummy)
        {
            foreach(var key in dummy.Keys)
            {
                foreach(var fieldAndValue in key.Fields)
                    Console.WriteLine("Key: {0}, Value: {1}", fieldAndValue.Key, fieldAndValue.Value);
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }


    }
}
