﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UniversalCardGame;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _21CardGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        private CardGame _game;

        public GamePage()
        {
            this.InitializeComponent();

            //initialize the _game field variable
            _game = new CardGame();
        }

        private void OnDealCards(object sender, RoutedEventArgs e)
        {
            _game.DealCards();
        }

        private void OnFlipCards(object sender, RoutedEventArgs e)
        {
            //show the cards
            ShowCard(_cardPlayer1, _game.Player1Card);
            ShowCard(_cardPlayer2, _game.Player2Card);
            ShowCard(_cardPlayer3, _game.Player3Card);
            ShowCard(_cardPlayer4, _game.Player4Card);
        }

        private void ShowCard(Image imageCtrl, Card card)
        {
            //DONE: determine the name of hte image based on card value and suit
            char suitId = card.Suit.ToString()[0];
            string cardValueId = card.Value.ToString("00");
            string cardImageFileName = $"{suitId}{cardValueId}.png";

            //DONE: display the image in the image control
            string cardImgPath = $"ms-appx:///Assets/Card Assets/{cardImageFileName}";
            imageCtrl.Source = new BitmapImage(new Uri(cardImgPath));

        }
    }
}
