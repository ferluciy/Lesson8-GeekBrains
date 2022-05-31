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
    public partial class FormGame : Form
    {
        TrueFalseDatabase database;
        string NameProg = "Игра \"Правда или Ложь\"";
        int numVal, numMax, result;
        bool truefalse;
        public FormGame()
        {
            InitializeComponent();
        }

        public void CheckProgram(bool playeranswer)
        {
            if (playeranswer == truefalse)
            {
                result++;
            }
            if (numVal < numMax)
            {
                numVal++;
                tbQuestion.Text = database[numVal - 1].Text;
                truefalse = database[numVal - 1].TrueFalse;
                labelQuestCount.Text = $"Вопрос {numVal} из {numMax}:";
            } else
            {
                btnTrue.Enabled = false;
                btnFalse.Enabled = false;
                DialogResult dialogResult = MessageBox.Show($"Ваш результат {Math.Round (((double)result / numMax) * 100 , 0)}%. Хотите начать заново?", NameProg,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    numMax = database.Count;
                    numVal = 1;
                    result = 0;
                    tbQuestion.Text = database[numVal - 1].Text;
                    truefalse = database[numVal - 1].TrueFalse;
                    labelQuestCount.Text = $"Вопрос {numVal} из {numMax}:";
                    btnTrue.Enabled = true;
                    btnFalse.Enabled = true;
                }
            }
        }

        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFalse_Click(object sender, EventArgs e)
        {
            CheckProgram(false);
            
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            numMax = database.Count;
            numVal = 1;
            result = 0;
            tbQuestion.Text = database[numVal - 1].Text;
            truefalse = database[numVal - 1].TrueFalse;
            labelQuestCount.Text = $"Вопрос {numVal} из {numMax}:";
            btnTrue.Enabled = true;
            btnFalse.Enabled = true;
        }

        private void btnTrue_Click(object sender, EventArgs e)
        {
            CheckProgram(true);            
        }

        private void btnNewGame_Click(object sender, EventArgs e)
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
                        btnNewGame_Click(sender, e);
                        return;
                    }
                    else return;
                }
                numMax = database.Count;
                numVal = 1;
                result = 0;
                tbQuestion.Text = database[numVal - 1].Text;
                truefalse = database[numVal - 1].TrueFalse;
                btnRestart.Enabled = true;
                btnTrue.Enabled = true;
                btnFalse.Enabled = true;
                labelQuestCount.Text = $"Вопрос {numVal} из {numMax}:";
                FileInfo fl = new FileInfo(dlg.FileName);
                this.Text = NameProg + " | База \"" + fl.Name + "\"";
                //CheckProgram();
            }
        }
    }
}
