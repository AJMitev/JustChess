namespace JustChess.Movements
{
    using System;
    using Board.Contracts;
    using Common;
    using Contract;
    using Figures.Contracts;

    public class NormalKingMovement : IMovement
    {
        private const string InvalidKingMove = "The king moves one square in any direction";
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var to = move.To;

            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            if (rowDistance == 1 && colDistance == 1 ||
                rowDistance == 0 && colDistance == 1 ||
                rowDistance == 1 && colDistance == 0)
            {
                var figureAtPositionTo = board.GetFigureAtPosition(to);
                if (figureAtPositionTo == null || figureAtPositionTo.Color != figure.Color)
                {
                    return;
                }
            }

            throw new InvalidOperationException(InvalidKingMove);
        }
    }
}
