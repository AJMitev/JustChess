namespace JustChess.Figures
{
    using System.Collections.Generic;

    using JustChess.Figures.Contracts;
    using JustChess.Common;
    using Movements.Contract;

    public class Knight :BaseFigure, IFigure
    {
        public Knight(ChessColor color)
            : base(color)
        {
            
        }

        public override ICollection<IMovement> Move(IMovementStrategy movementStrategy)
        {
            throw new System.NotImplementedException();
        }
    }
}
