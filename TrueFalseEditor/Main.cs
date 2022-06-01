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

namespace TrueFalseEditor
{
    public partial class Main : Form
    {
        TrueFalseDatabase database;
        decimal num; //предыдущий номер вопроса
        string NameProg = "TrueFalseEditor";

        public Main()
        {
            InitializeComponent();
        }

        public void CheckProgram()
        {
            if (database != null)
            {
                panel1.Enabled = true;
                panel2.Enabled = true;
                menuItemSave.Enabled = true;
                menuItemSaveAs.Enabled = true;
                labelQuestCount.Text = $"Вопрос {nudNumber.Value} из {nudNumber.Maximum}:";
            }
            if (nudNumber.Maximum > 1) btnDelete.Enabled = true; 
            else btnDelete.Enabled = false;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Base|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                     database = new TrueFalseDatabase(dlg.FileName);
                    database.Add("Текст вопроса #1", false);
                    database.Save();
                    nudNumber.Minimum = 1;
                    nudNumber.Maximum = 1;
                    nudNumber.Value = 1;
                    num = 1;
                    CheckProgram();
                FileInfo fl = new FileInfo(dlg.FileName);
                this.Text = NameProg + " | База \"" + fl.Name + "\"";
            }
            

        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Base|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseDatabase(dlg.FileName);
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
                tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
                btnSave.Enabled = false;
                FileInfo fl = new FileInfo(dlg.FileName);
                this.Text = NameProg + " | База \""+fl.Name+"\"";
                CheckProgram();
            }

        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            database.Save();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            database.Add($"Текст вопроса #{database.Count + 1}", true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            database.Remove((int)nudNumber.Value - 1);
            if (nudNumber.Value > 1) nudNumber.Value--;
            else
            {
                tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
            }
            nudNumber.Maximum--;            
            CheckProgram();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
            database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
            btnSave.Enabled = false;
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                DialogResult dialogResult = MessageBox.Show("Вы не сохранили предыдущий вопрос! Сохранить сейчас?", NameProg,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    database[(int)num - 1].Text = tbQuestion.Text;
                    database[(int)num - 1].TrueFalse = cbTrue.Checked;
                }
            }
            num = nudNumber.Value;
            tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
            btnSave.Enabled = false;
            CheckProgram();
        }

        private void tbQuestion_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            Form frm = new About();
            frm.ShowDialog();
            
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Base|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database.Save(dlg.FileName);
                FileInfo fl = new FileInfo(dlg.FileName);
                this.Text = NameProg + " | База \"" + fl.Name + "\"";
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            nudNumber.UpButton();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            nudNumber.DownButton();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }
    }
}
