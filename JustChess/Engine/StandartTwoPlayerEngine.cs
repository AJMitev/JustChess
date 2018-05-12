namespace JustChess.Engine
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using JustChess.Board;
    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using JustChess.InputProviders.Contracts;
    using JustChess.Players.Contracts;
    using JustChess.Engine.Contracts;
    using JustChess.Movements.Contract;
    using JustChess.Movements.Strategies;
    using JustChess.Players;
    using JustChess.Renderers.Contracts;

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> _players;
        private readonly IRenderer _renderer;
        private readonly IInputProvider _input;
        private readonly IBoard _board;
        private readonly IMovementStrategy _movementStrategy;

        private int currentPlayerIndex;

        public StandartTwoPlayerEngine(IRenderer renderer, IInputProvider input)
        {
            this._renderer = renderer;
            this._input = input;
            this._board = new Board();
            this._movementStrategy = new NormalMovementStrategy();
        }



        public IEnumerable<IPlayer> Players => new List<IPlayer>(this._players);

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {

            //TODO: BUG - if players are changed- board is reversed
            this._players = new List<IPlayer>
            {
                new Player("Black", ChessColor.Black),
                new Player("White", ChessColor.White)
            }; //this._input.GetPlayers(GlobalConstants.StandartGameNumberOfPlayers);

            this.SetFirstPlayerIndex();
            gameInitializationStrategy.Initialize(this._players, this._board);
            this._renderer.RenderBoard(this._board);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this._input.GetNextPlayerMove(player);
                    var from = move.From;
                    var to = move.To;
                    var figure = this._board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionIsEmpty(figure, to);

                    var avaliableMovements = figure.Move(this._movementStrategy);

                    foreach (var movement in avaliableMovements)
                    {
                        movement.ValidateMove(figure, this._board, move);
                    }

                    _board.MoveFigureAtPosition(figure, from, to);

                    this._renderer.RenderBoard(_board);

                    //TODO: On everymove chekc if we are in checkmate
                    //TODO: Check pawn on last row.
                    //TODO: if not check -  move figure  (check castle - check if castle is valid, check pawn for  An-pasan)
                    //TODO: Check check
                    //TODO: If in check -  checkmate
                    //TODO: If not in mate - check draw
                    //TODO: Countinue 
                    //TODO: Add Option for resignation

                }
                catch (Exception e)
                {
                    this.currentPlayerIndex--;
                    this._renderer.PrintErrorMessage(e.Message);
                }
            }
        }




        public void WinningConditions()
        {

        }

        private IPlayer GetFirstPlayer()
        {
            return this._players.FirstOrDefault(p => p.Color == ChessColor.White);
        }

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this._players.Count; i++)
            {
                if (this._players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i - 1;
                    return;
                }
            }
        }

        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;

            if (this.currentPlayerIndex >= this._players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            return this._players[this.currentPlayerIndex];
        }

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position from)
        {

            if (figure == null)
            {
                throw new InvalidOperationException($"Position {from.Col} - {from.Row} is empty!");
            }


            if (figure.Color != player.Color)
            {
                throw new InvalidOperationException("Figure at this position is not yours!");
            }
        }

        private void CheckIfToPositionIsEmpty(IFigure figure, Position to)
        {
            var figureAtPosition = this._board.GetFigureAtPosition(to);
            if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
            {
                throw new InvalidOperationException($"You already have a figure at {to.Col}{to.Row}!");
            }
        }
    }
}
