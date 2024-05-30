using Checkers.Models;
using Checkers.Services;
using Checkers.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

    public partial class GameWindow : Window
    {
        private GameVMSerializer serializer;
        private string filePath;
        public GameWindow(bool multipleMoves,string filePath="")
        {
            serializer = new GameVMSerializer();
            if (filePath == "")
            {
                DataContext = new GameVM(multipleMoves);
                this.filePath = filePath;
            }
            else
            {
                DataContext = serializer.DeserializeObject(filePath);
                this.filePath = filePath; 
            }
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Button clickedButton = (Button)sender;
            //Cell itemData = (Cell)clickedButton.CommandParameter;
            //if((DataContext as GameVM).SelectedCell == null && itemData.HasPiece)
            //{
            //    (DataContext as GameVM).SelectedCell = itemData;
            //}
            //else if ((DataContext as GameVM).SelectedCell != null && itemData != (DataContext as GameVM).SelectedCell)
            //{
            //    (DataContext as GameVM).CellToMOveIn = itemData;
            //}
            if((DataContext as GameVM).Status==Status.Win)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Fișierul a fost șters cu succes.");
                }
                else
                {
                    Console.WriteLine("Fișierul nu există.");
                }
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
                Close();
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (filePath == "")
            {
                string userInput = Microsoft.VisualBasic.Interaction.InputBox("Introduceti numele fisierului in care doriti sa salvati jocul", "Save Game", "");

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    string path = @"C:\Users\vladb\VisualStudio\Checkers\Checkers\Resources\Games\" + userInput + ".xml";
                    serializer.SerializeObject((DataContext as GameVM), path);
                    MenuWindow menuWindow = new MenuWindow();
                    menuWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Nu ați introdus niciun text.");
                }
            }
            else
            {
                serializer.SerializeObject((DataContext as GameVM), filePath);
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
                Close();
            }
            
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            if(filePath!="")
            {
                serializer.SerializeObject((DataContext as GameVM), filePath);
            }
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            Close();
        }
    }
}
