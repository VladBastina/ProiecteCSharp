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
    internal class StocuriBBL
    {
        public ObservableCollection<Stocuri> stocuri;

        StocuriDAL stocuriDAL = new StocuriDAL();

        public ObservableCollection<Stocuri> GetAll()
        {
            return stocuriDAL.GetAllStocks();
        }

        public bool AddStock(Stocuri stock,string numeProdus)
        {
            if(stock.Cantitate==0)
            {
                MessageBox.Show("Stocul trebuie sa aiba o cantitate");
                return false;
            }
            if(stock.UnitateMasura.IsNullOrEmpty())
            {
                MessageBox.Show("Stocul trebuie sa aiba o unitate de masura");
                return false;
            }
            if(stock.PretAchizitie==0)
            {
                MessageBox.Show("Stocul trebuie sa aiba un pret de achizitie");
                return false;
            }
            if(stocuriDAL.AdaugaStock(stock, numeProdus)) 
            {
                return true;
            }
            return false;
        }

        public bool DeleteStock(Stocuri stock)
        {
            if(stocuriDAL.DeleteStock(stock))
            {
                return true;
            }
            return false;
        }

        public bool ModifyPriceStock(Stocuri stock)
        {
            if(stocuriDAL.UpdatePriceForStock(stock))
            {
                return true;
            }
            return false;
        }
    }
}
