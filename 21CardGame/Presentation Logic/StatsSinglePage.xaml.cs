using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class StatsSinglePage : Page
    {
        /// <summary>
        /// Initialize the stats page
        /// </summary>
        public StatsSinglePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// On Stats page loaded
        /// </summary>
        /// <param name="sender">page loaded</param>
        /// <param name="e"></param>
        private void OnStatsLoad(object sender, RoutedEventArgs e)
        {
            // Set the fields to the values taken from Game page
            _player1Wins.Text = SinglePlayerGamePage._playerWins;
            _player2Wins.Text = SinglePlayerGamePage._houseWins;

            _player1Loss.Text = SinglePlayerGamePage._playerOneLosses;
            _player2Loss.Text = SinglePlayerGamePage._playerTwoLosses;

            _player1WinPercent.Text = SinglePlayerGamePage._playerPercentage;
            _player2WinPercent.Text = SinglePlayerGamePage._housePercentage;

            if (_player1WinPercent.Text == "NaN%")
            {
                _player1WinPercent.Text = "0%";
            }

            if (_player2WinPercent.Text == "NaN%")
            {
                _player2WinPercent.Text = "0%";
            }

            
        }

        /// <summary>
        /// Method for when the user clicks go back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onGoBack(object sender, RoutedEventArgs e)
        {
            // Navigate back to the game
            Frame.Navigate(typeof(SinglePlayerGamePage));
        }
    }
}
