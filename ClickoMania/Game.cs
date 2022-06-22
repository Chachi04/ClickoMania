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
        List<PictureBox> tiles;

        public Game(GroupBox board)
        {
            this._board = board;
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
        }

        private void GenerateBlocks(uint level)
        {
            MessageBox.Show(_board.Size.ToString());
            int n = _GetNumberOfTiles(level);
            tiles = new List<PictureBox>(n);
            int width, height, gap;
            width = height = (_board.Width - 10) / n;
            gap = 10;
            int row = 0, col = 0;
            for (int i = 0; i < n; i++)
            {
                PictureBox tmp = new PictureBox();
                tmp.Parent = this._board;
                tmp.Width = width;
                tmp.Height = height;
                tmp.Top = row * (width + gap);
                tmp.Left = col * (height + gap);
                tmp.BackColor = Color.Chocolate;
                tmp.Click += myPictureBox_Click;
                tiles.Add(tmp);
                if (col < level+2) col++;
                else
                {
                    col = 0;
                    row++;
                }
            }
        }
        private void myPictureBox_Click(object sender, EventArgs e)
        {
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
            MessageBox.Show("Game Over");
        }
    }
}
