using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач_1._0
{
    public partial class Form3 : Form
    {
        int n;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            n = 0;
            Form4 f4 = new Form4(n);
            f4.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            n = 0;
            Form10 f10 = new Form10(n);
            f10.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            n = 0;
            Form8 f8 = new Form8(n);
            f8.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            n = 0;
            Form9 f9 = new Form9(n);
            f9.Show();
            this.Hide();
        }
    }
}
