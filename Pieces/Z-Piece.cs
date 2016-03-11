using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Pieces
{
    class Z_Piece : Piece
    {
        public Z_Piece()
        {
            form = new XY[2][]
            {
                new XY [4] {new XY(0, 0), new XY(1, 0), new XY(1, -1), new XY(2, -1)},
                new XY [4] {new XY(1, 0), new XY(1, -1), new XY(0, -1), new XY(0, -2)}
            };
            type = 7;
        }
    }
}
