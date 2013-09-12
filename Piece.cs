using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    abstract class Piece
    {
        protected Glass glass; // "стакан", в котором находится фигурка
        protected XY location; // координаты левого верхнего угла фигурки в "стакане"
        protected byte type; // тип фигурки

        protected XY[][] form; // массив содержит все возможные формы одной фигуры

        public byte Type { get { return type; } }

        public bool PlaceToGlass(Glass glass, XY location)
        {
            if (this.glass != null)
                Hide();
            this.glass = glass;
            this.location = location;
            if(glass.ThereBrick(GetPosition()))
                return false;
            Show();
            return true;
        }

        /// <summary>
        /// Возвращает массив координат всех частей фигурки.
        /// </summary>
        /// <returns>Массив с координатами.</returns>
        public XY[] GetPosition()
        {
            XY[] position = new XY[form[0].Length];
            for (int i = 0; i < position.Length; i++)
                position[i] = new XY(location.X + form[0][i].X, location.Y + form[0][i].Y);
            return position;
        }

        /// <summary>
        /// Сдвигает фигурку по оям на указанную величину.
        /// </summary>
        /// <param name="dX">Смещение по горизонтальной оси.</param>
        /// <param name="dY">Смещение по вертикальной оси.</param>
        /// <returns></returns>
        public bool Offset(int dX, int dY)
        {
            XY[] testPos = new XY[form[0].Length];
            for (int i = 0; i < testPos.Length; i++)
                testPos[i] = new XY(location.X + dX + form[0][i].X, location.Y + dY + form[0][i].Y);
            Hide();
            if (!glass.ThereBrick(testPos))
            {
                location = new XY(location.X + dX, location.Y + dY);
                Show();
                return true;
            }
            Show();
            return false;
        }

        /// <summary>
        /// Вращает фигурку.
        /// </summary>
        public bool Rotate()
        {
            if (form.Length > 1)
            {
                XY[] testPos = new XY[form[1].Length];
                for (int i = 0; i < testPos.Length; i++)
                    testPos[i] = new XY(location.X + form[1][i].X, location.Y + form[1][i].Y);
                Hide();
                if (!glass.ThereBrick(testPos))
                {
                    for (int i = 1; i < form.Length; i++)
                    {
                        XY[] tmp = form[i - 1];
                        form[i - 1] = form[i];
                        form[i] = tmp;
                    }
                    Show();
                    return true;
                }
                Show();
            }
            return false;
        }

        /// <summary>
        /// Удаляет фигурку из стакана.
        /// </summary>
        protected void Hide()
        {
            XY[] pieceLocation = this.GetPosition();
            foreach (XY c in pieceLocation)
                glass.RemoveBrick(c.X, c.Y);
        }

        /// <summary>
        /// Помещает фигурку в стакан.
        /// </summary>
        protected void Show()
        {
            XY[] pieceLocation = this.GetPosition();
            foreach (XY c in pieceLocation)
                glass.PlaceBrick(c.X, c.Y, type);
        }
    }
}
