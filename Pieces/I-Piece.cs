using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame.Pieces
{
    class I_Piece : Piece
    {
        public I_Piece()
        {
            form = new XY[2][]
            {
                new XY [4] {new XY(1, 0), new XY(1, -1), new XY(1, -2), new XY(1, -3)},
                new XY [4] {new XY(0, -1), new XY(1, -1), new XY(2, -1), new XY(3, -1)}
            };
            type = 3;
        }
    }
}
