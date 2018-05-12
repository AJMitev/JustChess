﻿namespace JustChess.Movements
{
    using System;

    using Board.Contracts;
    using Common;
    using Contract;
    using Figures.Contracts;


    public class NormalKnightMovement : IMovement
    {
        private const string KnightInvalidMove = "Knights cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);
            var color = figure.Color;
            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if (figureAtPosition == null || color != figureAtPosition.Color)
            {
                if (rowDistance == 2 && colDistance == 1)
                {
                    return;
                }
                
                if (colDistance == 2 && rowDistance == 1)
                {
                    return;
                }
            }

            throw new InvalidOperationException(KnightInvalidMove);
        }
    }
}
