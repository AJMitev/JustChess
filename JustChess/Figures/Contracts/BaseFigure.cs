namespace JustChess.Figures.Contracts
{
    using JustChess.Common;


    public abstract class BaseFigure : IFigure
    {
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }
    }
}
