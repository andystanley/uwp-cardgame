using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardGame.Business_Logic
{

    struct PlayerScore
    {
        /// <summary>
        /// The score value for the player1
        /// </summary>
        private int _player1Score;

        /// <summary>
        /// The score value for player2
        /// </summary>
        private int _player2Score;

        /// <summary>
        /// The score value for player3
        /// </summary>
        private int _player3Score;

        /// <summary>
        /// The score value for player4
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
        /// The score value for player 2. The property provides access
        /// to the internal field variable
        /// </summary>
        public int Player2Score
        {
            get { return _player2Score; }
            set { _player2Score = value; }
        }

        /// <summary>
        /// The score value for player3. The property provides access
        /// to the internal field variable
        /// </summary>
        public int Player3Score
        {
            get { return _player3Score; }
            set { _player3Score = value; }
        }

        /// <summary>
        /// The score value for player4. The property provides access
        /// to the internal field variable
        /// </summary>
        public int Player4Score
        {
            get { return _player4Score; }
            set { _player4Score = value; }
        }
    }
    class GameScore
    {
    }
}
