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
    /// Interaction logic for ProdusManager.xaml
    /// </summary>
    public partial class ProdusManager : Window
    {
        private Utilizatori LoggedUser;

        public Produse SelectedProduct { get; private set; }
        public ProdusManager(bool adauga, bool sterge, bool modifica, bool vizualizare,Utilizatori loggedUser)
        {
            this.LoggedUser = loggedUser;
            InitializeComponent();
            addButton.Visibility = Visibility.Collapsed;
            modifyButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
            ok_button.Visibility = Visibility.Collapsed;
            if (adauga)
            {
                addButton.Visibility = Visibility.Visible;
                ProdusDataGrid.IsReadOnly = true;
            }
            else if (sterge)
            {
                deleteButton.Visibility = Visibility.Visible;
                ProdusDataGrid.IsReadOnly = true;
            }
            else if (modifica)
            {
                modifyButton.Visibility = Visibility.Visible;
            }
            else if (vizualizare)
            {
                ProdusDataGrid.IsReadOnly = true;
            }
            else
            {
                back_button.Visibility = Visibility.Collapsed;
                ok_button.Visibility = Visibility.Visible;
            }
        }

        public ProdusManager(bool adauga, bool sterge, bool modifica, bool vizualizare, Utilizatori loggedUser,Producatori producator)
        {
            this.LoggedUser = loggedUser;
            InitializeComponent();
            addButton.Visibility = Visibility.Collapsed;
            modifyButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
            ok_button.Visibility = Visibility.Collapsed;
            if (adauga)
            {
                addButton.Visibility = Visibility.Visible;
                ProdusDataGrid.IsReadOnly = true;
            }
            else if (sterge)
            {
                deleteButton.Visibility = Visibility.Visible;
                ProdusDataGrid.IsReadOnly = true;
            }
            else if (modifica)
            {
                modifyButton.Visibility = Visibility.Visible;
            }
            else if (vizualizare)
            {
                ProdusDataGrid.IsReadOnly = true;
            }
            else
            {
                back_button.Visibility = Visibility.Collapsed;
                ok_button.Visibility = Visibility.Visible;
            }
            (DataContext as ProdusVM).GetProductsForProducer(producator);
        }

        public ProdusManager(bool adauga, bool sterge, bool modifica, bool vizualizare, Utilizatori loggedUser,string categoryName)
        {
            this.LoggedUser = loggedUser;
            InitializeComponent();
            addButton.Visibility = Visibility.Collapsed;
            modifyButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
            ok_button.Visibility = Visibility.Collapsed;
            if (adauga)
            {
                addButton.Visibility = Visibility.Visible;
                ProdusDataGrid.IsReadOnly = true;
            }
            else if (sterge)
            {
                deleteButton.Visibility = Visibility.Visible;
                ProdusDataGrid.IsReadOnly = true;
            }
            else if (modifica)
            {
                modifyButton.Visibility = Visibility.Visible;
            }
            else if (vizualizare)
            {
                ProdusDataGrid.IsReadOnly = true;
            }
            else
            {
                back_button.Visibility = Visibility.Collapsed;
                ok_button.Visibility = Visibility.Visible;
            }
            (DataContext as ProdusVM).GetProductsForCategory(categoryName);
        }

        public ProdusManager(bool adauga, bool sterge, bool modifica, bool vizualizare, string name, Utilizatori loggedUser)
        {
            this.LoggedUser = loggedUser;
            InitializeComponent();
            addButton.Visibility = Visibility.Collapsed;
            modifyButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
            ok_button.Visibility = Visibility.Collapsed;
            if (adauga)
            {
                addButton.Visibility = Visibility.Visible;
                ProdusDataGrid.IsReadOnly = true;
            }
            else if (sterge)
            {
                deleteButton.Visibility = Visibility.Visible;
                ProdusDataGrid.IsReadOnly = true;
            }
            else if (modifica)
            {
                modifyButton.Visibility = Visibility.Visible;
            }
            else if (vizualizare)
            {
                ProdusDataGrid.IsReadOnly = true;
            }
            else
            {
                back_button.Visibility = Visibility.Collapsed;
                ok_button.Visibility = Visibility.Visible;
            }
            (DataContext as ProdusVM).GetProductsForName(name);
        }

        public ProdusManager(string barcode ,bool adauga, bool sterge, bool modifica, bool vizualizare, Utilizatori loggedUser)
        {
            this.LoggedUser = loggedUser;
            InitializeComponent();
            addButton.Visibility = Visibility.Collapsed;
            modifyButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
            ok_button.Visibility = Visibility.Collapsed;
            if (adauga)
            {
                addButton.Visibility = Visibility.Visible;
                ProdusDataGrid.IsReadOnly = true;
            }
            else if (sterge)
            {
                deleteButton.Visibility = Visibility.Visible;
                ProdusDataGrid.IsReadOnly = true;
            }
            else if (modifica)
            {
                modifyButton.Visibility = Visibility.Visible;
            }
            else if (vizualizare)
            {
                ProdusDataGrid.IsReadOnly = true;
            }
            else
            {
                back_button.Visibility = Visibility.Collapsed;
                ok_button.Visibility = Visibility.Visible;
            }
            (DataContext as ProdusVM).GetProductsForBarcode(barcode);
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ProdusVM).SelectedProduct = ProdusDataGrid.SelectedItem as Produse;
            (DataContext as ProdusVM).UpdateProduct();
            AdminMenu adminMenu = new AdminMenu(LoggedUser);
            adminMenu.Show();
            Close();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductAddDialog productAddDialog = new ProductAddDialog(LoggedUser);
            productAddDialog.ShowDialog();
            Close();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ProdusVM).SelectedProduct = ProdusDataGrid.SelectedItem as Produse;
            (DataContext as ProdusVM).DeleteProduct();
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

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void ProdusDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedProduct = ProdusDataGrid.SelectedItem as Produse;
        }
    }
}
