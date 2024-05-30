using Microsoft.IdentityModel.Tokens;
using SuperMarket_Gestiune.Models.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace SuperMarket_Gestiune.Models.BusinessLogicLayer
{
    internal class ProducatoriBBL
    {
       public ObservableCollection<Producatori> producatoriList;

       ProducatoriDAL producatoriDAL = new ProducatoriDAL();

        public ObservableCollection<Producatori> GetAll()
        {
            return producatoriDAL.GetAllProducatori();
        }

        public bool AddProducator(Producatori producatori)
        {
            if(producatori.Nume.IsNullOrEmpty())
            {
                MessageBox.Show("Producatorul nu are un nume");
                return false;
            }
            if(producatori.TaraOrigine.IsNullOrEmpty()) 
            {
                MessageBox.Show("Producatorul trebuie sa aiba o tara de origine");
                return false;
            }
            if(producatoriDAL.AddProducator(producatori)) 
            {
                return true;
            }
            return false;
        }
        
        public bool DeleteProducator(Producatori producatori)
        {
            if(producatoriDAL.DeleteProducator(producatori)) 
            {
                return true;
            }
            return false;
        }

        public bool UpdateProducator(Producatori producatori)
        {
            if( producatori.Nume.IsNullOrEmpty())
            {
                MessageBox.Show("Producatorul nu are un nume");
                return false;
            }
            if(producatori.TaraOrigine.IsNullOrEmpty())
            {
                MessageBox.Show("Producatorul trebuie sa aiba o tara de origine");
                return false;
            }
            if(producatoriDAL.UpdateUser(producatori)) 
            {
                return true;
            }
            return false;
        }

    }
}
