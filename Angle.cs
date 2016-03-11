using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Angle
    {
        // Для простоты угол задается четвертями, таким образом можно задать
        // 0, 90, 270, 360 углы.
        const int minNumber = 0;
        const int maxNumber = 3;

        int numberOfQuarters; // количество четвертей

        public Angle(int numberOfQuarters)
        {
            if (numberOfQuarters < minNumber || numberOfQuarters > maxNumber)
                throw new ArgumentOutOfRangeException("numberOfQuarters");
            this.numberOfQuarters = numberOfQuarters;
        }

        public int Sin()
        {
            switch (numberOfQuarters)
            {
                case 0: return 0;
                case 1: return 1;
                case 2: return 0;
                case 3: return -1;
                default: return 0;
            }
        }
        public int Cos()
        {
            switch (numberOfQuarters)
            {
                case 0: return 1;
                case 1: return 0;
                case 2: return -1;
                case 3: return 0;
                default: return 1;
            }
        }
    }
}
