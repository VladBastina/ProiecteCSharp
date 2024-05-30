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
    internal class UtilizatoriBLL
    {
        public ObservableCollection<Utilizatori> UsersList;

        public UtilizatoriDAL userDal = new UtilizatoriDAL();

        public ObservableCollection<Utilizatori> GetAllUSers()
        {
            return userDal.GetAllUsers();
        }

        public bool AddUser (Utilizatori user)
        {
            if(user.NumeUtilizator.IsNullOrEmpty())
            {
                MessageBox.Show("Trebuie sa introduceti un nume");
                return false;
            }
            if(user.Parola.IsNullOrEmpty())
            {
                MessageBox.Show("Trebuie sa introduceti o parola");
                return false;
            }
            if (userDal.AddUser(user))
            {
                return true;
            }
            return false;
        }

        public bool DeleteUser(Utilizatori user)
        {
            if (user != null)
            {
                if (user.NumeUtilizator.IsNullOrEmpty())
                {
                    MessageBox.Show("Trebuie sa introduceti un nume");
                    return false;
                }
                if (user.Parola.IsNullOrEmpty())
                {
                    MessageBox.Show("Trebuie sa introduceti o parola");
                    return false;
                }
                if (user.Id == 0)
                {
                    MessageBox.Show("Utilizatorul nu are un id");
                    return false;
                }
                if (userDal.DeleteUser(user))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool UpdateUser(Utilizatori user)
        {
            if (user.NumeUtilizator.IsNullOrEmpty())
            {
                MessageBox.Show("Trebuie sa introduceti un nume");
                return false;
            }
            if (user.Parola.IsNullOrEmpty())
            {
                MessageBox.Show("Trebuie sa introduceti o parola");
                return false;
            }
            if(user.Id==0)
            {
                MessageBox.Show("Utilizatorul nu are un id");
                return false;
            }
            if (userDal.UpdateUser(user))
            {
                return true;
            }
            return false;
        }
    }
}
