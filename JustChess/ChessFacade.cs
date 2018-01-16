namespace JustChess
{
    using System;
    using Engine;
    using Engine.Contracts;
    using Engine.Initializations;
    using InputProviders;
    using InputProviders.Contracts;
    using Renderers;
    using Renderers.Contracts;

    public static class ChessFacade
    {
        public static void Start()
        {
            IRenderer renderer = new ConsoleRenderer();
            //renderer.RenderMainManu();

            IInputProvider inputProvider = new ConsoleInputProvider();

            IChessEngine chessEngine = new StandartTwoPlayerEngine(renderer, inputProvider);

            IGameInitializationStrategy gameInitializationStrategy = new StandartStartGameInitializationStrategy();
            chessEngine.Initialize(gameInitializationStrategy);
            chessEngine.Start();

            Console.ReadLine();
        }
    }
}
