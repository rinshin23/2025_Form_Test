using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BomberMini
{
    public partial class Form1 : Form
    {
        Button[,] map = new Button[9, 9];
        Random rand = new Random();
        bool bombPlaced = false;

        PictureBox player;
        Point playerPos;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Shown += (s, e) => this.Focus(); // フォーカスを強制
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // マップ生成
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    var btn = new Button();
                    btn.Size = new Size(40, 40);
                    btn.Location = new Point(x * 42, y * 42);
                    btn.Tag = new Point(x, y);
                    btn.BackColor = rand.Next(3) == 0 ? Color.Brown : Color.White;
                    map[x, y] = btn;
                    Controls.Add(btn);
                }
            }

            // プレイヤー初期位置
            playerPos = new Point(0, 0);
            player = new PictureBox();
            player.Size = new Size(40, 40);
            player.BackColor = Color.Blue;
            player.Location = map[playerPos.X, playerPos.Y].Location;
            Controls.Add(player);

            // キー入力設定
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = playerPos.X;
            int y = playerPos.Y;

            if (e.KeyCode == Keys.Up && y > 0) y--;
            if (e.KeyCode == Keys.Down && y < 8) y++;
            if (e.KeyCode == Keys.Left && x > 0) x--;
            if (e.KeyCode == Keys.Right && x < 8) x++;

            if (map[x, y].BackColor != Color.Brown)
            {
                playerPos = new Point(x, y);
                player.Location = map[x, y].Location;
            }

            if (e.KeyCode == Keys.Space)
            {
                PlaceBomb(playerPos.X, playerPos.Y);
            }
        }

        private void PlaceBomb(int x, int y)
        {
            if (bombPlaced) return;
            if (x < 0 || y < 0 || x >= 9 || y >= 9) return;

            var btn = map[x, y];
            if (btn == null || btn.BackColor == Color.Red) return;

            btn.BackColor = Color.Red;
            bombPlaced = true;

            var timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += (s, ev) =>
            {
                Explode(x, y);
                bombPlaced = false;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        void Explode(int x, int y)
        {
            List<Button> affected = new List<Button>();

            int[][] dirs = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 0, -1 },
                new int[] { -1, 0 }
            };

            for (int i = 0; i < dirs.Length; i++)
            {
                for (int step = 1; step <= 2; step++)
                {
                    int nx = x + dirs[i][0] * step;
                    int ny = y + dirs[i][1] * step;
                    if (nx < 0 || ny < 0 || nx >= 9 || ny >= 9) break;

                    var target = map[nx, ny];
                    if (target.BackColor == Color.Brown)
                    {
                        target.BackColor = Color.White;
                        break;
                    }
                    else
                    {
                        target.BackColor = Color.Yellow;
                        affected.Add(target);
                    }
                }
            }

            map[x, y].BackColor = Color.White;

            var clearTimer = new Timer();
            clearTimer.Interval = 300;
            clearTimer.Tick += (s, e) =>
            {
                foreach (var b in affected)
                    b.BackColor = Color.White;

                clearTimer.Stop();
                clearTimer.Dispose();
            };
            clearTimer.Start();
        }
    }
}