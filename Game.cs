using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TetrisGame
{
    class Game
    {
        private Thread thread; // поток для игры
        private Level level; // уровень игры, определяет скорость падения фигурок
        private Glass glass; // "стакан", в который падают фигурки
        private uint score; // заработанные очки
        private bool gameOver; // флаг завершения игры
        private Piece fallingPiece; // падающая фигурка

        public event EventHandler UpdateOutput; //

        public Game()
        {
            thread = new Thread(Action);
            thread.IsBackground = true;
            level = new Level(1, 10);
            glass = new Glass(10, 20);
            score = 0;
            gameOver = false;
        }

        public void Action()
        {
            this.NewPiece();
            this.OnUpdateOutput(EventArgs.Empty);
            Thread.Sleep(1000 / level.CurrentLevel);
            while (!gameOver)
            {
                this.MovePieceDown();
                Thread.Sleep(1000 / level.CurrentLevel);
            }
        }

        /// <summary>
        /// Запускает игру.
        /// </summary>
        public void Start()
        {
            thread.Start();
        }

        /// <summary>
        /// Завершает игру.
        /// </summary>
        public void Stop()
        {

        }

        public bool[,] GetGlassSnapshot()
        {
            return glass.GetGlass();
        }

        private void NewPiece()
        {
            fallingPiece = new T_Piece(glass.Width / 2, glass.Height - 2);
            if (Collision())
            {
                gameOver = true;
                fallingPiece = null;
            }
            else
                fallingPiece.PlaceToGlass(glass);
        }

        /// <summary>
        /// Создает событие, указывающее на необходимость перерисовки "стакана".
        /// </summary>
        /// <param name="e">Аргументы события.</param>
        private void OnUpdateOutput(EventArgs e)
        {
            EventHandler handler = UpdateOutput;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private bool Collision()
        {
            foreach (Coordinates c in fallingPiece.GetLocation())
            {
                if (glass.ThereIsBrick(c.X, c.Y))
                    return true;
            }
            return false;
        }

        public void MovePieceDown()
        {
            if (!gameOver)
            {
                fallingPiece.RemoveFromGlass(glass);
                fallingPiece.MoveDown();
                if (Collision())
                {
                    fallingPiece.MoveUp();
                    fallingPiece.PlaceToGlass(glass);
                    this.NewPiece();
                    score += (uint)(100 * level.CurrentLevel * glass.RemoveCompleteLines());
                    if (score > level.CurrentLevel * 1000)
                        level.LevelUp();
                }
                fallingPiece.PlaceToGlass(glass);
                this.OnUpdateOutput(EventArgs.Empty);
            }
        }

        public void MovePieceRight()
        {
            if (!gameOver)
            {
                fallingPiece.RemoveFromGlass(glass);
                fallingPiece.MoveRight();
                if (Collision())
                    fallingPiece.MoveLeft();
                fallingPiece.PlaceToGlass(glass);
                this.OnUpdateOutput(EventArgs.Empty);
            }
        }

        public void MovePieceLeft()
        {
            if (!gameOver)
            {
                fallingPiece.RemoveFromGlass(glass);
                fallingPiece.MoveLeft();
                if (Collision())
                    fallingPiece.MoveRight();
                fallingPiece.PlaceToGlass(glass);
                this.OnUpdateOutput(EventArgs.Empty);
            }
        }

        public void RotatePiece()
        {
            if (!gameOver)
            {
                fallingPiece.RemoveFromGlass(glass);
                fallingPiece.RotateLeft();
                if (Collision())
                    fallingPiece.RotateRight();
                fallingPiece.PlaceToGlass(glass);
                this.OnUpdateOutput(EventArgs.Empty);
            }
        }
    }
}
