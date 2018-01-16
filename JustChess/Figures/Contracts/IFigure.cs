namespace JustChess.Figures.Contracts
{
    using System.Collections.Generic;

    using JustChess.Common;
    using Movements.Contract;

    public interface IFigure
    {
        ChessColor Color { get; }

       ICollection<IMovement>  Move(IMovementStrategy movementStrategy);
    }
}
