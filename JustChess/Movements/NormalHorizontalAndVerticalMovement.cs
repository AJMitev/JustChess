namespace JustChess.Movements
{
    using System;
    using Board.Contracts;
    using Common;
    using Contract;
    using Figures.Contracts;

    public class NormalHorizontalAndVerticalMovement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {

            var from = move.From;
            var to = move.To;

            var horizontalMovement = Math.Abs(from.Row - to.Row);
            var verticalMovement = Math.Abs(from.Col - to.Col);

            if (horizontalMovement == 0 || verticalMovement == 0)
            {
                if (horizontalMovement == 0)
                {
                    char colIndex = from.Col;
                    char colDirection = (char)(from.Col < to.Col ? 1 : -1);

                    while (true)
                    {
                        colIndex += colDirection;

                        if (to.Col == colIndex)
                        {
                            CheckForFigureOnTheWay(figure, board, to);
                            return;
                        }

                        var position = Position.FromChessCordinates(move.From.Row, colIndex);
                        CheckForFigureOnTheWay(figure, board, position);

                    }
                }
                else
                {
                    int rowIndex = from.Row;
                    int rowDirection = from.Row < to.Row ? 1 : -1;

                    while (true)
                    {
                        rowIndex += rowDirection;

                        if (to.Row == rowIndex)
                        {
                            CheckForFigureOnTheWay(figure,board, to);
                            return;
                        }

                        var position = Position.FromChessCordinates(rowIndex, move.From.Col);
                        CheckForFigureOnTheWay(figure,board,position);
                    }
                }


            }
            else
            {
            throw new InvalidOperationException($"{figure.GetType().Name} cannot move that way!");

            }
        }

        private static void CheckForFigureOnTheWay(IFigure figure, IBoard board, Position to)
        {
            var figureAtPositon = board.GetFigureAtPosition(to);

            if (figureAtPositon != null && figureAtPositon.Color == figure.Color)
            {
                throw new InvalidOperationException(GlobalErrorMessages.FigureOnTheWayErrorMessage);
            }
            else
            {
                return;
            }
        }
    }
}
