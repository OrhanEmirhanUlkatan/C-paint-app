using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cakmaPaint
{
    public partial class boyutForm : Form
    {
        Form1 s;
        public boyutForm(Form1 f)
        {
            InitializeComponent();
            s = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null || textBox2.Text != null)
            {
                bool yapildi = s.BoyutDegistir(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                if (yapildi == true)
                {
                    this.Close();
                }
            }
        }
    }
}
