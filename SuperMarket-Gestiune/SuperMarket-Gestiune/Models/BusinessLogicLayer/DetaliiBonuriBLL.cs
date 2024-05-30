using SuperMarket_Gestiune.Models.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_Gestiune.Models.BusinessLogicLayer
{
    internal class DetaliiBonuriBLL
    {
        public ObservableCollection<DetaliiBonuri> ProductsOnBon;

        private DetaliiBonuriDAL detaliiBonuriDAL = new DetaliiBonuriDAL();

        public void GetAll(Bonuri bon)
        {
            ProductsOnBon.Clear();
            foreach (var item in detaliiBonuriDAL.GetDetailsForBon(bon))
            {
                ProductsOnBon.Add(item);
            }
        }

    }
}
