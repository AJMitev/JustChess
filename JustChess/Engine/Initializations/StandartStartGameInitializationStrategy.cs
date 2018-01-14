namespace JustChess.Engine.Initializations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using JustChess.Board.Contracts;
    using JustChess.Engine.Contracts;
    using JustChess.Players.Contracts;
    using JustChess.Common;
    using JustChess.Figures;
    using JustChess.Figures.Contracts;


    public class StandartStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int BoardTotalRowsAndCols = 8;

        private readonly IList<Type> _figureTypes;

        public StandartStartGameInitializationStrategy()
        {
            this._figureTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Knight),
                typeof(Bishop),
                typeof(Queen),
                typeof(King),
                typeof(Bishop),
                typeof(Knight),
                typeof(Rook)

            };
        }

        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];


            this.AddPownsToBoardRow(board, firstPlayer,7);
            this.AddArmy(board,firstPlayer,8);

            this.AddPownsToBoardRow(board,secondPlayer,2);
            this.AddArmy(board,secondPlayer,1);
        }


        private  void AddArmy(IBoard board, IPlayer player, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var figureType = this._figureTypes[i];
                var figurInstance = (IFigure)Activator.CreateInstance(figureType, player.Color);
                player.AddFigure(figurInstance);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(figurInstance, position);
            }
        }

        private  void AddPownsToBoardRow(IBoard board, IPlayer player, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var pawn = new Pawn(player.Color);
                player.AddFigure(pawn);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(pawn, position);
            }
        }

        private  void ValidateStrategy(IEnumerable<IPlayer> players, IBoard board)
        {
            if (players.Count() != GlobalConstants.StandartGameNumberOfPlayers)
            {
                throw new InvalidOperationException("Standart Start Game Initialization Strategy needs exactly two players!");
            }

            if (board.TotalRows != BoardTotalRowsAndCols || board.TotalCols != BoardTotalRowsAndCols)
            {
                throw new InvalidOperationException("Standart Start Game Initialization Strategy needs exactly 8x8 board!");
            }
        }
    }
}
