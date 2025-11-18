using System;
using System.Drawing;
using System.Windows.Forms;

namespace BomberMini
{
    public partial class Form1 : Form
    {
        Button[,] map = new Button[9, 9];
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    var btn = new Button();
                    btn.Size = new Size(40, 40);
                    btn.Location = new Point(x * 42, y * 42);
                    btn.Tag = new Point(x, y);
                    btn.Click += Btn_Click;

                    // ランダムで壊せる壁 or 空きスペース
                    btn.BackColor = rand.Next(3) == 0 ? Color.Brown : Color.White;

                    map[x, y] = btn;
                    Controls.Add(btn);
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var pos = (Point)btn.Tag;

            btn.BackColor = Color.Red; // 爆弾設置

            var timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += (s, ev) =>
            {
                Explode(pos.X, pos.Y);
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        void Explode(int x, int y)
        {
            int[][] dirs = new int[][]
            {
        new int[] { 0, 1 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { -1, 0 }
            };

            foreach (var dir in dirs)
            {
                int nx = x + dir[0], ny = y + dir[1];
                if (nx < 0 || ny < 0 || nx >= 9 || ny >= 9) continue;

                var target = map[nx, ny];
                if (target.BackColor == Color.Brown)
                    target.BackColor = Color.White; // 壁破壊
                else
                    target.BackColor = Color.Yellow; // 爆風演出
            }

            map[x, y].BackColor = Color.White; // 爆弾消去
        }
    }
        }