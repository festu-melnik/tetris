using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tetris
{
    class Game
    {
        private Thread thread; // поток для игры
        private Level level; // уровень игры, определяет скорость падения фигурок
        private Glass glass; // "стакан", в который падают фигурки
        private int score; // заработанные очки
        private bool gameOver; // флаг завершения игры
        private bool gamePaused; // флаг приостановки игры
        private Piece fallingPiece; // падающая фигурка
        private Piece nextPiece; // следующая фигурка
        private XY defPosition; // позиция фигурки по-умолчанию

        public event EventHandler UpdateOutput; //

        public bool GameOver { get { return gameOver; } }

        public bool Paused { get { return gamePaused; } }

        public int Score { get { return score; } }
        public int Level { get { return level.CurrentLevel; } }

        public byte NextType { get { return nextPiece.Type; } }
        public XY[] NextPosition { get { return nextPiece.GetPosition(); } }

        public Game()
        {
            thread = new Thread(Action);
            thread.IsBackground = true;
            level = new Level(1, 10);
            glass = new Glass(10, 20);
            glass.LinesRemoved += glass_LinesRemoved;
            defPosition = new XY(4, 19);
            gameOver = false;
        }

        private void glass_LinesRemoved(object sender, LinesRemovedEventHadler e)
        {
            score += e.NumberOfDeleteLines * 100 * level.CurrentLevel;
            if (score > 1000 * level.CurrentLevel * level.CurrentLevel)
                level.LevelUp();
        }

        private void Action()
        {
            NewPiece();
            Thread.Sleep(1000 / level.CurrentLevel);
            while (!gameOver)
            {
                if(!gamePaused)
                    MovePieceDown();
                Thread.Sleep(1000 / level.CurrentLevel);
            }
        }

        /// <summary>
        /// Создает и запускает новую игру.
        /// </summary>
        public void NewGame()
        {
            thread.Start();
        }

        /// <summary>
        /// Останавливает или возобновляет игру.
        /// </summary>
        public void Pause()
        {
            if(!gameOver)
                gamePaused = !gamePaused;
            OnUpdateOutput(EventArgs.Empty);
        }

        /// <summary>
        /// Возвращает слепок состояния игрового стакана.
        /// </summary>
        /// <returns>Двумерный массив целочисленных значений.</returns>
        public byte[,] GetGlassSnapshot()
        {
            return glass.GetGlass();
        }

        /// <summary>
        /// Создает новую фигурку в игровом стакане.
        /// </summary>
        private void NewPiece()
        {
            if (nextPiece == null)
                nextPiece = RandomPiece();
            fallingPiece = nextPiece;
            nextPiece = RandomPiece();
            if (!fallingPiece.PlaceToGlass(glass, defPosition))
                gameOver = true;
            OnUpdateOutput(EventArgs.Empty);
        }

        /// <summary>
        /// Возвращает случайную фигурку.
        /// </summary>
        /// <returns>Объект класса Piece.</returns>
        private Piece RandomPiece()
        {
            Random rnd = new Random();
            switch (rnd.Next(7))
            {
                case 0:
                    return new Pieces.T_Piece();
                case 1:
                    return new Pieces.O_Piece();
                case 2:
                    return new Pieces.I_Piece();
                case 3:
                    return new Pieces.J_Piece();
                case 4:
                    return new Pieces.L_Piece();
                case 5:
                    return new Pieces.S_Piece();
                case 6:
                    return new Pieces.Z_Piece();
                default:
                    return new Pieces.T_Piece();
            }
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

        public void MovePieceDown()
        {
            if (!gameOver && !gamePaused)
            {
                if (!fallingPiece.Offset(0, -1))
                {
                    glass.RemoveCompleteLines();
                    NewPiece();
                }
                this.OnUpdateOutput(EventArgs.Empty);
            }
        }

        public void MovePieceRight()
        {
            if (!gameOver && !gamePaused)
            {
                fallingPiece.Offset(1, 0);
                this.OnUpdateOutput(EventArgs.Empty);
            }
        }

        public void MovePieceLeft()
        {
            if (!gameOver && !gamePaused)
            {
                fallingPiece.Offset(-1, 0);
                this.OnUpdateOutput(EventArgs.Empty);
            }
        }

        public void RotatePiece()
        {
            if (!gameOver && !gamePaused)
            {
                fallingPiece.Rotate();
                this.OnUpdateOutput(EventArgs.Empty);
            }
        }
    }
}
