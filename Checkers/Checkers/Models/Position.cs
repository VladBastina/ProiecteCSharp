using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Checkers.Models
{
    [Serializable]
    public class Position
    {

        public Position(int x, int y)
        {
            this.X= x;
            this.Y = y;
        }

        public Position() { }

        [XmlElement]
        public int X { get; set; }
        [XmlElement]
        public int Y { get; set; }

        public Position Clone()
        {
            return new Position(X, Y);
        }
    }
}
