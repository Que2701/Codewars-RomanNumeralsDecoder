using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsDecoderApp
{
    /// <summary>
    /// Main program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string roman = "MCMXC";
            Dictionary<int, int> romanNumbers = new Dictionary<int, int>();
            var dictionaryIndexCounter = 0;

            roman.ToList().ForEach(letter =>
            {
                dictionaryIndexCounter++;
                switch (letter)
                {
                    case 'I':
                        romanNumbers.Add(dictionaryIndexCounter,1);
                        break;
                    case 'V':
                        romanNumbers.Add(dictionaryIndexCounter,5);
                        break;
                    case 'X':
                        romanNumbers.Add(dictionaryIndexCounter,10);
                        break;
                    case 'L':
                        romanNumbers.Add(dictionaryIndexCounter,50);
                        break;
                    case 'C':
                        romanNumbers.Add(dictionaryIndexCounter,100);
                        break;
                    case 'D':
                        romanNumbers.Add(dictionaryIndexCounter,500);
                        break;
                    case 'M':
                        romanNumbers.Add(dictionaryIndexCounter,1000);
                        break;
                    default:
                        break;
                }
            });
            Console.WriteLine(ConvertLettersToNumber(romanNumbers));
        }

        private static int ConvertLettersToNumber(Dictionary<int, int> romanNumbers)
        {
            var numericRepresentation = new List<int>();
            var previousIndex = 0;
            foreach (var item in romanNumbers)
            {
                var nextValueIndex = item.Key + 1 <= romanNumbers.Count() ? item.Key + 1 : item.Key;

                if (item.Value < romanNumbers[nextValueIndex])
                {
                    if (nextValueIndex == previousIndex)
                        continue;
                    previousIndex = nextValueIndex + 1 <= romanNumbers.Count() ? nextValueIndex + 1 : nextValueIndex;
                    var subtractedValue = romanNumbers[nextValueIndex] - item.Value;
                    numericRepresentation.Add(subtractedValue);
                }
                else
                {
                    if (nextValueIndex == previousIndex)
                        continue;
                    numericRepresentation.Add(item.Value);
                }
            }

            return numericRepresentation.Sum();
        }
    }
}
