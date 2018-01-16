namespace JustChess.Figures
{
    using System.Collections.Generic;

    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using Movements.Contract;

    public class Rook : BaseFigure, IFigure
    {
        public Rook(ChessColor color)
            : base(color)
        {

        }

        public override ICollection<IMovement> Move(IMovementStrategy movementStrategy)
        {
            return movementStrategy.GetMovements(this.GetType().Name);
        }
    }
}
