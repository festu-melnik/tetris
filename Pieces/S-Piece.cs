using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame.Pieces
{
    class S_Piece : Piece
    {
        public S_Piece()
        {
            form = new XY[2][]
            {
                new XY [4] {new XY(0, -1), new XY(1, -1), new XY(1, 0), new XY(2, 0)},
                new XY [4] {new XY(0, 0), new XY(0, -1), new XY(1, -1), new XY(1, -2)}
            };
            type = 6;
        }
    }
}
