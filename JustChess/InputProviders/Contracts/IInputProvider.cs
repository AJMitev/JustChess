namespace JustChess.InputProviders.Contracts
{
    using System.Collections.Generic;

    using Common;
    using Players.Contracts;

    public  interface IInputProvider
    {
         IList<IPlayer> GetPlayers(int numberOfPlayers);
        Move GetNextPlayerMove(IPlayer player);
    }
}
