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

namespace DexExplicativ
{  
    public partial class AddWord : Window
    {
        private WordClass word = new WordClass();

        public AddWord(object dContext)
        {
            DataContext = dContext;
            InitializeComponent();
        }

        private void categorySelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categorySelection.SelectedItem == dummyItem)
            {
                categoryWriter.Visibility = Visibility.Visible;
            }
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = @"D:\VisualStudio\DexExplicativ\images";

            openFileDialog.Filter = "Fișiere de imagine (*.png;*.jpeg;*.jpg;*.gif)|*.png;*.jpeg;*.jpg;*.gif|Toate fișierele (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                word.ImagePath = imagePath;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            word.Word=wordBox.Text;
            word.Explenation=descriptionBox.Text;
            if (categorySelection.SelectedItem == dummyItem)
            {
                word.Category = newCategory.Text;
            }
            else
            {
                if (categorySelection.SelectedItem != null)
                {
                    word.Category = (categorySelection.SelectedItem as string);
                }
                else
                {
                    word.Category = "";
                }
            }
            (DataContext as ObjectToSerialize).AddWord(word);
            (DataContext as ObjectToSerialize).UpdateCategoryList();
            Close();
        }
    }
}
