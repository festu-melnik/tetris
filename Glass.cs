using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class LinesRemovedEventHadler
    {
        private int number;

        public int NumberOfDeleteLines { get { return number; } }

        public LinesRemovedEventHadler(int number)
        {
            this.number = number;
        }
    }

    class Glass
    {
        private const int minWidth = 10; // минимальное значение ширины
        private const int minHeight = 20; // минимальное значение высоты

        private const int maxWidth = 25; // максимальное значение ширины
        private const int maxHeight = 50; // максимальное значение высоты

        // Стакан представляет собой двумерный массив из клеток. Число в массиве
        // определяет состояние клетки: 0 - не заполнена, 1, 2,.. - заполнена.
        // Числа, отличные от нуля задают тип клетки. В зависимости от типа, 
        // клетки будут рисоваться по-разному.
        private byte[,] bricks; // "стакан"

        private readonly int width; // ширина "стакана"
        private readonly int height; // высота "стакана

        public event EventHandler<LinesRemovedEventHadler> LinesRemoved;

        /// <summary>
        /// Возвращает ширину "стакана" в клетках.
        /// </summary>
        public int Width { get { return width; } }

        /// <summary>
        /// Возвращает высоту "стакана" в клетках.
        /// </summary>
        public int Height { get { return height; } }

        /// <summary>
        /// Инициализирует новый экземпляр класса TetrisGame.Glass указанного размера.
        /// </summary>
        /// <param name="width">Ширина нового стакана.</param>
        /// <param name="height">Высота нового стакана.</param>
        public Glass(int width, int height)
        {
            if (width < minWidth || width > maxWidth)
                throw new ArgumentOutOfRangeException("width");
            if (height < minHeight || height > maxHeight)
                throw new ArgumentOutOfRangeException("height");
            this.width = width;
            this.height = height;
            this.bricks = new byte[height, width];
        }

        /// <summary>
        /// Возвращает копию массива с информацией о заполненных ячейках "стакана".
        /// </summary>
        /// <returns>Массив, в котором указано, какие ячейки в "стакане" заполнены.</returns>
        public byte[,] GetGlass()
        {
            return (byte[,])bricks.Clone();
        }

        public void PlaceBrick(int x, int y, byte type)
        {
            if(bricks[y, x] == 0)
                bricks[y, x] = type;
        }

        public void RemoveBrick(int x, int y)
        {
            if (bricks[y, x] != 0)
                bricks[y, x] = 0;
        }

        public bool ThereBrick(int x, int y)
        {
            if (x < bricks.GetLowerBound(1) || x > bricks.GetUpperBound(1))
                return true;
            if (y < bricks.GetLowerBound(0) || y > bricks.GetUpperBound(0))
                return true;
            if (bricks[y, x] != 0)
                return true;
            return false;
        }

        public bool ThereBrick(XY[] cArray)
        {
            foreach (XY c in cArray)
                if (ThereBrick(c.X, c.Y))
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
                if (bricks[lineNumber, j] != 0)
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
                if (bricks[lineNumber, j] == 0)
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
                    if (bricks[i, j] != 0)
                        bricks[i, j] = 0;
        }

        /// <summary>
        /// Удаляет заполненные линии.
        /// </summary>
        public void RemoveCompleteLines()
        {
            int num = 0; // количество удаленных линий
            for (int i = bricks.GetUpperBound(0); i >= bricks.GetLowerBound(0); i--)
            {
                if (this.LineIsComplete(i))
                {
                    num++;
                    this.DeleteLine(i);
                }
            }
            if(num > 0)
                OnLinesRemoved(new LinesRemovedEventHadler(num));
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

        private void OnLinesRemoved(LinesRemovedEventHadler e)
        {
            EventHandler<LinesRemovedEventHadler> handler = LinesRemoved;
            if (handler != null)
                handler(this, e);
        }
    }
}
