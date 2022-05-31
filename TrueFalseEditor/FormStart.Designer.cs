namespace TrueFalseEditor
{
    partial class FormStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEditorStart = new System.Windows.Forms.Button();
            this.btnGameStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEditorStart
            // 
            this.btnEditorStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.btnEditorStart.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnEditorStart.FlatAppearance.BorderSize = 0;
            this.btnEditorStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditorStart.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditorStart.ForeColor = System.Drawing.Color.Black;
            this.btnEditorStart.Location = new System.Drawing.Point(43, 87);
            this.btnEditorStart.Name = "btnEditorStart";
            this.btnEditorStart.Size = new System.Drawing.Size(122, 88);
            this.btnEditorStart.TabIndex = 3;
            this.btnEditorStart.Text = "Редактор";
            this.btnEditorStart.UseVisualStyleBackColor = false;
            this.btnEditorStart.Click += new System.EventHandler(this.btnEditorStart_Click);
            // 
            // btnGameStart
            // 
            this.btnGameStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.btnGameStart.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnGameStart.FlatAppearance.BorderSize = 0;
            this.btnGameStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameStart.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGameStart.ForeColor = System.Drawing.Color.Black;
            this.btnGameStart.Location = new System.Drawing.Point(196, 87);
            this.btnGameStart.Name = "btnGameStart";
            this.btnGameStart.Size = new System.Drawing.Size(122, 88);
            this.btnGameStart.TabIndex = 4;
            this.btnGameStart.Text = "Играть";
            this.btnGameStart.UseVisualStyleBackColor = false;
            this.btnGameStart.Click += new System.EventHandler(this.btnGameStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(43, 197);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(275, 39);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(71, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "ПРАВДА ИЛИ ЛОЖЬ";
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(365, 276);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGameStart);
            this.Controls.Add(this.btnEditorStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditorStart;
        private System.Windows.Forms.Button btnGameStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}