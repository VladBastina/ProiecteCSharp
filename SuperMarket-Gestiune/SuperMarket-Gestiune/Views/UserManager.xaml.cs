using Microsoft.VisualBasic.ApplicationServices;
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
using System.Windows.Forms.Design;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SuperMarket_Gestiune.Views
{
    /// <summary>
    /// Interaction logic for UserManager.xaml
    /// </summary>
    public partial class UserManager : Window
    {
        private Utilizatori LoggedUser;
        public UserManager(bool adauga , bool sterge , bool modifica , bool vizualizare,Utilizatori LoggedUser)
        {
            this.LoggedUser = LoggedUser;
            InitializeComponent();
            addButton.Visibility = Visibility.Collapsed;
            modifyButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
            if (adauga)
            {
                addButton.Visibility = Visibility.Visible;
                UsersDataGrid.IsReadOnly = true;
            }
            else if (sterge) 
            {
                deleteButton.Visibility = Visibility.Visible;
                UsersDataGrid.IsReadOnly = true;
            }
            else if (modifica)
            {
                modifyButton.Visibility = Visibility.Visible;
            }
            else if (vizualizare)
            {
                UsersDataGrid.IsReadOnly = true;
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            UsersAddDialog usersAddDialog = new UsersAddDialog(LoggedUser);
            usersAddDialog.ShowDialog();
            Close();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as UtilizatoriVM).SelectedUser = UsersDataGrid.SelectedItem as Utilizatori;
            (DataContext as UtilizatoriVM).UpdateUser();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as UtilizatoriVM).SelectedUser = UsersDataGrid.SelectedItem as Utilizatori;
            (DataContext as UtilizatoriVM).RemoveUser();
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

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as UtilizatoriVM).SelectedUser = UsersDataGrid.SelectedItem as Utilizatori;
            DatePickerWindow datePickerWindow = new DatePickerWindow();
            if (datePickerWindow.ShowDialog() == true)
            {
                DateTime? selectedDate = datePickerWindow.SelectedDate;
                DateAndSumManager dateAndSumManager = new DateAndSumManager(LoggedUser, (DataContext as UtilizatoriVM).SelectedUser, selectedDate.Value);
                dateAndSumManager.Show();
                Close();
            }
        }
    }


}
