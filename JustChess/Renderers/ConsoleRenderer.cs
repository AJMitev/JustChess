namespace JustChess.Renderers
{
    using System;
    using System.Threading;
    using Board.Contracts;
    using Common;
    using Common.Console;
    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "JUST CHESS";
     
        private const ConsoleColor DarkSquareConsoleColor = ConsoleColor.DarkGray;
        private const ConsoleColor WhoteSquareConsoleColor = ConsoleColor.Gray;

        public ConsoleRenderer()
        {
            if(Console.WindowWidth < 100 || Console.WindowHeight < 80)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Clear();
                Console.WriteLine("Please, set the Console window and buffer size to 100x80. For best experience  use Raserer font");
                Environment.Exit(0);
            }
        }

        public void RenderMainManu()
        { 
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            //TODO: Add Main menu.

            Thread.Sleep(1000);
        }

        public void RenderBoard(IBoard board)
        {
            //TODO: Validate console dimensions.
            var startRowPrint = Console.WindowWidth / 2 - (board.TotalRows / 2) * ConsoleConstants.CharactersPerRowPerBoardSquare;
            var startColPrint = Console.WindowHeight / 2 - (board.TotalCols / 2) * ConsoleConstants.CharactersPerColPerBoardSquare;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;
            var cntr = 1;


            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentColPrint = startRowPrint + left * ConsoleConstants.CharactersPerColPerBoardSquare;
                    currentRowPrint = startColPrint + top * ConsoleConstants.CharactersPerRowPerBoardSquare;

                    ConsoleColor backgroundColor;
                    
                    if (cntr % 2 == 0)
                    {
                        backgroundColor = DarkSquareConsoleColor;
                        Console.BackgroundColor = DarkSquareConsoleColor;
                    }
                    else
                    {
                        backgroundColor = WhoteSquareConsoleColor;
                        Console.BackgroundColor = WhoteSquareConsoleColor;
                    }

                    var position = Position.FromArrayCordinates(top, left, board.TotalRows);

                    var figure = board.GetFigureAtPosition(position);
                    ConsoleHelpers.PrintFIgure(figure, backgroundColor, currentRowPrint, currentColPrint);

                  

                    cntr++;
                }

                cntr++;
            }

            Console.SetCursorPosition(Console.WindowWidth /2, 2);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
