using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz2
{
    public partial class dz2 : Form
    {
        public dz2()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (sender as NumericUpDown).Value.ToString();
        }

        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.Text = (sender as NumericUpDown).Value.ToString();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            decimal n;             
            decimal.TryParse((sender as TextBox).Text, out n);
            numericUpDown1.Value = n;
        }
    }
}
