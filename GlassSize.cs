using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    struct GlassSize
    {
        private const byte minWidth = 10; // минимальное значение ширины
        private const byte minHeight = 20; // минимальное значение высоты

        private const byte maxWidth = 25; // максимальное значение ширины
        private const byte maxHeight = 50; // максимальное значение высоты

        private byte width; // ширина
        private byte height; // высота

        public byte Width
        {
            get
            {
                return width;
            }
        }

        public byte Height
        {
            get
            {
                return height;
            }
        }

        public GlassSize(byte width, byte height)
        {
            if (width < minWidth || width > maxWidth)
                throw new ArgumentOutOfRangeException("width");
            if (height < minHeight || height > maxHeight)
                throw new ArgumentOutOfRangeException("height");
            this.width = width;
            this.height = height;
        }
    }
}
