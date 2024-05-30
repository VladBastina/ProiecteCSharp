using Microsoft.Identity.Client.Extensions.Msal;
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
    /// Interaction logic for CategoryManager.xaml
    /// </summary>
    public partial class CategoryManager : Window
    {
        private Utilizatori LoggedUser;
        private bool vizualizare;
        public CategoryManager(bool adauga, bool sterge, bool modifica, bool vizualizare,Utilizatori LoggedUser)
        {
            this.LoggedUser = LoggedUser;
            InitializeComponent();
            addButton.Visibility = Visibility.Collapsed;
            modifyButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
            if (adauga)
            {
                addButton.Visibility = Visibility.Visible;
                CategoryDataGrid.IsReadOnly = true;
            }
            else if (sterge)
            {
                deleteButton.Visibility = Visibility.Visible;
                CategoryDataGrid.IsReadOnly = true;
            }
            else if (modifica)
            {
                modifyButton.Visibility = Visibility.Visible;
            }
            else if (vizualizare)
            {
                CategoryDataGrid.IsReadOnly = true;
            }
            this.vizualizare = vizualizare;
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CategoriiVM).SelectedCategory = CategoryDataGrid.SelectedItem as Categorii;
            (DataContext as CategoriiVM).UpdateCategory();
            AdminMenu adminMenu = new AdminMenu(LoggedUser);
            adminMenu.Show();
            Close();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            string userInput = Microsoft.VisualBasic.Interaction.InputBox("Introduceti numele categoriei pe care vreti sa o introduceti", "Category Name", "");
            if (!userInput.IsNullOrEmpty())
            {
                Categorii categorii = new Categorii { Nume = userInput };
                (DataContext as CategoriiVM).AddCategory(categorii);
                AdminMenu adminMenu = new AdminMenu(LoggedUser);
                adminMenu.Show();
                Close();
            }
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CategoriiVM).SelectedCategory = CategoryDataGrid.SelectedItem as Categorii;
            (DataContext as CategoriiVM).RemoveCategory();
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

        private void CategoryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(vizualizare)
            {
                (DataContext as CategoriiVM).SelectedCategory = CategoryDataGrid.SelectedItem as Categorii;
                (DataContext as CategoriiVM).GetSumPerCategory();
            }
        }
    }
}
