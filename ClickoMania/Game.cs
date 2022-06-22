using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ClickoMania
{
    class Game
    {
        private uint _level;
        private GroupBox _board;
        private List<PictureBox> tiles;
        private List<Color> colors;
        private Random r ;
        private int score;

        public Game(GroupBox board)
        {
            this._board = board;
            colors = new List<Color>()
            {
                Color.Aqua,
                Color.Brown,
                Color.Chartreuse,
                Color.Crimson,
                Color.Orange,
                Color.Indigo,
            };
            r = new Random();
            _level = 1;
            score = 0;
        }

        public void Start(uint level = 1)
        {
            //this.StartTimer(level);
            this.GenerateBlocks(level);
        }

        public void NextLevel()
        {
            _level++;
            this.Start(_level);
            ProgressBar progressBar1 = Application.OpenForms["Form1"].Controls["progressBar1"] as ProgressBar;
            
            progressBar1.BeginInvoke(new Action(() =>
            {
                progressBar1.Value = progressBar1.Maximum;
            }));
        }

        private void GenerateBlocks(uint level)
        {
            int n = _GetNumberOfTiles(level);
            tiles = new List<PictureBox>(n);
            int width, height, gap;
            gap = 10;
            width = height = (int)((_board.Width - (level+2)*gap) / (level+2));
            for (int i = 0; i < level + 2; i++)
            {
                for (int j = 0; j < level + 2; j++)
                {
                    PictureBox tmp = new PictureBox();
                    tmp.Parent = _board;
                    tmp.Width = width;
                    tmp.Height = height;
                    tmp.Top = i * (width + gap) +gap/2;
                    tmp.Left = j * (width + gap) + gap/2;
                    tmp.BackColor = GetRandomColor();
                    tmp.Click += myPictureBox_Click;
                    tiles.Add(tmp);
                }
            }
        }
        private void myPictureBox_Click(object sender, EventArgs e)
        {
            score++;
            PictureBox p = (PictureBox)sender;
            p.Visible = false;
            tiles.Remove(p);
            if (tiles.Count == 0)
                NextLevel();
        }

        private int _GetNumberOfTiles(uint level)
        {
            return ((int)level+2)* ((int)level + 2);
        }

        public void GameOver()
        {
            foreach (PictureBox p in tiles)
            {
                p.Visible = false;
            }
            tiles.Clear();
            MessageBox.Show("Game Over\nYour Score is: " + score);
        }

        private Color GetRandomColor()
        {
            return colors[r.Next(0, colors.Count - 1)];
        }
    }
}
