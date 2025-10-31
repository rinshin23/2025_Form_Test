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


        public Form1()
        {
            InitializeComponent();


            for (int i = 0; i < BOARD_SIZE_X; i++)
            {
                for (int j = 0; j < BOARD_SIZE_Y; j++)
                //　インスタンスの生成
                {
                    test_button test_Button = new test_button(new Point(BUTTUN_SIZE_X * j, BUTTUN_SIZE_Y * i),
                                              new Size(BUTTUN_SIZE_X, BUTTUN_SIZE_Y), "あ");

                    
                    //コントロールにボタンを 追加
                    Controls.Add(test_Button);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ハト");
        }
    }
}
