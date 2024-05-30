using SuperMarket_Gestiune.Models;
using SuperMarket_Gestiune.ViewModels;
using System;
using System.Windows;

namespace SuperMarket_Gestiune.Views
{
    public partial class ProductAddDialog : Window
    {
        public string NumeProdus { get; private set; }
        public string CodBare { get; private set; }
        public string NumeCategorie { get; private set; }
        public string NumeProducator { get; private set; }
        public int Cantitate { get; private set; }
        public string UnitateMasura { get; private set; }
        public DateTime DataAprovizionarii { get; private set; }
        public DateTime DataExpirarii { get; private set; }
        public float PretVanzare { get; private set; }

        private Utilizatori LoggedUser;

        public ProductAddDialog(Utilizatori LoggedUser)
        {
            this.LoggedUser = LoggedUser;
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            NumeProdus = NumeProdusTextBox.Text;
            CodBare = CodBareTextBox.Text;
            NumeCategorie = NumeCategorieTextBox.Text;
            NumeProducator = NumeProducatorTextBox.Text;
            Cantitate = int.Parse(CantitateTextBox.Text);
            UnitateMasura = UnitateMasuraTextBox.Text;
            DataAprovizionarii = DataAprovizionariiDatePicker.SelectedDate ?? DateTime.Now;
            DataExpirarii = DataExpirariiDatePicker.SelectedDate ?? DateTime.Now;
            PretVanzare = float.Parse(PretVanzareTextBox.Text);
            Produse produse = new Produse
            {
                Nume = NumeProdus,
                CodBare = CodBare
            };
            Stocuri stock = new Stocuri
            { 
                Cantitate=Cantitate,
                UnitateMasura = UnitateMasura,
                DataAprovizionarii = DataAprovizionarii,
                DataExpirarii = DataExpirarii,
                PretAchizitie = PretVanzare
            };
            ProdusVM produsVM = new ProdusVM();
            produsVM.AddProduct(produse, stock, NumeCategorie, NumeProducator);
            DialogResult = true;
            AdminMenu adminMenu = new AdminMenu(LoggedUser);
            adminMenu.Show();
            Close();
        }
    }
}
