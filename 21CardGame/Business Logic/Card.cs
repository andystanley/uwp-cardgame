using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalCardGame
{
    /// <summary>
    /// Represents the card suit with the values diamonds, hearts etc.
    /// </summary>
    enum CardSuit
    {
        Diamonds = 1,
        Clubs,
        Hearts,
        Spades
    }

    /// <summary>
    /// Represents a card in a card game with a value and a suit.
    /// </summary>
    class Card
    {
        /// <summary>
        /// The numeric value of the card
        /// </summary>
        private byte _value;

        /// <summary>
        /// The suit of the card
        /// </summary>
        private CardSuit _suit;

        /// <summary>
        /// Constructor to create card objects given a numeric value and suit
        /// </summary>
        /// <param name="value">the numeric value for the created card</param>
        /// <param name="suit">the suit of the created card</param>
        public Card(byte value, CardSuit suit)
        {
            _value = value;
            _suit = suit;
        }

        /// <summary>
        /// The numeric value of the card (Ace is 1)
        /// </summary>
        public byte Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// The suit of the card
        /// </summary>
        public CardSuit Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        /// <summary>
        /// The card name based on its value. 1 is Ace, 11 is Jack etc.
        /// </summary>
        /// <returns></returns>
        public string CardName
        {
            get
            {
                //determine the card name based on its value
                string cardName;
                switch (_value)
                {
                    case 1:
                        cardName = "Ace";
                        break;

                    case 11:
                        cardName = "Jack";
                        break;

                    case 12:
                        cardName = "Queen";
                        break;

                    case 13:
                        cardName = "King";
                        break;

                    default:
                        cardName = _value.ToString();
                        break;
                }

                return cardName;
            }
        }

        /// <summary>
        /// The name of the suit. This is transfered from Python which used integer
        /// to represent suit values. As we are using enums will it be necessary?
        /// </summary>
        /// <returns></returns>
        public string SuitName
        {
            get
            {
                //determine the name of the suit
                switch (_suit)
                {
                    case CardSuit.Diamonds:
                    case CardSuit.Clubs:
                    case CardSuit.Hearts:
                    case CardSuit.Spades:
                        return _suit.ToString();

                    default:
                        Debug.Assert(false, "Unexpected suit value");
                        return "N/A";
                }
            }
        }

        /// <summary>
        /// Parses a card description in the format "{Value} of {Suit}"
        /// </summary>
        /// <param name="cardDesc">the description of the card</param>
        /// <returns>a card instance with the given value and suit</returns>
        public static Card Parse(string cardDesc)
        {
            //parse the description to obtain value and suit
            string[] cardProps = cardDesc.Split(' ');

            byte value = byte.Parse(cardProps[0]);
            //TODO: change this to accept a description such as "Ace of Diamonds" instead of "1 of Diamonds"

            CardSuit suit = (CardSuit)Enum.Parse(typeof(CardSuit), cardProps[2]);

            //return a card object with the given properties
            return new Card(value, suit);
        }

        // Define the equivalent to __str__(), the ToString() method
        public override string ToString()
        {
            return $"{this.CardName} of {this.SuitName}";
        }
    }
}
