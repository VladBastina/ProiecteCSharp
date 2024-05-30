using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Checkers.Models
{
    [Serializable]
    public class Piece : INotifyPropertyChanged
    {
        private bool isKing;
        private bool color;
        private string image;

        public event PropertyChangedEventHandler? PropertyChanged;
        [XmlElement]
        public bool IsKing { get { return isKing; } set { isKing = value; } }
        [XmlElement]
        public bool Color { get { return color; } set { color = value; } }
        [XmlElement]
        public string Image { get { return image; } set { image = value; OnPropertyChanged(nameof(Image)); } }

        public Piece( bool color)
        {
            isKing = false;
            this.color = color;
            if (color ) 
            {
                image = "C:/Users/vladb/VisualStudio/Checkers/Checkers/Resources/black.png";
            }
            else
            {
                image = "C:/Users/vladb/VisualStudio/Checkers/Checkers/Resources/white.jpg";
            }
        }

        public Piece() { }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Piece Clone()
        {
            return new Piece
            {
                color = this.color,
                image = this.image,
                isKing = this.isKing
            };
        }
    }
}
