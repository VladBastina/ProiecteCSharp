using SuperMarket_Gestiune.Models;
using SuperMarket_Gestiune.Models.BusinessLogicLayer;
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
    internal class BonuriVM : BasePropertyChanged
    {
        public Bonuri SelectedBon {  get; set; }

        BonuriBLL bonuriBLL = new BonuriBLL();
        public ObservableCollection<Bonuri> bonuri
        {
            get => bonuriBLL.bonuriList;
            set => bonuriBLL.bonuriList = value;
        }

        public ObservableCollection<DateAndSum> dateAndSums
        {
            get
            {
                return bonuriBLL.dateAndSumList;
            }
            set
            {
                bonuriBLL.dateAndSumList = value;
                NotifyPropertyChanged(nameof(dateAndSums));
            }
        }

        public ObservableCollection<DetaliiBonuri> ProductsOnCurrentBon
        {
            get
            {
                return bonuriBLL.ProductsOnCurrentBon;
            }
            set
            {
                bonuriBLL.ProductsOnCurrentBon = value;
                NotifyPropertyChanged(nameof(ProductsOnCurrentBon));
            }
        }

        public float SumaIncasata
        {
            get
            {
                return bonuriBLL.SumaIncasata;
            }
            set
            {
                bonuriBLL.SumaIncasata = value;
                NotifyPropertyChanged(nameof(SumaIncasata));
            }
        }

        public BonuriVM() 
        {
            bonuri = bonuriBLL.GetAll();
            dateAndSums = new ObservableCollection<DateAndSum>();
            ProductsOnCurrentBon = new ObservableCollection<DetaliiBonuri>();
            SumaIncasata = 0.00f;
        }

        public void AddBon(Utilizatori utilizatori)
        {
            bonuriBLL.AddBon(utilizatori);
        }

        public void GetDateAndSums(Utilizatori utilizatori,DateTime date)
        {
            bonuriBLL.GetDateAndSum(utilizatori,date);
        }

        public void GetHighestBon(DateTime date)
        {
            bonuriBLL.GetHighestBon(date);
        }

        public void AddProductOnBon(Produse produs,int cantitate)
        {
            bonuriBLL.AddProductOnBon(produs,cantitate);
            SumaIncasata = bonuriBLL.SumaIncasata;
        }

        public void SubmitBon()
        {
            bonuriBLL.AddProductsInDataBase();
            MessageBox.Show("Bonul a fost emis cu succes");
        }

        public void Reset()
        {
            bonuriBLL.ResetReceipt();
        }
    }
}
