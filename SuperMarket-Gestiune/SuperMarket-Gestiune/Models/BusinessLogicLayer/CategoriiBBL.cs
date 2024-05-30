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
    internal class CategoriiBBL
    {
        public ObservableCollection<Categorii> categoryList;

        private CategoriiDAL categoriiDAL = new CategoriiDAL();

        public ObservableCollection<Categorii> GetAll()
        {
            return categoriiDAL.GetAllCategories();
        }

        public bool AddCategory( Categorii categorii)
        {
            if(categorii.Nume.IsNullOrEmpty())
            {
                MessageBox.Show("Categoria trebuie sa aiba un nume");
                return false;
            }
            else if (categoriiDAL.AddCategory(categorii))
            {
                return true;
            }
            return false;
        }

        public bool DeleteCategory( Categorii categorii) 
        {
            if (categorii != null)
            {
                if (categorii.Id == 0)
                {
                    MessageBox.Show("Categoria selectata nu este valida");
                    return false;
                }
                else if (categoriiDAL.DeleteCategory(categorii))
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdateCategory( Categorii categorii) 
        {
            if (categorii != null)
            {
                if (categorii.Nume.IsNullOrEmpty())
                {
                    MessageBox.Show("Categoria trebuie sa aiba un nume");
                    return false;
                }
                else if (categoriiDAL.UpdateCategory(categorii))
                {
                    return true;
                }
            }
            return false;
        }

        public float GetSumPerCategory( Categorii categorii)
        {
            float sum = categoriiDAL.SumaPreturilorPerCategorie(categorii);
            return sum;
        }
    }
}
