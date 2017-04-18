using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalCardGame;

namespace _21CardGame.Business_Logic.SinglePlayer
{
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
        /// The score value for Player 2. The property provides access
        /// to the internal field variable
        /// </summary>
        public int HouseScore
        {
            get { return _houseScore; }
            set { _houseScore = value; }
        }

        /// <summary>
        /// The score value for Player 3. The property provides access
        /// to the internal field variable
        /// </summary>
    }
    class SinglePlayerCardGame
    {
        private SinglePlayerCardDeck _cardDeck;

        private GameScore _score;

        /// <summary>
        /// The card being played by the player in the current round
        /// </summary>
        private Card _playerCard;
        private Card _houseCard;

        /// <summary>
        /// Constructor method for creating a card game object with a new
        /// card deck.
        /// </summary>
        public SinglePlayerCardGame()
        {
            //initialize the _cardDeck field variable
            _cardDeck = new SinglePlayerCardDeck();

            //initialize the score of the game
            _score = new GameScore();

            //initialize the current player card
            _playerCard = null;
            _houseCard = null;
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
        public Card PlayerCard
        {
            get { return _playerCard; }
        }

        public Card HouseCard
        {
            get { return _houseCard; }
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
            byte playerCardRank = DetermineCardRank(_playerCard);
            byte houseCardRank = DetermineCardRank(_houseCard);

            //compare the card ranks to determine round winner
            if (playerCardRank > houseCardRank)
            {
                //player1 won the round
                return 1;
            }
            else if (houseCardRank > playerCardRank)
            {
                //House won the round
                return 2;
            }

            else
            {
                //Draw!
                return 0;
            }

        }

        /// <summary>
        /// Deals cards to the player and the house
        /// </summary>
        public void DealCards()
        {
            //provide the player and the house with two random cards from the deck
            bool cardsDealt = _cardDeck.GetCards(out _playerCard, out _houseCard);
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
