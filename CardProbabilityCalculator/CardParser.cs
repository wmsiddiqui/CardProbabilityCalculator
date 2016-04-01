using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[assembly:InternalsVisibleTo("ConstructionTests")]

namespace CardProbabilityCalculator
{
    internal class CardParser
    {
        public CardParser()
        {

        }

        public List<Card> ConvertLineToCardSet(string line)
        {
            var quantity = GetCardQuantityFromLine(line);
            var cardName = GetCardNameFromLine(line);

            List<Card> playSet = new List<Card>();

            for (int i = 0; i < quantity; i++)
            {
                Card card = new Card(cardName);
                playSet.Add(card);
            }

            if (playSet.Count == 0)
                throw new PlaySetEmptyException();

            return playSet;
        }

        private int GetCardQuantityFromLine(string line)
        {
            string pattern = @"^\D*(?<Quantity>\d+)\S* .*";

            var matches = Regex.Match(line, pattern);

            int quantity;

            if (int.TryParse(matches.Groups["Quantity"].Value, out quantity))
                return quantity;
            else
                return 1;
        }

        private string GetCardNameFromLine(string line)
        {
            string pattern = @"^(\D*\d+\S* )?(?<Name>.*)";

            var match = Regex.Match(line, pattern);

            string cardName = match.Groups["Name"].Value.Trim();

            if(string.IsNullOrEmpty(cardName))
            {
                throw new NoNameFoundException();
            }

            return cardName;
        }
    }

    public class NoNameFoundException : Exception
    {
        public NoNameFoundException()
            : base("No name found in string")
        { }
    }
    public class PlaySetEmptyException : Exception
    {
        public PlaySetEmptyException()
            : base("No cards in play set card list")
        { }
    }
}
