using System.Numerics;
using ClosedXML.Excel;
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
                FileReader fr = new FileReader();
                BigInteger temp = BigInteger.Zero;
                foreach (IXLWorksheet worksheet in workbook.Worksheets)
                {
                    foreach (IXLRow row in worksheet.Rows())
                    {
                        string number = string.Empty;
                        foreach (IXLCell cell in row.Cells())
                        {
                            number += cell.Value.ToString();
                        }
                        if (number.Length > 0)
                        {
                            temp += fr.handleSimpleAdd(number);
                        }
                    }
                }
                outputWindow.Text = fr.HandleFormatting(temp);
                fr.Dispose();
            }
            catch (FileFormatException e)
            {
                outputWindow.Text = e.Message;
            }

        }
    }
}
