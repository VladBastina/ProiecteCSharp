using SuperMarket_Gestiune.Models;
using SuperMarket_Gestiune.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperMarket_Gestiune.ViewModels
{
    public class UtilizatoriVM
    {
        UtilizatoriBLL UtilizatoriBLL = new UtilizatoriBLL();
        public Utilizatori LoggedUser { get; set; }

        public Utilizatori SelectedUser { get; set; }

        public UtilizatoriVM()
        {
            users = UtilizatoriBLL.GetAllUSers();
        }

        public ObservableCollection<Utilizatori> users
        {
            get => UtilizatoriBLL.UsersList;
            set => UtilizatoriBLL.UsersList = value;
        }

        public bool VerifyLogin(string name , string parola)
        {
            foreach (var user in users) 
            {
                if(user.NumeUtilizator == name && user.Parola == parola)
                {
                    LoggedUser = user;
                    return true;
                }
            }
            return false;
        }

        public void UpdateUser()
        {
            if(UtilizatoriBLL.UpdateUser(SelectedUser))
            {
                MessageBox.Show("User-ul a fost actualizat cu succes");
            }
            else
            {
                MessageBox.Show($"S-a produs o eroare la actualizarea user-ului {SelectedUser.NumeUtilizator}");
            }
        }

        public void AddUser(Utilizatori user)
        {
            if(UtilizatoriBLL.AddUser(user))
            {
                MessageBox.Show("Utilizatorul a fost adaugat cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la adaugarea utilizatorului");
            }
        }

        public void RemoveUser() 
        {
            if(UtilizatoriBLL.DeleteUser(SelectedUser))
            {
                MessageBox.Show("Utilizatorul a fost sters cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la stergerea utilizatorului");
            }

        }

    }
}
