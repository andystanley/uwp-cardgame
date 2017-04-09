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
        public StatsPage()
        {
            this.InitializeComponent();
        }

        private void textBlock2_Copy_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }  

    private void OnStatsLoad(object sender, RoutedEventArgs e)
        {
            _player1Name.Text = GamePage._stats1Name;
            _player2Name.Text = GamePage._stats2Name;
            _player3Name.Text = GamePage._stats3Name;
            _player4Name.Text = GamePage._stats4Name;

            _player1Wins.Text = GamePage._stats1Wins;
            _player2Wins.Text = GamePage._stats2Wins;
            _player3Wins.Text = GamePage._stats3Wins;
            _player4Wins.Text = GamePage._stats4Wins;

            _player1Loss.Text = GamePage._stats1Loss;
            _player2Loss.Text = GamePage._stats2Loss;
            _player3Loss.Text = GamePage._stats3Loss;
            _player4Loss.Text = GamePage._stats4Loss;

            _player1WinPercent.Text = GamePage._playerOnePercentage;
            _player2WinPercent.Text = GamePage._playerTwoPercentage;
            _player3WinPercent.Text = GamePage._playerThreePercentage;
            _player4WinPercent.Text = GamePage._playerFourPercentage;

        }

        private void onGoBack(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GamePage));
        }
    }
}
