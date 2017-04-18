﻿using System;
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
        public StatsSinglePage()
        {
            this.InitializeComponent();
        }

        private void OnStatsLoad(object sender, RoutedEventArgs e)
        {
            _player1Name.Text = SinglePlayerGamePage._singleName;
            _player2Name.Text = SinglePlayerGamePage._singleHouseName;

            _player1Wins.Text = SinglePlayerGamePage._singleScore;
            _player2Wins.Text = SinglePlayerGamePage._playerTwoScore;

            _player1Loss.Text = SinglePlayerGamePage._playerOneLosses;
            _player2Loss.Text = SinglePlayerGamePage._playerTwoLosses;

            _player1WinPercent.Text = SinglePlayerGamePage._playerOnePercentage;
            _player2WinPercent.Text = SinglePlayerGamePage._playerTwoPercentage;


        }

        private void onGoBack(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SinglePlayerGamePage));
        }
    }
}