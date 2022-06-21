using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickoMania
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Game myGame = new Game(this);
            myGame.Start();
            //progressBar1.Maximum = 100;
            //progressBar1.Value = 100;
            //progressBar1.Minimum = 0;
            //while (progressBar1.Value !=0)
            //{
            //    System.Threading.Thread.Sleep(200);
            //    progressBar1.Value--;
            //}
        }
    }

    public class Game
    {
        private uint _level;
        private Form _board;
            
        public Game(Form board)
        {
            this._board = board;
        }

        public void Start(int level = 1)
        {
            this.GenerateBlocks(level);
        }

        public void NextLevel()
        {
            _level++;
        }

        private void GenerateBlocks(int level)
        {
            int n = level + 2;
            PictureBox[] pb = new PictureBox[n];
            for (int i = 0; i < n; i++)
            {
                pb[i] = new PictureBox();
                pb[i].Parent = this._board;
                pb[i].Width = this._board.Width / this._GetNumberOfTiles();
                pb[i].Height = this._board.Height / this._GetNumberOfTiles();
                pb[i].Top = _board.Height / 2;
                pb[i].Left = _board.Width / 2;
                pb[i].BackColor = Color.Chocolate;
            }
        }

        private int _GetNumberOfTiles()
        {
            switch (_level)
            {
                case 1:
                    return 3;
                case 2:
                    return 5;
                case 3:
                    return 9;
                case 4:
                    return 12;
                case 5:
                    return 15;
            }

            return 3;
        }
    }
}
