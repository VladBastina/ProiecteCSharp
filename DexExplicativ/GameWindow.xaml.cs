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

namespace DexExplicativ
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private List<WordClass> gameWords;
        private List<int> propertyShown;
        private int index = 1;
        private List<string> guesses;
        public GameWindow(object datactx)
        {
            InitializeComponent();
            DataContext = datactx;
            gameWords = (DataContext as ObjectToSerialize).SelectFive();
            propertyShown = (DataContext as ObjectToSerialize).propertyShownWords(gameWords);
            guesses = new List<string> { "" , "" , "" , "" , ""};
            indexText.Text = index.ToString();
            updateWindow(index - 1);
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            guesses[index-1]=guessBox.Text;
            index--;
            indexText.Text = index.ToString();
            nextButton.Visibility = Visibility.Visible;
            endButton.Visibility = Visibility.Collapsed;
            if (index == 1) 
            {
                prevButton.Visibility = Visibility.Collapsed;
            }
            guessBox.Text= guesses[index-1];
            updateWindow(index - 1);
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            guesses[index - 1] = guessBox.Text;
            index++;
            indexText.Text = index.ToString();
            prevButton.Visibility = Visibility.Visible;
            if (index==5)
            {
                nextButton.Visibility = Visibility.Collapsed;
                endButton.Visibility = Visibility.Visible;
            }
            guessBox.Text = guesses[index - 1];
            updateWindow(index - 1);
        }

        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            guesses[index - 1] = guessBox.Text;
            int correctGuesses = 0;
            for(int i=0; i<5;i++)
            {
                if (gameWords[i].Word == guesses[i])
                {
                    correctGuesses++;
                }
            }
            MessageBox.Show($"Ati ghicit {correctGuesses} din 5");
            Close();
        }

        private void updateWindow(int index)
        {
            descriptionBox.Visibility = Visibility.Collapsed;
            imageBox.Visibility = Visibility.Collapsed;
            if (propertyShown[index] == 2)
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(gameWords[index].ImagePath));
                imageBox.Source = bitmapImage;
                imageBox.Visibility= Visibility.Visible;
            }
            else if (propertyShown[index] == 1)
            {
                descriptionBox.Text = gameWords[index].Explenation;
                descriptionBox.Visibility = Visibility.Visible;
            }
        }

    }
}
