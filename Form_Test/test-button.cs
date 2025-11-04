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
    private Color _onColor = Color.Purple;
    private Color _offColor = Color.White;
        private bool _enable;
        private Form1 _form1;

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




        public test_button(Form1 form1,  Point position, Size size, string text)
        {
            _form1 = form1;

            Location = position;
            Size = size;
            Text = text;

            SetEnable(true);

            Click += Click1Event;
        }
        
        private void  Click1Event (object sender, EventArgs e) 
        {
            _form1.GetTestButton(1, 1).SetEnable(true);
            
        }
    }
    
}

