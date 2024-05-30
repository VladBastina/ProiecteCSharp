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
    /// Interaction logic for StockAddDialog.xaml
    /// </summary>
    public partial class StockAddDialog : Window
    {
        private Utilizatori loggedUser;

        public StockAddDialog(Utilizatori loggedUser)
        {
            this.loggedUser = loggedUser;
            InitializeComponent();
        }

        public string NumeProdus { get; private set; }
        public int Cantitate { get; private set; }
        public string UnitateMasura { get; private set; }
        public DateTime DataAprovizionarii { get; private set; }
        public DateTime DataExpirarii { get; private set; }
        public float PretVanzare { get; private set; }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            NumeProdus = NumeProdusTextBox.Text;
            Cantitate = int.Parse(CantitateTextBox.Text);
            UnitateMasura = UnitateMasuraTextBox.Text;
            DataAprovizionarii = DataAprovizionariiDatePicker.SelectedDate ?? DateTime.Now;
            DataExpirarii = DataExpirariiDatePicker.SelectedDate ?? DateTime.Now;
            PretVanzare = float.Parse(PretVanzareTextBox.Text);
            Stocuri stock = new Stocuri
            {
                Cantitate = Cantitate,
                UnitateMasura = UnitateMasura,
                DataAprovizionarii = DataAprovizionarii,
                DataExpirarii = DataExpirarii,
                PretAchizitie = PretVanzare
            };
            StocuriVM stockVM = new StocuriVM();
            stockVM.AddStock(stock, NumeProdus);
            DialogResult = true;
            AdminMenu adminMenu = new AdminMenu(loggedUser);
            adminMenu.Show();
            Close();
        }
    }
}
