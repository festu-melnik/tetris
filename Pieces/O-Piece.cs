using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Pieces
{
    class O_Piece : Piece
    {
        public O_Piece()
        {
            form = new XY[1][]
            {
                new XY [4] {new XY(0, 0), new XY(0, -1), new XY(1 , 0), new XY(1, -1)}
            };
            type = 1;
        }
    }
}
