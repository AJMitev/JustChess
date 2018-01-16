namespace JustChess.Common
{
    using System;

    public struct Position
    {
        public static Position FromArrayCordinates(int arrRow, int arrCol, int totalRows)
        {
            return new Position(totalRows - arrRow, (char)(arrCol + 'a'));
        }

        public static Position FromChessCordinates(int chessRow, char chessCol)
        {
            var newPosition = new Position(chessRow, chessCol);
            CheckIfValid(newPosition);

            return newPosition;
        }

        public static void CheckIfValid(Position position)
        {
            if (position.Row < GlobalConstants.MinimumRowValueOnBoard || position.Row > GlobalConstants.MaximumRowValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected row position on the board is not valid!");
            }

            if (position.Col < GlobalConstants.MinimumColValueOnBoard || position.Col > GlobalConstants.MaximumColValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected col position on the board is not valid!");
            }
        } 

        public Position(int row, char col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }
        public char Col { get; private set; }
    }
}
