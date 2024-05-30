using SuperMarket_Gestiune.Models;
using SuperMarket_Gestiune.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket_Gestiune.ViewModels
{
    internal class DetaliiBonuriVM
    {
        public ObservableCollection<DetaliiBonuri> ProductsOnBon
        {
            get => detaliiBonuriBLL.ProductsOnBon;
            set => detaliiBonuriBLL.ProductsOnBon = value;
        }

        private DetaliiBonuriBLL detaliiBonuriBLL = new DetaliiBonuriBLL();

        public DetaliiBonuriVM()
        {
            ProductsOnBon = new ObservableCollection<DetaliiBonuri>();
        }

        public void GetAll(Bonuri bon)
        {
            detaliiBonuriBLL.GetAll(bon);
        }
    }
}
