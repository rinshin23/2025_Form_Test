using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{
    internal class test_button : Button
    {
    private Color _onColor = Color.Purple;
    private Color _offColor = Color.White;
        private bool _enable;

        public void SetEnable(bool on)
        {
            _enable = on;
            if (on)
            {
                BackColor = _onColor;
            }
            else
            {
                BackColor = _offColor;
            }
        }




        public test_button(Point position, Size size, string text)
        {
            Location = position;
            Size = size;
            Text = text;

            SetEnable(true);

            Click += Click1Event;
        }
        
        private void  Click1Event (object sender, EventArgs e) 
        {


            MessageBox.Show("ハト");
            SetEnable(!_enable);
        }
    }
    
}

