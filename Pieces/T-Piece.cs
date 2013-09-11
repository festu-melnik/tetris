using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    class T_Piece : Piece
    {
        public T_Piece(int start_x, int start_y)
        {
            axis = new Coordinates(start_x, start_y);
            form = new Coordinates[4];
            form[0] = new Coordinates(0, 0);
            form[1] = new Coordinates(0, 1);
            form[2] = new Coordinates(1, 0);
            form[3] = new Coordinates(-1, 0);
            angle = new Angle(1);
        }
    }
}
