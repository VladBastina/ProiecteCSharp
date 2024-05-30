using SuperMarket_Gestiune.ViewModels;
using SuperMarket_Gestiune.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperMarket_Gestiune
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UtilizatoriVM utilizatoriVM;

        public MainWindow()
        {
            utilizatoriVM = new UtilizatoriVM();    
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            if(utilizatoriVM.VerifyLogin(username, password)) 
            {
                MessageBox.Show("Logarea s-a realizat cu succes");
                if(utilizatoriVM.LoggedUser.TipUtilizator == "Administrator")
                {
                    AdminMenu adminMenu = new AdminMenu(utilizatoriVM.LoggedUser);
                    adminMenu.Show();
                    Close();
                }
                else if (utilizatoriVM.LoggedUser.TipUtilizator == "Casier")
                    {
                        CasierMenu casierMenu = new CasierMenu(utilizatoriVM.LoggedUser);
                        casierMenu.Show();
                        Close();
                    }
            }
            else
            {
                MessageBox.Show("Credentialele sunt gresite");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.Clear();
            PasswordBox.Clear();
        }
    }
}