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
    /// Interaction logic for BonuriManager.xaml
    /// </summary>
    public partial class BonuriManager : Window
    {
        private Utilizatori LoggedUser;
        public BonuriManager(Utilizatori LoggedUser)
        {
            this.LoggedUser = LoggedUser;
            InitializeComponent();
            BonuriDataGrid.IsReadOnly = true;
        }


        public BonuriManager(Utilizatori LoggedUser,DateTime date)
        {
            this.LoggedUser = LoggedUser;
            InitializeComponent();
            BonuriDataGrid.IsReadOnly = true;
            (DataContext as BonuriVM).GetHighestBon(date);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu(LoggedUser);
            adminMenu.Show();
            Close();
        }

        private void BonuriDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReceiptManager receiptManager = new ReceiptManager(BonuriDataGrid.SelectedItem as Bonuri , LoggedUser);
            receiptManager.Show();
            Close();
        }
    }
}
