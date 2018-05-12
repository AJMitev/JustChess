namespace JustChess.Figures
{
    using System.Collections.Generic;

    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using Movements.Contract;

    public class King : BaseFigure, IFigure
    {
        public King(ChessColor color)
            : base(color)
        {

        }

        public override ICollection<IMovement> Move(IMovementStrategy movementStrategy)
        {
            return movementStrategy.GetMovements(this.GetType().Name);
        }
    }
}
