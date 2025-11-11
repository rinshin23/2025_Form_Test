using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{
    public partial class Form1 : Form
    {//constをつけると初期値のみ変更できる
        const int BUTTUN_SIZE_X = 100;
        const int BUTTUN_SIZE_Y = 100;
        const int BOARD_SIZE_X = 3;
        const int BOARD_SIZE_Y = 3;

        private test_button[,] _buttonArray;
        public Form1()
        {
            InitializeComponent();
            _buttonArray = new test_button[BOARD_SIZE_Y, BOARD_SIZE_X];

            for (int i = 0; i < BOARD_SIZE_X; i++)
            {
                for (int j = 0; j < BOARD_SIZE_Y; j++)
                //　インスタンスの生成
                {
                    test_button test_Button = new test_button(this, i, j,
                        new Point(BUTTUN_SIZE_X * j, BUTTUN_SIZE_Y * i),
                        new Size(BUTTUN_SIZE_X, BUTTUN_SIZE_Y), "");
                    _buttonArray[i, j] = test_Button;




                    //コントロールにボタンを 追加
                    Controls.Add(test_Button);
                }
            }
            Random();

        }
        private void Random()
        {
            Random rand = new Random();

            for (int x = 0; x < BOARD_SIZE_X; x++)
            {
                for (int y = 0; y < BOARD_SIZE_Y; y++)
                {
                    _buttonArray[x, y].SetEnable(rand.Next(2) == 0);
                }
            }
        }
        public void CheckClear()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (!_buttonArray[x, y].IsEnabled()) return;
                }
            }

            MessageBox.Show("クリア！");
            Random();
        }

        public test_button GetTestButton(int x, int y)
        {
            if (x < 0 || x >= BOARD_SIZE_X)return null;
            if (y < 0 || y >= BOARD_SIZE_Y)return null;
            return _buttonArray[x,y];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ハト");
        }
    }
}
