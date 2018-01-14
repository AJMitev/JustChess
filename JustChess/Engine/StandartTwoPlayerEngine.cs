namespace JustChess.Engine
{
    using System.Collections.Generic;

    using Board;
    using Board.Contracts;
    using Common;
    using InputProviders.Contracts;
    using JustChess.Players.Contracts;
    using JustChess.Engine.Contracts;
    using Players;
    using Renderers.Contracts;

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private readonly IEnumerable<IPlayer> _players;
        private readonly IRenderer _renderer;
        private readonly IInputProvider _input;
        private readonly IBoard _board;

        public StandartTwoPlayerEngine(IRenderer renderer, IInputProvider input)
        {
            this._renderer = renderer;
            this._input = input;
            this._board = new Board();
        }

        public IEnumerable<IPlayer> Players => new List<IPlayer>(this._players);

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            var players =  new List<IPlayer>
            {
                new Player("Gosho", ChessColor.Black),
                new Player("Tosho", ChessColor.White)
            }; //this._input.GetPlayers(GlobalConstants.StandartGameNumberOfPlayers);
            gameInitializationStrategy.Initialize(players, this._board);
            this._renderer.RenderBoard(this._board);
        }

        public void Start()
        {
           
        }

        public void WinningConditions()
        {
          
        }
    }
}
