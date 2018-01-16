namespace JustChess.Figures
{
    using System.Collections.Generic;

    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using Movements.Contract;

    public class Queen : BaseFigure, IFigure
    {
        public Queen(ChessColor color)
            : base(color)
        {

        }

        public override ICollection<IMovement> Move(IMovementStrategy movementStrategy)
        {
            throw new System.NotImplementedException();
        }
    }
}
