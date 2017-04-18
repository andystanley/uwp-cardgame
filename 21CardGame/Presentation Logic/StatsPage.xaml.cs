using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    /// 
    public sealed partial class StatsPage : Page
    {
        SinglePlayerGamePage stat = new SinglePlayerGamePage();
        public StatsPage()
        {
            this.InitializeComponent();
        }

    private void OnStatsLoad(object sender, RoutedEventArgs e)
        {
           
            //updates players names in this page to the names used in the game
            _player1Name.Text = GamePage._stats1Name;
            _player2Name.Text = GamePage._stats2Name;
            _player3Name.Text = GamePage._stats3Name;
            _player4Name.Text = GamePage._stats4Name;

            //updates wins in this page according to wins in leadership board
            //on gamePage
            _player1Wins.Text = GamePage._stats1Wins;
            _player2Wins.Text = GamePage._stats2Wins;
            _player3Wins.Text = GamePage._stats3Wins;
            _player4Wins.Text = GamePage._stats4Wins;

            //updates losses in this page according to losses from gamePage
            _player1Loss.Text = GamePage._stats1Loss;
            _player2Loss.Text = GamePage._stats2Loss;
            _player3Loss.Text = GamePage._stats3Loss;
            _player4Loss.Text = GamePage._stats4Loss;

            //adds in winning percentages of each player based off calculations from gamePage
            _player1WinPercent.Text = GamePage._playerOnePercentage;
            _player2WinPercent.Text = GamePage._playerTwoPercentage;
            _player3WinPercent.Text = GamePage._playerThreePercentage;
            _player4WinPercent.Text = GamePage._playerFourPercentage;

            //percentage win automatically sets to NAN%
            //sets it to 0 instead
            if (_player1WinPercent.Text == "NaN%")
            {
                _player1WinPercent.Text = "0%";
            }

            if (_player2WinPercent.Text == "NaN%")
            {
                _player2WinPercent.Text = "0%";
            }

            if (_player3WinPercent.Text == "NaN%")
            {
                _player3WinPercent.Text = "0%";
            }

            if (_player4WinPercent.Text == "NaN%")
            {
                _player4WinPercent.Text = "0%";
            }

        }

        private void onGoBack(object sender, RoutedEventArgs e)
        {
            //return to gamePage
            Frame.Navigate(typeof(GamePage));
        }
    }
}
