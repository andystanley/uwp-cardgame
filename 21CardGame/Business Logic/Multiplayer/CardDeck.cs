using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalCardGame
{
    /// <summary>
    /// card deck class created that stores list of all the cards.
    /// And allows access to add, shuffle and extract cards.
    /// </summary>
    class CardDeck
    {
        /// <summary>
        /// The list of cards that are in the deck
        /// </summary>
        private List<Card> _cardList;

        //define the maximum possible card value MAX_CARD_VALUE = 13 or ACE
        private const int MAX_CARD_VALUE = 13;

        //define the maximum suit in the deck MAX_SUIT_COUNT = 4
        private const int MAX_SUIT_COUNT = 4;

        /// <summary>
        /// Randomizer object to extract random cards and shuffle cards
        /// </summary>
        private static Random s_randomizer;

        /// <summary>
        ///constructor for intializing static field variables
        /// </summary>
        static CardDeck()
        {
            s_randomizer = new Random();
        }

        /// <summary>
        /// Constructor for CardDeck creates card deck of
        /// 52 cards 
        /// </summary>
        public CardDeck()
        {
            _cardList = new List<Card>();

            //fills the card list with card objects
            CreateCards();
        }

        /// <summary>
        /// The number of cards left in the deck.
        /// </summary>
        public int CardCount
        {
            get { return _cardList.Count; }
        }

        public List<Card> CardList
        {
            get { return _cardList; }
        }

        /// <summary>
        /// Provide access to the static randomizer used by the card deck.
        /// </summary>
        public static Random Randomizer
        {
            get { return s_randomizer; }
            set { s_randomizer = value; }
        }

        /// <summary>
        /// Creates a complete deck with all the cards of every suit
        /// </summary>
        private void CreateCards()
        {
            //go through every suit to create cards of that suit
            for (int iSuit = 1; iSuit <= MAX_SUIT_COUNT; iSuit++)
            {
                //obtain the suit for the current index
                CardSuit suit = (CardSuit)iSuit;

                //go through every card value and create cards
                for (byte value = 1; value <= MAX_CARD_VALUE; value++)
                {
                    //create the card
                    Card card = new Card(value, suit);

                    //add the card to the list
                    _cardList.Add(card);
                }
            }
        }

        public void ShuffleCards()
        {
            //create a random generator object 
            Random randomizer = new Random();
        }

        /// <summary>
        /// Prints the deck of cards in the order the cards are found
        /// </summary>
        public string PrintCards()
        {
            //sets output to empty
            string output = "";

            foreach (Card card in _cardList)
            {

                //accumulate the cards in the output variable
                output += $"{card}\n";
            }

            return output;
        }

        //The cards are removed from the deck
        public bool GetCards(out Card cardOne, out Card cardTwo, out Card cardThree, out Card cardFour)
        {
            //check that we have enough cards
            if (_cardList.Count >= 4)
            {
                //extract four random cards

                //determine a random index
                int randCardOneIndex = CardDeck.Randomizer.Next(_cardList.Count);

                //obtain the card at the index
                cardOne = _cardList[randCardOneIndex];

                //remove the card from the deck
                _cardList.RemoveAt(randCardOneIndex);

                //extract the second card
                int randCardTwoIndex = CardDeck.Randomizer.Next(_cardList.Count);
                cardTwo = _cardList[randCardTwoIndex];
                _cardList.RemoveAt(randCardTwoIndex);

                //extract the third card
                int randCardThreeIndex = CardDeck.Randomizer.Next(_cardList.Count);
                cardThree = _cardList[randCardThreeIndex];
                _cardList.RemoveAt(randCardThreeIndex);

                //extract the fourth card
                int randCardFourIndex = CardDeck.Randomizer.Next(_cardList.Count);
                cardFour = _cardList[randCardFourIndex];
                _cardList.RemoveAt(randCardFourIndex);

                return true;
            }
            // If the deck has less than four cards in it
            else 
            {
                // Create a new card list
                _cardList = new List<Card>();

                //fill the card list with card objects
                CreateCards();

                //extract four random cards

                //extract the first card
                int randCardOneIndex = CardDeck.Randomizer.Next(_cardList.Count);
                cardOne = _cardList[randCardOneIndex];
                _cardList.RemoveAt(randCardOneIndex);

                //extract the second card
                int randCardTwoIndex = CardDeck.Randomizer.Next(_cardList.Count);
                cardTwo = _cardList[randCardTwoIndex];
                _cardList.RemoveAt(randCardTwoIndex);

                //extract the third card
                int randCardThreeIndex = CardDeck.Randomizer.Next(_cardList.Count);
                cardThree = _cardList[randCardThreeIndex];
                _cardList.RemoveAt(randCardThreeIndex);

                //extract the fourth card
                int randCardFourIndex = CardDeck.Randomizer.Next(_cardList.Count);
                cardFour = _cardList[randCardFourIndex];
                _cardList.RemoveAt(randCardFourIndex);

                return true;
            }
        }
    }
}
