using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz4
{
    public partial class Main : Form
    {
        birthday database;
        string NameProg = "Дни рождения";
        public Main()
        {
            InitializeComponent();
        }
        public void CheckProgram()
        {
            if (database != null)
            {
                groupBox1.Enabled = true;
                panel1.Enabled = true;
                menuItemSave.Enabled = true;
                menuItemSaveAs.Enabled = true;
            }
            if (nudNumber.Maximum > 1) btnDelete.Enabled = true;
            else btnDelete.Enabled = false;
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "User|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new birthday(dlg.FileName);
                database.Add("-", "-", DateTime.Now);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                CheckProgram();
                FileInfo fl = new FileInfo(dlg.FileName);
                this.Text = NameProg + " | База \"" + fl.Name + "\"";
            }
           
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "User|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new birthday(dlg.FileName);
                try
                {
                    database.Load();
                }
                catch
                {
                    database = null;
                    DialogResult dialogResult = MessageBox.Show("Ошибка при открытии файла. Убедитесь, что выбран корректный файл xml.\nХотите открыть другой файл?", NameProg,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        menuItemOpen_Click(sender, e);
                        return;
                    }
                    else return;
                }
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                textBoxFirstName.Text = database[(int)nudNumber.Value - 1].FirstName;
                textBoxLastName.Text = database[(int)nudNumber.Value - 1].LastName;
                dateTimeBirthday.Value = database[(int)nudNumber.Value - 1].datetime;

                FileInfo fl = new FileInfo(dlg.FileName);
                this.Text = NameProg + " | База \"" + fl.Name + "\"";
                CheckProgram();
            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            database.Save();
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "User|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database.Save(dlg.FileName);
                FileInfo fl = new FileInfo(dlg.FileName);
                this.Text = NameProg + " | База \"" + fl.Name + "\"";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            database.Add("-", "-", DateTime.Now);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            database[(int)nudNumber.Value - 1].FirstName = textBoxFirstName.Text;
            database[(int)nudNumber.Value - 1].LastName = textBoxLastName.Text;
            database[(int)nudNumber.Value - 1].datetime = dateTimeBirthday.Value;
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            textBoxFirstName.Text = database[(int)nudNumber.Value - 1].FirstName;
            textBoxLastName.Text = database[(int)nudNumber.Value - 1].LastName;
            dateTimeBirthday.Value = database[(int)nudNumber.Value - 1].datetime;
            CheckProgram();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            nudNumber.DownButton();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            nudNumber.UpButton();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            database.Remove((int)nudNumber.Value - 1);
            if (nudNumber.Value > 1) nudNumber.Value--;
            else
            {
                textBoxFirstName.Text = database[(int)nudNumber.Value - 1].FirstName;
                textBoxLastName.Text = database[(int)nudNumber.Value - 1].LastName;
                dateTimeBirthday.Value = database[(int)nudNumber.Value - 1].datetime;
            }
            nudNumber.Maximum--;
            CheckProgram();
        }


    }
}
