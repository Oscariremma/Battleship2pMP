namespace Battleship2pMP.MDI_Forms
{
    partial class MDI_Host
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
            this.Btn_Back_To_MainMenu = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Host = new System.Windows.Forms.Button();
            this.tbx_IPs = new System.Windows.Forms.TextBox();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.lbl_GameStart = new System.Windows.Forms.Label();
            this.Btn_GameSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Back_To_MainMenu
            // 
            this.Btn_Back_To_MainMenu.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Back_To_MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Back_To_MainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Back_To_MainMenu.Location = new System.Drawing.Point(12, 612);
            this.Btn_Back_To_MainMenu.Name = "Btn_Back_To_MainMenu";
            this.Btn_Back_To_MainMenu.Size = new System.Drawing.Size(159, 36);
            this.Btn_Back_To_MainMenu.TabIndex = 5;
            this.Btn_Back_To_MainMenu.Text = "Main Menu";
            this.Btn_Back_To_MainMenu.UseCompatibleTextRendering = true;
            this.Btn_Back_To_MainMenu.UseVisualStyleBackColor = false;
            this.Btn_Back_To_MainMenu.Click += new System.EventHandler(this.Btn_Back_To_MainMenu_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_Title.Location = new System.Drawing.Point(66, 37);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(319, 90);
            this.lbl_Title.TabIndex = 6;
            this.lbl_Title.Text = "Host Game";
            this.lbl_Title.UseCompatibleTextRendering = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(532, -11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(550, 724);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Host
            // 
            this.btn_Host.BackColor = System.Drawing.Color.Aqua;
            this.btn_Host.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Host.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Host.Location = new System.Drawing.Point(138, 444);
            this.btn_Host.Name = "btn_Host";
            this.btn_Host.Size = new System.Drawing.Size(203, 54);
            this.btn_Host.TabIndex = 7;
            this.btn_Host.Text = "Start Server";
            this.btn_Host.UseCompatibleTextRendering = true;
            this.btn_Host.UseVisualStyleBackColor = false;
            this.btn_Host.Click += new System.EventHandler(this.Btn_Host_Click);
            // 
            // tbx_IPs
            // 
            this.tbx_IPs.Location = new System.Drawing.Point(138, 280);
            this.tbx_IPs.Multiline = true;
            this.tbx_IPs.Name = "tbx_IPs";
            this.tbx_IPs.ReadOnly = true;
            this.tbx_IPs.Size = new System.Drawing.Size(203, 142);
            this.tbx_IPs.TabIndex = 8;
            this.tbx_IPs.Visible = false;
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_IP.Location = new System.Drawing.Point(148, 260);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(184, 17);
            this.lbl_IP.TabIndex = 9;
            this.lbl_IP.Text = "Server opened on these IPs";
            this.lbl_IP.Visible = false;
            // 
            // lbl_GameStart
            // 
            this.lbl_GameStart.AutoSize = true;
            this.lbl_GameStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lbl_GameStart.Location = new System.Drawing.Point(80, 209);
            this.lbl_GameStart.Name = "lbl_GameStart";
            this.lbl_GameStart.Size = new System.Drawing.Size(324, 20);
            this.lbl_GameStart.TabIndex = 10;
            this.lbl_GameStart.Text = "The game will start ones a client connects";
            this.lbl_GameStart.Visible = false;
            // 
            // Btn_GameSettings
            // 
            this.Btn_GameSettings.BackColor = System.Drawing.Color.Aqua;
            this.Btn_GameSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_GameSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_GameSettings.Location = new System.Drawing.Point(161, 504);
            this.Btn_GameSettings.Name = "Btn_GameSettings";
            this.Btn_GameSettings.Size = new System.Drawing.Size(159, 36);
            this.Btn_GameSettings.TabIndex = 11;
            this.Btn_GameSettings.Text = "Game Settings";
            this.Btn_GameSettings.UseCompatibleTextRendering = true;
            this.Btn_GameSettings.UseVisualStyleBackColor = false;
            this.Btn_GameSettings.Click += new System.EventHandler(this.Btn_GameSettings_Click);
            // 
            // MDI_Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.Controls.Add(this.Btn_GameSettings);
            this.Controls.Add(this.lbl_GameStart);
            this.Controls.Add(this.lbl_IP);
            this.Controls.Add(this.tbx_IPs);
            this.Controls.Add(this.btn_Host);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.Btn_Back_To_MainMenu);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MDI_Host";
            this.Text = "MDI_Host";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Btn_Back_To_MainMenu;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_Host;
        private System.Windows.Forms.TextBox tbx_IPs;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label lbl_GameStart;
        private System.Windows.Forms.Button Btn_GameSettings;
    }
}