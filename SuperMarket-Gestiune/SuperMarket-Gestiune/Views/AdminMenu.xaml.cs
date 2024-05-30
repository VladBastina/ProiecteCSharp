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
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        private Utilizatori LoggedUser;

        public AdminMenu(Utilizatori LoggedUser)
        {
            this.LoggedUser = LoggedUser;
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            UserManager userManager = new UserManager(true,false,false,false,LoggedUser);
            userManager.Show();
            Close();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            UserManager userManager = new UserManager(false, false, true, false,LoggedUser);
            userManager.Show();
            Close();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            UserManager userManager = new UserManager(false, true, false, false,LoggedUser);
            userManager.Show();
            Close();
        }

        private void ViewUsers_Click(object sender, RoutedEventArgs e)
        {
            UserManager userManager = new UserManager(false, false, false, true,LoggedUser);
            userManager.Show();
            Close();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryManager categoryManager = new CategoryManager(true, false, false, false,LoggedUser);
            categoryManager.Show();
            Close();
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryManager categoryManager = new CategoryManager(false, false, true, false,LoggedUser);
            categoryManager.Show();
            Close();
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryManager categoryManager = new CategoryManager(false, true, false, false,LoggedUser);
            categoryManager.Show();
            Close();
        }

        private void ViewCategories_Click(object sender, RoutedEventArgs e)
        {
            CategoryManager categoryManager = new CategoryManager(false, false, false, true,LoggedUser);
            categoryManager.Show();
            Close();
        }

        private void AddManufacturer_Click(object sender, RoutedEventArgs e)
        {
            ProducatorManager producatorManager = new ProducatorManager(true,false, false, false,LoggedUser);
            producatorManager.Show();
            Close();
        }

        private void EditManufacturer_Click(object sender, RoutedEventArgs e)
        {
            ProducatorManager producatorManager = new ProducatorManager(false, false, true, false,LoggedUser);
            producatorManager.Show();
            Close();
        }

        private void DeleteManufacturer_Click(object sender, RoutedEventArgs e)
        {
            ProducatorManager producatorManager = new ProducatorManager(false, true, false, false,LoggedUser);
            producatorManager.Show();
            Close();
        }

        private void ViewManufacturers_Click(object sender, RoutedEventArgs e)
        {
            ProducatorManager producatorManager = new ProducatorManager(false, false, false, true,LoggedUser);
            producatorManager.Show();
            Close();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProdusManager produsManager = new ProdusManager(true, false, false, false,LoggedUser);
            produsManager.Show();
            Close();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            ProdusManager produsManager = new ProdusManager(false, false, true, false,LoggedUser);
            produsManager.Show();
            Close();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            ProdusManager produsManager = new ProdusManager(false, true, false, false,LoggedUser);
            produsManager.Show();
            Close();
        }

        private void ViewProducts_Click(object sender, RoutedEventArgs e)
        {
            ProdusManager produsManager = new ProdusManager(false, false, false, true,LoggedUser);
            produsManager.Show();
            Close();
        }

        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            StockManager stockManager = new StockManager(true, false, false, false,LoggedUser);
            stockManager.Show();
            Close();
        }

        private void EditStock_Click(object sender, RoutedEventArgs e)
        {
            StockManager stockManager = new StockManager(false, false, true, false,LoggedUser);
            stockManager.Show();
            Close();
        }

        private void DeleteStock_Click(object sender, RoutedEventArgs e)
        {
            StockManager stockManager = new StockManager(false, true, false, false,LoggedUser);
            stockManager.Show();
            Close();
        }

        private void ViewStocks_Click(object sender, RoutedEventArgs e)
        {
            StockManager stockManager = new StockManager(false, false, false, true,LoggedUser);
            stockManager.Show();
            Close();
        }

        private void LargestReceipt_Click(object sender, RoutedEventArgs e)
        {
            DatePickerWindow datePickerWindow = new DatePickerWindow();
            if (datePickerWindow.ShowDialog() == true)
            {
                DateTime? selectedDate = datePickerWindow.SelectedDate;
                BonuriManager bonuriManager = new BonuriManager(LoggedUser, selectedDate.Value);
                bonuriManager.Show();
                Close();
            }
        }

        private void ViewReceipts_Click(object sender, RoutedEventArgs e)
        {
            BonuriManager bonuriManager = new BonuriManager(LoggedUser);
            bonuriManager.Show();
            Close();
        }
    }
}
