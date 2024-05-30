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
    /// Interaction logic for StockManager.xaml
    /// </summary>
    public partial class StockManager : Window
    {
        private Utilizatori loggedUser;
        public StockManager(bool adauga, bool sterge, bool modifica, bool vizualizare,Utilizatori loggedUSer)
        {
            this.loggedUser = loggedUser;
            InitializeComponent();
            addButton.Visibility = Visibility.Collapsed;
            modifyButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
            if (adauga)
            {
                addButton.Visibility = Visibility.Visible;
                StockDataGrid.IsReadOnly = true;
            }
            else if (sterge)
            {
                deleteButton.Visibility = Visibility.Visible;
                StockDataGrid.IsReadOnly = true;
            }
            else if (modifica)
            {
                modifyButton.Visibility = Visibility.Visible;
            }
            else if (vizualizare)
            {
                StockDataGrid.IsReadOnly = true;
            }
        }

        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            StockAddDialog stockAddDialog = new StockAddDialog(loggedUser);
            stockAddDialog.ShowDialog();
            Close();
        }

        private void EditStock_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as StocuriVM).SelectedStock = StockDataGrid.SelectedItem as Stocuri;
            (DataContext as StocuriVM).UpdatePrice();
        }

        private void DeleteStock_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as StocuriVM).SelectedStock = StockDataGrid.SelectedItem as Stocuri;
            (DataContext as StocuriVM).DeleteStock();
            AdminMenu adminMenu = new AdminMenu(loggedUser);
            adminMenu.Show();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu(loggedUser);
            adminMenu.Show();
            Close();
        }
    }
}
