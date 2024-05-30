using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Checkers.ViewModel
{
    [Serializable]
    public class BoardVM : Board
    {
        public BoardVM(bool x) 
        {
            CellConfig = new ObservableCollection<Cell>();
            Init();
        }

        public BoardVM() { }

        private void Init()
        {
            ObservableCollection<ObservableCollection<Cell>> cells=new ObservableCollection<ObservableCollection<Cell>>();

            for(int i = 0;i<4;i++)
            {
                ObservableCollection<Cell> firstRow = new ObservableCollection<Cell>() 
                { new Cell(new Position(2*i,0),true) , new Cell(new Position(2*i,1),false),new Cell(new Position(2*i,2),true),new Cell(new Position(2*i,3),false),new Cell(new Position(2*i,4),true),new Cell(new Position(2*i,5),false),new Cell(new Position(2*i,6),true),new Cell(new Position(2*i,7),false) };
                cells.Add(firstRow);
                foreach(Cell cell in firstRow)
                {
                    CellConfig.Add(cell);
                }
                ObservableCollection<Cell> secondRow = new ObservableCollection<Cell>()
                { new Cell(new Position(2*i+1,0),false) , new Cell(new Position(2*i+1,1),true),new Cell(new Position(2*i+1,2),false),new Cell(new Position(2*i+1,3),true),new Cell(new Position(2*i+1,4),false),new Cell(new Position(2*i+1,5),true),new Cell(new Position(2*i+1,6),false),new Cell(new Position(2*i+1,7),true) };
                cells.Add(secondRow);
                foreach (Cell cell in secondRow)
                {
                    CellConfig.Add(cell);
                }
            }
            for(int i=0;i<3;i++)
                for(int j=0;j<8;j++)
                {
                    if (cells[i][j].Color==true)
                    {
                        cells[i][j].HasPiece = true;
                        cells[i][j].Piece = new Piece(true);
                    }
                }
            for (int i = 5; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (cells[i][j].Color == true)
                    {
                        cells[i][j].HasPiece = true;
                        cells[i][j].Piece = new Piece(false);
                    }
                }
            BoardConfig = cells;
        }

        public BoardVM Clone()
        {
            ObservableCollection<ObservableCollection<Cell>> cells= new ObservableCollection<ObservableCollection<Cell>> ();
            for(int i=0 ; i<8 ; i++) 
            {
                ObservableCollection<Cell> row = new ObservableCollection<Cell>();
                for(int j=0 ; j<8 ; j++)
                {
                    row.Add(CellConfig[8 * i + j].Clone());
                }
                cells.Add(row);
            }
            BoardConfig=cells;
            return new BoardVM
            {
                BoardConfig = this.BoardConfig,
                CellConfig = this.CellConfig
            };
            
        }

        public void ReconfigCells()
        {
            CellConfig.Clear();
            for (int i=0 ; i<8 ;i++)
                for(int j=0 ; j<8 ;j++)
                {
                    CellConfig.Add(BoardConfig[i][j]);
                }
        }
    }
}
