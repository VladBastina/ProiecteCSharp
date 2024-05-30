using Checkers.Commands;
using Checkers.Models;
using Checkers.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Checkers.ViewModel
{
    [XmlRoot("GameVM")]
    public class GameVM : INotifyPropertyChanged
    {
        private GameLogic gameLogic;
        private Cell selectedCell;
        private Cell cellToMoveIn;
        private int whitePiecesLeft;
        private int blackPiecesLeft;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [XmlElement]
        public BoardVM BoardVM { get; set; }
        [XmlIgnore]
        public Cell SelectedCell { get { return selectedCell; } 
            set
            {
                if (value.Piece!=null && value.Piece.Color == Turn)
                {
                    selectedCell = value;
                    BoardVM.BoardConfig[selectedCell.Pos.X][selectedCell.Pos.Y].IsSelected = true;
                    gameLogic.RecomandMoves(BoardVM, selectedCell, MultipleMoves);
                    cellToMoveIn = null;
                }
                else
                {
                    MessageBox.Show("Este randul celuilalt jucator");
                }
            } }
        [XmlIgnore]
        public Cell CellToMOveIn { get { return cellToMoveIn; }
            set 
            {
                cellToMoveIn = value;
                BoardVM.BoardConfig[selectedCell.Pos.X][selectedCell.Pos.Y].IsSelected = false;
                if (cellToMoveIn.IsRecomended)
                {
                    if (gameLogic.PerformMoves(BoardVM, selectedCell, cellToMoveIn, MultipleMoves, Turn) == false)
                    {
                        Status = Status.Win;
                    }
                }
                gameLogic.ClearRecomendedCells(BoardVM);
                if (selectedCell.Piece == null)
                {
                    Turn = !Turn;
                }
                selectedCell = null;
                WhitePiecesLeft = gameLogic.WhitePiecesLeft;
                BlackPiecesLeft = gameLogic.BlackPiecesLeft;
            } }
        [XmlAttribute]
        public bool MultipleMoves { get; set; }
        [XmlElement]
        public int WhitePiecesLeft { get { return whitePiecesLeft; }  set { whitePiecesLeft = value; OnPropertyChanged(nameof(WhitePiecesLeft)); } }
        [XmlElement]
        public int BlackPiecesLeft { get { return blackPiecesLeft; } set{ blackPiecesLeft = value; OnPropertyChanged(nameof(BlackPiecesLeft)); } }
        [XmlElement]
        public bool Turn { get; set; }

        public Status Status { get; set; }
        public GameVM(bool multipleMoves)
        {
            BoardVM = new BoardVM(true);
            this.MultipleMoves = multipleMoves;
            gameLogic = new GameLogic();
            Turn = false;
            whitePiecesLeft=gameLogic.WhitePiecesLeft;
            blackPiecesLeft=gameLogic.BlackPiecesLeft;
        }

        public GameVM() 
        {
        }

        public GameVM Clone()
        {
            return new GameVM
            {
                BoardVM = this.BoardVM.Clone(),
                selectedCell = this.selectedCell,
                cellToMoveIn = this.cellToMoveIn,
                MultipleMoves = this.MultipleMoves,
                Turn = this.Turn,
                whitePiecesLeft = this.whitePiecesLeft,
                blackPiecesLeft = this.blackPiecesLeft,
                gameLogic = new GameLogic(blackPiecesLeft,whitePiecesLeft),
                Status= Status.Ongoing
            };
        }

        public void SelectedCellAndCellToMoveIn(Cell cell)
        {
            if (SelectedCell == null && cell.HasPiece)
            {
                SelectedCell = cell;
            }
            else if (SelectedCell != null && cell != SelectedCell)
            {
                CellToMOveIn = cell;
            }
        }

        private ICommand switchCells;
        public ICommand SwitchSelctedAndToMove {
            get
            {
                if (switchCells == null) 
                {
                    switchCells = new RelayCommand(SelectedCellAndCellToMoveIn);
                }
                return switchCells;
            }
            }
    }
}
