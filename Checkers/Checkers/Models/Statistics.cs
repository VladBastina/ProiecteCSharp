using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Checkers.Models
{
    [Serializable]
    public class Statistics
    {
        public Statistics() 
        {
        }
        [XmlElement]
        public int WhiteWins { get; set; }
        [XmlElement]
        public int BlackWins { get; set; }
        [XmlElement]
        public int MaxPiecesWin { get; set; }

        public Statistics Clone()
        {
            return new Statistics
            {
                WhiteWins = this.WhiteWins,
                BlackWins = this.BlackWins,
                MaxPiecesWin = this.MaxPiecesWin
            };
        }
    }
}
