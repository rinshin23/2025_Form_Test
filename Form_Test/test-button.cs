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
        public test_button(Point position, Size size, string text)
        {
            Location = position;
            Size = size;
            Text = text;
        }
     
        private void  ClickEvent (object sender, EventArgs e) 
        {
            MessageBox.Show("ハト");
        }
    }

}

