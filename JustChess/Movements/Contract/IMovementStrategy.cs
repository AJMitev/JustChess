namespace JustChess.Movements.Contract
{
    using System.Collections.Generic;

    public interface IMovementStrategy
    {
        IList<IMovement> GetMovements(string figure);
    }
}
