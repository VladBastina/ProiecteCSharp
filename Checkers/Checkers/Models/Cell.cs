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
    public class Cell : INotifyPropertyChanged
    {
        private bool hasPiece;
        private Piece piece;
        private bool isSelected;
        private bool isRecomended;

        public Cell(Position pos, bool colour)
        {
            this.Pos = pos;
            this.Color = colour;
            hasPiece = false;
            piece =null;
            isSelected = false;
            isRecomended = false;
        }

        public Cell() { }

        [XmlElement]
        public Position Pos { get; set; }
        [XmlElement]
        public bool Color { get; set; }
        [XmlElement]
        public bool HasPiece { get {  return hasPiece; } set { hasPiece = value; } }
        [XmlElement]
        public Piece Piece { get {  return piece; } set { piece = value; OnPropertyChanged("Piece"); } }
        [XmlElement]
        public bool IsSelected { get { return isSelected; } set { isSelected = value; OnPropertyChanged(nameof(IsSelected)); } }
        [XmlElement]
        public bool IsRecomended { get { return isRecomended; } set { isRecomended = value; OnPropertyChanged(nameof(IsRecomended)); } }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Cell Clone()
        {
            Cell cloneCell = new Cell();
            cloneCell.Color = Color;
            cloneCell.Pos = Pos.Clone();
            cloneCell.HasPiece = HasPiece;
            cloneCell.IsRecomended = false;
            cloneCell.IsSelected = false;
            if(cloneCell.HasPiece)
            {
                cloneCell.Piece = Piece;
            }
            return cloneCell;
        }
    }
}
