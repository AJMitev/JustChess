namespace JustChess.Movements
{
    using System;

    using Board.Contracts;
    using Common;
    using Figures.Contracts;


    public class MovementValidator
    {
        public static void CheckForFigureOnTheWay(IFigure figure, IBoard board, Position position)
        {
            var figureAtPositon = board.GetFigureAtPosition(position);

            if (figureAtPositon != null && figureAtPositon.Color == figure.Color)
            {
                throw new InvalidOperationException(GlobalErrorMessages.FigureOnTheWayErrorMessage);
            }
            else
            {
                return;
            }
        }

        public  static bool IsItADiagonalMove(Position from, Position to)
        {
            return (from.Col + 1 == to.Col || from.Col - 1 == to.Col);
        }

        public static bool IsItValidOponentFigure(IBoard board, Position to, ChessColor color)
        {
            var otherFigure = board.GetFigureAtPosition(to);
            if (otherFigure != null && otherFigure.Color == color)
            {
                return true;
            }

            return false;
        }
    }
}
