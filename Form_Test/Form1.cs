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
    {
        public Form1()
        {
            InitializeComponent();


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                //　インスタンスの生成
                {
                    test_button test_Button = new test_button(new Point(50 * j, 50 * i), new Size(50, 50), "あ");

                    
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
