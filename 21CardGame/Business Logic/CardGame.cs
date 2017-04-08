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
        /// The score value for the player
        /// </summary>
        private int _playerScore;

        /// <summary>
        /// The score value for the house
        /// </summary>
        private int _houseScore;

        /// <summary>
        /// The score value for the player. The property provides access
        /// to the internal field variable
        /// </summary>
        public int PlayerScore
        {
            get { return _playerScore; }
            set { _playerScore = value; }
        }

        /// <summary>
        /// The score value for the house. The property provides access
        /// to the internal field variable
        /// </summary>
        public int HouseScore
        {
            get { return _houseScore; }
            set { _houseScore = value; }
        }

    }

    /// <summary>
    /// Represents a basic single player card game in which the user plays
    /// against the house to score a higher points by winning tricks. A trick
    /// is won by the user with a card with a higher value. The player has the
    /// ability to switch cards with the house before playing each hand.
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
        /// The card in the hand of the player (currently being played). Value
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


        /// <summary>
        /// Read-only property to check if player won
        /// </summary>
        public bool PlayerWins
        {
            get { return _score.PlayerScore > _score.HouseScore; } 
        }

        /// <summary>
        /// Read-only property to check if the house won 
        /// </summary>
        public bool HouseWins
        {
            get { return _score.HouseScore > _score.PlayerScore; } 
        }

        /// <summary>
        /// Read-only property to check if the game is over
        /// </summary>
        public bool IsOver
        {
            get { return _cardDeck.CardCount == 0; } 
        }

        /// <summary>
        /// Plays the game rounds until no more cards are left keeping the score.
        /// </summary>
        public void StartGame()
        {
            //shuffle the cards
            _cardDeck.ShuffleCards();

            //What else needs to happen to (Re)start the game?
        }

        public sbyte PlayRound()
        {
            //determine the ranks of the player and house cards
            byte player1CardRank = DetermineCardRank(_player1Card);
            byte player2CardRank = DetermineCardRank(_player2Card);
            byte player3CardRank = DetermineCardRank(_player3Card);
            byte player4CardRank = DetermineCardRank(_player4Card);

            return 0;
            /*
            byte houseCardRank = DetermineCardRank(_houseCard);

            //compare the card ranks to determine round winner
            if (playerCardRank > houseCardRank)
            {
                //player won the round
                _score.PlayerScore++; // means += 1
                return 1;
            }
            else if (playerCardRank < houseCardRank)
            {
                //house won the round
                _score.HouseScore++; // means += 1
                return -1;
            }
            else
            {
                //the round is a draw, no change in score
                return 0;
            }
            */
        }

        /// <summary>
        /// Deals cards to the player and the house
        /// </summary>
        public void DealCards()
        {
           //provide the player and the house with two random cards from the deck
           bool cardsDealt = _cardDeck.GetCards(out _player1Card, out _player2Card, out _player3Card, out _player4Card);
            //Debug.Assert(cardsDealt, "Could not deal cards. The card deck cannot provide them.");
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
