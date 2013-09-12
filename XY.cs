namespace TetrisGame
{
    struct XY
    {
        private int abcissa;
        private int ordinate;

        public int X { get { return abcissa; } }
        public int Y { get { return ordinate; } }

        public XY(int x, int y)
        {
            this.abcissa = x;
            this.ordinate = y;
        }
    }
}
