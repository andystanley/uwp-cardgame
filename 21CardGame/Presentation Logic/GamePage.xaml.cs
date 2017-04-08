using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UniversalCardGame;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _21CardGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        private CardGame _game;
        private int _player1Score;
        private int _player2Score;
        private int _player3Score;
        private int _player4Score;

        public GamePage()
        {
            this.InitializeComponent();

            //initialize the _game field variable
            _game = new CardGame();

            _player1Score = 0;
            _player2Score = 0;
            _player3Score = 0;
            _player4Score = 0;
        }

        private void OnDealCards(object sender, RoutedEventArgs e)
        {
            // Deal the cards
            _game.DealCards();

            // Displays Hint
            _txtHint.Text = "";

            // Disable the Deal Cards button
            _btnDealCards.IsEnabled = false;

            // Enable the Flip Cards button
            _btnFlipCards.IsEnabled = true;
        }

        private void OnFlipCards(object sender, RoutedEventArgs e)
        {

            //show the cards
            ShowCard(_cardPlayer1, _game.Player1Card);
            ShowCard(_cardPlayer2, _game.Player2Card);
            ShowCard(_cardPlayer3, _game.Player3Card);
            ShowCard(_cardPlayer4, _game.Player4Card);

            // Disable Flip Cards button
            _btnFlipCards.IsEnabled = false;
            
            // Enable the Deal Cards button
            _btnDealCards.IsEnabled = true;

            //update the score
            if (_game.PlayRound() == 1)
            {
                _player1Score++;
                Player1Point.Text = _player1Score.ToString();
                if(_player1Score == 5)
                {
                    _txtHint.Text = "Player 1 Won!";
                }
            }

            else if (_game.PlayRound() == 2)
            {
                _player2Score++;
                Player2Point.Text = _player2Score.ToString();
                if (_player2Score == 5)
                {
                    _txtHint.Text = "Player 2 Won!";
                }
            }

            else if (_game.PlayRound() == 3)
            {
                _player3Score++;
                Player3Point.Text = _player3Score.ToString();
                if (_player3Score == 5)
                {
                    _txtHint.Text = "Player 3 Won!";
                }
            }

            else if (_game.PlayRound() == 4)
            {
                _player4Score++;
                Player4Point.Text = _player4Score.ToString();
                if (_player4Score == 5)
                {
                    _txtHint.Text = "Player 4 Won!";
                }
            }

            else if(_game.PlayRound()== 0)
            {
                
            }

        }

        private void ShowCard(Image imageCtrl, Card card)
        {
            //DONE: determine the name of hte image based on card value and suit
            char suitId = card.Suit.ToString()[0];
            string cardValueId = card.Value.ToString("00");
            string cardImageFileName = $"{suitId}{cardValueId}.png";

            //DONE: display the image in the image control
            string cardImgPath = $"ms-appx:///Assets/Card Assets/{cardImageFileName}";
            imageCtrl.Source = new BitmapImage(new Uri(cardImgPath));

        }

       private void ShowRoundResult(sbyte roundResult)
       {
          
       }
    }
}
