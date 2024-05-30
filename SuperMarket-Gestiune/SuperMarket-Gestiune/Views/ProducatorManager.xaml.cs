using Microsoft.IdentityModel.Tokens;
using SuperMarket_Gestiune.Models;
using SuperMarket_Gestiune.ViewModels;
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

namespace SuperMarket_Gestiune.Views
{
    /// <summary>
    /// Interaction logic for ProducatorManager.xaml
    /// </summary>
    public partial class ProducatorManager : Window
    {
        private Utilizatori LoggedUser;
        private bool vizualizare;
        public Produse SelectedProduct { get; private set; }
        public ProducatorManager(bool adauga, bool sterge, bool modifica, bool vizualizare,Utilizatori LoggedUser)
        {
            this.LoggedUser = LoggedUser;
            InitializeComponent();
            addButton.Visibility = Visibility.Collapsed;
            modifyButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
            if (adauga)
            {
                addButton.Visibility = Visibility.Visible;
                ProducatoriDataGrid.IsReadOnly = true;
            }
            else if (sterge)
            {
                deleteButton.Visibility = Visibility.Visible;
                ProducatoriDataGrid.IsReadOnly = true;
            }
            else if (modifica)
            {
                modifyButton.Visibility = Visibility.Visible;
            }
            else if (vizualizare)
            {
                ProducatoriDataGrid.IsReadOnly = true;
            }
            this.vizualizare = vizualizare;
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ProducatoriVM).SelectedProducator = ProducatoriDataGrid.SelectedItem as Producatori;
            (DataContext as ProducatoriVM).UpdateProducator();
            AdminMenu adminMenu = new AdminMenu(LoggedUser);
            adminMenu.Show();
            Close();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            string userInput = Microsoft.VisualBasic.Interaction.InputBox("Introduceti numele producatorului pe care vreti sa l introduceti", "Producator Name", "");
            string userInput2 = Microsoft.VisualBasic.Interaction.InputBox("Introduceti tara de origine producatorului pe care vreti sa l introduceti", "Country Name", "");
            if (!userInput.IsNullOrEmpty())
            {
                Producatori producatori = new Producatori
                {
                    Nume = userInput,
                    TaraOrigine = userInput2
                };
                (DataContext as ProducatoriVM).AddProducator(producatori);
                AdminMenu adminMenu = new AdminMenu(LoggedUser);
                adminMenu.Show();
                Close();
            }
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ProducatoriVM).SelectedProducator = ProducatoriDataGrid.SelectedItem as Producatori;
            (DataContext as ProducatoriVM).DeleteProducator();
            AdminMenu adminMenu = new AdminMenu(LoggedUser);
            adminMenu.Show();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu(LoggedUser);
            adminMenu.Show();
            Close();
        }

        private void ProducatoriDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(vizualizare)
            {
                (DataContext as ProducatoriVM).SelectedProducator = ProducatoriDataGrid.SelectedItem as Producatori;
                ProdusManager produsManager = new ProdusManager(false, false, false, true, LoggedUser, (DataContext as ProducatoriVM).SelectedProducator);
                produsManager.Show();
                Close();
            }
        }
    }
}
