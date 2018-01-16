namespace JustChess.Figures.Contracts
{
    using System.Collections.Generic;

    using JustChess.Common;
    using Movements.Contract;


    public abstract class BaseFigure : IFigure
    {
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        public abstract ICollection<IMovement> Move(IMovementStrategy movementStrategy); 
    }
}
