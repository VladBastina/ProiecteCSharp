using Checkers.Models;
using Checkers.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Checkers.Views
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private bool multipleMoves = false;

        public MenuWindow()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow(multipleMoves);
            gameWindow.Show();
            Close();
        }

        private void statisticsButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statisticsWindow = new StatisticsWindow();
            statisticsWindow.Show();
            Close();
        }

        private void openGameButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = @"C:\Users\vladb\VisualStudio\Checkers\Checkers\Resources\Games";

            openFileDialog.Filter = "Fișiere XML (*.xml)|*.xml|Toate fișierele (*.*)|*.*";


            if (openFileDialog.ShowDialog() == true)
            {
                string gamePath = openFileDialog.FileName;
                GameWindow gameWindow = new GameWindow(multipleMoves, gamePath);
                gameWindow.Show();
                Close();
            }
        }

        private void multipleMovesButton_Checked(object sender, RoutedEventArgs e)
        {
            multipleMoves = true;
        }

        private void multipleMovesButton_Unchecked(object sender, RoutedEventArgs e)
        {
            multipleMoves = false;
        }
    }
}
