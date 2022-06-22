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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool GameIsRunning = false;

        private void button1_Click(object sender, EventArgs e)
        {
            GameBoard.Size = new Size(600, 600);
            MessageBox.Show(GameBoard.Size.ToString());
            Game myGame = new Game(GameBoard);

            if (GameIsRunning)
            {
                MessageBox.Show("Game has already started");
                return;
            }

            myGame.Start();

            progressBar1.Maximum = 100;
            progressBar1.Value = 100;
            progressBar1.Minimum = 0;

            Thread timer = new Thread(
               new ThreadStart(() =>
               {
                   GameIsRunning = true;


                   while (progressBar1.Value > 1)
                   {
                       Thread.Sleep(200);
                       progressBar1.BeginInvoke(new Action(() =>
                       {
                           progressBar1.Value--;
                       }));
                   }
                   myGame.GameOver();

                   GameIsRunning = false;
               }));
            timer.Start();
        }

    }
}
