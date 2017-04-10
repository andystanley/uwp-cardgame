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
        public static string _player1Name;
        public static string _player2Name;
        public static string _player3Name;
        public static string _player4Name;

        public static string _difficulty;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void OnBeginGame(object sender, RoutedEventArgs e)
        {
            if (_player1Text.Visibility == Visibility.Visible)
            {
                // Navigates to the Game Page
                Frame.Navigate(typeof(GamePage));

                _player1Name = _player1Text.Text;
                _player2Name = _player2Text.Text;
                _player3Name = _player3Text.Text;
                _player4Name = _player4Text.Text;

                GamePage gamepage = new GamePage();
                gamepage.InitializeComponent();
            }
            else if (_rbBeginner.Visibility == Visibility.Visible)
            {
                Frame.Navigate(typeof(SinglePlayerGamePage));
                SetDifficulty();

                // Navigates to the Single Player Game Page
                SinglePlayerGamePage gamepage = new SinglePlayerGamePage();
                gamepage.InitializeComponent();
            }
            else
            {
                // Message
                var dialog = new MessageDialog("Please choose single player or multiplayer before beginning a game", "Error");
                await dialog.ShowAsync();
            }
        }

        private async void OnViewRules(object sender, RoutedEventArgs e)
        {
            // Store the text from instructions.txt in a variable
            string rules = File.ReadAllText("Assets/rules.txt");

            // Display the instructions in a MessageDialog
            var dialog = new MessageDialog(rules, "Game Rules");
            await dialog.ShowAsync();
        }

        private void OnSinglePlayer(object sender, RoutedEventArgs e)
        {
            _btnMultiPlayer.Opacity = 1.0;
            _btnSinglePlayer.Opacity = 0.5;
            _txtInstructions.Text = "Ready to Play? Just choose the difficulty and press Begin Game";
            _player1Text.Visibility = Visibility.Collapsed;
            _player2Text.Visibility = Visibility.Collapsed;
            _player3Text.Visibility = Visibility.Collapsed;
            _player4Text.Visibility = Visibility.Collapsed;

            _rbBeginner.Visibility = Visibility.Visible;
            _rbAmateur.Visibility = Visibility.Visible;
            _rbExpert.Visibility = Visibility.Visible;
            
            // Navigates to the Game Page
            //Frame.Navigate(typeof(SinglePlayerGamePage));
        }

        private void OnMultiPlayer(object sender, RoutedEventArgs e)
        {
            _btnMultiPlayer.Opacity = 0.5;
            _btnSinglePlayer.Opacity = 1.0;
            _txtInstructions.Text = "Ready to Play? Just enter your friends names and leave the rest of the fields blank and press Begin Game";
            _rbBeginner.Visibility = Visibility.Collapsed;
            _rbAmateur.Visibility = Visibility.Collapsed;
            _rbExpert.Visibility = Visibility.Collapsed;

            _player1Text.Visibility = Visibility.Visible;
            _player2Text.Visibility = Visibility.Visible;
            _player3Text.Visibility = Visibility.Visible;
            _player4Text.Visibility = Visibility.Visible;
        }

        private void SetDifficulty()
        {
            // Update the selected bettor label depending on which bettor is selected
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
