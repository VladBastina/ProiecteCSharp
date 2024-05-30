using SuperMarket_Gestiune.Models.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_Gestiune.Models.BusinessLogicLayer
{
    internal class BonuriBLL
    {
        public ObservableCollection<Bonuri> bonuriList;
        public ObservableCollection<DateAndSum> dateAndSumList;
        public Bonuri CurrentBon;
        public ObservableCollection<DetaliiBonuri> ProductsOnCurrentBon;

        public float SumaIncasata;

        BonuriDAL bonuriDAL=new BonuriDAL();


        public ObservableCollection<Bonuri> GetAll()
        {
           return bonuriDAL.GetAllBonuri();
        }

        public void AddBon(Utilizatori utilizatori)
        {
            CurrentBon = bonuriDAL.AddBon(utilizatori);
        }

        public void GetDateAndSum(Utilizatori utilizatori,DateTime date)
        {
            dateAndSumList.Clear();
            foreach(var dateandsum in bonuriDAL.GetSumInDates(utilizatori,date))
            {
                dateAndSumList.Add(dateandsum);
            }
        }

        public void GetHighestBon(DateTime date)
        {
            bonuriList.Clear();
            bonuriList.Add(bonuriDAL.GetHighestBon(date));
        }

        public void AddProductOnBon(Produse produse,int cantitate) 
        {
            bool exists = false;
            foreach(var product in ProductsOnCurrentBon)
            {

                if(product.ProdusId == produse.Id)
                {
                    ProdusDAL produsDAL = new ProdusDAL();
                    float pretVanzare = produsDAL.GetPriceForProduct(produse);
                    exists = true;
                    product.Cantitate += cantitate;
                    product.Subtotal = (float)product.Cantitate * pretVanzare;
                    SumaIncasata += product.Subtotal;
                    break;
                }
            }
            if (exists==false)
            {
                ProdusDAL produsDAL = new ProdusDAL();
                float pretVanzare = produsDAL.GetPriceForProduct(produse);
                DetaliiBonuri detaliiBonuri = new DetaliiBonuri
                {
                    BonId = CurrentBon.Id,
                    ProdusId = produse.Id,
                    Cantitate = cantitate,
                    Subtotal = (cantitate * pretVanzare),
                };
                ProductsOnCurrentBon.Add(detaliiBonuri);
                SumaIncasata += detaliiBonuri.Subtotal;
            }
        }

        public void AddProductsInDataBase()
        {
            foreach(var product in ProductsOnCurrentBon)
            {
                bonuriDAL.AddProductOnBon(product);
            }
        }

        public void ResetReceipt()
        {
            ProductsOnCurrentBon.Clear();
            SumaIncasata = 0.0f;
        }

    }
}
