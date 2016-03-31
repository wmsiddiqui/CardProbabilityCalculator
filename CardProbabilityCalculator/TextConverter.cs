using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CardProbabilityCalculator
{
    public class TextConverter
    {
        public TextConverter(string fileName)
        {
            ConvertToDeck(new FileInfo(fileName));
        }
        public TextConverter(FileInfo file)
        {
            ConvertToDeck(file);
        }

        public TextConverter()
        {

        }

        private List<Card> Deck = new List<Card>();

        private void ConvertToDeck(FileInfo file)
        {
        }

        private void ReadFile(FileInfo file)
        {
            //CreateCardFromLine();
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                var line = string.Empty;
                while (line != null)
                {

                }
            }
        }

        public string CreateCardFromLine(string line)
        {
            //TODO: Fix Regex with multiple capture groups.
            string pattern = @"((?i)x(?<Quantity>\d+))|(\[[(?<Quantity>\d+)]\])";
            var matches = Regex.Match(line, pattern);

            return matches.Groups["Quantity"].Value;
        }
    }
}
