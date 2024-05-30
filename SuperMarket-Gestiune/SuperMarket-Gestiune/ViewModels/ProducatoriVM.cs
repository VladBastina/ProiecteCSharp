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
    internal class ProducatoriVM
    {
        ProducatoriBBL producatoriBBL = new ProducatoriBBL();

        public Producatori SelectedProducator {  get; set; }

        public ProducatoriVM()
        {
            producatoriList = producatoriBBL.GetAll();
        }

        public ObservableCollection<Producatori> producatoriList
        {
            get => producatoriBBL.producatoriList;
            set => producatoriBBL.producatoriList = value;
        }

        public void AddProducator(Producatori producatori)
        {
            if (producatoriBBL.AddProducator(producatori))
            {
                MessageBox.Show("Producatorul a fost adaugat cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la adaugarea producatorului");
            }
        }

        public void DeleteProducator()
        {
            if (producatoriBBL.DeleteProducator(SelectedProducator))
            {
                MessageBox.Show("Producatorul a fost sters cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la stergerea producatorului");
            }
        }

        public void UpdateProducator()
        {
            if (producatoriBBL.UpdateProducator(SelectedProducator))
            {
                MessageBox.Show("Producatorul a fost actualizat cu succes");
            }
            else
            {
                MessageBox.Show("S-a produs o eroare la actualizarea producatorului");
            }
        }
    }
}
