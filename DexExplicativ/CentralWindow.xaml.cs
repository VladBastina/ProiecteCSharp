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
    /// Interaction logic for CentralWindow.xaml
    /// </summary>
    public partial class CentralWindow : Window
    {
        SerializationActions act;

        public CentralWindow()
        {
            InitializeComponent();
            ObjectToSerialize dataCtx = DataContext as ObjectToSerialize;
            act = new SerializationActions(dataCtx.Words);
            act.DeserializeObject();
            ObjectToSerialize obj = DataContext as ObjectToSerialize;
            Closing += CentralWindow_Closing;
            (DataContext as ObjectToSerialize).UpdateCategoryList();
        }

        private void CentralWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            act.SerializeObject(DataContext as ObjectToSerialize);
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddWord addWordWindow = new AddWord(DataContext as ObjectToSerialize);
            addWordWindow.Show();
        }

        private void wordToSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            recommendationsListBox.Visibility = Visibility.Visible;
            string wordForSearch = wordToSearch.Text;
            string categoryToSearch = string.Empty;
            if (selectionBox.SelectedItem != null)
            {
                categoryToSearch = (selectionBox.SelectedItem as string);
            }
            else
            {
                categoryToSearch = string.Empty;
            }
            if (categoryToSearch != string.Empty)
            (DataContext as ObjectToSerialize).updateRecomadations(wordForSearch,categoryToSearch);
            else
            {
                (DataContext as ObjectToSerialize).updateRecomadations(wordForSearch);
            }
            if(recommendationsListBox.Items.Count == 0) 
            {
                recommendationsListBox.Visibility = Visibility.Hidden;
            }
        }

        private void recommendationsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as ObjectToSerialize).SelectedWord = recommendationsListBox.SelectedItem as WordClass;
        }

        private void selectionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            recommendationsListBox.Visibility = Visibility.Visible;
            string wordForSearch = wordToSearch.Text;
            string categoryToSearch = string.Empty;
            if (selectionBox.SelectedItem != null)
            {
                categoryToSearch = (selectionBox.SelectedItem as string);
            }
            else
            {
                categoryToSearch = string.Empty;
            }
            if (categoryToSearch != string.Empty)
                (DataContext as ObjectToSerialize).updateRecomadations(wordForSearch, categoryToSearch);
            else
            {
                (DataContext as ObjectToSerialize).updateRecomadations(wordForSearch);
            }
            if (recommendationsListBox.Items.Count == 0)
            {
                recommendationsListBox.Visibility = Visibility.Hidden;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = Microsoft.VisualBasic.Interaction.InputBox("Introduceti cuvantul pe care vreti sa-l stergeti", "Delete Box", "");

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                (DataContext as ObjectToSerialize).DeleteWord(userInput);
                (DataContext as ObjectToSerialize).UpdateCategoryList();
            }
            else
            {
                MessageBox.Show("Nu ați introdus niciun text.");
            }
        }

        private void gameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow(DataContext as ObjectToSerialize);
            gameWindow.Show();
        }
    }
}
