using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace itemReader
{

    interface IFileReader
    {
        IEnumerable<Char> ReadData(string inputData);
        BigInteger handleSimpleAdd(string rawNumber);
        BigInteger HandleCalculation(List<String> Numbers);
        string HandleFormatting(BigInteger rawNumber);

    }


    class FileReader : IFileReader
    {
        public IEnumerable<Char> ReadData(string inputData)
        {
            var inputList = inputData.ToArray();
            return inputList.ToArray();
        }

        public BigInteger handleSimpleAdd(string rawNumber)
        {
            BigInteger temp = BigInteger.Zero;
            if (BigInteger.TryParse(rawNumber, out var _temp))
            {
                temp += _temp;
            }
            else
            {
                return BigInteger.MinusOne;
            }
            return temp;
        }

        public BigInteger HandleCalculation(List<string> Numbers)
        {
            BigInteger temp = BigInteger.Zero;
            foreach(var number in Numbers)
            {
                if (BigInteger.TryParse(number, out BigInteger _temp))
                {
                    temp += _temp;
                }
                else
                {
                    return BigInteger.MinusOne;
                }
            }
            return temp;
        }

        public string HandleFormatting(BigInteger rawNumber)
        {
            var formattedText = rawNumber.ToString();
            if (formattedText.Length > 9)
            {
                formattedText = formattedText.Substring(formattedText.Length - 10);
            }
            return formattedText;
        }

        public virtual void Dispose() { }
    }


}
