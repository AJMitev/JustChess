using JustChess.Common;

namespace JustChess.Figures
{
    using JustChess.Figures.Contracts;
    public class Pawn : IFigure
    {
        public Pawn(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }
    }
}
