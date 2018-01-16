﻿namespace JustChess.Movements.Strategies
{
    using System.Collections.Generic;
    using Contract;

    public class NormalMovementStrategy : IMovementStrategy
    {
        private readonly IDictionary<string, IList<IMovement>> movements = new Dictionary<string, IList<IMovement>>
        {
            { "Pawn", new List<IMovement>
                {
                    new NormalPawnMovement()
                }},
            { "Bishop", new List<IMovement>
            {
                new NormalDiagonalMovement()
            }},
            { "Rook", new List<IMovement>
            {
                new NormalHorizontalAndVerticalMovement()
            }}
        };

        public IList<IMovement> GetMovements(string figure)
        {
            return this.movements[figure];
        }
    }
}
