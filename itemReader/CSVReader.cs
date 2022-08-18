using System;
using System.IO;
using ClosedXML.Excel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Numerics;

namespace itemReader
{
    public partial class CSVReader : Form
    {

        private void handleFormatting(string temp)
        {

            if (temp.Length > 9)
                outputWindow.Text = temp.Substring(temp.Length - 10);
            else
                outputWindow.Text = temp;
        }

        public CSVReader()
        {
            InitializeComponent();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            showOpenFileDialog();
        }

        //Handle Excel Spreadsheets using an external library
        //Gets the number from each row by adding the columns together to form a larger number
        private void HandleExcelSpreadsheetBigInteger(string fileName)
        {
            try
            {
                var workbook = new XLWorkbook(fileName.ToString());
                foreach (IXLWorksheet worksheet in workbook.Worksheets)
                {
                    BigInteger temp = new BigInteger();
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
                    foreach (string item in addedNumber)
                    {
                        temp += BigInteger.Parse(item);
                    }
                    handleFormatting(temp.ToString());
                }
            }
            catch (FileFormatException e)
            {
                outputWindow.Text = e.Message;
            }

        }

        //Handles importing of CSV File
        private void SimpleHandleCSVDatabase(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    List<string> numbers = new List<string>();
                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();
                        numbers.Add(line.Trim('\'', ',')); //trim non-numerical input
                        BigInteger temp = 0;

                        foreach (string value in numbers)
                        {
                            if (BigInteger.TryParse(value, out BigInteger _temp))
                            {
                                temp += _temp;
                            }
                            else
                            {
                                outputWindow.Text = "Invalid Data Specified";
                                return;
                            }
                        }

                        handleFormatting(temp.ToString());
                    }
                }
            }
        }

        public void showOpenFileDialog()
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            if(fileBrowser.ShowDialog() == DialogResult.OK)
            {
                fileNameBox.Text = fileBrowser.FileName;
                FileInfo fileInfo = new FileInfo(fileBrowser.FileName);
                if (fileInfo.Extension == ".xlsx")
                {
                    HandleExcelSpreadsheetBigInteger(fileBrowser.FileName);
                }
                if(fileInfo.Extension == ".csv")
                {
                    SimpleHandleCSVDatabase(fileBrowser.FileName);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CSVReader_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
