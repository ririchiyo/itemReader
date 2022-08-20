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
                    BigInteger temp = BigInteger.Zero;
                    foreach (IXLRow row in worksheet.Rows())
                    {
                        string number = string.Empty;
                        foreach (IXLCell cell in row.Cells())
                        {
                            number += cell.Value.ToString();
                        }

                        if (number.Length > 0)
                        {
                            if (BigInteger.TryParse(number, out BigInteger _temp))
                            {
                                temp += _temp;
                            }
                            else
                            {
                                outputWindow.Text = "Invalid Data Specified";
                                return;
                            }
                        }
                    }
                    FileReader fr = new FileReader();
                    outputWindow.Text = fr.HandleFormatting(temp);
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
