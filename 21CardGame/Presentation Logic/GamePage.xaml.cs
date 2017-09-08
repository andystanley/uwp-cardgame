using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UniversalCardGame;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;
using _21CardGame.Presentation_Logic;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _21CardGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        /// <summary>
        /// fields variables for the name of the players used for leadership scoreboard
        /// </summary>
        // Create an instance of the StoryBoard class to be used for rotation
        private Storyboard rotation = new Storyboard();
        private bool rotating = false;

        // Declare static field variables that will be used in the stats page
        public static string _stats1Name;
        public static string _stats2Name;
        public static string _stats3Name;
        public static string _stats4Name;

        /// <summary>
        /// field variables for keeping track of wins for the stats page
        /// </summary>
        public static string _stats1Wins;
        public static string _stats2Wins;
        public static string _stats3Wins;
        public static string _stats4Wins;

        /// <summary>
        /// field variables for tracking losses of each player
        /// </summary>
        public static string _stats1Loss;
        public static string _stats2Loss;
        public static string _stats3Loss;
        public static string _stats4Loss;

        /// <summary>
        /// field variables for converting the numbers on leadership board to doubles
        /// to be used in StatsPage
        /// </summary>
        public static double _totalWins;
        public static double _player1LeaderboardNumber;
        public static double _player2LeaderboardNumber;
        public static double _player3LeaderboardNumber;
        public static double _player4LeaderboardNumber;

        /// <summary>
        /// field variables for keeping tracking of winning percentage of each player
        /// </summary>
        public static string _playerOnePercentage;
        public static string _playerTwoPercentage;
        public static string _playerThreePercentage;
        public static string _playerFourPercentage;

        /// <summary>
        /// new instance of CardGame
        /// </summary>
        private CardGame _game;

        /// <summary>
        /// field variables for the label of each player 
        /// that keeps track of wins per round
        /// </summary>
        private int _player1Score;
        private int _player2Score;
        private int _player3Score;
        private int _player4Score;

        /// <summary>
        /// field variables for storing wins per round
        /// </summary>
        private int _playerOneScore;
        private int _playerTwoScore;
        private int _playerThreeScore;
        private int _playerFourScore;

        /// <summary>
        /// field variables for storing losses per round
        /// </summary>
        private int _playerOneLoss;
        private int _playerTwoLoss;
        private int _playerThreeLoss;
        private int _playerFourLoss;

        public GamePage()
        {
            this.InitializeComponent();

            // Initialize the CardGame instance
            _game = new CardGame();

            // Hide each of the players cards
            _cardPlayer1.Opacity = 0.0;
            _cardPlayer2.Opacity = 0.0;
            _cardPlayer3.Opacity = 0.0;
            _cardPlayer4.Opacity = 0.0;

            //initialize the _game field variable
            _game = new CardGame();

            ///initialize the labels to 0
            _player1Score = 0;
            _player2Score = 0;
            _player3Score = 0;
            _player4Score = 0;

            //intialize the actual scores to 0
            _playerOneScore = 0;
            _playerTwoScore = 0;
            _playerThreeScore = 0;
            _playerFourScore = 0;

            //initialize the losses to 0
            _playerOneLoss = 0;
            _playerTwoLoss = 0;
            _playerThreeLoss = 0;
            _playerFourLoss = 0;
        }

        public void Rotate(string axis, ref Image target)
        {
            
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

        }

        /// <summary>
        /// Method created for when cards are dealt
        /// Deal card animation is initiated
        /// cards are dealt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDealCards(object sender, RoutedEventArgs e)
        {
            if (rotating)
            {
                rotation.Stop();
                rotating = false;
            }
            DealCardsAnimation();

            // Deal the cards
            _game.DealCards();

            // Clear hint
            _txtHint.Text = "";

            // Disable the Deal Cards button
            _btnDealCards.IsEnabled = false;

            // Enable the Flip Cards button
            _btnFlipCards.IsEnabled = true;
        }

        private void OnFlipCards(object sender, RoutedEventArgs e)
        {
            // Restock the deck
            _card1.Visibility = Visibility.Visible;
            _card2.Visibility = Visibility.Visible;
            _card3.Visibility = Visibility.Visible;
            _card4.Visibility = Visibility.Visible;

            //show the cards with one second between each to give the illusion like they are being flipped
            FlipCardsAnimation();

            // Disable Flip Cards button
            _btnFlipCards.IsEnabled = false;
            
            // Enable the Deal Cards button
            _btnDealCards.IsEnabled = true;

        }
        private async void OnNewGame(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Are you sure wish to start a new game?  This will reset the current game!");

            dialog.Commands.Add(new UICommand("Yes"));
            dialog.Commands.Add(new UICommand("Cancel"));

            var result = await dialog.ShowAsync();

            if (result.Label == "Yes")
            {
                // Navigates to the Game Page
                this.Frame.Navigate(typeof(MainPage));
            }
        }
        private async void FlipCardsAnimation()
        {
            // Flip the cards

            // Wait for 1 second
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            
            // Flip the first card
            ShowCard(_cardPlayer1, _game.Player1Card);

            // Flip the third card
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            ShowCard(_cardPlayer2, _game.Player2Card);

            // Flip the second card
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            ShowCard(_cardPlayer3, _game.Player3Card);

            // Flip the fourth card
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            ShowCard(_cardPlayer4, _game.Player4Card);

            DetermineWinner();

        }

        private void DetermineWinner()
        {
            //update the score
            if (_game.PlayRound() == 1)
            {
                _player1Score++;
                _txtHint.Text = $"{_player1Name.Text} Won The Round!";
                _player1Point.Text = _player1Score.ToString();
                //if player 1 reaches 5, then update leaderboard to add 
                //a win. Clears result.
                if(_player1Score == 5)
                {
                    _txtHint.Text = $"{_player1Name.Text} Won The Game!";
                    _playerOneScore++;
                    _playerTwoLoss++;
                    _playerThreeLoss++;
                    _playerFourLoss++;
                    _player1LeaderboardScore.Text = _playerOneScore.ToString();
                    Rotate("Y", ref _cardPlayer1);
                    ClearResults();
                }
            }

            else if (_game.PlayRound() == 2)
            {
                _player2Score++;
                _txtHint.Text = $"{_player2Name.Text} Won The Round!";
                _player2Point.Text = _player2Score.ToString();
                //if player 2 reaches 5, then update leaderboard to add 
                //a win. Clears result.
                if (_player2Score == 5)
                {
                    _txtHint.Text = $"{_player2Name.Text} Won The Game!";
                    _playerTwoScore++;
                    _playerOneLoss++;
                    _playerThreeLoss++;
                    _playerFourLoss++;
                    _player2LeaderboardScore.Text = _playerTwoScore.ToString();
                    Rotate("Y", ref _cardPlayer2);
                    ClearResults();
                }
            }

            else if (_game.PlayRound() == 3)
            {
                _player3Score++;
                _txtHint.Text = $"{_player3Name.Text} Won The Round!";
                _player3Point.Text = _player3Score.ToString();
                //if player 3 reaches 5, then update leaderboard to add 
                //a win. Clears result.
                if (_player3Score == 5)
                {
                    _txtHint.Text = $"{_player3Name.Text} Won The Game!";
                    _playerThreeScore++;
                    _playerTwoLoss++;
                    _playerOneLoss++;
                    _playerFourLoss++;
                    _player3LeaderboardScore.Text = _playerThreeScore.ToString();
                    Rotate("Y", ref _cardPlayer3);
                    ClearResults();
                }
            }

            else if (_game.PlayRound() == 4)
            {
                _player4Score++;
                _txtHint.Text = $"{_player4Name.Text} Won The Round!";
                _player4Point.Text = _player4Score.ToString();
                //if player 4 reaches 5, then update leaderboard to add 
                //a win. Clears result.
                if (_player4Score == 5)
                {
                    _txtHint.Text = $"{_player4Name.Text} Won The Game!"; 
                    _playerFourScore++;
                    _playerTwoLoss++;
                    _playerThreeLoss++;
                    _playerOneLoss++;
                    _player4LeaderboardScore.Text = _playerFourScore.ToString();
                    Rotate("Y", ref _cardPlayer4);
                    ClearResults();
                }
            }

            else if(_game.PlayRound()== 0)
            {
                _txtHint.Text = "It's a draw!";
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
            //if player does not put name in mainpage
            //it automatically sets it to Player
            if (MainPage._player1Name == "")
            {
                _player1Name.Text = "Player";
                _player1LeaderboardName.Text = "Player";
            }
            //else set the name of the player to the name the player
            //typed in MainPage
            else
            {
                _player1Name.Text = MainPage._player1Name;
                _player1LeaderboardName.Text = MainPage._player1Name;
            }

            //if player does not put name in mainpage
            //it automatically sets it to CPU2
            if (MainPage._player2Name == "")
            {
                _player2Name.Text = "CPU 2";
                _player2LeaderboardName.Text = "CPU 2";
            }
            //else set the name of the player to the name the player
            //typed in MainPage
            else
            {
                _player2Name.Text = MainPage._player2Name;
                _player2LeaderboardName.Text = MainPage._player2Name;

            }

            //if player does not put name in mainpage
            //it automatically sets it to CPU3
            if (MainPage._player3Name == "")
            {
                _player3Name.Text = "CPU 3";
                _player3LeaderboardName.Text = "CPU 3";
            }
            //else set the name of the player to the name the player
            //typed in MainPage
            else
            {
                _player3Name.Text = MainPage._player3Name;
                _player3LeaderboardName.Text = MainPage._player3Name;
            }

            //if player does not put name in mainpage
            //it automatically sets it to CPU4
            if (MainPage._player4Name == "")
            {
                _player4Name.Text = "CPU 4";
                _player4LeaderboardName.Text = "CPU 4";
            }
            //else set the name of the player to the name the player
            //typed in MainPage
            else
            {
                _player4Name.Text = MainPage._player4Name;
                _player4LeaderboardName.Text = MainPage._player4Name;
            }

        }
        private void ClearResults()
        {
            //sets the values of the scores to 0
            //clears results
            _player1Score = 0;
            _player2Score = 0;
            _player3Score = 0;
            _player4Score = 0;

            //set the labels back to 0
            _player1Point.Text = "0";
            _player2Point.Text = "0";
            _player3Point.Text = "0";
            _player4Point.Text = "0";
        }

        private async void OnViewRules(object sender, RoutedEventArgs e)
        {
            // Store the text from instructions.txt in a variable
            string rules = File.ReadAllText("Assets/rules.txt");

            // Display the instructions in a MessageDialog
            var dialog = new MessageDialog(rules, "Game Rules");
            await dialog.ShowAsync();
        }

        private async void DealCardsAnimation()
        {
            // Get the path for the back of the card
            string cardImgPath = $"ms-appx:///Assets/Card Assets/playing-card-back.jpg";

            // Remove the cards from the deck and give them to the players

            // Wait for one second
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));

            // Hide the card at the top of the deck
            _card4.Visibility = Visibility.Collapsed;
            
            // Display Player 1s Card
            _cardPlayer1.Source = new BitmapImage(new Uri(cardImgPath));
            _cardPlayer1.Opacity = 1.0;

            // Display Player 2s Card
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            _card3.Visibility = Visibility.Collapsed;
            _cardPlayer2.Source = new BitmapImage(new Uri(cardImgPath));
            _cardPlayer2.Opacity = 1.0;

            // Display Player 3s Card
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            _card2.Visibility = Visibility.Collapsed;
            _cardPlayer3.Source = new BitmapImage(new Uri(cardImgPath));
            _cardPlayer3.Opacity = 1.0;

            // Display Player 4s Card
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            _card1.Visibility = Visibility.Collapsed;
            _cardPlayer4.Source = new BitmapImage(new Uri(cardImgPath));
            _cardPlayer4.Opacity = 1.0;
        }

        /// <summary>
        /// event handler created for checking stats of the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStatsCheck(object sender, RoutedEventArgs e)
        {
            
            // Navigates to the Game Page
            this.Frame.Navigate(typeof(StatsPage));

            //assign values of the names to new variables
            //to be used in statsPage
            _stats1Name = _player1Name.Text;
            _stats2Name = _player2Name.Text;
            _stats3Name = _player3Name.Text;
            _stats4Name = _player4Name.Text;

            //stores values on scoreboard in new variables
            _stats1Wins = _player1LeaderboardScore.Text;
            _stats2Wins = _player2LeaderboardScore.Text;
            _stats3Wins = _player3LeaderboardScore.Text;
            _stats4Wins = _player4LeaderboardScore.Text;

            //converts losses to strings and stores them in new variables
            _stats1Loss = _playerOneLoss.ToString();
            _stats2Loss = _playerTwoLoss.ToString();
            _stats3Loss = _playerThreeLoss.ToString();
            _stats4Loss = _playerFourLoss.ToString();

            //converts scores on leadership board to double and stores them in new variables
            _player1LeaderboardNumber = Double.Parse(_player1LeaderboardScore.Text);
            _player2LeaderboardNumber = Double.Parse(_player2LeaderboardScore.Text);
            _player3LeaderboardNumber = Double.Parse(_player3LeaderboardScore.Text);
            _player4LeaderboardNumber = Double.Parse(_player4LeaderboardScore.Text);
            //variable that stores total value of all the wins
            _totalWins = _player1LeaderboardNumber + _player2LeaderboardNumber + _player3LeaderboardNumber + _player4LeaderboardNumber;

            //percentage variables that calculate each players winning percentage based on total wins
            _playerOnePercentage = (Math.Round(_player1LeaderboardNumber / _totalWins * 100)).ToString() + "%";
            _playerTwoPercentage = (Math.Round(_player2LeaderboardNumber / _totalWins * 100)).ToString() + "%";
            _playerThreePercentage = (Math.Round(_player3LeaderboardNumber / _totalWins * 100)).ToString() + "%";
            _playerFourPercentage = (Math.Round(_player4LeaderboardNumber / _totalWins * 100)).ToString() + "%";

            //initializes statsPage
            StatsPage statspage = new StatsPage();
            statspage.InitializeComponent();
        }
    }
}
