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

namespace DexExplicativ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new UserSerialize();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as UserSerialize).VerifyLogin(usernameTextBox.Text, passwordTextBox.Password) == true)
            {
                MessageBox.Show("User-ul a fost logat");
                Window centralWindow = new CentralWindow();
                centralWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Credentialele sunt gresite");
            }
        }
    }
}