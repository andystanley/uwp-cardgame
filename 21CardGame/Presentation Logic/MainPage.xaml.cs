using _21CardGame.Presentation_Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _21CardGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Create field variables to be used to in the Game Pages
        public static string _player1Name;
        public static string _player2Name;
        public static string _player3Name;
        public static string _player4Name;

        public static string _difficulty;

        /// <summary>
        /// Initiaze the MainPage
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Method for when the user clicks the Begin Game button
        /// </summary>
        /// <param name="sender">Begin Game button</param>
        /// <param name="e"></param>
        private async void OnBeginGame(object sender, RoutedEventArgs e)
        {
            // If multiplayer is selected
            if (_player1Text.Visibility == Visibility.Visible)
            {
                // Navigates to the Game Page
                Frame.Navigate(typeof(GamePage));

                // Store the players names in the field variables to be used later
                _player1Name = _player1Text.Text;
                _player2Name = _player2Text.Text;
                _player3Name = _player3Text.Text;
                _player4Name = _player4Text.Text;

                // Initialize the multiplayer GamePage
                GamePage gamepage = new GamePage();
                gamepage.InitializeComponent();
            }

            // If Single player is selected
            else if (_rbBeginner.Visibility == Visibility.Visible)
            {
                // Navigate to the SinglePlayerGamePage
                Frame.Navigate(typeof(SinglePlayerGamePage));

                // Determine which difficulty the player selected
                SetDifficulty();

                // Initialize the SinglePlayerGamePage
                SinglePlayerGamePage gamepage = new SinglePlayerGamePage();
                gamepage.InitializeComponent();
            }

            // Else if the user has not selected a game mode
            else
            {
                // Display an error message
                var dialog = new MessageDialog("Please choose single player or multiplayer before beginning a game", "Error");
                await dialog.ShowAsync();
            }
        }

        /// <summary>
        /// Method for when the user clicks the View Rules button
        /// </summary>
        /// <param name="sender">The View Rules button</param>
        /// <param name="e"></param>
        private async void OnViewRules(object sender, RoutedEventArgs e)
        {
            // Store the text from rules.txt in a variable
            string rules = File.ReadAllText("Assets/rules.txt");

            // Display the instructions in a MessageDialog
            var dialog = new MessageDialog(rules, "Game Rules");
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Method for when the user clicks on the Single Player button
        /// </summary>
        /// <param name="sender">Single Player button</param>
        /// <param name="e"></param>
        private void OnSinglePlayer(object sender, RoutedEventArgs e)
        {
            // Make the single player button appear like it is selected
            _btnSinglePlayer.Opacity = 0.5;

            // Make the mulitplayer button appear like it is NOT selected
            _btnMultiPlayer.Opacity = 1.0;

            // Displays a helpful hint to the user
            _txtInstructions.Text = "Ready to Play? Just choose the difficulty and press Begin Game";

            // Collapse the multiplayer entry options
            _player1Text.Visibility = Visibility.Collapsed;
            _player2Text.Visibility = Visibility.Collapsed;
            _player3Text.Visibility = Visibility.Collapsed;
            _player4Text.Visibility = Visibility.Collapsed;

            // Display the single player difficulty radio buttons
            _rbBeginner.Visibility = Visibility.Visible;
            _rbAmateur.Visibility = Visibility.Visible;
            _rbExpert.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Method for when the user clicks on the Multi Player button
        /// </summary>
        /// <param name="sender">multiplayer button</param>
        /// <param name="e"></param>
        private void OnMultiPlayer(object sender, RoutedEventArgs e)
        {
            // Make the multiplayer button appear like it is selected
            _btnMultiPlayer.Opacity = 0.5;

            // Make the single player button appear like it is NOT selected
            _btnSinglePlayer.Opacity = 1.0;

            // Display a helpful hint
            _txtInstructions.Text = "Ready to Play? Just enter your friends names and leave the rest of the fields blank and press Begin Game";

            // Collapse the difficulty radio buttons
            _rbBeginner.Visibility = Visibility.Collapsed;
            _rbAmateur.Visibility = Visibility.Collapsed;
            _rbExpert.Visibility = Visibility.Collapsed;

            // Display the multiplayer entry options
            _player1Text.Visibility = Visibility.Visible;
            _player2Text.Visibility = Visibility.Visible;
            _player3Text.Visibility = Visibility.Visible;
            _player4Text.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Method to determine which difficulty is selected
        /// </summary>
        private void SetDifficulty()
        {
            //  Update the difficulty field variables depending on which radio button is selected
            if (_rbBeginner.IsChecked == true)
            {
                _difficulty = "Beginner";
            }
            else if (_rbAmateur.IsChecked == true)
            {
                _difficulty = "Amateur";
            }
            else if (_rbExpert.IsChecked == true)
            {
                _difficulty = "Expert";
            }
        }
    }
}
