namespace Battleship2pMP.MDI_Forms
{
    partial class MDI_Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI_Game));
            this.pnlGameBoard = new System.Windows.Forms.Panel();
            this.pbx_Reticle = new System.Windows.Forms.PictureBox();
            this.pbx_Selected_Ship = new System.Windows.Forms.PictureBox();
            this.lbl_cordA = new System.Windows.Forms.Label();
            this.lbl_cordD = new System.Windows.Forms.Label();
            this.lbl_cordE = new System.Windows.Forms.Label();
            this.lbl_cordH = new System.Windows.Forms.Label();
            this.lbl_cordI = new System.Windows.Forms.Label();
            this.lbl_cordB = new System.Windows.Forms.Label();
            this.lbl_cordG = new System.Windows.Forms.Label();
            this.lbl_cordF = new System.Windows.Forms.Label();
            this.lbl_cordC = new System.Windows.Forms.Label();
            this.lbl_cord8 = new System.Windows.Forms.Label();
            this.lbl_cord7 = new System.Windows.Forms.Label();
            this.lbl_cord6 = new System.Windows.Forms.Label();
            this.lbl_cord5 = new System.Windows.Forms.Label();
            this.lbl_cord4 = new System.Windows.Forms.Label();
            this.lbl_cord3 = new System.Windows.Forms.Label();
            this.lbl_cord2 = new System.Windows.Forms.Label();
            this.lbl_cord1 = new System.Windows.Forms.Label();
            this.lbl_cord9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_OpponentsTurn = new System.Windows.Forms.Label();
            this.lbl_YourTurn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Waiting_For_Opponent = new System.Windows.Forms.Label();
            this.btn_Ship_Placement_Done = new System.Windows.Forms.Button();
            this.Rbtn_Remove = new System.Windows.Forms.RadioButton();
            this.Rbtn_Submarine = new System.Windows.Forms.RadioButton();
            this.Rbtn_Destroyer = new System.Windows.Forms.RadioButton();
            this.Rbtn_Cruiser = new System.Windows.Forms.RadioButton();
            this.Rbtn_Battleship = new System.Windows.Forms.RadioButton();
            this.Rbtn_Carrier = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.bnt_Surrender = new System.Windows.Forms.Button();
            this.pnlGameBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Reticle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Selected_Ship)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGameBoard
            // 
            this.pnlGameBoard.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlGameBoard.Controls.Add(this.pbx_Reticle);
            this.pnlGameBoard.Controls.Add(this.pbx_Selected_Ship);
            this.pnlGameBoard.Controls.Add(this.lbl_cordA);
            this.pnlGameBoard.Controls.Add(this.lbl_cordD);
            this.pnlGameBoard.Controls.Add(this.lbl_cordE);
            this.pnlGameBoard.Controls.Add(this.lbl_cordH);
            this.pnlGameBoard.Controls.Add(this.lbl_cordI);
            this.pnlGameBoard.Controls.Add(this.lbl_cordB);
            this.pnlGameBoard.Controls.Add(this.lbl_cordG);
            this.pnlGameBoard.Controls.Add(this.lbl_cordF);
            this.pnlGameBoard.Controls.Add(this.lbl_cordC);
            this.pnlGameBoard.Controls.Add(this.lbl_cord8);
            this.pnlGameBoard.Controls.Add(this.lbl_cord7);
            this.pnlGameBoard.Controls.Add(this.lbl_cord6);
            this.pnlGameBoard.Controls.Add(this.lbl_cord5);
            this.pnlGameBoard.Controls.Add(this.lbl_cord4);
            this.pnlGameBoard.Controls.Add(this.lbl_cord3);
            this.pnlGameBoard.Controls.Add(this.lbl_cord2);
            this.pnlGameBoard.Controls.Add(this.lbl_cord1);
            this.pnlGameBoard.Controls.Add(this.lbl_cord9);
            this.pnlGameBoard.Location = new System.Drawing.Point(411, 22);
            this.pnlGameBoard.Name = "pnlGameBoard";
            this.pnlGameBoard.Size = new System.Drawing.Size(611, 611);
            this.pnlGameBoard.TabIndex = 0;
            // 
            // pbx_Reticle
            // 
            this.pbx_Reticle.BackColor = System.Drawing.Color.Transparent;
            this.pbx_Reticle.Image = ((System.Drawing.Image)(resources.GetObject("pbx_Reticle.Image")));
            this.pbx_Reticle.Location = new System.Drawing.Point(80, 490);
            this.pbx_Reticle.Name = "pbx_Reticle";
            this.pbx_Reticle.Size = new System.Drawing.Size(61, 61);
            this.pbx_Reticle.TabIndex = 3;
            this.pbx_Reticle.TabStop = false;
            this.pbx_Reticle.Visible = false;
            // 
            // pbx_Selected_Ship
            // 
            this.pbx_Selected_Ship.BackColor = System.Drawing.Color.Transparent;
            this.pbx_Selected_Ship.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbx_Selected_Ship.Location = new System.Drawing.Point(68, 16);
            this.pbx_Selected_Ship.Name = "pbx_Selected_Ship";
            this.pbx_Selected_Ship.Size = new System.Drawing.Size(62, 287);
            this.pbx_Selected_Ship.TabIndex = 3;
            this.pbx_Selected_Ship.TabStop = false;
            // 
            // lbl_cordA
            // 
            this.lbl_cordA.AutoSize = true;
            this.lbl_cordA.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cordA.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cordA.Location = new System.Drawing.Point(68, 554);
            this.lbl_cordA.Name = "lbl_cordA";
            this.lbl_cordA.Size = new System.Drawing.Size(48, 62);
            this.lbl_cordA.TabIndex = 17;
            this.lbl_cordA.Text = "A";
            this.lbl_cordA.UseCompatibleTextRendering = true;
            // 
            // lbl_cordD
            // 
            this.lbl_cordD.AutoSize = true;
            this.lbl_cordD.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cordD.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cordD.Location = new System.Drawing.Point(251, 554);
            this.lbl_cordD.Name = "lbl_cordD";
            this.lbl_cordD.Size = new System.Drawing.Size(51, 62);
            this.lbl_cordD.TabIndex = 16;
            this.lbl_cordD.Text = "D";
            this.lbl_cordD.UseCompatibleTextRendering = true;
            // 
            // lbl_cordE
            // 
            this.lbl_cordE.AutoSize = true;
            this.lbl_cordE.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cordE.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cordE.Location = new System.Drawing.Point(312, 554);
            this.lbl_cordE.Name = "lbl_cordE";
            this.lbl_cordE.Size = new System.Drawing.Size(48, 62);
            this.lbl_cordE.TabIndex = 15;
            this.lbl_cordE.Text = "E";
            this.lbl_cordE.UseCompatibleTextRendering = true;
            // 
            // lbl_cordH
            // 
            this.lbl_cordH.AutoSize = true;
            this.lbl_cordH.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cordH.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cordH.Location = new System.Drawing.Point(495, 554);
            this.lbl_cordH.Name = "lbl_cordH";
            this.lbl_cordH.Size = new System.Drawing.Size(51, 62);
            this.lbl_cordH.TabIndex = 14;
            this.lbl_cordH.Text = "H";
            this.lbl_cordH.UseCompatibleTextRendering = true;
            // 
            // lbl_cordI
            // 
            this.lbl_cordI.AutoSize = true;
            this.lbl_cordI.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cordI.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cordI.Location = new System.Drawing.Point(556, 554);
            this.lbl_cordI.Name = "lbl_cordI";
            this.lbl_cordI.Size = new System.Drawing.Size(29, 62);
            this.lbl_cordI.TabIndex = 13;
            this.lbl_cordI.Text = "I";
            this.lbl_cordI.UseCompatibleTextRendering = true;
            // 
            // lbl_cordB
            // 
            this.lbl_cordB.AutoSize = true;
            this.lbl_cordB.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cordB.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cordB.Location = new System.Drawing.Point(129, 554);
            this.lbl_cordB.Name = "lbl_cordB";
            this.lbl_cordB.Size = new System.Drawing.Size(48, 62);
            this.lbl_cordB.TabIndex = 12;
            this.lbl_cordB.Text = "B";
            this.lbl_cordB.UseCompatibleTextRendering = true;
            // 
            // lbl_cordG
            // 
            this.lbl_cordG.AutoSize = true;
            this.lbl_cordG.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cordG.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cordG.Location = new System.Drawing.Point(434, 554);
            this.lbl_cordG.Name = "lbl_cordG";
            this.lbl_cordG.Size = new System.Drawing.Size(53, 62);
            this.lbl_cordG.TabIndex = 11;
            this.lbl_cordG.Text = "G";
            this.lbl_cordG.UseCompatibleTextRendering = true;
            // 
            // lbl_cordF
            // 
            this.lbl_cordF.AutoSize = true;
            this.lbl_cordF.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cordF.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cordF.Location = new System.Drawing.Point(373, 554);
            this.lbl_cordF.Name = "lbl_cordF";
            this.lbl_cordF.Size = new System.Drawing.Size(45, 62);
            this.lbl_cordF.TabIndex = 10;
            this.lbl_cordF.Text = "F";
            this.lbl_cordF.UseCompatibleTextRendering = true;
            // 
            // lbl_cordC
            // 
            this.lbl_cordC.AutoSize = true;
            this.lbl_cordC.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cordC.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cordC.Location = new System.Drawing.Point(190, 554);
            this.lbl_cordC.Name = "lbl_cordC";
            this.lbl_cordC.Size = new System.Drawing.Size(51, 62);
            this.lbl_cordC.TabIndex = 9;
            this.lbl_cordC.Text = "C";
            this.lbl_cordC.UseCompatibleTextRendering = true;
            // 
            // lbl_cord8
            // 
            this.lbl_cord8.AutoSize = true;
            this.lbl_cord8.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cord8.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cord8.Location = new System.Drawing.Point(9, 67);
            this.lbl_cord8.Name = "lbl_cord8";
            this.lbl_cord8.Size = new System.Drawing.Size(43, 62);
            this.lbl_cord8.TabIndex = 8;
            this.lbl_cord8.Text = "8";
            this.lbl_cord8.UseCompatibleTextRendering = true;
            // 
            // lbl_cord7
            // 
            this.lbl_cord7.AutoSize = true;
            this.lbl_cord7.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cord7.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cord7.Location = new System.Drawing.Point(9, 128);
            this.lbl_cord7.Name = "lbl_cord7";
            this.lbl_cord7.Size = new System.Drawing.Size(43, 62);
            this.lbl_cord7.TabIndex = 7;
            this.lbl_cord7.Text = "7";
            this.lbl_cord7.UseCompatibleTextRendering = true;
            // 
            // lbl_cord6
            // 
            this.lbl_cord6.AutoSize = true;
            this.lbl_cord6.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cord6.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cord6.Location = new System.Drawing.Point(9, 189);
            this.lbl_cord6.Name = "lbl_cord6";
            this.lbl_cord6.Size = new System.Drawing.Size(43, 62);
            this.lbl_cord6.TabIndex = 6;
            this.lbl_cord6.Text = "6";
            this.lbl_cord6.UseCompatibleTextRendering = true;
            // 
            // lbl_cord5
            // 
            this.lbl_cord5.AutoSize = true;
            this.lbl_cord5.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cord5.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cord5.Location = new System.Drawing.Point(9, 250);
            this.lbl_cord5.Name = "lbl_cord5";
            this.lbl_cord5.Size = new System.Drawing.Size(43, 62);
            this.lbl_cord5.TabIndex = 5;
            this.lbl_cord5.Text = "5";
            this.lbl_cord5.UseCompatibleTextRendering = true;
            // 
            // lbl_cord4
            // 
            this.lbl_cord4.AutoSize = true;
            this.lbl_cord4.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cord4.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cord4.Location = new System.Drawing.Point(9, 311);
            this.lbl_cord4.Name = "lbl_cord4";
            this.lbl_cord4.Size = new System.Drawing.Size(43, 62);
            this.lbl_cord4.TabIndex = 4;
            this.lbl_cord4.Text = "4";
            this.lbl_cord4.UseCompatibleTextRendering = true;
            // 
            // lbl_cord3
            // 
            this.lbl_cord3.AutoSize = true;
            this.lbl_cord3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cord3.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cord3.Location = new System.Drawing.Point(9, 372);
            this.lbl_cord3.Name = "lbl_cord3";
            this.lbl_cord3.Size = new System.Drawing.Size(43, 62);
            this.lbl_cord3.TabIndex = 3;
            this.lbl_cord3.Text = "3";
            this.lbl_cord3.UseCompatibleTextRendering = true;
            // 
            // lbl_cord2
            // 
            this.lbl_cord2.AutoSize = true;
            this.lbl_cord2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cord2.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cord2.Location = new System.Drawing.Point(9, 433);
            this.lbl_cord2.Name = "lbl_cord2";
            this.lbl_cord2.Size = new System.Drawing.Size(43, 62);
            this.lbl_cord2.TabIndex = 2;
            this.lbl_cord2.Text = "2";
            this.lbl_cord2.UseCompatibleTextRendering = true;
            // 
            // lbl_cord1
            // 
            this.lbl_cord1.AutoSize = true;
            this.lbl_cord1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cord1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cord1.Location = new System.Drawing.Point(13, 494);
            this.lbl_cord1.Name = "lbl_cord1";
            this.lbl_cord1.Size = new System.Drawing.Size(43, 62);
            this.lbl_cord1.TabIndex = 1;
            this.lbl_cord1.Text = "1";
            this.lbl_cord1.UseCompatibleTextRendering = true;
            // 
            // lbl_cord9
            // 
            this.lbl_cord9.AutoSize = true;
            this.lbl_cord9.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cord9.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.lbl_cord9.Location = new System.Drawing.Point(9, 6);
            this.lbl_cord9.Name = "lbl_cord9";
            this.lbl_cord9.Size = new System.Drawing.Size(43, 62);
            this.lbl_cord9.TabIndex = 0;
            this.lbl_cord9.Text = "9";
            this.lbl_cord9.UseCompatibleTextRendering = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Battleship2pMP.Properties.Resources.Menu_Board;
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl_OpponentsTurn);
            this.panel2.Controls.Add(this.lbl_YourTurn);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(197, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 312);
            this.panel2.TabIndex = 8;
            this.panel2.Visible = false;
            // 
            // lbl_OpponentsTurn
            // 
            this.lbl_OpponentsTurn.AutoSize = true;
            this.lbl_OpponentsTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OpponentsTurn.ForeColor = System.Drawing.Color.White;
            this.lbl_OpponentsTurn.Location = new System.Drawing.Point(35, 30);
            this.lbl_OpponentsTurn.Name = "lbl_OpponentsTurn";
            this.lbl_OpponentsTurn.Size = new System.Drawing.Size(167, 25);
            this.lbl_OpponentsTurn.TabIndex = 8;
            this.lbl_OpponentsTurn.Text = "Opponents Turn";
            this.lbl_OpponentsTurn.Visible = false;
            // 
            // lbl_YourTurn
            // 
            this.lbl_YourTurn.AutoSize = true;
            this.lbl_YourTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_YourTurn.ForeColor = System.Drawing.Color.White;
            this.lbl_YourTurn.Location = new System.Drawing.Point(68, 28);
            this.lbl_YourTurn.Name = "lbl_YourTurn";
            this.lbl_YourTurn.Size = new System.Drawing.Size(108, 25);
            this.lbl_YourTurn.TabIndex = 7;
            this.lbl_YourTurn.Text = "Your Turn";
            this.lbl_YourTurn.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Battleship2pMP.Properties.Resources.Menu_Board;
            this.panel1.Controls.Add(this.lbl_Waiting_For_Opponent);
            this.panel1.Controls.Add(this.btn_Ship_Placement_Done);
            this.panel1.Controls.Add(this.Rbtn_Remove);
            this.panel1.Controls.Add(this.Rbtn_Submarine);
            this.panel1.Controls.Add(this.Rbtn_Destroyer);
            this.panel1.Controls.Add(this.Rbtn_Cruiser);
            this.panel1.Controls.Add(this.Rbtn_Battleship);
            this.panel1.Controls.Add(this.Rbtn_Carrier);
            this.panel1.Location = new System.Drawing.Point(78, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 312);
            this.panel1.TabIndex = 2;
            // 
            // lbl_Waiting_For_Opponent
            // 
            this.lbl_Waiting_For_Opponent.AutoSize = true;
            this.lbl_Waiting_For_Opponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Waiting_For_Opponent.ForeColor = System.Drawing.Color.White;
            this.lbl_Waiting_For_Opponent.Location = new System.Drawing.Point(57, 27);
            this.lbl_Waiting_For_Opponent.Name = "lbl_Waiting_For_Opponent";
            this.lbl_Waiting_For_Opponent.Size = new System.Drawing.Size(145, 18);
            this.lbl_Waiting_For_Opponent.TabIndex = 7;
            this.lbl_Waiting_For_Opponent.Text = "Waiting for opponent";
            this.lbl_Waiting_For_Opponent.Visible = false;
            // 
            // btn_Ship_Placement_Done
            // 
            this.btn_Ship_Placement_Done.Location = new System.Drawing.Point(83, 260);
            this.btn_Ship_Placement_Done.Name = "btn_Ship_Placement_Done";
            this.btn_Ship_Placement_Done.Size = new System.Drawing.Size(75, 23);
            this.btn_Ship_Placement_Done.TabIndex = 6;
            this.btn_Ship_Placement_Done.Text = "Done";
            this.btn_Ship_Placement_Done.UseVisualStyleBackColor = true;
            this.btn_Ship_Placement_Done.Click += new System.EventHandler(this.btn_Ship_Placement_Done_Click);
            // 
            // Rbtn_Remove
            // 
            this.Rbtn_Remove.AutoSize = true;
            this.Rbtn_Remove.BackColor = System.Drawing.Color.Transparent;
            this.Rbtn_Remove.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Rbtn_Remove.Location = new System.Drawing.Point(24, 214);
            this.Rbtn_Remove.Name = "Rbtn_Remove";
            this.Rbtn_Remove.Size = new System.Drawing.Size(89, 17);
            this.Rbtn_Remove.TabIndex = 5;
            this.Rbtn_Remove.TabStop = true;
            this.Rbtn_Remove.Text = "Remove Ship";
            this.Rbtn_Remove.UseVisualStyleBackColor = false;
            this.Rbtn_Remove.CheckedChanged += new System.EventHandler(this.Rbtn_Remove_CheckedChanged);
            // 
            // Rbtn_Submarine
            // 
            this.Rbtn_Submarine.AutoSize = true;
            this.Rbtn_Submarine.BackColor = System.Drawing.Color.Transparent;
            this.Rbtn_Submarine.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Rbtn_Submarine.Location = new System.Drawing.Point(24, 183);
            this.Rbtn_Submarine.Name = "Rbtn_Submarine";
            this.Rbtn_Submarine.Size = new System.Drawing.Size(123, 17);
            this.Rbtn_Submarine.TabIndex = 4;
            this.Rbtn_Submarine.TabStop = true;
            this.Rbtn_Submarine.Text = "Submarine       3 Left";
            this.Rbtn_Submarine.UseVisualStyleBackColor = false;
            this.Rbtn_Submarine.CheckedChanged += new System.EventHandler(this.Rbtn_Submarine_CheckedChanged);
            // 
            // Rbtn_Destroyer
            // 
            this.Rbtn_Destroyer.AutoSize = true;
            this.Rbtn_Destroyer.BackColor = System.Drawing.Color.Transparent;
            this.Rbtn_Destroyer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Rbtn_Destroyer.Location = new System.Drawing.Point(24, 153);
            this.Rbtn_Destroyer.Name = "Rbtn_Destroyer";
            this.Rbtn_Destroyer.Size = new System.Drawing.Size(124, 17);
            this.Rbtn_Destroyer.TabIndex = 3;
            this.Rbtn_Destroyer.TabStop = true;
            this.Rbtn_Destroyer.Text = "Destroyer         2 Left";
            this.Rbtn_Destroyer.UseVisualStyleBackColor = false;
            this.Rbtn_Destroyer.CheckedChanged += new System.EventHandler(this.Rbtn_Destroyer_CheckedChanged);
            // 
            // Rbtn_Cruiser
            // 
            this.Rbtn_Cruiser.AutoSize = true;
            this.Rbtn_Cruiser.BackColor = System.Drawing.Color.Transparent;
            this.Rbtn_Cruiser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Rbtn_Cruiser.Location = new System.Drawing.Point(24, 122);
            this.Rbtn_Cruiser.Name = "Rbtn_Cruiser";
            this.Rbtn_Cruiser.Size = new System.Drawing.Size(123, 17);
            this.Rbtn_Cruiser.TabIndex = 2;
            this.Rbtn_Cruiser.TabStop = true;
            this.Rbtn_Cruiser.Text = "Cruiser             1 Left";
            this.Rbtn_Cruiser.UseVisualStyleBackColor = false;
            this.Rbtn_Cruiser.CheckedChanged += new System.EventHandler(this.Rbtn_Cruiser_CheckedChanged);
            // 
            // Rbtn_Battleship
            // 
            this.Rbtn_Battleship.AutoSize = true;
            this.Rbtn_Battleship.BackColor = System.Drawing.Color.Transparent;
            this.Rbtn_Battleship.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Rbtn_Battleship.Location = new System.Drawing.Point(24, 92);
            this.Rbtn_Battleship.Name = "Rbtn_Battleship";
            this.Rbtn_Battleship.Size = new System.Drawing.Size(122, 17);
            this.Rbtn_Battleship.TabIndex = 1;
            this.Rbtn_Battleship.TabStop = true;
            this.Rbtn_Battleship.Text = "Battleship        1 Left";
            this.Rbtn_Battleship.UseVisualStyleBackColor = false;
            this.Rbtn_Battleship.CheckedChanged += new System.EventHandler(this.Rbtn_Battleship_CheckedChanged);
            // 
            // Rbtn_Carrier
            // 
            this.Rbtn_Carrier.AutoSize = true;
            this.Rbtn_Carrier.BackColor = System.Drawing.Color.Transparent;
            this.Rbtn_Carrier.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Rbtn_Carrier.Location = new System.Drawing.Point(24, 61);
            this.Rbtn_Carrier.Name = "Rbtn_Carrier";
            this.Rbtn_Carrier.Size = new System.Drawing.Size(121, 17);
            this.Rbtn_Carrier.TabIndex = 0;
            this.Rbtn_Carrier.TabStop = true;
            this.Rbtn_Carrier.Text = "Carrier             1 Left";
            this.Rbtn_Carrier.UseVisualStyleBackColor = false;
            this.Rbtn_Carrier.CheckedChanged += new System.EventHandler(this.Rbtn_Carrier_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(79, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ships Left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(148, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Opponent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(98, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "You";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(22, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Submarine";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(24, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Carrier";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Battleship";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(22, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Cruiser";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(22, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Destroyer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(98, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(164, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(98, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(98, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(164, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(164, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(98, 217);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(164, 217);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(164, 241);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(98, 241);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "0";
            // 
            // bnt_Surrender
            // 
            this.bnt_Surrender.Location = new System.Drawing.Point(23, 576);
            this.bnt_Surrender.Name = "bnt_Surrender";
            this.bnt_Surrender.Size = new System.Drawing.Size(94, 39);
            this.bnt_Surrender.TabIndex = 9;
            this.bnt_Surrender.Text = "Surrender";
            this.bnt_Surrender.UseVisualStyleBackColor = true;
            this.bnt_Surrender.Click += new System.EventHandler(this.bnt_Surrender_Click);
            // 
            // MDI_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.Controls.Add(this.bnt_Surrender);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGameBoard);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MDI_Game";
            this.Text = "MDI_Game";
            this.Load += new System.EventHandler(this.MDI_Game_Load);
            this.pnlGameBoard.ResumeLayout(false);
            this.pnlGameBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Reticle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Selected_Ship)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGameBoard;
        private System.Windows.Forms.Label lbl_cord8;
        private System.Windows.Forms.Label lbl_cord7;
        private System.Windows.Forms.Label lbl_cord6;
        private System.Windows.Forms.Label lbl_cord5;
        private System.Windows.Forms.Label lbl_cord4;
        private System.Windows.Forms.Label lbl_cord3;
        private System.Windows.Forms.Label lbl_cord2;
        private System.Windows.Forms.Label lbl_cord1;
        private System.Windows.Forms.Label lbl_cord9;
        private System.Windows.Forms.Label lbl_cordA;
        private System.Windows.Forms.Label lbl_cordD;
        private System.Windows.Forms.Label lbl_cordE;
        private System.Windows.Forms.Label lbl_cordH;
        private System.Windows.Forms.Label lbl_cordI;
        private System.Windows.Forms.Label lbl_cordB;
        private System.Windows.Forms.Label lbl_cordG;
        private System.Windows.Forms.Label lbl_cordF;
        private System.Windows.Forms.Label lbl_cordC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Ship_Placement_Done;
        private System.Windows.Forms.RadioButton Rbtn_Remove;
        private System.Windows.Forms.RadioButton Rbtn_Submarine;
        private System.Windows.Forms.RadioButton Rbtn_Destroyer;
        private System.Windows.Forms.RadioButton Rbtn_Cruiser;
        private System.Windows.Forms.RadioButton Rbtn_Battleship;
        private System.Windows.Forms.RadioButton Rbtn_Carrier;
        private System.Windows.Forms.PictureBox pbx_Selected_Ship;
        private System.Windows.Forms.Label lbl_Waiting_For_Opponent;
        private System.Windows.Forms.PictureBox pbx_Reticle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_YourTurn;
        private System.Windows.Forms.Label lbl_OpponentsTurn;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnt_Surrender;
    }
}