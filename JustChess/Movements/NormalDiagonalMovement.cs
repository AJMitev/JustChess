﻿namespace JustChess.Movements
{
    using System;

    using JustChess.Movements.Contract;
    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Figures.Contracts;

    public class NormalDiagonalMovement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            // TODO: extract to method
            var other = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;

            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException($"{figure.GetType().Name} cannot move this way!");
            }

            var from = move.From;
            var to = move.To;

            int rowIndex = from.Row;
            char colIndex = from.Col;


            int rowDirection = from.Row < to.Row ? 1 : -1;
            char colDirection = (char)(from.Col < to.Col ? 1 : -1);


            while (true)
            {
                rowIndex += rowDirection;
                colIndex += colDirection;

                if (to.Row == rowIndex && to.Col == colIndex)
                {
                   MovementValidator.CheckForFigureOnTheWay(figure,board,to);
                    return;
                    }

                var position = Position.FromChessCordinates(rowIndex, colIndex);
                MovementValidator.CheckForFigureOnTheWay(figure, board, position);
            }
        }
    }
}
