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

        private List<Card> Deck = new List<Card>();

        private void ConvertToDeck(FileInfo file)
        {
            //TODO: Read file.
            var cardListFromText = new List<Card>();
            using (var reader = new StreamReader(file.FullName))
            {
                var line = string.Empty;
                while((line = reader.ReadLine()) != null)
                {

                } 
            }


        }

        private IEnumerable<CardSet> ReadFile(FileInfo file)
        {
            List<CardSet> Cards = new List<CardSet>();
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                var line = string.Empty;
                var parser = new CardParser();
                while (line != null)
                {
                    Cards.Add(parser.ConvertLineToCardSet(line));
                }
            }
            return Cards;
        }

        public string CreateCardFromLine(string line)
        {
            //TODO: Fix Regex with multiple capture groups.
            string pattern = @".*(?<Quantity>\d+)\S*";
            var matches = Regex.Match(line, pattern);

            return matches.Groups["Quantity"].Value;
        }

        
    }
}
