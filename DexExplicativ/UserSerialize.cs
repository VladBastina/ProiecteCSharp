using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DexExplicativ
{
    class UserSerialize
    {
        public ObservableCollection<User> Users { get; set; }

        public UserSerialize() 
        {
            Users = new ObservableCollection<User>();
            User user1 = new User("Vlad", "parola");
            Users.Add(user1);
            User user2 = new User("Cristi", "parola2");
            Users.Add(user2);
        }

        public bool VerifyLogin(string username, string password)
        {
            foreach (var user in Users) 
            {
                if (user.Username == username && user.Password == password)
                    return true;
            }
            return false;
        }
    }

}
