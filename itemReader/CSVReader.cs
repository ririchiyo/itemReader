using System;
using System.IO;
using ClosedXML.Excel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace itemReader
{

    public partial class CSVReader : Form
    {

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

        public class Number
        {
            [CsvHelper.Configuration.Attributes.Index(0)]
            public string number { get; set; }
        }

        //Handles importing of CSV File

        public void showOpenFileDialog()
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                fileNameBox.Text = fileBrowser.FileName;
                FileInfo fileInfo = new FileInfo(fileBrowser.FileName);
                if (fileInfo.Extension == ".xlsx")
                {
                    HandleExcelSpreadsheetBigInteger(fileBrowser.FileName);
                }
                if (fileInfo.Extension == ".csv")
                {
                    SimpleHandleCSVDatabase(fileBrowser.FileName);
                }
            }
        }

    }
}
