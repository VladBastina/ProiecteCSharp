using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    internal class Move
    {
        public Cell LeavingCell { get; set; }

        public Cell DestinationCell { get; set; }

        public Move(Cell cell1 , Cell cell2) 
        {
            LeavingCell = cell1;
            DestinationCell = cell2;
        }
    }
}
