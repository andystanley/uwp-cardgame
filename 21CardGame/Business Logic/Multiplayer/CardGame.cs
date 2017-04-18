using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalCardGame
{
    /// <summary>
    /// Represents the score of the game. As a structure it allows the score to 
    /// be represented as one value with two components: the player score and the 
    /// house score.
    /// </summary>
    struct GameScore
    {
        /// <summary>
        /// field variable for score of player 1
        /// </summary>
        private int _player1Score;

        /// <summary>
        /// field variable for score value of player 2
        /// </summary>
        private int _player2Score;

        /// <summary>
        /// field variable for score value of player 3
        /// </summary>
        private int _player3Score;

        /// <summary>
        /// field variable for score value of player 4
        /// </summary>
        private int _player4Score;

        /// <summary>
        /// The score value for player 1. The property provides access
        /// to the internal field variable
        /// </summary>
        public int Player1Score
        {
            get { return _player1Score; }
            set { _player1Score = value; }
        }

        /// <summary>
        /// The score value for Player 2.
        /// </summary>
        public int Player2Score
        {
            get { return _player2Score; }
            set { _player2Score = value; }
        }

        /// <summary>
        /// The score value for Player 3.
        /// </summary>
        public int Player3Score
        {
            get { return _player3Score; }
            set { _player3Score = value; }
        }

        /// <summary>
        /// The score value for Player 4. 
        /// </summary>
        public int Player4Score
        {
            get { return _player4Score; }
            set { _player4Score = value; }
        }

    }

    /// <summary>
    /// Represents a four player card game in which the user(s) play
    /// against eachother to score a higher points by winning tricks. A trick
    /// is won by the user with a card with a higher value.
    /// </summary>
    class CardGame
    {
        /// <summary>
        /// The card deck used in the game which has a list of cards inside
        /// </summary>
        private CardDeck _cardDeck;

        /// <summary>
        /// The current score of the game
        /// </summary>
        private GameScore _score;

        /// <summary>
        /// The card being played by the player in the current round
        /// </summary>
        private Card _player1Card;
        private Card _player2Card;
        private Card _player3Card;
        private Card _player4Card;

        /// <summary>
        /// Constructor method for creating a card game object with a new
        /// card deck.
        /// </summary>
        public CardGame()
        {
            //initialize the _cardDeck field variable
            _cardDeck = new CardDeck();

            //initialize the score of the game
            _score = new GameScore();

            //initialize the current player card
            _player1Card = null;
            _player2Card = null;
            _player3Card = null;
            _player4Card = null;

        }

        /// <summary>
        ///The score of the game as a read-only property. Value can be obtained
        ///but not set because it can only be set by playing the game.
        /// </summary>
        public GameScore Score
        {
            get { return _score; }
        }

        /// <summary>
        /// The card in the hand of players. Value
        /// can obtained but not set because it can only be set by playing the game
        /// </summary>
        public Card Player1Card
        {
            get { return _player1Card; }
        }

        public Card Player2Card
        {
            get { return _player2Card; }
        }

        public Card Player3Card
        {
            get { return _player3Card; }
        }

        public Card Player4Card
        {
            get { return _player4Card; }
        }

        public void StartGame()
        {
            //shuffle the cards
            _cardDeck.ShuffleCards();
        }

        public sbyte PlayRound()
        {
            //determine the ranks of the player and house cards
            byte player1CardRank = DetermineCardRank(_player1Card);
            byte player2CardRank = DetermineCardRank(_player2Card);
            byte player3CardRank = DetermineCardRank(_player3Card);
            byte player4CardRank = DetermineCardRank(_player4Card);
            
            //compare the card ranks to determine round winner
            if (player1CardRank > player2CardRank && player1CardRank > player3CardRank && player1CardRank > player4CardRank)
            {
                //player1 won the round
                return 1;
            }
            else if (player2CardRank > player1CardRank && player2CardRank > player3CardRank && player2CardRank > player4CardRank)
            {
                //player2 won the round
                return 2;
            }

            else if (player3CardRank > player1CardRank && player3CardRank > player2CardRank && player3CardRank > player4CardRank)
            {
                //player3 won the round
                return 3;
            }

            else if (player4CardRank > player1CardRank && player4CardRank > player3CardRank && player4CardRank > player3CardRank)
            {
                //player4 won the round
                return 4;
            }

            else
            {
                //the round is a draw, no change in score
                return 0;
            }
            
        }

        /// <summary>
        /// Deals cards to the player and the house
        /// </summary>
        public void DealCards()
        {
            //provide the player and the house with two random cards from the deck
            bool cardsDealt = _cardDeck.GetCards(out _player1Card, out _player2Card, out _player3Card, out _player4Card);
            Debug.Assert(cardsDealt, "Could not deal cards. The card deck cannot provide them.");
        }

        /// <summary>
        /// Determines the ranks cards have in the game based on their value and suit
        /// The rank is used to determine which card is better and would win a round
        /// </summary>
        /// <param name="card">the card whose rank is to be determined</param>
        /// <returns>the rank of the card in the game</returns>
        private byte DetermineCardRank(Card card)
        {
            //Ensure the Ace is the highest ranked card in the game. The 
            //conditional expression below is equivalent to an if statement to
            //decide the value to return. 
            return (card.Value == 1) ? (byte)14 : card.Value;
        }        
    }
}
