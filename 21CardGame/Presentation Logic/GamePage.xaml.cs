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
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _21CardGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {

        private Storyboard rotation = new Storyboard();
        private bool rotating = false;

        private CardGame _game;

        private int _player1Score;
        private int _player2Score;
        private int _player3Score;
        private int _player4Score;

        private int _playerOneScore;
        private int _playerTwoScore;
        private int _playerThreeScore;
        private int _playerFourScore;

        public GamePage()
        {
            this.InitializeComponent();

            //initialize the _game field variable
            _game = new CardGame();

            _player1Score = 0;
            _player2Score = 0;
            _player3Score = 0;
            _player4Score = 0;

            _playerOneScore = 0;
            _playerTwoScore = 0;
            _playerThreeScore = 0;
            _playerFourScore = 0;
        }

        public void Rotate(string axis, ref Image target)
        {
            
            //else
            //{
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 0.0;
                animation.To = 360.0;
                animation.BeginTime = TimeSpan.FromSeconds(1);
                animation.RepeatBehavior = RepeatBehavior.Forever;
                Storyboard.SetTarget(animation, _cardPlayer1);
                Storyboard.SetTargetProperty(animation, "(UIElement.Projection).(PlaneProjection.Rotation" + "Y" + ")");

                DoubleAnimation animation2 = new DoubleAnimation();
                animation2.From = 0.0;
                animation2.To = 360.0;
                animation2.BeginTime = TimeSpan.FromSeconds(1);
                animation2.RepeatBehavior = RepeatBehavior.Forever;
                Storyboard.SetTarget(animation2, _cardPlayer2);
                Storyboard.SetTargetProperty(animation2, "(UIElement.Projection).(PlaneProjection.Rotation" + "Y" + ")");

                DoubleAnimation animation3 = new DoubleAnimation();
                animation3.From = 0.0;
                animation3.To = 360.0;
                animation3.BeginTime = TimeSpan.FromSeconds(1);
                animation3.RepeatBehavior = RepeatBehavior.Forever;
                Storyboard.SetTarget(animation3, _cardPlayer3);
                Storyboard.SetTargetProperty(animation3, "(UIElement.Projection).(PlaneProjection.Rotation" + "Y" + ")");

                DoubleAnimation animation4 = new DoubleAnimation();
                animation4.From = 0.0;
                animation4.To = 360.0;
                animation4.BeginTime = TimeSpan.FromSeconds(1);
                animation4.RepeatBehavior = RepeatBehavior.Forever;
                Storyboard.SetTarget(animation4, _cardPlayer4);
                Storyboard.SetTargetProperty(animation4, "(UIElement.Projection).(PlaneProjection.Rotation" + "Y" + ")");

            rotation.Children.Clear();

            if (_player1Score == 5)
            {
                rotation.Children.Add(animation);
            }

            else if (_player2Score == 5)
            {
                rotation.Children.Add(animation2);
            }

            else if (_player3Score == 5)
            {
                rotation.Children.Add(animation3);
            }
            else if (_player4Score == 5)
            {
                rotation.Children.Add(animation4);
            }
                rotation.Begin();
                rotating = true;

            //}
        }

        private void OnDealCards(object sender, RoutedEventArgs e)
        {
            if (rotating)
            {
                rotation.Stop();
                rotating = false;
            }
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
            ScaleTransform transform = new ScaleTransform();
            //transform.ScaleX = -1;
            _cardPlayer1.RenderTransform = transform;
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
                _player1Point.Text = _player1Score.ToString();
                if(_player1Score == 5)
                {
                    _txtHint.Text = "Player 1 Won!";
                    _playerOneScore++;
                    _player1LeaderboardScore.Text = _playerOneScore.ToString();
                    Rotate("Y", ref _cardPlayer1);
                    ClearResults();
                }
            }

            else if (_game.PlayRound() == 2)
            {
                _player2Score++;
                _player2Point.Text = _player2Score.ToString();
                if (_player2Score == 5)
                {
                    _txtHint.Text = "Player 2 Won!";
                    _playerTwoScore++;
                    _player2LeaderboardScore.Text = _playerTwoScore.ToString();
                    Rotate("Y", ref _cardPlayer2);
                    ClearResults();
                }
            }

            else if (_game.PlayRound() == 3)
            {
                _player3Score++;
                _player3Point.Text = _player3Score.ToString();
                if (_player3Score == 5)
                {
                    _txtHint.Text = "Player 3 Won!";
                    _playerThreeScore++;
                    _player3LeaderboardScore.Text = _playerThreeScore.ToString();
                    Rotate("Y", ref _cardPlayer3);
                    ClearResults();
                }
            }

            else if (_game.PlayRound() == 4)
            {
                _player4Score++;
                _player4Point.Text = _player4Score.ToString();
                if (_player4Score == 5)
                {
                    _txtHint.Text = "Player 4 Won!";
                    _playerFourScore++;
                    _player4LeaderboardScore.Text = _playerFourScore.ToString();
                    Rotate("Y", ref _cardPlayer4);
                    ClearResults();
                }
            }

            else if(_game.PlayRound()== 0)
            {
                
            }

        }

        private void ShowCard(Image imageCtrl, Card card)
        {
            //DONE: determine the name of the image based on card value and suit
            char suitId = card.Suit.ToString()[0];
            string cardValueId = card.Value.ToString("00");
            string cardImageFileName = $"{suitId}{cardValueId}.png";

            //DONE: display the image in the image control
            string cardImgPath = $"ms-appx:///Assets/Card Assets/{cardImageFileName}";
            imageCtrl.Source = new BitmapImage(new Uri(cardImgPath));

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainPage._player1Name == "")
            {
                _player1Name.Text = "Player";
                _player1LeaderboardName.Text = "Player";
            }
            else
            {
                _player1Name.Text = MainPage._player1Name;
                _player1LeaderboardName.Text = MainPage._player1Name;
            }

            if (MainPage._player2Name == "")
            {
                _player2Name.Text = "CPU 2";
                _player2LeaderboardName.Text = "CPU 2";
            }
            else
            {
                _player2Name.Text = MainPage._player2Name;
                _player2LeaderboardName.Text = MainPage._player2Name;

            }

            if (MainPage._player3Name == "")
            {
                _player3Name.Text = "CPU 3";
                _player3LeaderboardName.Text = "CPU 3";
            }
            else
            {
                _player3Name.Text = MainPage._player3Name;
                _player3LeaderboardName.Text = MainPage._player3Name;
            }

            if (MainPage._player4Name == "")
            {
                _player4Name.Text = "CPU 4";
                _player4LeaderboardName.Text = "CPU 4";
            }
            else
            {
                _player4Name.Text = MainPage._player4Name;
                _player4LeaderboardName.Text = MainPage._player4Name;
            }

        }
        private void ClearResults()
        {
            _player1Score = 0;
            _player2Score = 0;
            _player3Score = 0;
            _player4Score = 0;

            _player1Point.Text = "0";
            _player2Point.Text = "0";
            _player3Point.Text = "0";
            _player4Point.Text = "0";
        }
    }
}
