namespace JustChess.InputProviders.Contracts
{
    using System.Collections.Generic;
    using Players.Contracts;

    public  interface IInputProvider
    {
         IList<IPlayer> GetPlayers(int numberOfPlayers);
    }
}
