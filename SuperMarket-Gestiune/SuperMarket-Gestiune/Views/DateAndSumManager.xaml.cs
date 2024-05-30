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
    /// Interaction logic for DateAndSumManager.xaml
    /// </summary>
    public partial class DateAndSumManager : Window
    {
        private Utilizatori LoggedUser;
        public DateAndSumManager(Utilizatori LoggedUser,Utilizatori user , DateTime date)
        {
            this.LoggedUser = LoggedUser;
            InitializeComponent();
            (DataContext as BonuriVM).GetDateAndSums(user, date);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu(LoggedUser);
            adminMenu.Show();
            Close();
        }
    }
}
