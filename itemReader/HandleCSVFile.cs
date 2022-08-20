using CsvHelper;
using CsvHelper.Configuration;
using System.Numerics;
using System.IO;

namespace itemReader
{
    partial class CSVReader
    {
        private void SimpleHandleCSVDatabase(string fileName)
        {
            var config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ",",
                Quote = '\'',
                Mode = CsvMode.RFC4180,
            };

            if (File.Exists(fileName))

            {
                using (var reader = new StreamReader(fileName))
                using (var csv = new CsvHelper.CsvReader(reader, config))
                {

                    BigInteger temp = BigInteger.Zero;
                    var _csvlist = csv.GetRecords<Number>();
                    FileReader fr = new FileReader();
                    foreach (Number item in _csvlist)
                    {
                        temp += fr.handleSimpleAdd(item.number);
                    }

                    outputWindow.Text = fr.HandleFormatting(temp);
                    fr.Dispose();
                }
            }
        }
    }
}
