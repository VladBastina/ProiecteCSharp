using SuperMarket_Gestiune.Models;
using SuperMarket_Gestiune.Models.BusinessLogicLayer;
using SuperMarket_Gestiune.Models.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperMarket_Gestiune.ViewModels
{
    internal class StocuriVM
    {
        StocuriBBL stocuriBBL=new StocuriBBL();

        public Stocuri SelectedStock {  get; set; }

        public ObservableCollection<Stocuri> stocuri
        {
            get => stocuriBBL.stocuri;
            set => stocuriBBL.stocuri = value;
        }

        public StocuriVM()
        {
            stocuri = stocuriBBL.GetAll();
        }

        public void AddStock(Stocuri st, string NumeProdus)
        {
            if(stocuriBBL.AddStock(st, NumeProdus))
            {
                MessageBox.Show("Stocul a fost adaugat cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la adaugarea stocului");
            }
        }

        public void DeleteStock()
        {
            if (stocuriBBL.DeleteStock(SelectedStock))
            {
                MessageBox.Show("Stocul a fost sters cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la stergerea stocului");
            }
        }

        public void UpdatePrice()
        {
            if (stocuriBBL.ModifyPriceStock(SelectedStock))
            {
                MessageBox.Show("Stocul a fost actualizat cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la actualizarea stocului");
            }
        }
    }
}
