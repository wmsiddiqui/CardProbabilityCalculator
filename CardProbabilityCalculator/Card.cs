using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProbabilityCalculator
{
    class Card
    {
        private string _cardName;
        protected List<Card> _searchableCards;
        protected List<Card> searchCards;

        public Card(string cardName)
        {
            _cardName = cardName;
        }

        public void AddSearchableCard(Card searchableCard)
        {
            if(_searchableCards == null)
            {
                _searchableCards = new List<Card>();
            }
            if(searchableCard.searchCards == null)
            {
                searchableCard.searchCards = new List<Card>();
            }
            if(!searchableCard.searchCards.Contains(this))
            {
                searchableCard.searchCards.Add(this);
            }
            _searchableCards.Add(searchableCard);
        }

        public bool CanSearch(Card searchedCard)
        {
            if(_searchableCards == null || !_searchableCards.Contains(searchedCard))
            {
                return false;
            }
            return true;
        }

        public string CardName
        {
            get
            {
                return _cardName;
            }
        }

    }
}
