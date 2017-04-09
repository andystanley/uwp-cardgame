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
        private Storyboard rotation = new Storyboard();
        private bool rotating = false;

        private SinglePlayerCardGame _game;

        private int _player1Score;
        private int _houseScore;

        private int _playerOneScore;
        private int _playerHouseScore;

        public SinglePlayerGamePage()
        {
            this.InitializeComponent();

            // Hide each of the players cards
            _cardPlayer.Opacity = 0.0;
            _cardHouse.Opacity = 0.0;

            //initialize the _game field variable
            _game = new SinglePlayerCardGame();

            _player1Score = 0;
            _houseScore = 0;


            _playerOneScore = 0;
            _playerHouseScore = 0;
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
            Storyboard.SetTarget(animation, _cardPlayer);
            Storyboard.SetTargetProperty(animation, "(UIElement.Projection).(PlaneProjection.Rotation" + "Y" + ")");

            DoubleAnimation animation2 = new DoubleAnimation();
            animation2.From = 0.0;
            animation2.To = 360.0;
            animation2.BeginTime = TimeSpan.FromSeconds(1);
            animation2.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTarget(animation2, _cardHouse);
            Storyboard.SetTargetProperty(animation2, "(UIElement.Projection).(PlaneProjection.Rotation" + "Y" + ")");

            rotation.Children.Clear();

            if (_player1Score == 5)
            {
                rotation.Children.Add(animation);
            }

            else if (_houseScore == 5)
            {
                rotation.Children.Add(animation2);
            }
            //rotation.Begin();
            //rotating = true;
        }

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

            ScaleTransform transform = new ScaleTransform();
            //transform.ScaleX = -1;
            _cardPlayer.RenderTransform = transform;
            //show the cards with one second between each to give the illusion like they are being flipped
            FlipCardsAnimation();

            // Disable Flip Cards button
            _btnFlipCards.IsEnabled = false;

            // Enable the Deal Cards button
            _btnDealCards.IsEnabled = true;

            //update the score
            if (_game.PlayRound() == 1)
            {
                _player1Score++;
                _playerPoint.Text = _player1Score.ToString();
                if (_player1Score == 5)
                {
                    _txtHint.Text = "Player 1 Won!";
                    _playerOneScore++;
                    _player1LeaderboardScore.Text = _playerOneScore.ToString();
                    Rotate("Y", ref _cardPlayer);
                    ClearResults();
                }
            }

            else if (_game.PlayRound() == 2)
            {
                _houseScore++;
                _housePoint.Text = _houseScore.ToString();
                if (_houseScore == 5)
                {
                    _txtHint.Text = "Player 2 Won!";
                    _playerHouseScore++;
                    _player2LeaderboardScore.Text = _playerHouseScore.ToString();
                    Rotate("Y", ref _cardHouse);
                    ClearResults();
                }
            }

            else if (_game.PlayRound() == 0)
            {
                // Draw
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
                _playerName.Text = "Player";
                _playerLeaderboardName.Text = "Player";
            }
            else
            {
                _playerName.Text = MainPage._player1Name;
                _playerLeaderboardName.Text = MainPage._player1Name;
            }
        }
        private void ClearResults()
        {
            _player1Score = 0;
            _houseScore = 0;

            _playerPoint.Text = "0";
            _playerPoint.Text = "0";
        }

        private async void OnViewRules(object sender, RoutedEventArgs e)
        {
            // Store the text from instructions.txt in a variable
            string rules = File.ReadAllText("Assets/rules.txt");

            // Display the instructions in a MessageDialog
            var dialog = new MessageDialog(rules, "Game Rules");
            await dialog.ShowAsync();
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

            // Flip the player card
            ShowCard(_cardPlayer, _game.PlayerCard);

            // Flip the house card
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            ShowCard(_cardHouse, _game.HouseCard);
        }

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
    }
}
