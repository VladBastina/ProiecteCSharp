using SuperMarket_Gestiune.Models.BusinessLogicLayer;
using SuperMarket_Gestiune.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperMarket_Gestiune.ViewModels
{
    internal class CategoriiVM
    {
        CategoriiBBL categoriiBBL=new CategoriiBBL();

        public Categorii SelectedCategory { get; set; }

        public ObservableCollection<Categorii> categories
        {
            get => categoriiBBL.categoryList;
            set => categoriiBBL.categoryList = value;
        }

        public CategoriiVM()
        {
            categories = categoriiBBL.GetAll();
        }

        public void AddCategory(Categorii categorii)
        {
            if (categoriiBBL.AddCategory(categorii))
            {
                MessageBox.Show("Categoria a fost adaugata cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la adaugarea categoriei");
            }
        }

        public void RemoveCategory() 
        {
            if(categoriiBBL.DeleteCategory(SelectedCategory)) 
            {
                MessageBox.Show("Categoria a fost stearsa cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la stergerea categoriei");
            }
        }

        public void UpdateCategory()
        {
            if (categoriiBBL.UpdateCategory(SelectedCategory))
            {
                MessageBox.Show("Categoria a fost actualizata cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la actualizarea categoriei");
            }
        }

        public void GetSumPerCategory()
        {
            MessageBox.Show($"Suma tuturor produselor din categorie {SelectedCategory.Nume} este {categoriiBBL.GetSumPerCategory(SelectedCategory)}. ");
        }
    }
}
