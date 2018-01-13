namespace JustChess.Renderers
{
    using System;
    using System.Threading;
    using Board.Contracts;
    using Common.Console;
    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "JUST CHESS";
        public void RenderMainManu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            //TODO: Add Main menu.

            Thread.Sleep(1000);
        }

        public void RenderBoard(IBoard board)
        {
            throw new System.NotImplementedException();
        }
    }
}
