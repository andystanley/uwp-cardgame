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

        public MainPage()
        {
            this.InitializeComponent();
        }

        public String Player1Name()
        {
            return _player1Text.Text;
        }

        private void OnBeginGame(object sender, RoutedEventArgs e)
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
            // Navigates to the Game Page
            Frame.Navigate(typeof(SinglePlayerGamePage));
        }
    }
}
