namespace Battleship2pMP.MDI_Forms
{
    partial class MDI_MainMenu
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
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_Host = new System.Windows.Forms.Button();
            this.btn_Join = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_Title.Location = new System.Drawing.Point(66, 37);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(292, 90);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Battleship";
            this.lbl_Title.UseCompatibleTextRendering = true;
            // 
            // btn_Host
            // 
            this.btn_Host.BackColor = System.Drawing.Color.Aqua;
            this.btn_Host.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Host.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Host.Location = new System.Drawing.Point(108, 191);
            this.btn_Host.Name = "btn_Host";
            this.btn_Host.Size = new System.Drawing.Size(244, 67);
            this.btn_Host.TabIndex = 2;
            this.btn_Host.Text = "Host Game";
            this.btn_Host.UseCompatibleTextRendering = true;
            this.btn_Host.UseVisualStyleBackColor = false;
            this.btn_Host.Click += new System.EventHandler(this.Btn_Host_Click);
            // 
            // btn_Join
            // 
            this.btn_Join.BackColor = System.Drawing.Color.Aqua;
            this.btn_Join.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Join.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Join.Location = new System.Drawing.Point(108, 287);
            this.btn_Join.Name = "btn_Join";
            this.btn_Join.Size = new System.Drawing.Size(244, 67);
            this.btn_Join.TabIndex = 3;
            this.btn_Join.Text = "Join Game";
            this.btn_Join.UseCompatibleTextRendering = true;
            this.btn_Join.UseVisualStyleBackColor = false;
            this.btn_Join.Click += new System.EventHandler(this.Btn_Join_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.BackColor = System.Drawing.Color.Aqua;
            this.btn_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.Location = new System.Drawing.Point(108, 457);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(244, 67);
            this.btn_Quit.TabIndex = 4;
            this.btn_Quit.Text = "Quit";
            this.btn_Quit.UseCompatibleTextRendering = true;
            this.btn_Quit.UseVisualStyleBackColor = false;
            this.btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(532, -11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(550, 724);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MDI_MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Join);
            this.Controls.Add(this.btn_Host);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MDI_MainMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MainMenu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_Host;
        private System.Windows.Forms.Button btn_Join;
        private System.Windows.Forms.Button btn_Quit;
    }
}