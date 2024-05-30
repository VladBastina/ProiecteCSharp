using Microsoft.IdentityModel.Tokens;
using SuperMarket_Gestiune.Models;
using SuperMarket_Gestiune.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace SuperMarket_Gestiune.Views
{
    /// <summary>
    /// Interaction logic for CasierMenu.xaml
    /// </summary>
    public partial class CasierMenu : Window
    {
        private Utilizatori LoggedUser;
        public CasierMenu(Utilizatori LoggedUser)
        {
            this.LoggedUser = LoggedUser;
            InitializeComponent();
            (DataContext as BonuriVM).AddBon(LoggedUser);
        }

        private void SearchProduct_Click(object sender, RoutedEventArgs e)
        {
            ProdusManager produsManager;
            if (!ProductNameSearch.Text.IsNullOrEmpty())
            {
                produsManager = new ProdusManager(false, false, false, false, ProductNameSearch.Text, LoggedUser);
            }
            else if(!BarcodeSearch.Text.IsNullOrEmpty())
            {
                produsManager = new ProdusManager(BarcodeSearch.Text,false, false, false, false, LoggedUser);
            }
            else if (!CategorySearch.Text.IsNullOrEmpty())
            {
                produsManager = new ProdusManager(false, false, false, false, LoggedUser, CategorySearch.Text);
            }
            else if (ExpirationDateSearch.SelectedDate.HasValue)
            {
                produsManager = new ProdusManager(false, false, false, false, LoggedUser);
            }
            else if (!ManufacturerSearch.Text.IsNullOrEmpty())
            {
                produsManager = new ProdusManager(false, false, false, false, LoggedUser, new Producatori { Nume = ManufacturerSearch.Text });
            }
            else
            {
                produsManager = new ProdusManager(false, false, false, false, LoggedUser);
            }
            if (produsManager.ShowDialog() == true)
            {
                Produse SelectedProduct = produsManager.SelectedProduct;
                string userInput = Microsoft.VisualBasic.Interaction.InputBox("Introduceti cantitatea", "Cantitate", "");
                int cantitate = int.Parse(userInput);
                (DataContext as BonuriVM).AddProductOnBon(SelectedProduct,cantitate);
            }
            ProductNameSearch.Clear();
            CategorySearch.Clear();
            ManufacturerSearch.Clear();
            BarcodeSearch.Clear();
            ExpirationDateSearch.SelectedDate = null;
        }

        private void ConfirmReceipt_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as BonuriVM).SubmitBon();
            CasierMenu casierMenu = new CasierMenu(LoggedUser);
            casierMenu.Show();
            Close();
        }

        private void ResetReceipt_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as BonuriVM).Reset();
        }


    }
}

