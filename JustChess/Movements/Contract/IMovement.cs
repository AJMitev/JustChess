namespace JustChess.Movements.Contract
{
    using Board.Contracts;
    using Common;
    using Figures.Contracts;

    public interface IMovement
    {
        void ValidateMove(IFigure figure, IBoard board, Move move);
    }
}
