using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProbabilityCalculator
{
    internal class Card
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
                _searchableCards = new List<Card>();

            if(searchableCard.searchCards == null)
                searchableCard.searchCards = new List<Card>();
            
            if(!searchableCard.searchCards.Contains(this))
                searchableCard.searchCards.Add(this);
            
            _searchableCards.Add(searchableCard);
        }

        public void AddSearcher(Card searcherCard)
        {
            if(searchCards == null)
                searchCards = new List<Card>();
            
            if(searcherCard._searchableCards == null)
                searcherCard._searchableCards = new List<Card>();
            
            if(!searcherCard._searchableCards.Contains(this))
                searcherCard._searchableCards.Add(this);

            searchCards.Add(searcherCard);
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
    class CardSet
    {
        public readonly int Quantity;
        public readonly string CardName;
        public CardSet(string cardName, int quantity)
        {
            CardName = cardName;
            Quantity = quantity;
        }
    }
}
