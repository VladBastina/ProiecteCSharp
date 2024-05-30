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
    /// Interaction logic for UsersAddDialog.xaml
    /// </summary>
    public partial class UsersAddDialog : Window
    {
        public string NumeUtilizator { get; private set; }
        public string Parola { get; private set; }
        public string TipUtilizator { get; private set; }

        private Utilizatori loggedUser;

        public UsersAddDialog(Utilizatori LoggedUser)
        {
            this.loggedUser = LoggedUser;
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            NumeUtilizator = NumeUtilizatorTextBox.Text;
            Parola = ParolaTextBox.Text;
            TipUtilizator = TipUtilizatorTextBox.Text;
            DialogResult = true;
            UtilizatoriVM utilizatoriVM = new UtilizatoriVM();
            Utilizatori utilizatori = new Utilizatori { NumeUtilizator = this.NumeUtilizator, Parola = this.Parola, TipUtilizator = this.TipUtilizator };
            utilizatoriVM.AddUser(utilizatori);
            Close();
            AdminMenu adminMenu = new AdminMenu(loggedUser);
            adminMenu.Show();
        }
    }
}
