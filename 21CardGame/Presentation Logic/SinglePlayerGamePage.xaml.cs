using _21CardGame.Business_Logic.SinglePlayer;
using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _21CardGame.Presentation_Logic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SinglePlayerGamePage : Page
    {
        // Create instances of the Storyboard and SinglePlayerCardGame classes
        private Storyboard _rotation;
        private SinglePlayerCardGame _game;

        // Create a field variable for if the card is rotatating
        private bool _rotating = false;

        // Create field variables to store the player and house scores
        private int _playerScore;
        private int _houseScore;

        // Create Field variables to score the player and houses wins and losses
        private int _playerOneScore;
        private int _HouseScore;
        private int _playerOneLoss;
        private int _houseLoss;

        // Create static field variables for the wins and losses to be used in the stats page
        public static string _playerWins;
        public static string _houseWins;
        public static string _playerOneLosses;
        public static string _playerTwoLosses;

        // Create win double values to be used in the stats page
        public static double _playerWinsDouble;
        public static double _houseWinsDouble;

        // Create static field variable for the total wins
        public static double _totalWins;

        // Create static field variables for the win percentage
        public static string _playerPercentage;
        public static string _housePercentage; 

        /// <summary>
        /// Initialize the SinglePlayerGamePage
        /// </summary>
        public SinglePlayerGamePage()
        {
            // Initialize the page
            this.InitializeComponent();

            // Initialize the SinglePlayerCardGame and Storyboard instances
            _game = new SinglePlayerCardGame();
            _rotation = new Storyboard();

            // Hide each of the players cards
            _cardPlayer.Opacity = 0.0;
            _cardHouse.Opacity = 0.0;

            // Set the player and house values to a default 0
            _playerScore = 0;
            _houseScore = 0;

            _playerOneScore = 0;
            _HouseScore = 0;

            _playerOneLoss = 0;
            _houseLoss = 0;

        }

        /// <summary>
        /// Deal Cards Button
        /// </summary>
        /// <param name="sender">deal cards button</param>
        /// <param name="e"></param>
        private void OnDealCards(object sender, RoutedEventArgs e)
        {
            // Rotation to be implented in a future version
            /*
            if (_rotating)
            {
                _rotation.Stop();
                _rotating = false;
            }
            */
            
            // Display the Deal Cards animation
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

        /// <summary>
        /// Flip cards button
        /// </summary>
        /// <param name="sender">flip cards buttin</param>
        /// <param name="e"></param>
        private void OnFlipCards(object sender, RoutedEventArgs e)
        {
            // Restock the deck
            _card1.Visibility = Visibility.Visible;
            _card2.Visibility = Visibility.Visible;

            // Rotation to be implemented in a future version
            /*
            ScaleTransform transform = new ScaleTransform();
            //transform.ScaleX = -1;
            _cardPlayer.RenderTransform = transform;
            */

            //show the cards with one second between each to give the illusion like they are being flipped
            FlipCardsAnimation();

            // Disable Flip Cards button
            _btnFlipCards.IsEnabled = false;

            // Enable the Deal Cards button
            _btnDealCards.IsEnabled = true;
        }

        /// <summary>
        /// Show the card
        /// </summary>
        /// <param name="imageCtrl"></param>
        /// <param name="card"></param>
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
                _playerName.Text = "Player";
                _playerLeaderboardName.Text = "Player";
            }
            else
            {
                _playerName.Text = MainPage._player1Name;
                _playerLeaderboardName.Text = MainPage._player1Name;
            }
        }

        /// <summary>
        /// Method for View Rules Button
        /// </summary>
        /// <param name="sender">view rules button</param>
        /// <param name="e"></param>
        private async void OnViewRules(object sender, RoutedEventArgs e)
        {
            // Store the text from instructions.txt in a variable
            string rules = File.ReadAllText("Assets/rules.txt");

            // Display the instructions in a MessageDialog
            var dialog = new MessageDialog(rules, "Game Rules");
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Method for New Game Button
        /// </summary>
        /// <param name="sender">new game button</param>
        /// <param name="e"></param>
        private async void OnNewGame(object sender, RoutedEventArgs e)
        {
            // Display a warning dialog
            var dialog = new MessageDialog("Are you sure wish to start a new game?  This will reset the current game!");

            // Add yes and no commands to the dialog
            dialog.Commands.Add(new UICommand("Yes"));
            dialog.Commands.Add(new UICommand("Cancel"));

            // Get the result
            var result = await dialog.ShowAsync();

            // If result is yes navigate back to the main page, else do nothing
            if (result.Label == "Yes")
            {
                // Navigates to the Game Page
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        /// <summary>
        /// Method to display a card dealing animation
        /// </summary>
        private async void DealCardsAnimation()
        {
            // Get the path for the back of the card
            string cardImgPath = $"ms-appx:///Assets/Card Assets/playing-card-back.jpg";

            // Remove the cards from the deck and give them to the players

            // Wait for one second
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));

            // Hide the card at the top of the deck
            _card2.Visibility = Visibility.Collapsed;

            // Display Player 1s Card
            _cardPlayer.Source = new BitmapImage(new Uri(cardImgPath));
            _cardPlayer.Opacity = 1.0;

            // Display Player 2s Card
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            _card1.Visibility = Visibility.Collapsed;
            _cardHouse.Source = new BitmapImage(new Uri(cardImgPath));
            _cardHouse.Opacity = 1.0;
        }

        /// <summary>
        /// Method to display a flipping cards animation
        /// </summary>
        private async void FlipCardsAnimation()
        {
            // Flip the cards

            // Wait for 1 second
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));

            // Flip the player card
            ShowCard(_cardPlayer, _game.PlayerCard);

            // Flip the house card
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            ShowCard(_cardHouse, _game.HouseCard);

            DetermineWinner();
        }

        /// <summary>
        /// Method to determine the winner
        /// </summary>
        private void DetermineWinner()
        {
            // Update the score and labels if the player won
            if (_game.PlayRound() == 1)
            {
                _txtHint.Text = "Player Won Round!";
                _playerScore++;
                _playerPoint.Text = _playerScore.ToString();
                if (_playerScore == 5)
                {
                    _txtHint.Text = "Player Won!";
                    _playerOneScore++;
                    _houseLoss++;
                    _player1LeaderboardScore.Text = _playerOneScore.ToString();
                    //Rotate("Y", ref _cardPlayer);
                    ClearResults();
                }
            }

            // Update the score and labels if house won
            else if (_game.PlayRound() == 2)
            {
                _txtHint.Text = "House Won Round!";
                _houseScore++;
                _housePoint.Text = _houseScore.ToString();
                HouseDifficulty();

            }

            // Update label if the round was a draw
            else if (_game.PlayRound() == 0)
            {
                _txtHint.Text = "Round was a draw";
            }
        }

        /// <summary>
        /// Method for when the Check Stats button
        /// </summary>
        /// <param name="sender">check stats button</param>
        /// <param name="e"></param>
        private void OnStatsCheck(object sender, RoutedEventArgs e)
        {
            // Navigate to the stats page
            Frame.Navigate(typeof(StatsSinglePage));

            // Get the current stats and store them in the field varaibles to be used in the stats page
            _playerWins = _player1LeaderboardScore.Text;
            _houseWins = _player2LeaderboardScore.Text;

            _playerOneLosses = _playerOneLoss.ToString();
            _playerTwoLosses = _houseLoss.ToString();

            _playerWinsDouble = Double.Parse(_player1LeaderboardScore.Text);
            _houseWinsDouble = Double.Parse(_player2LeaderboardScore.Text);

            _totalWins = (_playerWinsDouble + _houseWinsDouble);
            _playerPercentage = (Math.Round(_playerWinsDouble / _totalWins * 100)).ToString() + "%";
            _housePercentage = (Math.Round(_houseWinsDouble / _totalWins * 100)).ToString() + "%";

        }

        private void ClearResults()
        {
            //sets the values of the scores to 0
            //clears results
            _playerScore = 0;
            _houseScore = 0;

            //set the labels back to 0
            _playerPoint.Text = "0";
            _housePoint.Text = "0";
        }

        /// <summary>
        /// On page loaded
        /// </summary>
        /// <param name="sender">on page loaded</param>
        /// <param name="e"></param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Set the diffculity label to whatever difficulty has been selected
            _txtDifficulty.Text = $"Difficulty: {MainPage._difficulty}";
        }

        /// <summary>
        ///  Determine the house difficulty
        /// </summary>
        private void HouseDifficulty()
        {
            // Update the score depending on the difficulty
            if (_txtDifficulty.Text == "Difficulty: Beginner")
            {
                if (_houseScore == 6)
                {
                    _txtHint.Text = "House Won!";
                    _HouseScore++;
                    _playerOneLoss++;
                    _player2LeaderboardScore.Text = _HouseScore.ToString();
                    Rotate("Y", ref _cardHouse);
                    ClearResults();
                }
            }
            else if (_txtDifficulty.Text == "Difficulty: Amateur")
            {
                if (_houseScore == 5)
                {
                    _txtHint.Text = "Player 2 Won!";
                    _HouseScore++;
                    _playerOneLoss++;
                    _player2LeaderboardScore.Text = _HouseScore.ToString();
                    Rotate("Y", ref _cardHouse);
                    ClearResults();
                }
            }
            else
            {
                if (_houseScore == 4)
                {
                    _txtHint.Text = "House Won!";
                    _HouseScore++;
                    _playerOneLoss++;
                    _player2LeaderboardScore.Text = _HouseScore.ToString();
                    Rotate("Y", ref _cardHouse);
                    ClearResults();
                }
            }

        }

        /// <summary>
        /// Rotate method.  Will work in a future version
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="target"></param>
        public void Rotate(string axis, ref Image target)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0.0;
            animation.To = 360.0;
            animation.BeginTime = TimeSpan.FromSeconds(1);
            animation.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTarget(animation, _cardPlayer);
            Storyboard.SetTargetProperty(animation, "(UIElement.Projection).(PlaneProjection.Rotation" + "Y" + ")");

            DoubleAnimation animation2 = new DoubleAnimation();
            animation2.From = 0.0;
            animation2.To = 360.0;
            animation2.BeginTime = TimeSpan.FromSeconds(1);
            animation2.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTarget(animation2, _cardHouse);
            Storyboard.SetTargetProperty(animation2, "(UIElement.Projection).(PlaneProjection.Rotation" + "Y" + ")");

            _rotation.Children.Clear();

            if (_playerScore == 5)
            {
                _rotation.Children.Add(animation);
            }

            else if (_houseScore == 5)
            {
                _rotation.Children.Add(animation2);
            }
            _rotation.Begin();
            _rotating = true;
        }
    }
}
