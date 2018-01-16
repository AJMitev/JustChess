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
            //TODO: Change this maginc values to something calculated
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


            this.PrintBoarder(startRowPrint, board.TotalRows, startColPrint, board.TotalCols);

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
        }

        private void PrintBoarder(int startRowPrint, int boardTotalRows, int startColPrint, int boardTotalCols)
        {
            var start = startRowPrint + ConsoleConstants.CharactersPerRowPerBoardSquare / 2;
            for (int i = 0; i < boardTotalCols; i++)
            {
                Console.SetCursorPosition(start+ i * ConsoleConstants.CharactersPerRowPerBoardSquare, startColPrint - 1);
                Console.Write((char)('A' + i));

                Console.SetCursorPosition(start + i * ConsoleConstants.CharactersPerRowPerBoardSquare, startColPrint + boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare);
                Console.Write((char)('A' + i));
            }


            start = startColPrint + ConsoleConstants.CharactersPerColPerBoardSquare / 2;
            for (int i = 0; i < boardTotalRows; i++)
            { 
                Console.SetCursorPosition(startRowPrint - 1, start + i * ConsoleConstants.CharactersPerColPerBoardSquare);
                Console.Write(boardTotalRows - i);

                Console.SetCursorPosition(startRowPrint + boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare, start + i * ConsoleConstants.CharactersPerColPerBoardSquare);
                Console.Write(boardTotalRows - i);

            }


            //TODO: Check this math!
            for (int i = startRowPrint - 2; i < startRowPrint + boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint - 2);
                Console.Write(" ");
            }

            for (int i = startRowPrint - 2; i < startRowPrint + boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint + boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare + 1);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint + boardTotalCols * ConsoleConstants.CharactersPerRowPerBoardSquare + 1, i);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint - 2, i);
                Console.Write(" ");
            }
        }

        public void PrintErrorMessage(string errorMessage)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);

            Console.SetCursorPosition(Console.WindowWidth / 2 - errorMessage.Length / 2, ConsoleConstants.ConsoleRowForPlayerIO);
            Console.Write(errorMessage);
            Thread.Sleep(2500);
           ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
        }
    }
}
