namespace JustChess.Board.Contracts
{
    using JustChess.Common;
    using JustChess.Figures.Contracts;

    public interface IBoard
    {
        int TotalCols { get; }
        int TotalRows { get; }

        void AddFigure(IFigure figure, Position position);
        void RemoveFigure(Position position);

        IFigure GetFigureAtPosition(Position position);
    }
}