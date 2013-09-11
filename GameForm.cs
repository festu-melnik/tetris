using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisGame
{
    public partial class GameForm : Form
    {
        private Game currentGame;

        public GameForm()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentGame != null)
            {
                currentGame.Stop();
                currentGame.UpdateOutput -= new EventHandler(currentGame_Update);
            }
            currentGame = new Game();
            currentGame.UpdateOutput += new EventHandler(currentGame_Update);
            currentGame.Start();
        }

        private void currentGame_Update(object sender, EventArgs e)
        {
            gamePBox.Invalidate();
        }

        private void gamePBox_Paint(object sender, PaintEventArgs e)
        {
            if (currentGame != null)
            {

                bool[,] currentGlass = currentGame.GetGlassSnapshot();
                int w = gamePBox.Width / currentGlass.GetLength(1);
                int h = gamePBox.Height / currentGlass.GetLength(0);
                for (int i = currentGlass.GetLowerBound(0); i <= currentGlass.GetUpperBound(0); i++)
                {
                    for (int j = currentGlass.GetLowerBound(1); j <= currentGlass.GetUpperBound(1); j++)
                    {
                        if (currentGlass[i, j])
                        {
                            int x = j * w;
                            int y = (currentGlass.GetUpperBound(0) - i) * h;
                            e.Graphics.DrawRectangle(new Pen(Brushes.Black), x, y, w, h);
                            e.Graphics.DrawRectangle(new Pen(Brushes.Red), x + 5, y + 5, w - 10, h - 10);
                        }
                    }
                }
            }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                currentGame.RotatePiece();
            if (e.KeyCode == Keys.Down)
                currentGame.MovePieceDown();
            if (e.KeyCode == Keys.Left)
                currentGame.MovePieceLeft();
            if (e.KeyCode == Keys.Right)
                currentGame.MovePieceRight();

        }

        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //    currentGame.RotatePiece();
            //if (e.KeyCode == Keys.Left)
            //    currentGame.MovePieceLeft();
        }


    }
}
