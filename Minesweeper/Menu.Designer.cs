
namespace Minesweeper
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLv1 = new System.Windows.Forms.Button();
            this.buttonLv2 = new System.Windows.Forms.Button();
            this.buttonLv3 = new System.Windows.Forms.Button();
            this.buttonScores = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLv1
            // 
            this.buttonLv1.Location = new System.Drawing.Point(284, 35);
            this.buttonLv1.Name = "buttonLv1";
            this.buttonLv1.Size = new System.Drawing.Size(127, 25);
            this.buttonLv1.TabIndex = 0;
            this.buttonLv1.Text = "Beginner";
            this.buttonLv1.UseVisualStyleBackColor = true;
            this.buttonLv1.Click += new System.EventHandler(this.buttonLv1_Click);
            // 
            // buttonLv2
            // 
            this.buttonLv2.Location = new System.Drawing.Point(284, 66);
            this.buttonLv2.Name = "buttonLv2";
            this.buttonLv2.Size = new System.Drawing.Size(127, 25);
            this.buttonLv2.TabIndex = 1;
            this.buttonLv2.Text = "Intermediate";
            this.buttonLv2.UseVisualStyleBackColor = true;
            this.buttonLv2.Click += new System.EventHandler(this.buttonLv2_Click);
            // 
            // buttonLv3
            // 
            this.buttonLv3.Location = new System.Drawing.Point(284, 97);
            this.buttonLv3.Name = "buttonLv3";
            this.buttonLv3.Size = new System.Drawing.Size(127, 25);
            this.buttonLv3.TabIndex = 2;
            this.buttonLv3.Text = "Expert";
            this.buttonLv3.UseVisualStyleBackColor = true;
            this.buttonLv3.Click += new System.EventHandler(this.buttonLv3_Click);
            // 
            // buttonScores
            // 
            this.buttonScores.Location = new System.Drawing.Point(284, 140);
            this.buttonScores.Name = "buttonScores";
            this.buttonScores.Size = new System.Drawing.Size(127, 25);
            this.buttonScores.TabIndex = 3;
            this.buttonScores.Text = "Scores";
            this.buttonScores.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 212);
            this.Controls.Add(this.buttonScores);
            this.Controls.Add(this.buttonLv3);
            this.Controls.Add(this.buttonLv2);
            this.Controls.Add(this.buttonLv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Menu";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLv1;
        private System.Windows.Forms.Button buttonLv2;
        private System.Windows.Forms.Button buttonLv3;
        private System.Windows.Forms.Button buttonScores;
    }
}

