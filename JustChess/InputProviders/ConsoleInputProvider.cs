﻿namespace JustChess.InputProviders
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Common.Console;
    using Contracts;
    using Players;
    using Players.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PlayerNameText = "Enter player {0} name: ";

        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);

                Console.Write(string.Format(PlayerNameText, i));
                string name = Console.ReadLine();
                var player = new Player(name, (ChessColor) (i - 1));
                players.Add(player);
            }

            return players;
        }
    }
}
