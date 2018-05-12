namespace JustChess.Movements
{
    using System;

    using Contract;
    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using JustChess.Movements;

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
                if (from.Row + 1 == to.Row && MovementValidator.IsItADiagonalMove(from, to))
                {
                    if (MovementValidator.IsItValidOponentFigure(board, to, other))
                    {
                        return;
                    }
                }
                if (from.Row == GlobalConstants.WhitePawnsStartingRow && !MovementValidator.IsItADiagonalMove(from, to))
                {
                    if (from.Row + 2 == to.Row && figureAtPosition == null)
                    {
                        return;
                    }
                }
                if (from.Row + 1 == to.Row && !MovementValidator.IsItADiagonalMove(from, to))
                {
                    if (figureAtPosition == null)
                    {
                        return;
                    }
                }
            }
            else if (color == ChessColor.Black)
            {
                if (from.Row - 1 == to.Row && MovementValidator.IsItADiagonalMove(from, to))
                {
                    if (MovementValidator.IsItValidOponentFigure(board, to, other))
                    {
                        return;
                    }
                }
                if (from.Row == GlobalConstants.BlackPawnsStartingRow && !MovementValidator.IsItADiagonalMove(from, to))
                {
                    if (from.Row - 2 == to.Row && figureAtPosition == null)
                    {
                        return;
                    }
                }
                if (from.Row - 1 == to.Row && !MovementValidator.IsItADiagonalMove(from, to))
                {
                    if (figureAtPosition == null)
                    {
                        return;
                    }
                }
            }

            throw new InvalidOperationException(PawnInvalidMove);
        }
    }
}
