namespace JustChess.Common
{
    public struct Position
    {
        public Position(int row, char col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }
        public char Col { get; private set; }
    }
}
