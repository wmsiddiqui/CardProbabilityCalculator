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

        public CardSet ConvertLineToCardSet(string line)
        {
            var quantity = GetCardQuantityFromLine(line);
            var cardName = GetCardNameFromLine(line);

            var playSet = new CardSet(cardName, quantity);
           
            if (playSet.Quantity == 0)
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
            //A limitation to this regex is the use of "X" following a 
            //quantity. If the name is "X NAME", then the "X" cannot have a quantity
            //before it. Therefore the format "3 x CardName" will be accepted as
            //quantity 3 of "X CardName"
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
