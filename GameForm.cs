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
        private Dictionary<byte, Color> colors;

        public GameForm()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void AddColors()
        {
            colors = new Dictionary<byte, Color>();
            colors.Add(1, Color.DeepSkyBlue);
            colors.Add(2, Color.OrangeRed);
            colors.Add(3, Color.DarkOliveGreen);
            colors.Add(4, Color.LightSkyBlue);
            colors.Add(5, Color.DarkRed);
            colors.Add(6, Color.DarkSeaGreen);
            colors.Add(7, Color.Orange);
        }

        private void StartNewGame()
        {
            AddColors();
            if (currentGame != null)
                currentGame.UpdateOutput -= currentGame_Update;
            currentGame = new Game();
            currentGame.UpdateOutput += currentGame_Update;
            currentGame.NewGame();
        }

        private void ShowInfo()
        {
            PauseGame();
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void PauseGame()
        {
            if (currentGame != null)
                currentGame.Pause();
        }

        private void currentGame_Update(object sender, EventArgs e)
        {
            gamePBox.Invalidate();
            nextPBox.Invalidate();
            statGBox.Invalidate();
        }

        private void gamePBox_Paint(object sender, PaintEventArgs e)
        {
            if (currentGame != null)
            {
                byte[,] currentGlass = currentGame.GetGlassSnapshot();
                int w = gamePBox.Width / currentGlass.GetLength(1);
                int h = gamePBox.Height / currentGlass.GetLength(0);
                for (int i = currentGlass.GetLowerBound(0); i <= currentGlass.GetUpperBound(0); i++)
                {
                    for (int j = currentGlass.GetLowerBound(1); j <= currentGlass.GetUpperBound(1); j++)
                    {
                        byte type = currentGlass[i, j];
                        if (type != 0)
                        {
                            Pen p = new Pen(Color.Black);
                            SolidBrush br = new SolidBrush(colors[type]);
                            int x = j * w;
                            int y = (currentGlass.GetUpperBound(0) - i) * h;
                            e.Graphics.DrawRectangle(p, x, y, w, h);
                            e.Graphics.FillRectangle(br, x + 3, y + 3, w - 6, h - 6);
                            p.Dispose();
                            br.Dispose();
                        }
                    }
                }
                if (currentGame.GameOver)
                {
                    Font strFont = new Font("Arial", 24);
                    SolidBrush strBrush = new SolidBrush(Color.IndianRed);
                    StringFormat strForm = new StringFormat();
                    strForm.Alignment = StringAlignment.Center;
                    e.Graphics.DrawString("GAME OVER", strFont, strBrush, gamePBox.DisplayRectangle, strForm);
                    strFont.Dispose();
                    strBrush.Dispose();
                }
                if (currentGame.Paused)
                {
                    Font strFont = new Font("Arial", 24);
                    SolidBrush strBrush = new SolidBrush(Color.DeepSkyBlue);
                    StringFormat strForm = new StringFormat();
                    strForm.Alignment = StringAlignment.Center;
                    e.Graphics.DrawString("GAME PAUSED", strFont, strBrush, gamePBox.DisplayRectangle, strForm);
                    strFont.Dispose();
                    strBrush.Dispose();
                }
            }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentGame != null)
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

            if (e.KeyCode == Keys.F2)
                StartNewGame();
            if (e.KeyCode == Keys.F3)
                PauseGame();
            if (e.KeyCode == Keys.F1)
                ShowInfo();
            if (e.KeyCode == Keys.F4)
                Close();
        }

        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //    currentGame.RotatePiece();
            //if (e.KeyCode == Keys.Left)
            //    currentGame.MovePieceLeft();
        }

        private void nextPBox_Paint(object sender, PaintEventArgs e)
        {
            if (currentGame != null)
            {
                int w = 16;
                int h = 16;
                XY[] next = currentGame.NextPosition;
                byte type = currentGame.NextType;
                Pen p = new Pen(Color.Black);
                SolidBrush br = new SolidBrush(colors[type]);
                for (int i = 0; i < next.Length; i++)
                {
                    int x = next[i].X * w + 2 * w;
                    int y = -next[i].Y * h + 2 * h;
                    e.Graphics.DrawRectangle(p, x, y, w, h);
                    e.Graphics.FillRectangle(br, x + 3, y + 3, w - 6, h - 6);
                }
            }
        }

        private void statGBox_Paint(object sender, PaintEventArgs e)
        {
            if (currentGame != null)
            {
                scoreL.Text = String.Format("Очки: {0}", currentGame.Score);
                levelL.Text = String.Format("Уровень: {0}", currentGame.Level);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInfo();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
