﻿namespace Kombajn
{
    partial class Correction
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_new = new System.Windows.Forms.TextBox();
            this.textBox_regex = new System.Windows.Forms.TextBox();
            this.button_regex = new System.Windows.Forms.Button();
            this.button_wykReg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(150, 364);
            this.checkedListBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Wykonaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // textBox_new
            // 
            this.textBox_new.Location = new System.Drawing.Point(7, 41);
            this.textBox_new.Name = "textBox_new";
            this.textBox_new.Size = new System.Drawing.Size(100, 20);
            this.textBox_new.TabIndex = 3;
            // 
            // textBox_regex
            // 
            this.textBox_regex.Location = new System.Drawing.Point(112, 22);
            this.textBox_regex.Name = "textBox_regex";
            this.textBox_regex.Size = new System.Drawing.Size(241, 20);
            this.textBox_regex.TabIndex = 4;
            // 
            // button_regex
            // 
            this.button_regex.Location = new System.Drawing.Point(3, 19);
            this.button_regex.Name = "button_regex";
            this.button_regex.Size = new System.Drawing.Size(96, 23);
            this.button_regex.TabIndex = 5;
            this.button_regex.Text = "Wczytaj Regex";
            this.button_regex.UseVisualStyleBackColor = true;
            this.button_regex.Click += new System.EventHandler(this.button_regex_Click);
            // 
            // button_wykReg
            // 
            this.button_wykReg.Location = new System.Drawing.Point(6, 71);
            this.button_wykReg.Name = "button_wykReg";
            this.button_wykReg.Size = new System.Drawing.Size(347, 23);
            this.button_wykReg.TabIndex = 6;
            this.button_wykReg.Text = "Wykonaj Regex";
            this.button_wykReg.UseVisualStyleBackColor = true;
            this.button_wykReg.Click += new System.EventHandler(this.button_wykReg_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_new);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(168, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manualne";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Podaj nową wartość dla zaznaczonych";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_regex);
            this.groupBox2.Controls.Add(this.textBox_regex);
            this.groupBox2.Controls.Add(this.button_wykReg);
            this.groupBox2.Location = new System.Drawing.Point(178, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Regex";
            // 
            // Correction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 404);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "Correction";
            this.Text = "Correction";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_new;
        private System.Windows.Forms.TextBox textBox_regex;
        private System.Windows.Forms.Button button_regex;
        private System.Windows.Forms.Button button_wykReg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}