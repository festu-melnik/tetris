using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    class Glass
    {
        private const int minWidth = 10; // минимальное значение ширины
        private const int minHeight = 20; // минимальное значение высоты

        private const int maxWidth = 25; // максимальное значение ширины
        private const int maxHeight = 50; // максимальное значение высоты

        private bool[,] bricks; // в массиве указываются заполненные ячейки в стакане

        public int Width { get { return bricks.GetLength(1); } }
        public int Height { get { return bricks.GetLength(0); } }

        public Glass(int width, int height)
        {
            if (width < minWidth || width > maxWidth)
                throw new ArgumentOutOfRangeException("width");
            if (height < minHeight || height > maxHeight)
                throw new ArgumentOutOfRangeException("height");
            this.bricks = new bool[height, width];
        }

        /// <summary>
        /// Возвращает копию массива с информацией о заполненных ячейках "стакана".
        /// </summary>
        /// <returns>Массив, в котором указано, какие ячейки в "стакане" заполнены.</returns>
        public bool[,] GetGlass()
        {
            return (bool[,])bricks.Clone();
        }

        public bool PlaceBrick(int x, int y)
        {
            if (OutOfRange(x, y))
                return false;
            if (ThereIsBrick(x, y))
                return false;
            bricks[y, x] = true;
            return true;
        }

        public bool RemoveBrick(int x, int y)
        {
            if (OutOfRange(x, y))
                return false;
            if (!ThereIsBrick(x, y))
                return false;
            bricks[y, x] = false;
            return true;
        }

        public bool ThereIsBrick(int x, int y)
        {
            if (OutOfRange(x, y))
                return true;
            if (bricks[y, x])
                return true;
            return false;
        }

        private bool OutOfRange(int x, int y)
        {
            if (y < bricks.GetLowerBound(0) || y > bricks.GetUpperBound(0))
                return true;
            if (x < bricks.GetLowerBound(1) || x > bricks.GetUpperBound(1))
                return true;
            return false;
        }

        /// <summary>
        /// Проверяет, пуста ли указанная линия в "стакане".
        /// </summary>
        /// <param name="lineNumber">Номер линии, которую нужно проверить.</param>
        /// <returns>Возвращает true, если указанная линия пуста.</returns>
        public bool LineIsBlank(int lineNumber)
        {
            if (lineNumber < bricks.GetLowerBound(0) || lineNumber > bricks.GetUpperBound(0))
                throw new ArgumentOutOfRangeException("lineNumber");
            for (int j = bricks.GetLowerBound(1); j <= bricks.GetUpperBound(1); j++)
            {
                if (bricks[lineNumber, j])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Проверяет, заполнена ли указанная линия в "стакане".
        /// </summary>
        /// <param name="lineNumber">Номер линии, которую нужно проверить.</param>
        /// <returns>Возвращает true, если указанная линия заполнена.</returns>
        public bool LineIsComplete(int lineNumber)
        {
            if (lineNumber < bricks.GetLowerBound(0) || lineNumber > bricks.GetUpperBound(0))
                throw new ArgumentOutOfRangeException("lineNumber");
            for (int j = bricks.GetLowerBound(1); j <= bricks.GetUpperBound(1); j++)
            {
                if (!bricks[lineNumber, j])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Очищает весь "стакан".
        /// </summary>
        public void Clear()
        {
            for (int i = bricks.GetLowerBound(0); i <= bricks.GetUpperBound(0); i++)
                for (int j = bricks.GetLowerBound(1); j <= bricks.GetLowerBound(1); j++)
                    if (bricks[i, j])
                        bricks[i, j] = false;
        }

        /// <summary>
        /// Удаляет заполненные линии.
        /// </summary>
        /// <returns>Количество удаленных линий.</returns>
        public int RemoveCompleteLines()
        {
            int count = 0;
            for (int i = bricks.GetUpperBound(0); i >= bricks.GetLowerBound(0); i--)
            {
                if (this.LineIsComplete(i))
                {
                    count++;
                    this.DeleteLine(i);
                }
            }
            return count;
        }

        /// <summary>
        /// Удаляет указанную линию.
        /// </summary>
        /// <param name="lineNumber">Номер линии, которую нужно удалить.</param>
        private void DeleteLine(int lineNumber)
        {
            if (lineNumber < bricks.GetLowerBound(0) || lineNumber > bricks.GetUpperBound(0))
                throw new ArgumentOutOfRangeException("lineNumber");
            for (int i = lineNumber; i <= bricks.GetUpperBound(0) - 1; i++)
            {
                for (int j = bricks.GetLowerBound(1); j <= bricks.GetUpperBound(1); j++)
                    bricks[i, j] = bricks[i + 1, j];
                if (this.LineIsBlank(i + 1))
                    break;
            }
        }
    }
}
