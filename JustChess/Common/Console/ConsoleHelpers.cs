﻿namespace JustChess.Common.Console
{
    using System;
    using System.Collections.Generic;

    using Figures;
    using Figures.Contracts;

    public static class ConsoleHelpers
    {
        private static IDictionary<string, bool[,]> patterns = new Dictionary<string, bool[,]>
        {
            {"Pawn", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, false, false, false, false, false, false, false }
                }
            },
            {"Rook", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, true, false, true, false, true, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, false, false, false, false, false, false, false }
                }
            },
            {"Knight", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false,false, true, true, false, false, false },
                    {false, false, false, true, true, true, true, false, false },
                    {false, false, true, true, true, false, true, false, false },
                    {false, false, false, true, false, true, true, false, false },
                    {false, false, false, false, true, true, true, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, false, false, false, false, false, false, false }
                }
            },
            {"Bishop", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, false, true, true, false, true, true, false, false },
                    {false, false, true, false, false, false, true, false, false },
                    {false, false, false, true, false, true, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, true, true, true, false, true, true, true, false },
                    {false, false, false, false, false, false, false, false, false }
                }
            },
            {"King", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, false, false, true, true, true, false, false, false },
                    {false, true, true, false, true, false, true, true, false },
                    {false, true, true, true, false, true, true, true, false },
                    {false, true, true, true, true, true, true, true, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, false, false, false, false, false, false, false }
                }
            },
            {"Queen", new bool[,]
                {
                    {false, false, false, false, false, false, false, false, false },
                    {false, false, false, false, true, false, false, false, false },
                    {false, false, true, false, true, false, true, false, false },
                    {false, false, false, true, false, true, false, false, false },
                    {false, true, false, true, true, true, false, true, false },
                    {false, false, true, false, true, false, true, false, false },
                    {false, false, true, true, false, true, true, false, false },
                    {false, false, true, true, true, true, true, false, false },
                    {false, false, false, false, false, false, false, false, false }
                }
            }

        };

        public static void SetCursorAtCenter(int lengthOfMessage)
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = Console.WindowWidth / 2 - lengthOfMessage / 2;
            Console.SetCursorPosition(centerCol, centerRow);
        }

        public static void PrintFIgure(IFigure figure, ConsoleColor backgroundColor, int top, int left)
        {
            if (figure == null)
            {
                PrintEmptySquare(backgroundColor, top, left);
                return;
            }

            if (!patterns.ContainsKey(figure.GetType().Name))
            {
                return;
            }

            var figurePattern = patterns[figure.GetType().Name];


            for (int i = 0; i < figurePattern.GetLength(0); i++)
            {
                for (int j = 0; j < figurePattern.GetLength(1); j++)
                {
                    Console.SetCursorPosition(left + j, top + i);

                    if (figurePattern[i, j])
                    {
                        Console.BackgroundColor = figure.Color.ToConsoleColor();
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundColor;
                    }
                    Console.WriteLine(" ");
                }
            }
        }

        public static ConsoleColor ToConsoleColor(this ChessColor chessColor)
        {
            switch (chessColor)
            {
                case ChessColor.Black:
                    return ConsoleColor.Black;
                case ChessColor.White:
                    return ConsoleColor.White;
                default:
                    throw new InvalidOperationException("Cannot convert chess color");
            }
        }

        public static void PrintEmptySquare(ConsoleColor backgroundColor, int top, int left)
        {
            for (int i = 0; i < ConsoleConstants.CharactersPerRowPerBoardSquare; i++)
            {
                for (int j = 0; j < ConsoleConstants.CharactersPerColPerBoardSquare; j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    Console.WriteLine(" ");
                }
            }
        }


        /// <summary>
        ///  Command should be in format : a5-c5
        /// </summary>
        public static Move CreateMoveFromCommand(string command)
        {
            var positionAsStringParts = command.Split('-');

            if (positionAsStringParts.Length != 2)
            {
                throw new InvalidOperationException("Invalid command!");
            }


            var fromAsString = positionAsStringParts[0];
            var toAsString = positionAsStringParts[1];

            var fromPostiion = Position.FromChessCordinates(fromAsString[1] - '0', fromAsString[0]);
            var toPosition = Position.FromChessCordinates(toAsString[1] - '0', toAsString[0]);

            return new Move(fromPostiion, toPosition);
        }

        public static void ClearRow(int row)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, row);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }

}
