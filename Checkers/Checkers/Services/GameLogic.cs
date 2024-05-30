using Checkers.Models;
using Checkers.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers.Services
{
    class GameLogic
    {
        private List<Cell> recomendedCellsToMoveIn;
        private Dictionary<Cell, Cell> roadOfThePiece;
        private int whitePiecesLeft;
        private int blackPiecesLeft;
        private StatisticsSerializer statisticsSerializer;

        public int WhitePiecesLeft {  get { return whitePiecesLeft; } }
        public int BlackPiecesLeft { get { return blackPiecesLeft; } }

        public GameLogic(int blackPiecesLeft = 12,int whitePiecesLeft=12 )
        {
            recomendedCellsToMoveIn = new List<Cell>();
            roadOfThePiece = new Dictionary<Cell, Cell>();
            this.blackPiecesLeft = blackPiecesLeft;
            this.whitePiecesLeft = whitePiecesLeft;
            statisticsSerializer = new StatisticsSerializer();
        }

        public void MoveAPiece(BoardVM board, Cell selectedCell, Cell cellToMoveIn)
        {
            if (selectedCell.HasPiece && selectedCell.Color && cellToMoveIn.Color && !cellToMoveIn.HasPiece && cellToMoveIn.IsRecomended)
            {
                Piece aux = null;
                aux = board.BoardConfig[selectedCell.Pos.X][selectedCell.Pos.Y].Piece;
                board.BoardConfig[selectedCell.Pos.X][selectedCell.Pos.Y].Piece = board.BoardConfig[cellToMoveIn.Pos.X][cellToMoveIn.Pos.Y].Piece;
                board.BoardConfig[cellToMoveIn.Pos.X][cellToMoveIn.Pos.Y].Piece = aux;
                board.BoardConfig[selectedCell.Pos.X][selectedCell.Pos.Y].HasPiece = false;
                board.BoardConfig[cellToMoveIn.Pos.X][cellToMoveIn.Pos.Y].HasPiece = true;
                if (board.BoardConfig[cellToMoveIn.Pos.X][cellToMoveIn.Pos.Y].Piece.Color && cellToMoveIn.Pos.X == 7)
                {
                    board.BoardConfig[cellToMoveIn.Pos.X][cellToMoveIn.Pos.Y].Piece.IsKing = true;
                    board.BoardConfig[cellToMoveIn.Pos.X][cellToMoveIn.Pos.Y].Piece.Image = "C:/Users/vladb/VisualStudio/Checkers/Checkers/Resources/blackKing.jpg";
                }
                else if (!board.BoardConfig[cellToMoveIn.Pos.X][cellToMoveIn.Pos.Y].Piece.Color && cellToMoveIn.Pos.X == 0)
                {
                    board.BoardConfig[cellToMoveIn.Pos.X][cellToMoveIn.Pos.Y].Piece.IsKing = true;
                    board.BoardConfig[cellToMoveIn.Pos.X][cellToMoveIn.Pos.Y].Piece.Image = "C:/Users/vladb/VisualStudio/Checkers/Checkers/Resources/whiteKing.jpg";
                }
            }
        }

        public void ClearRecomendedCells(BoardVM board)
        {
            for (int i = 0; i <= 7; i++)
                for (int j = 0; j <= 7; j++)
                {
                    if (board.BoardConfig[i][j].IsRecomended)
                    {
                        board.BoardConfig[i][j].IsRecomended = false;
                    }
                }
        }

        public void RecomandMoves(BoardVM board, Cell selectedCell, bool multipleMoves)
        {
            recomendedCellsToMoveIn.Clear();
            roadOfThePiece.Clear();
            if (selectedCell.HasPiece)
            {
                bool isBlack = selectedCell.Piece.Color;
                MoveDirection moveDirection = isBlack ? MoveDirection.Down : MoveDirection.Up;

                RecomandSingleMoves(board, selectedCell, moveDirection);

                if (selectedCell.Piece.IsKing)
                {
                    MoveDirection oppositeDirection = isBlack ? MoveDirection.Up : MoveDirection.Down;
                    RecomandSingleMoves(board, selectedCell, oppositeDirection);
                }

                if (multipleMoves)
                {
                    RecomandMultipleMoves(board, selectedCell, moveDirection);
                    if (selectedCell.Piece.IsKing)
                    {
                        MoveDirection oppositeDirection = isBlack ? MoveDirection.Up : MoveDirection.Down;
                        RecomandMultipleMoves(board, selectedCell, oppositeDirection);
                    }
                }
            }
        }
        private void RecomandSingleMoves(BoardVM board, Cell selectedCell, MoveDirection moveDirection)
        {
            int xIncrement = moveDirection == MoveDirection.Up ? -1 : 1;
            Cell cellLeft = GetAdjacentCell(board, selectedCell, xIncrement, -1);
            Cell cellRight = GetAdjacentCell(board, selectedCell, xIncrement, 1);

            AddRecommendedMoveIfPossible(board, selectedCell,cellLeft);
            AddRecommendedMoveIfPossible(board,selectedCell, cellRight);

            Cell jumpLeft = GetAdjacentCell(board, selectedCell, 2 * xIncrement, -2);
            Cell jumpRight = GetAdjacentCell(board, selectedCell, 2 * xIncrement, 2);

            if (jumpLeft != null && cellLeft.HasPiece && cellLeft.Piece.Color != selectedCell.Piece.Color)
            {
                Cell landingCell = jumpLeft;
                if (landingCell != null && !landingCell.HasPiece)
                {
                    landingCell.IsRecomended = true;
                    recomendedCellsToMoveIn.Add(landingCell);
                }
            }

            if (jumpRight != null && cellRight.HasPiece && cellRight.Piece.Color != selectedCell.Piece.Color)
            {
                Cell landingCell = jumpRight;
                if (landingCell != null && !landingCell.HasPiece)
                {
                    landingCell.IsRecomended = true;
                    recomendedCellsToMoveIn.Add(landingCell);
                }
            }
        }

        private void RecomandMultipleMoves(BoardVM board, Cell selectedCell, MoveDirection moveDirection)
        {
            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(selectedCell);

            while (queue.Count > 0)
            {
                Cell currentCell = queue.Dequeue();
                int xIncrement = moveDirection == MoveDirection.Up ? -1 : 1;
                Cell cellLeft = GetAdjacentCell(board, currentCell, xIncrement, -1);
                Cell cellRight = GetAdjacentCell(board, currentCell, xIncrement, 1);

                AddRecommendedMoveIfPossible(board,selectedCell, cellLeft);
                AddRecommendedMoveIfPossible(board,selectedCell, cellRight);

                if (cellLeft != null && cellLeft.HasPiece && cellLeft.Piece.Color != selectedCell.Piece.Color)
                {
                    Cell jumpCell = GetAdjacentCell(board, cellLeft, xIncrement, -1);
                    if (jumpCell != null && !jumpCell.HasPiece)
                    {
                        jumpCell.IsRecomended = true;
                        recomendedCellsToMoveIn.Add(jumpCell);
                        roadOfThePiece.Add(jumpCell,currentCell);
                        queue.Enqueue(jumpCell);
                    }
                }

                if (cellRight != null && cellRight.HasPiece && cellRight.Piece.Color != selectedCell.Piece.Color)
                {
                    Cell jumpCell = GetAdjacentCell(board, cellRight, xIncrement, 1);
                    if (jumpCell != null && !jumpCell.HasPiece)
                    {
                        jumpCell.IsRecomended = true;
                        recomendedCellsToMoveIn.Add(jumpCell);
                        roadOfThePiece.Add(jumpCell,currentCell);
                        queue.Enqueue(jumpCell);
                    }
                }
            }
        }

        private Cell GetAdjacentCell(BoardVM board, Cell currentCell, int xIncrement, int yIncrement)
        {
            int newX = currentCell.Pos.X + xIncrement;
            int newY = currentCell.Pos.Y + yIncrement;
            if (newX >= 0 && newX < board.BoardConfig.Count && newY >= 0 && newY < board.BoardConfig[newX].Count)
            {
                return board.BoardConfig[newX][newY];
            }
            return null;
        }

        private void AddRecommendedMoveIfPossible(BoardVM board,Cell current , Cell cell)
        {
            if (cell != null && !cell.HasPiece && Math.Abs(current.Pos.X-cell.Pos.X)<=1 && Math.Abs(current.Pos.Y - cell.Pos.Y)<=1) 
            {
                cell.IsRecomended = true;
                recomendedCellsToMoveIn.Add(cell);
            }
        }

        enum MoveDirection
        {
            Up,
            Down
        }

        public void PerformSingleMove(BoardVM board, Cell selectedCell, Cell destinationCell , bool turn)
        {
            float jumpedX = (selectedCell.Pos.X + destinationCell.Pos.X) / 2;
            float jumpedY = (selectedCell.Pos.Y + destinationCell.Pos.Y) / 2;
            MoveAPiece(board, selectedCell, destinationCell);
            int cellToVerifyX = Math.Min(selectedCell.Pos.X, destinationCell.Pos.X);
            int cellToVerifyY = Math.Min(selectedCell.Pos.Y, destinationCell.Pos.Y);
            if (jumpedX != cellToVerifyX && jumpedY != cellToVerifyY)
            {
                Cell jumpedCell = board.BoardConfig[(int)jumpedX][(int)jumpedY];
                if (jumpedCell.HasPiece)
                {
                    jumpedCell.HasPiece = false;
                    if (turn)
                    {
                        whitePiecesLeft -= 1;
                    }
                    else
                    {
                        blackPiecesLeft -= 1;
                    }
                    jumpedCell.Piece = null;
                }

            }
        }

        public void PerformMultipleMoves(BoardVM board, Cell selectedCell, Cell destinationCell,bool turn)
        {
            if (Math.Abs(selectedCell.Pos.X - destinationCell.Pos.X) >= 2)
            {
                Cell currentCell = destinationCell;
                List<Move> listOfMoves = new List<Move>();
                while (currentCell != selectedCell)
                {
                    Move move = new Move(roadOfThePiece[currentCell], currentCell);
                    currentCell = roadOfThePiece[currentCell];
                    listOfMoves.Add(move);
                }
                foreach (Move move in listOfMoves.Reverse<Move>())
                {
                    PerformSingleMove(board, move.LeavingCell, move.DestinationCell,turn);
                }
            }
            else
            {
                PerformSingleMove(board, selectedCell, destinationCell,turn);
            }
            
        }

        public bool PerformMoves(BoardVM board, Cell selectedCell, Cell destinationCell , bool multipleMoves,bool turn)
        {
            if(multipleMoves)
            {
                PerformMultipleMoves(board, selectedCell, destinationCell, turn);
            }
            else
            {
                PerformSingleMove(board,selectedCell, destinationCell,turn);
            }
            if(whitePiecesLeft==0)
            {
                MessageBox.Show("Jucatorul cu piese negre a castigat");
                Statistics statistics = statisticsSerializer.DeserializeObject();
                statistics.BlackWins += 1;
                if(blackPiecesLeft >= statistics.MaxPiecesWin)
                {
                    statistics.MaxPiecesWin = blackPiecesLeft;
                }
                statisticsSerializer.SerializeObject(statistics);
                return false;
            }
            else if (blackPiecesLeft == 0)
            {
                MessageBox.Show("Jucatorul cu piese albe a castigat");
                Statistics statistics = statisticsSerializer.DeserializeObject();
                statistics.WhiteWins += 1;
                if (whitePiecesLeft >= statistics.MaxPiecesWin)
                {
                    statistics.MaxPiecesWin = whitePiecesLeft;
                }
                statisticsSerializer.SerializeObject(statistics);
                return false;
            }
            return true;
        }

    }
}
