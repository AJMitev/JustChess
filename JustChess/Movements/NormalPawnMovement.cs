﻿namespace JustChess.Movements
{
    using System;

    using Contract;
    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Figures.Contracts;

    public class NormalPawnMovement : IMovement
    {
        private const string PawnBackwardsErrorMessage = "Pawns cannot move backwards!";
        private const string PawnInvalidMove = "Pawns cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var color = figure.Color;
            var other = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;
            var from = move.From;
            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if (color == ChessColor.White && to.Row < from.Row)
            {
                throw new InvalidOperationException(PawnBackwardsErrorMessage);
            }

            if (color == ChessColor.Black && to.Row > from.Row)
            {
                throw new InvalidOperationException(PawnBackwardsErrorMessage);
            }

            if (color == ChessColor.White)
            {
                if (from.Row + 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
                    {
                        return;
                    }
                }
                if (from.Row == 2 && !this.CheckDiagonalMove(from, to))
                {
                    if (from.Row + 2 == to.Row && figureAtPosition == null)
                    {
                        return;
                    }
                }
                if (from.Row + 1 == to.Row && !this.CheckDiagonalMove(from, to))
                {
                    if (figureAtPosition == null)
                    {
                        return;
                    }
                }
            }
            else if (color == ChessColor.Black)
            {
                if (from.Row - 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
                    {
                        return;
                    }
                }
                if (from.Row == 7 && !this.CheckDiagonalMove(from, to))
                {
                    if (from.Row - 2 == to.Row && figureAtPosition == null)
                    {
                        return;
                    }
                }
                if (from.Row - 1 == to.Row && !this.CheckDiagonalMove(from, to))
                {
                    if (figureAtPosition == null)
                    {
                        return;
                    }
                }
            }

            throw new InvalidOperationException(PawnInvalidMove);
        }

        private bool CheckOtherFigureIfValid(IBoard board, Position to, ChessColor color)
        {
            var otherFigure = board.GetFigureAtPosition(to);
            if (otherFigure != null && otherFigure.Color == color)
            {
                return true;
            }

            return false;
        }

        private bool CheckDiagonalMove(Position from, Position to)
        {
            return (from.Col + 1 == to.Col || from.Col - 1 == to.Col);
        }
    }
}
