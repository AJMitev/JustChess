namespace JustChess.Common
{
    public struct Position
    {
        public static Position FromArrayCordinates(int arrRow, int arrCol, int totalRows)
        {
            return new Position(totalRows - arrRow, (char)(arrCol + 'a'));
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
