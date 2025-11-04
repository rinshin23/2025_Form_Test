using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{
    public class test_button : Button
    {
    private Color _onColor = Color.Red;
    private Color _offColor = Color.Blue;
        private bool _enable;
        private Form1 _form1;
        private int _x;
        private int _y;

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
         public void Toggle()
        {
            SetEnable(!_enable);
        }



        public test_button(Form1 form1,int x,int y,  Point position, Size size, string text)
        {
            _form1 = form1;

            _x = x;
            _y = y;


            Location = new Point(x * size.Width, y * size.Height);
            Size = size;
            Text = text;

            SetEnable(false);

            Click += Click1Event;
        }
        
        private void  Click1Event (object sender, EventArgs e) 
        {
            _form1.GetTestButton(_x,_y)?.Toggle();
            _form1.GetTestButton(_x+1, _y)?.Toggle();
            _form1.GetTestButton(_x-1, _y)?.Toggle();
            _form1.GetTestButton(_x, _y+1)?.Toggle();
            _form1.GetTestButton(_x, _y-1)?.Toggle();



        }
    }
    
}

