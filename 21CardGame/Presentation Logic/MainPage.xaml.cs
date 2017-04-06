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
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnBeginGame(object sender, RoutedEventArgs e)
        {
            // Navigates to the Game Page
            this.Frame.Navigate(typeof(GamePage));
        }

        private async void OnViewInstructions(object sender, RoutedEventArgs e)
        {
            // Store the text from instructions.txt in a variable
            string instructions = File.ReadAllText("Assets/instructions.txt");

            // Display the instructions in a MessageDialog
            var dialog = new MessageDialog(instructions);
            await dialog.ShowAsync();
        }
    }
}
