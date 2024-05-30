using SuperMarket_Gestiune.Models;
using SuperMarket_Gestiune.Models.BusinessLogicLayer;
using SuperMarket_Gestiune.Models.Data_Access_Layer;
using SuperMarket_Gestiune.Models.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperMarket_Gestiune.ViewModels
{
    internal class ProdusVM : BasePropertyChanged
    {

        ProdusBBL produsBBL = new ProdusBBL();

        public Produse SelectedProduct { get; set; }

        public ObservableCollection<Produse> produses
        {
            get
            {
                return produsBBL.produse;
            }
            
            set
            {
                produsBBL.produse = value;
                NotifyPropertyChanged(nameof(produses));
            }
        }

        public ProdusVM()
        {
            produses = produsBBL.GetAll();
        }


        public void AddProduct(Produse produse , Stocuri stock , string numeCategorie , string NumeProducator)
        {
            if(produsBBL.AddProductWithStock(produse, stock , numeCategorie , NumeProducator)) 
            {
                MessageBox.Show("Produsul a fost  adaugat cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la adaugarea produsului");
            }
        }

        public void DeleteProduct()
        {
            if(produsBBL.DeleteProduct(SelectedProduct))
            {
                MessageBox.Show("Produsul a fost sters cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la stergerea produsului");
            }
        }

        public void UpdateProduct()
        {
            if (produsBBL.UpdateProduct(SelectedProduct))
            {
                MessageBox.Show("Produsul a fost modificat cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la modificarea produsului");
            }
        }

        public void GetProductsForProducer(Producatori producatori)
        {
            produsBBL.GetProductsForProducers(producatori);
        }

        public void GetProductsForCategory(string categoryName)
        {
            produsBBL.GetProductsForCategory(categoryName);
        }

        public void GetProductsForName(string name)
        {
            produsBBL.GetProductsForName(name);
        }

        public void GetProductsForBarcode(string barcode)
        {
            produsBBL.GetProductsForBarcode(barcode);
        }
    }
}
