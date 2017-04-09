using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalCardGame
{
    /// <summary>
    /// Represents a card deck which contains a list of cards that are to be played
    /// in a card game. The Card Deck allows access to the cards and implements basic
    /// operations of extracting, adding, shuffling, exchanging cards.
    /// </summary>
    class CardDeck
    {
        /// <summary>
        /// The list of cards that are in the deck to be played
        /// (read as "List of Cards")
        /// </summary>
        private List<Card> _cardList;

        //define the maximum possible card value MAX_CARD_VALUE = 13
        private const int MAX_CARD_VALUE = 13;

        //define the maximum suit in the deck MAX_SUIT_COUNT = 4
        private const int MAX_SUIT_COUNT = 4;

        /// <summary>
        /// Randomizer object used by the deck to extract random cards and shuffle cards
        /// </summary>
        private static Random s_randomizer;

        /// <summary>
        /// Declare the static constructor responsible for initializing all
        /// static field variables
        /// </summary>
        static CardDeck()
        {
            s_randomizer = new Random();
        }

        /// <summary>
        /// Constructor for CardDeck objects, creates a full card deck of
        /// 52 cards unshuffled
        /// </summary>
        public CardDeck()
        {
            _cardList = new List<Card>();

            //fill the card list with card objects
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

                //create the cards for the current suit. How?
                //go through every card value and create cards
                for (byte value = 1; value <= MAX_CARD_VALUE; value++)
                {
                    //create the card
                    Card card = new Card(value, suit);

                    //add the card to the list of the deck
                    _cardList.Add(card);
                }
            }
        }

        /// <summary>
        /// Shuffles the card deck using a Fisher-Yates shuffle algorithm
        /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        public void ShuffleCards()
        {
            //create a random generator object 
            Random randomizer = new Random();

            //TODO: learn about the Random class (press F1 with the cursor
            //has to be on Random.

            //TODO: implement the shuffle algorithm with a for loop
        }

        /// <summary>
        /// Prints the deck of cards in the order the cards are found
        /// </summary>
        public string PrintCards()
        {
            //TODO: use a regular for loop to go through all the cards
            //in the list of cards N(_cardList) and create a string
            //output and return it
            string output = "";

            foreach (Card card in _cardList)
            {
                //accumulate the cards in the output variable
                output += $"{card}\n";
            }

            return output;
        }

        //Implement GetPairOfCards that extracts two random cards out of the deck. 
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

                //extract the second card
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

        //Implement ExchangeCards that receives two cards and exchanges them with each other
        public void ExchangeCards( ref Card cardOne,  ref Card cardTwo)
        {
            Card temp = cardOne;
            cardOne = cardTwo;
            cardTwo = temp;
        }
    }
}
