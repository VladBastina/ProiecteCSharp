using Microsoft.IdentityModel.Tokens;
using SuperMarket_Gestiune.Models.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperMarket_Gestiune.Models.BusinessLogicLayer
{
    internal class ProdusBBL
    {
        public ObservableCollection<Produse> produse;
        ProdusDAL produsDAL = new ProdusDAL();

        public ObservableCollection<Produse> GetAll()
        {
            return produsDAL.GetAllProducts();
        }

        public bool AddProductWithStock(Produse produse,Stocuri stock,string numeCategorie , string numeProducator)
        {
            if(produse.Nume.IsNullOrEmpty())
            {
                MessageBox.Show("Produsul trebuie sa aiba un nume");
                return false;
            }
            if(produse.CodBare.IsNullOrEmpty())
            {
                MessageBox.Show("Produsul trebuie sa aiba un cod de bare");
                return false;
            }
            if(numeCategorie.IsNullOrEmpty()) 
            {
                MessageBox.Show("Trebuie introdusa o categorie");
                return false;
            }
            if(numeProducator.IsNullOrEmpty()) 
            {
                MessageBox.Show("Trebuie introdus numele producatorului");
                return false;
            }
            if(stock.Cantitate == 0)
            {
                MessageBox.Show("Cantitatea trebuie sa existe");
                return false;
            }
            if(stock.UnitateMasura.IsNullOrEmpty())
            {
                MessageBox.Show("Trebuie sa existe o unitate de masura");
                return false;
            }
            if(stock.PretAchizitie == 0)
            {
                MessageBox.Show("Trebuie sa existe un pret de vanzare");
            }
            if(produsDAL.AddProductWithStock(produse,stock,numeCategorie,numeProducator))
            {
                return true;
            }
            return false;
        }

        public bool DeleteProduct(Produse produse) 
        {
            if(produsDAL.DeleteProduct(produse))
            {
                return true;
            }
            return false;
        }

        public bool UpdatePrroduct(Produse produse)
        {
            if(produsDAL.updateProduct(produse))
            {
                return true;
            }
            return false;
        }

        public bool UpdateProduct(Produse produse)
        {
            if(produse.Nume.IsNullOrEmpty())
            {
                MessageBox.Show("Produsul trebuie sa aiba un nume");
                return false;
            }
            if(produse.CodBare.IsNullOrEmpty())
            {
                MessageBox.Show("produsul trebuie sa aiba un cod de bare");
                return false;
            }
            if(produsDAL.updateProduct(produse))
            {
                return true;
            }
            return false;
        }

        public void GetProductsForProducers(Producatori producatori)
        {
            produse.Clear();
            foreach(var product in produsDAL.GetProductsForProducers(producatori))
            {
                produse.Add(product);
            }
        }

        public void GetProductsForCategory(string categoryName)
        {
            produse.Clear();
            foreach(var product in  produsDAL.GetAllForCategory(categoryName))
            {
                produse.Add(product);
            }
        }

        public void GetProductsForName(string name)
        {
            produse.Clear();
            foreach(var product in produsDAL.GetProductsForName(name))
            {
                produse.Add(product);
            }
        }

        public void GetProductsForBarcode(string barcode)
        {
            produse.Clear();
            foreach(var product in produsDAL.GetProductsForBarCode(barcode))
            {
                produse.Add(product);
            }
        }

    }
}
