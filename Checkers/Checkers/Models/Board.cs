using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Checkers.Models
{
    [Serializable]
    public class Board : INotifyPropertyChanged
    {
        private ObservableCollection<ObservableCollection<Cell>> boardConfig;

        private ObservableCollection<Cell> cellConfig;

        [XmlIgnore]
        public ObservableCollection<ObservableCollection<Cell>> BoardConfig { get { return boardConfig; }  set { boardConfig = value; OnPropertyChanged(nameof(BoardConfig)); } }

        [XmlElement]
        public ObservableCollection<Cell> CellConfig { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
