﻿namespace JustChess.Board
{
    using System;
    using JustChess.Figures.Contracts;
    using JustChess.Common;

    public class Board
    {
        private IFigure[,] board;

        public Board(int rows = GlobalConstants.StandratGameTotalBoardRows, int cols = GlobalConstants.StandartGameTotalBoardCols)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.board = new IFigure[rows, cols];
        }

        public int TotalRows { get; private set; }
        public int TotalCols { get; private set; }

        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsNull(figure,GlobalErrorMessages.NullFigureErrorMessage);
            this.CheckIfPositionIsValid(position);

            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = figure;
        }

        public void RemoveFigure(Position position)
        {
            this.CheckIfPositionIsValid(position);

            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = null;
        }


        private int GetArrayRow(int chessRow)
        {
            return  this.TotalRows - chessRow;
        }

        private int GetArrayCol(char chessCol)
        {
            return chessCol - 'a';

        }

        private void CheckIfPositionIsValid(Position position)
        {
            if (position.Row < GlobalConstants.MinimumRowValueOnBoard || position.Row > GlobalConstants.MaximumRowValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected row position on the board is not valid!");
            }

            if (position.Col < GlobalConstants.MinimumColValueOnBoard || position.Col > GlobalConstants.MaximumColValueOnBoard) 
            {
                throw new IndexOutOfRangeException("Selected col position on the board is not valid!");
            }
        }
    }
}