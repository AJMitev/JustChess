namespace JustChess.Figures
{
    using System.Collections.Generic;

    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using Movements;
    using Movements.Contract;

    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy movementStrategy)
        {
           return movementStrategy.GetMovements(this.GetType().Name);
        }
    }
}
