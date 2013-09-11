using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    abstract class Piece
    {
        // каждая фигурка состоит из нескольких частей
        // поворот фигурки осуществляется с помощью матрицы поворота
        protected Coordinates axis; // координаты центральной точки фигурки в "стакане"
        protected Coordinates[] form; // относительные координаты частей фигурки
        protected Angle angle; // угол поворота

        /// <summary>
        /// Возвращает массив координат всех частей фигурки.
        /// </summary>
        /// <returns>Массив с координатами.</returns>
        public Coordinates[] GetLocation()
        {
            Coordinates[] location = new Coordinates[form.Length];
            for (int i = 0; i < location.Length; i++)
                location[i] = new Coordinates(axis.X + form[i].X, axis.Y + form[i].Y);
            return location;
        }

        /// <summary>
        /// Сдвигает фигурку на единицу вправо.
        /// </summary>
        public void MoveRight()
        {
            axis = new Coordinates(axis.X + 1, axis.Y);
        }

        /// <summary>
        /// Сдвигает фигурку на единицу влево.
        /// </summary>
        public void MoveLeft()
        {
            axis = new Coordinates(axis.X - 1, axis.Y);
        }

        /// <summary>
        /// Сдвигает фигурку на единицу вверх.
        /// </summary>
        public void MoveUp()
        {
            axis = new Coordinates(axis.X, axis.Y + 1);
        }

        /// <summary>
        /// Сдвигает фигурку на единицу вниз.
        /// </summary>
        public void MoveDown()
        {
            axis = new Coordinates(axis.X, axis.Y - 1);
        }

        /// <summary>
        /// Вращает фигурку по часовой стрелке.
        /// </summary>
        public virtual void RotateRight()
        {
            for (int i = 1; i < form.Length; i++)
            {
                int oldX = form[i].X;
                int oldY = form[i].Y;
                int newX = form[i].X * angle.Cos() + form[i].Y * angle.Sin();
                int newY = -form[i].X * angle.Sin() + form[i].Y * angle.Cos();
                form[i] = new Coordinates(newY, newX);
            }
        }

        /// <summary>
        /// Вращает фигурку против часовой стрелки.
        /// </summary>
        public virtual void RotateLeft()
        {
            for (int i = 1; i < form.Length; i++)
            {
                int oldX = form[i].X;
                int oldY = form[i].Y;
                int newX = form[i].X * angle.Cos() - form[i].Y * angle.Sin();
                int newY = form[i].X * angle.Sin() + form[i].Y * angle.Cos();
                form[i] = new Coordinates(newX, newY);
            }
        }

        /// <summary>
        /// Удаляет фигурку из указанного стакана.
        /// </summary>
        /// <param name="glass">Ссылка на экземпляр класса Glass.</param>
        public void RemoveFromGlass(Glass glass)
        {
            Coordinates[] pieceLocation = this.GetLocation();
            foreach (Coordinates c in pieceLocation)
                glass.RemoveBrick(c.X, c.Y);
        }

        /// <summary>
        /// Помещает фигурку в указанный стакан.
        /// </summary>
        /// <param name="glass">Ссылка на экземпляр класса Glass.</param>
        public void PlaceToGlass(Glass glass)
        {
            Coordinates[] pieceLocation = this.GetLocation();
            foreach (Coordinates c in pieceLocation)
                glass.PlaceBrick(c.X, c.Y);
        }
    }
}
