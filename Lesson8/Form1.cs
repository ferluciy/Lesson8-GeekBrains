using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BT_Start_Click(object sender, EventArgs e)
        {
            Type type1 = typeof(DateTime);
            DateTime datatime = DateTime.Now;

                PropertyInfo[] propertyInfo = type1.GetProperties();
            TB_Result.Clear();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                //выводим название свойства и пример значения 
                TB_Result.Text += propertyInfo[i].Name + " - " + propertyInfo[i].GetValue(datatime).ToString() + "\r" + "\n";
            }
        }
    }
}
