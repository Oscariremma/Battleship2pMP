﻿namespace Battleship2pMP.MDI_Forms
{
    partial class MDI_Join
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
            this.btn_Back_To_MainMenu = new System.Windows.Forms.Button();
            this.pbx_SideBackround = new System.Windows.Forms.PictureBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.tbx_IP = new System.Windows.Forms.TextBox();
            this.Btn_Join = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_SideBackround)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Back_To_MainMenu
            // 
            this.btn_Back_To_MainMenu.BackColor = System.Drawing.Color.Aqua;
            this.btn_Back_To_MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Back_To_MainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back_To_MainMenu.Location = new System.Drawing.Point(12, 612);
            this.btn_Back_To_MainMenu.Name = "btn_Back_To_MainMenu";
            this.btn_Back_To_MainMenu.Size = new System.Drawing.Size(159, 36);
            this.btn_Back_To_MainMenu.TabIndex = 6;
            this.btn_Back_To_MainMenu.Text = "Main Menu";
            this.btn_Back_To_MainMenu.UseCompatibleTextRendering = true;
            this.btn_Back_To_MainMenu.UseVisualStyleBackColor = false;
            this.btn_Back_To_MainMenu.Click += new System.EventHandler(this.Btn_Back_To_MainMenu_Click);
            // 
            // pbx_SideBackround
            // 
            this.pbx_SideBackround.BackColor = System.Drawing.SystemColors.Highlight;
            this.pbx_SideBackround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbx_SideBackround.Location = new System.Drawing.Point(532, -11);
            this.pbx_SideBackround.Name = "pbx_SideBackround";
            this.pbx_SideBackround.Size = new System.Drawing.Size(550, 724);
            this.pbx_SideBackround.TabIndex = 7;
            this.pbx_SideBackround.TabStop = false;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_Title.Location = new System.Drawing.Point(66, 37);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(301, 90);
            this.lbl_Title.TabIndex = 8;
            this.lbl_Title.Text = "Join Game";
            this.lbl_Title.UseCompatibleTextRendering = true;
            // 
            // tbx_IP
            // 
            this.tbx_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tbx_IP.Location = new System.Drawing.Point(148, 322);
            this.tbx_IP.Name = "tbx_IP";
            this.tbx_IP.Size = new System.Drawing.Size(169, 23);
            this.tbx_IP.TabIndex = 9;
            // 
            // Btn_Join
            // 
            this.Btn_Join.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Join.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Join.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Join.Location = new System.Drawing.Point(127, 368);
            this.Btn_Join.Name = "Btn_Join";
            this.Btn_Join.Size = new System.Drawing.Size(203, 54);
            this.Btn_Join.TabIndex = 10;
            this.Btn_Join.Text = "Join Game";
            this.Btn_Join.UseCompatibleTextRendering = true;
            this.Btn_Join.UseVisualStyleBackColor = false;
            this.Btn_Join.Click += new System.EventHandler(this.Btn_Join_Click);
            // 
            // MDI_Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.Controls.Add(this.Btn_Join);
            this.Controls.Add(this.tbx_IP);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pbx_SideBackround);
            this.Controls.Add(this.btn_Back_To_MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MDI_Join";
            this.Text = "MDI_Join";
            ((System.ComponentModel.ISupportInitialize)(this.pbx_SideBackround)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Back_To_MainMenu;
        private System.Windows.Forms.PictureBox pbx_SideBackround;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TextBox tbx_IP;
        private System.Windows.Forms.Button Btn_Join;
    }
}