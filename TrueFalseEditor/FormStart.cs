using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueFalseEditor
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditorStart_Click(object sender, EventArgs e)
        {
            Form form2 = new Main();
            this.Hide();
            form2.Show();            
        }

        private void btnGameStart_Click(object sender, EventArgs e)
        {
            Form form3 = new FormGame();
            this.Hide();
            form3.Show();
        }
    }
}
