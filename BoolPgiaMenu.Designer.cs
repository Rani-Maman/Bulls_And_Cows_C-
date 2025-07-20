using System;

namespace Ex05
{
    partial class BoolPgiaMenu
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.buttonNumOfChances = new System.Windows.Forms.Button();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNumOfChances
            // 
            this.buttonNumOfChances.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNumOfChances.Location = new System.Drawing.Point(36, 32);
            this.buttonNumOfChances.Name = "buttonNumOfChances";
            this.buttonNumOfChances.Size = new System.Drawing.Size(363, 51);
            this.buttonNumOfChances.TabIndex = 0;
            this.buttonNumOfChances.Text = "Number of chances: 4";
            this.buttonNumOfChances.UseVisualStyleBackColor = true;
            this.buttonNumOfChances.Click += new System.EventHandler(this.buttonNumOfChances_Click);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartGame.Location = new System.Drawing.Point(302, 111);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(126, 36);
            this.buttonStartGame.TabIndex = 1;
            this.buttonStartGame.Text = "Start";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // BoolPgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 162);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.buttonNumOfChances);
            this.Name = "BoolPgia";
            this.Text = "Bool Pgia";
            this.ResumeLayout(false);
        }

        #endregion


        private System.Windows.Forms.Button buttonNumOfChances;
        private System.Windows.Forms.Button buttonStartGame;
    }
}