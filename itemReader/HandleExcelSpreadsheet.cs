using System;
using System.Collections.Generic;
using System.Numerics;
using ClosedXML.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace itemReader
{
    partial class CSVReader
    {
        //Handle Excel Spreadsheets using an external library
        //Gets the number from each row by adding the columns together to form a larger number
        private void HandleExcelSpreadsheetBigInteger(string fileName)
        {
            try
            {
                var workbook = new XLWorkbook(fileName.ToString());
                foreach (IXLWorksheet worksheet in workbook.Worksheets)
                {
                    List<string> addedNumber = new List<String>();
                    foreach (IXLRow row in worksheet.Rows())
                    {
                        string number = string.Empty;
                        foreach (IXLCell cell in row.Cells())
                        {
                            if (BigInteger.TryParse(cell.Value.ToString(), out BigInteger _temp))
                            {
                                number += _temp;
                            }
                            else
                            {
                                outputWindow.Text = "Invalid Data Specified";
                                return;
                            }
                        }
                        addedNumber.Add(number);
                    }

                    FileReader fr = new FileReader();
                    outputWindow.Text = fr.HandleFormatting(fr.HandleCalculation(addedNumber));
                    fr.Dispose();
                }
            }
            catch (FileFormatException e)
            {
                outputWindow.Text = e.Message;
            }

        }
    }
}
