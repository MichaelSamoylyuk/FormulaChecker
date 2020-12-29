namespace FormulaChecker
{
    partial class MainForm
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
            this.buttonCheckResults = new System.Windows.Forms.Button();
            this.labelTask = new System.Windows.Forms.Label();
            this.labelTest1 = new System.Windows.Forms.Label();
            this.labelTest2 = new System.Windows.Forms.Label();
            this.labelTest3 = new System.Windows.Forms.Label();
            this.labelTest4 = new System.Windows.Forms.Label();
            this.labelTest5 = new System.Windows.Forms.Label();
            this.textBoxTest1 = new System.Windows.Forms.TextBox();
            this.textBoxTest2 = new System.Windows.Forms.TextBox();
            this.textBoxTest3 = new System.Windows.Forms.TextBox();
            this.textBoxTest4 = new System.Windows.Forms.TextBox();
            this.textBoxTest5 = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCheckResults
            // 
            this.buttonCheckResults.Location = new System.Drawing.Point(713, 415);
            this.buttonCheckResults.Name = "buttonCheckResults";
            this.buttonCheckResults.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckResults.TabIndex = 0;
            this.buttonCheckResults.Text = "Check";
            this.buttonCheckResults.UseVisualStyleBackColor = true;
            this.buttonCheckResults.Click += new System.EventHandler(this.buttonCheckResults_Click);
            // 
            // labelTask
            // 
            this.labelTask.AutoSize = true;
            this.labelTask.Location = new System.Drawing.Point(13, 13);
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size(768, 26);
            this.labelTask.TabIndex = 1;
            this.labelTask.Text = "Длинный текст для того, чтобы в конце попросить Вас написать программу, благодаря" +
    " которой можно узнать результат, рассчитанный по формуле\r\n{formula}";
            // 
            // labelTest1
            // 
            this.labelTest1.AutoSize = true;
            this.labelTest1.Location = new System.Drawing.Point(16, 70);
            this.labelTest1.Name = "labelTest1";
            this.labelTest1.Size = new System.Drawing.Size(56, 13);
            this.labelTest1.TabIndex = 2;
            this.labelTest1.Text = "labelTest1";
            // 
            // labelTest2
            // 
            this.labelTest2.AutoSize = true;
            this.labelTest2.Location = new System.Drawing.Point(16, 120);
            this.labelTest2.Name = "labelTest2";
            this.labelTest2.Size = new System.Drawing.Size(56, 13);
            this.labelTest2.TabIndex = 2;
            this.labelTest2.Text = "labelTest2";
            // 
            // labelTest3
            // 
            this.labelTest3.AutoSize = true;
            this.labelTest3.Location = new System.Drawing.Point(16, 170);
            this.labelTest3.Name = "labelTest3";
            this.labelTest3.Size = new System.Drawing.Size(56, 13);
            this.labelTest3.TabIndex = 2;
            this.labelTest3.Text = "labelTest3";
            // 
            // labelTest4
            // 
            this.labelTest4.AutoSize = true;
            this.labelTest4.Location = new System.Drawing.Point(16, 220);
            this.labelTest4.Name = "labelTest4";
            this.labelTest4.Size = new System.Drawing.Size(56, 13);
            this.labelTest4.TabIndex = 2;
            this.labelTest4.Text = "labelTest4";
            // 
            // labelTest5
            // 
            this.labelTest5.AutoSize = true;
            this.labelTest5.Location = new System.Drawing.Point(16, 270);
            this.labelTest5.Name = "labelTest5";
            this.labelTest5.Size = new System.Drawing.Size(56, 13);
            this.labelTest5.TabIndex = 2;
            this.labelTest5.Text = "labelTest5";
            // 
            // textBoxTest1
            // 
            this.textBoxTest1.Location = new System.Drawing.Point(75, 67);
            this.textBoxTest1.Name = "textBoxTest1";
            this.textBoxTest1.Size = new System.Drawing.Size(100, 20);
            this.textBoxTest1.TabIndex = 3;
            // 
            // textBoxTest2
            // 
            this.textBoxTest2.Location = new System.Drawing.Point(75, 117);
            this.textBoxTest2.Name = "textBoxTest2";
            this.textBoxTest2.Size = new System.Drawing.Size(100, 20);
            this.textBoxTest2.TabIndex = 3;
            // 
            // textBoxTest3
            // 
            this.textBoxTest3.Location = new System.Drawing.Point(75, 167);
            this.textBoxTest3.Name = "textBoxTest3";
            this.textBoxTest3.Size = new System.Drawing.Size(100, 20);
            this.textBoxTest3.TabIndex = 3;
            // 
            // textBoxTest4
            // 
            this.textBoxTest4.Location = new System.Drawing.Point(75, 217);
            this.textBoxTest4.Name = "textBoxTest4";
            this.textBoxTest4.Size = new System.Drawing.Size(100, 20);
            this.textBoxTest4.TabIndex = 3;
            // 
            // textBoxTest5
            // 
            this.textBoxTest5.Location = new System.Drawing.Point(75, 267);
            this.textBoxTest5.Name = "textBoxTest5";
            this.textBoxTest5.Size = new System.Drawing.Size(100, 20);
            this.textBoxTest5.TabIndex = 3;
            // 
            // buttonReset
            // 
            this.buttonReset.Enabled = false;
            this.buttonReset.Location = new System.Drawing.Point(19, 415);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxTest5);
            this.Controls.Add(this.textBoxTest4);
            this.Controls.Add(this.textBoxTest3);
            this.Controls.Add(this.textBoxTest2);
            this.Controls.Add(this.textBoxTest1);
            this.Controls.Add(this.labelTest5);
            this.Controls.Add(this.labelTest4);
            this.Controls.Add(this.labelTest3);
            this.Controls.Add(this.labelTest2);
            this.Controls.Add(this.labelTest1);
            this.Controls.Add(this.labelTask);
            this.Controls.Add(this.buttonCheckResults);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCheckResults;
        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.Label labelTest1;
        private System.Windows.Forms.Label labelTest2;
        private System.Windows.Forms.Label labelTest3;
        private System.Windows.Forms.Label labelTest4;
        private System.Windows.Forms.Label labelTest5;
        private System.Windows.Forms.TextBox textBoxTest1;
        private System.Windows.Forms.TextBox textBoxTest2;
        private System.Windows.Forms.TextBox textBoxTest3;
        private System.Windows.Forms.TextBox textBoxTest4;
        private System.Windows.Forms.TextBox textBoxTest5;
        private System.Windows.Forms.Button buttonReset;
    }
}

