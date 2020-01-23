namespace Battleship2pMP.MDI_Forms
{
    partial class MDI_GameSettings
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
            this.Btn_Back = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pbx_SideBackround = new System.Windows.Forms.PictureBox();
            this.num_Carriers = new System.Windows.Forms.NumericUpDown();
            this.num_Battleships = new System.Windows.Forms.NumericUpDown();
            this.num_Cruisers = new System.Windows.Forms.NumericUpDown();
            this.num_Destroyers = new System.Windows.Forms.NumericUpDown();
            this.num_Submarines = new System.Windows.Forms.NumericUpDown();
            this.num_ShotsFirstTurn = new System.Windows.Forms.NumericUpDown();
            this.num_ShotsPerTurn = new System.Windows.Forms.NumericUpDown();
            this.num_PostTurnDelay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_Reset = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_SideBackround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Carriers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Battleships)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Cruisers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Destroyers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Submarines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ShotsFirstTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ShotsPerTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_PostTurnDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Back
            // 
            this.Btn_Back.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Back.Location = new System.Drawing.Point(12, 612);
            this.Btn_Back.Name = "Btn_Back";
            this.Btn_Back.Size = new System.Drawing.Size(159, 36);
            this.Btn_Back.TabIndex = 5;
            this.Btn_Back.Text = "Back";
            this.Btn_Back.UseCompatibleTextRendering = true;
            this.Btn_Back.UseVisualStyleBackColor = false;
            this.Btn_Back.Click += new System.EventHandler(this.Btn_Back_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Calibri", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_Title.Location = new System.Drawing.Point(25, 39);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(384, 84);
            this.lbl_Title.TabIndex = 6;
            this.lbl_Title.Text = "Game Settings";
            this.lbl_Title.UseCompatibleTextRendering = true;
            // 
            // pbx_SideBackround
            // 
            this.pbx_SideBackround.BackColor = System.Drawing.SystemColors.Highlight;
            this.pbx_SideBackround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbx_SideBackround.Location = new System.Drawing.Point(532, -11);
            this.pbx_SideBackround.Name = "pbx_SideBackround";
            this.pbx_SideBackround.Size = new System.Drawing.Size(550, 724);
            this.pbx_SideBackround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_SideBackround.TabIndex = 1;
            this.pbx_SideBackround.TabStop = false;
            // 
            // num_Carriers
            // 
            this.num_Carriers.Location = new System.Drawing.Point(229, 213);
            this.num_Carriers.Name = "num_Carriers";
            this.num_Carriers.Size = new System.Drawing.Size(73, 20);
            this.num_Carriers.TabIndex = 7;
            // 
            // num_Battleships
            // 
            this.num_Battleships.Location = new System.Drawing.Point(229, 245);
            this.num_Battleships.Name = "num_Battleships";
            this.num_Battleships.Size = new System.Drawing.Size(73, 20);
            this.num_Battleships.TabIndex = 8;
            // 
            // num_Cruisers
            // 
            this.num_Cruisers.Location = new System.Drawing.Point(229, 278);
            this.num_Cruisers.Name = "num_Cruisers";
            this.num_Cruisers.Size = new System.Drawing.Size(73, 20);
            this.num_Cruisers.TabIndex = 9;
            // 
            // num_Destroyers
            // 
            this.num_Destroyers.Location = new System.Drawing.Point(229, 308);
            this.num_Destroyers.Name = "num_Destroyers";
            this.num_Destroyers.Size = new System.Drawing.Size(73, 20);
            this.num_Destroyers.TabIndex = 10;
            // 
            // num_Submarines
            // 
            this.num_Submarines.Location = new System.Drawing.Point(229, 338);
            this.num_Submarines.Name = "num_Submarines";
            this.num_Submarines.Size = new System.Drawing.Size(73, 20);
            this.num_Submarines.TabIndex = 11;
            // 
            // num_ShotsFirstTurn
            // 
            this.num_ShotsFirstTurn.Location = new System.Drawing.Point(229, 403);
            this.num_ShotsFirstTurn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_ShotsFirstTurn.Name = "num_ShotsFirstTurn";
            this.num_ShotsFirstTurn.Size = new System.Drawing.Size(73, 20);
            this.num_ShotsFirstTurn.TabIndex = 12;
            this.num_ShotsFirstTurn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_ShotsPerTurn
            // 
            this.num_ShotsPerTurn.Location = new System.Drawing.Point(229, 433);
            this.num_ShotsPerTurn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_ShotsPerTurn.Name = "num_ShotsPerTurn";
            this.num_ShotsPerTurn.Size = new System.Drawing.Size(73, 20);
            this.num_ShotsPerTurn.TabIndex = 13;
            this.num_ShotsPerTurn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_PostTurnDelay
            // 
            this.num_PostTurnDelay.DecimalPlaces = 1;
            this.num_PostTurnDelay.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.num_PostTurnDelay.Location = new System.Drawing.Point(229, 498);
            this.num_PostTurnDelay.Name = "num_PostTurnDelay";
            this.num_PostTurnDelay.Size = new System.Drawing.Size(73, 20);
            this.num_PostTurnDelay.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Number of Carriers (5 units long)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Number of Battleships (4 units long)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Number of Cruisers (3 units long)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Number of Destroyers (2 units long)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Number of Destroyers (1 unit long)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 405);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Number of shots on the first turn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 435);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Number of shots per turn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 500);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Delay after a turn is done";
            // 
            // Btn_Reset
            // 
            this.Btn_Reset.BackColor = System.Drawing.Color.Aqua;
            this.Btn_Reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Reset.Location = new System.Drawing.Point(439, 612);
            this.Btn_Reset.Name = "Btn_Reset";
            this.Btn_Reset.Size = new System.Drawing.Size(87, 36);
            this.Btn_Reset.TabIndex = 23;
            this.Btn_Reset.Text = "Reset";
            this.Btn_Reset.UseCompatibleTextRendering = true;
            this.Btn_Reset.UseVisualStyleBackColor = false;
            this.Btn_Reset.Click += new System.EventHandler(this.Btn_Reset_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(308, 500);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "seconds";
            // 
            // MDI_GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Btn_Reset);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_PostTurnDelay);
            this.Controls.Add(this.num_ShotsPerTurn);
            this.Controls.Add(this.num_ShotsFirstTurn);
            this.Controls.Add(this.num_Submarines);
            this.Controls.Add(this.num_Destroyers);
            this.Controls.Add(this.num_Cruisers);
            this.Controls.Add(this.num_Battleships);
            this.Controls.Add(this.num_Carriers);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.Btn_Back);
            this.Controls.Add(this.pbx_SideBackround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MDI_GameSettings";
            this.Text = "MDI_Host";
            ((System.ComponentModel.ISupportInitialize)(this.pbx_SideBackround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Carriers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Battleships)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Cruisers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Destroyers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Submarines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ShotsFirstTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ShotsPerTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_PostTurnDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_SideBackround;
        private System.Windows.Forms.Button Btn_Back;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.NumericUpDown num_Carriers;
        private System.Windows.Forms.NumericUpDown num_Battleships;
        private System.Windows.Forms.NumericUpDown num_Cruisers;
        private System.Windows.Forms.NumericUpDown num_Destroyers;
        private System.Windows.Forms.NumericUpDown num_Submarines;
        private System.Windows.Forms.NumericUpDown num_ShotsFirstTurn;
        private System.Windows.Forms.NumericUpDown num_ShotsPerTurn;
        private System.Windows.Forms.NumericUpDown num_PostTurnDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Btn_Reset;
        private System.Windows.Forms.Label label9;
    }
}