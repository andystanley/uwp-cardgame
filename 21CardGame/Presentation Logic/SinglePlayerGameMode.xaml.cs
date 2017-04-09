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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _21CardGame.Presentation_Logic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SinglePlayerGameMode : Page
    {
        private CardGame _game;

        public SinglePlayerGameMode()
        {
            this.InitializeComponent();
            _game = new CardGame();
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

        private void OnDealCards(object sender, RoutedEventArgs e)
        {

        }

        private void OnFlipCards(object sender, RoutedEventArgs e)
        {

        }
    }
}
