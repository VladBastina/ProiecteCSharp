using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DexExplicativ
{
    [Serializable]
    public class WordClass : INotifyPropertyChanged
    {
        private string _word;
        private string _explenation;
        private string _category;
        private string _imagePath;
        public WordClass()
        {
            _word = "";
            _explenation = "";
            _imagePath = "";
            _category= "";
        }
        public WordClass(string word, string explenation, string imagePath,string category )
        {
            this.Word = word;
            this.Explenation = explenation;
            this.ImagePath = imagePath;
            this.Category = category;
        }
        
        [XmlAttribute]
        public string Category {
            get { return _category; }
            set {
                _category = value;
                OnPropertyChanged("Category");
            } }

        [XmlElement]
        public string Word
        {
            get { return _word; }
            set { _word = value;
                OnPropertyChanged("Word");
            }
        }
        
        [XmlElement]
        public string Explenation {
            get { return _explenation; }
            set
            {
                _explenation= value;
                OnPropertyChanged("Explenation");
            }
        }
        
        [XmlElement]
        public string ImagePath {
            get { return _imagePath; }
            set { _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
