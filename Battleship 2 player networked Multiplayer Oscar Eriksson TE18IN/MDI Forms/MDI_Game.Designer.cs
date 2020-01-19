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
            this.Btn_Surrender = new System.Windows.Forms.Button();
            this.pnl_GameOver = new System.Windows.Forms.Panel();
            this.lbl_OpSurrenderd = new System.Windows.Forms.Label();
            this.lbl_YouSurrenderd = new System.Windows.Forms.Label();
            this.lbl_OpLeftGame = new System.Windows.Forms.Label();
            this.lbl_WaitingForRematch = new System.Windows.Forms.Label();
            this.lbl_OpWantsRematch = new System.Windows.Forms.Label();
            this.Btn_SwitchGameBoard = new System.Windows.Forms.Button();
            this.Btn_Rematch = new System.Windows.Forms.Button();
            this.Btn_LeaveGame = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_Turns = new System.Windows.Forms.Label();
            this.lbl_Opponent_Accuracy = new System.Windows.Forms.Label();
            this.lbl_You_Accuracy = new System.Windows.Forms.Label();
            this.lbl_Opponent_Hits = new System.Windows.Forms.Label();
            this.lbl_You_Hits = new System.Windows.Forms.Label();
            this.lbl_Opponent_ShotsFired = new System.Windows.Forms.Label();
            this.lbl_You_ShotsFired = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_Defeat = new System.Windows.Forms.Label();
            this.lbl_Victory = new System.Windows.Forms.Label();
            this.pnl_ScoreBoard = new System.Windows.Forms.Panel();
            this.lbl_Total_Op = new System.Windows.Forms.Label();
            this.lbl_Total_You = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lbl_Submarine_You = new System.Windows.Forms.Label();
            this.lbl_Submarine_Op = new System.Windows.Forms.Label();
            this.lbl_Destroyer_Op = new System.Windows.Forms.Label();
            this.lbl_Destroyer_You = new System.Windows.Forms.Label();
            this.lbl_Cruiser_Op = new System.Windows.Forms.Label();
            this.lbl_Battleship_Op = new System.Windows.Forms.Label();
            this.lbl_Cruiser_You = new System.Windows.Forms.Label();
            this.lbl_Battleship_You = new System.Windows.Forms.Label();
            this.lbl_Carrier_Op = new System.Windows.Forms.Label();
            this.lbl_Carrier_You = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_OpponentsTurn = new System.Windows.Forms.Label();
            this.lbl_YourTurn = new System.Windows.Forms.Label();
            this.pnl_PlaceShips = new System.Windows.Forms.Panel();
            this.lbl_Waiting_For_Opponent = new System.Windows.Forms.Label();
            this.Btn_Ship_Placement_Done = new System.Windows.Forms.Button();
            this.Rbtn_Remove = new System.Windows.Forms.RadioButton();
            this.Rbtn_Submarine = new System.Windows.Forms.RadioButton();
            this.Rbtn_Destroyer = new System.Windows.Forms.RadioButton();
            this.Rbtn_Cruiser = new System.Windows.Forms.RadioButton();
            this.Rbtn_Battleship = new System.Windows.Forms.RadioButton();
            this.Rbtn_Carrier = new System.Windows.Forms.RadioButton();
            this.lbl_WhosGameBoard = new System.Windows.Forms.Label();
            this.pnlGameBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Reticle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Selected_Ship)).BeginInit();
            this.pnl_GameOver.SuspendLayout();
            this.pnl_ScoreBoard.SuspendLayout();
            this.pnl_PlaceShips.SuspendLayout();
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
            // Btn_Surrender
            // 
            this.Btn_Surrender.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_Surrender.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Surrender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Surrender.Location = new System.Drawing.Point(12, 605);
            this.Btn_Surrender.Name = "Btn_Surrender";
            this.Btn_Surrender.Size = new System.Drawing.Size(122, 43);
            this.Btn_Surrender.TabIndex = 9;
            this.Btn_Surrender.Text = "Surrender";
            this.Btn_Surrender.UseCompatibleTextRendering = true;
            this.Btn_Surrender.UseVisualStyleBackColor = false;
            this.Btn_Surrender.Click += new System.EventHandler(this.Btn_Surrender_Click);
            // 
            // pnl_GameOver
            // 
            this.pnl_GameOver.BackColor = System.Drawing.Color.Transparent;
            this.pnl_GameOver.BackgroundImage = global::Battleship2pMP.Properties.Resources.Large_Menu_Board;
            this.pnl_GameOver.Controls.Add(this.lbl_OpSurrenderd);
            this.pnl_GameOver.Controls.Add(this.lbl_YouSurrenderd);
            this.pnl_GameOver.Controls.Add(this.lbl_OpLeftGame);
            this.pnl_GameOver.Controls.Add(this.lbl_WaitingForRematch);
            this.pnl_GameOver.Controls.Add(this.lbl_OpWantsRematch);
            this.pnl_GameOver.Controls.Add(this.Btn_SwitchGameBoard);
            this.pnl_GameOver.Controls.Add(this.Btn_Rematch);
            this.pnl_GameOver.Controls.Add(this.Btn_LeaveGame);
            this.pnl_GameOver.Controls.Add(this.label22);
            this.pnl_GameOver.Controls.Add(this.label21);
            this.pnl_GameOver.Controls.Add(this.label20);
            this.pnl_GameOver.Controls.Add(this.lbl_Turns);
            this.pnl_GameOver.Controls.Add(this.lbl_Opponent_Accuracy);
            this.pnl_GameOver.Controls.Add(this.lbl_You_Accuracy);
            this.pnl_GameOver.Controls.Add(this.lbl_Opponent_Hits);
            this.pnl_GameOver.Controls.Add(this.lbl_You_Hits);
            this.pnl_GameOver.Controls.Add(this.lbl_Opponent_ShotsFired);
            this.pnl_GameOver.Controls.Add(this.lbl_You_ShotsFired);
            this.pnl_GameOver.Controls.Add(this.label10);
            this.pnl_GameOver.Controls.Add(this.label9);
            this.pnl_GameOver.Controls.Add(this.lbl_Defeat);
            this.pnl_GameOver.Controls.Add(this.lbl_Victory);
            this.pnl_GameOver.Location = new System.Drawing.Point(12, 22);
            this.pnl_GameOver.Name = "pnl_GameOver";
            this.pnl_GameOver.Size = new System.Drawing.Size(370, 556);
            this.pnl_GameOver.TabIndex = 10;
            this.pnl_GameOver.Visible = false;
            // 
            // lbl_OpSurrenderd
            // 
            this.lbl_OpSurrenderd.AutoSize = true;
            this.lbl_OpSurrenderd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OpSurrenderd.ForeColor = System.Drawing.Color.White;
            this.lbl_OpSurrenderd.Location = new System.Drawing.Point(94, 109);
            this.lbl_OpSurrenderd.Name = "lbl_OpSurrenderd";
            this.lbl_OpSurrenderd.Size = new System.Drawing.Size(161, 20);
            this.lbl_OpSurrenderd.TabIndex = 49;
            this.lbl_OpSurrenderd.Text = "Opponent surrenderd";
            this.lbl_OpSurrenderd.Visible = false;
            // 
            // lbl_YouSurrenderd
            // 
            this.lbl_YouSurrenderd.AutoSize = true;
            this.lbl_YouSurrenderd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_YouSurrenderd.ForeColor = System.Drawing.Color.White;
            this.lbl_YouSurrenderd.Location = new System.Drawing.Point(123, 109);
            this.lbl_YouSurrenderd.Name = "lbl_YouSurrenderd";
            this.lbl_YouSurrenderd.Size = new System.Drawing.Size(119, 20);
            this.lbl_YouSurrenderd.TabIndex = 48;
            this.lbl_YouSurrenderd.Text = "You surrenderd";
            this.lbl_YouSurrenderd.Visible = false;
            // 
            // lbl_OpLeftGame
            // 
            this.lbl_OpLeftGame.AutoSize = true;
            this.lbl_OpLeftGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OpLeftGame.ForeColor = System.Drawing.Color.White;
            this.lbl_OpLeftGame.Location = new System.Drawing.Point(62, 406);
            this.lbl_OpLeftGame.Name = "lbl_OpLeftGame";
            this.lbl_OpLeftGame.Size = new System.Drawing.Size(242, 20);
            this.lbl_OpLeftGame.TabIndex = 47;
            this.lbl_OpLeftGame.Text = "Your opponent has left the game";
            this.lbl_OpLeftGame.Visible = false;
            // 
            // lbl_WaitingForRematch
            // 
            this.lbl_WaitingForRematch.AutoSize = true;
            this.lbl_WaitingForRematch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WaitingForRematch.ForeColor = System.Drawing.Color.White;
            this.lbl_WaitingForRematch.Location = new System.Drawing.Point(39, 406);
            this.lbl_WaitingForRematch.Name = "lbl_WaitingForRematch";
            this.lbl_WaitingForRematch.Size = new System.Drawing.Size(289, 20);
            this.lbl_WaitingForRematch.TabIndex = 46;
            this.lbl_WaitingForRematch.Text = "Waiting for opponent to accept rematch";
            this.lbl_WaitingForRematch.Visible = false;
            // 
            // lbl_OpWantsRematch
            // 
            this.lbl_OpWantsRematch.AutoSize = true;
            this.lbl_OpWantsRematch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OpWantsRematch.ForeColor = System.Drawing.Color.White;
            this.lbl_OpWantsRematch.Location = new System.Drawing.Point(69, 403);
            this.lbl_OpWantsRematch.Name = "lbl_OpWantsRematch";
            this.lbl_OpWantsRematch.Size = new System.Drawing.Size(236, 20);
            this.lbl_OpWantsRematch.TabIndex = 45;
            this.lbl_OpWantsRematch.Text = "Your opponent wants a rematch";
            this.lbl_OpWantsRematch.Visible = false;
            // 
            // Btn_SwitchGameBoard
            // 
            this.Btn_SwitchGameBoard.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_SwitchGameBoard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_SwitchGameBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SwitchGameBoard.Location = new System.Drawing.Point(24, 434);
            this.Btn_SwitchGameBoard.Name = "Btn_SwitchGameBoard";
            this.Btn_SwitchGameBoard.Size = new System.Drawing.Size(313, 43);
            this.Btn_SwitchGameBoard.TabIndex = 44;
            this.Btn_SwitchGameBoard.Text = "View Opponents Game Board";
            this.Btn_SwitchGameBoard.UseCompatibleTextRendering = true;
            this.Btn_SwitchGameBoard.UseVisualStyleBackColor = false;
            this.Btn_SwitchGameBoard.Click += new System.EventHandler(this.Btn_SwitchGameBoard_Click);
            // 
            // Btn_Rematch
            // 
            this.Btn_Rematch.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_Rematch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Rematch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Rematch.Location = new System.Drawing.Point(215, 490);
            this.Btn_Rematch.Name = "Btn_Rematch";
            this.Btn_Rematch.Size = new System.Drawing.Size(122, 43);
            this.Btn_Rematch.TabIndex = 43;
            this.Btn_Rematch.Text = "Rematch";
            this.Btn_Rematch.UseCompatibleTextRendering = true;
            this.Btn_Rematch.UseVisualStyleBackColor = false;
            this.Btn_Rematch.Click += new System.EventHandler(this.Btn_Rematch_Click);
            // 
            // Btn_LeaveGame
            // 
            this.Btn_LeaveGame.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_LeaveGame.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_LeaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_LeaveGame.Location = new System.Drawing.Point(24, 490);
            this.Btn_LeaveGame.Name = "Btn_LeaveGame";
            this.Btn_LeaveGame.Size = new System.Drawing.Size(122, 43);
            this.Btn_LeaveGame.TabIndex = 11;
            this.Btn_LeaveGame.Text = "Leave Game";
            this.Btn_LeaveGame.UseCompatibleTextRendering = true;
            this.Btn_LeaveGame.UseVisualStyleBackColor = false;
            this.Btn_LeaveGame.Click += new System.EventHandler(this.Btn_LeaveGame_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(20, 290);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 22);
            this.label22.TabIndex = 42;
            this.label22.Text = "Accuracy";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(20, 240);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 22);
            this.label21.TabIndex = 41;
            this.label21.Text = "Hits";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(20, 190);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(102, 22);
            this.label20.TabIndex = 40;
            this.label20.Text = "Shots Fired";
            // 
            // lbl_Turns
            // 
            this.lbl_Turns.AutoSize = true;
            this.lbl_Turns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Turns.ForeColor = System.Drawing.Color.White;
            this.lbl_Turns.Location = new System.Drawing.Point(122, 353);
            this.lbl_Turns.Name = "lbl_Turns";
            this.lbl_Turns.Size = new System.Drawing.Size(130, 20);
            this.lbl_Turns.TabIndex = 39;
            this.lbl_Turns.Text = "20,5 turns played";
            // 
            // lbl_Opponent_Accuracy
            // 
            this.lbl_Opponent_Accuracy.AutoSize = true;
            this.lbl_Opponent_Accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Opponent_Accuracy.ForeColor = System.Drawing.Color.White;
            this.lbl_Opponent_Accuracy.Location = new System.Drawing.Point(278, 290);
            this.lbl_Opponent_Accuracy.Name = "lbl_Opponent_Accuracy";
            this.lbl_Opponent_Accuracy.Size = new System.Drawing.Size(41, 20);
            this.lbl_Opponent_Accuracy.TabIndex = 37;
            this.lbl_Opponent_Accuracy.Text = "50%";
            // 
            // lbl_You_Accuracy
            // 
            this.lbl_You_Accuracy.AutoSize = true;
            this.lbl_You_Accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_You_Accuracy.ForeColor = System.Drawing.Color.White;
            this.lbl_You_Accuracy.Location = new System.Drawing.Point(152, 290);
            this.lbl_You_Accuracy.Name = "lbl_You_Accuracy";
            this.lbl_You_Accuracy.Size = new System.Drawing.Size(41, 20);
            this.lbl_You_Accuracy.TabIndex = 36;
            this.lbl_You_Accuracy.Text = "50%";
            // 
            // lbl_Opponent_Hits
            // 
            this.lbl_Opponent_Hits.AutoSize = true;
            this.lbl_Opponent_Hits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Opponent_Hits.ForeColor = System.Drawing.Color.White;
            this.lbl_Opponent_Hits.Location = new System.Drawing.Point(278, 240);
            this.lbl_Opponent_Hits.Name = "lbl_Opponent_Hits";
            this.lbl_Opponent_Hits.Size = new System.Drawing.Size(27, 20);
            this.lbl_Opponent_Hits.TabIndex = 35;
            this.lbl_Opponent_Hits.Text = "20";
            // 
            // lbl_You_Hits
            // 
            this.lbl_You_Hits.AutoSize = true;
            this.lbl_You_Hits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_You_Hits.ForeColor = System.Drawing.Color.White;
            this.lbl_You_Hits.Location = new System.Drawing.Point(152, 240);
            this.lbl_You_Hits.Name = "lbl_You_Hits";
            this.lbl_You_Hits.Size = new System.Drawing.Size(27, 20);
            this.lbl_You_Hits.TabIndex = 34;
            this.lbl_You_Hits.Text = "20";
            // 
            // lbl_Opponent_ShotsFired
            // 
            this.lbl_Opponent_ShotsFired.AutoSize = true;
            this.lbl_Opponent_ShotsFired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Opponent_ShotsFired.ForeColor = System.Drawing.Color.White;
            this.lbl_Opponent_ShotsFired.Location = new System.Drawing.Point(278, 190);
            this.lbl_Opponent_ShotsFired.Name = "lbl_Opponent_ShotsFired";
            this.lbl_Opponent_ShotsFired.Size = new System.Drawing.Size(27, 20);
            this.lbl_Opponent_ShotsFired.TabIndex = 33;
            this.lbl_Opponent_ShotsFired.Text = "20";
            // 
            // lbl_You_ShotsFired
            // 
            this.lbl_You_ShotsFired.AutoSize = true;
            this.lbl_You_ShotsFired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_You_ShotsFired.ForeColor = System.Drawing.Color.White;
            this.lbl_You_ShotsFired.Location = new System.Drawing.Point(152, 190);
            this.lbl_You_ShotsFired.Name = "lbl_You_ShotsFired";
            this.lbl_You_ShotsFired.Size = new System.Drawing.Size(27, 20);
            this.lbl_You_ShotsFired.TabIndex = 32;
            this.lbl_You_ShotsFired.Text = "20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(242, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 24);
            this.label10.TabIndex = 31;
            this.label10.Text = "Opponent";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(143, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 24);
            this.label9.TabIndex = 30;
            this.label9.Text = "You";
            // 
            // lbl_Defeat
            // 
            this.lbl_Defeat.AutoSize = true;
            this.lbl_Defeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Defeat.ForeColor = System.Drawing.Color.White;
            this.lbl_Defeat.Location = new System.Drawing.Point(79, 40);
            this.lbl_Defeat.Name = "lbl_Defeat";
            this.lbl_Defeat.Size = new System.Drawing.Size(176, 64);
            this.lbl_Defeat.TabIndex = 29;
            this.lbl_Defeat.Text = "Defeat!";
            this.lbl_Defeat.UseCompatibleTextRendering = true;
            this.lbl_Defeat.Visible = false;
            // 
            // lbl_Victory
            // 
            this.lbl_Victory.AutoSize = true;
            this.lbl_Victory.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Victory.ForeColor = System.Drawing.Color.White;
            this.lbl_Victory.Location = new System.Drawing.Point(63, 40);
            this.lbl_Victory.Name = "lbl_Victory";
            this.lbl_Victory.Size = new System.Drawing.Size(182, 64);
            this.lbl_Victory.TabIndex = 28;
            this.lbl_Victory.Text = "Victory!";
            this.lbl_Victory.UseCompatibleTextRendering = true;
            this.lbl_Victory.Visible = false;
            // 
            // pnl_ScoreBoard
            // 
            this.pnl_ScoreBoard.BackColor = System.Drawing.Color.Transparent;
            this.pnl_ScoreBoard.BackgroundImage = global::Battleship2pMP.Properties.Resources.Menu_Board;
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Total_Op);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Total_You);
            this.pnl_ScoreBoard.Controls.Add(this.label19);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Submarine_You);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Submarine_Op);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Destroyer_Op);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Destroyer_You);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Cruiser_Op);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Battleship_Op);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Cruiser_You);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Battleship_You);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Carrier_Op);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_Carrier_You);
            this.pnl_ScoreBoard.Controls.Add(this.label8);
            this.pnl_ScoreBoard.Controls.Add(this.label7);
            this.pnl_ScoreBoard.Controls.Add(this.label6);
            this.pnl_ScoreBoard.Controls.Add(this.label5);
            this.pnl_ScoreBoard.Controls.Add(this.label4);
            this.pnl_ScoreBoard.Controls.Add(this.label3);
            this.pnl_ScoreBoard.Controls.Add(this.label2);
            this.pnl_ScoreBoard.Controls.Add(this.label1);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_OpponentsTurn);
            this.pnl_ScoreBoard.Controls.Add(this.lbl_YourTurn);
            this.pnl_ScoreBoard.Enabled = false;
            this.pnl_ScoreBoard.Location = new System.Drawing.Point(78, 167);
            this.pnl_ScoreBoard.Name = "pnl_ScoreBoard";
            this.pnl_ScoreBoard.Size = new System.Drawing.Size(246, 312);
            this.pnl_ScoreBoard.TabIndex = 8;
            this.pnl_ScoreBoard.Visible = false;
            // 
            // lbl_Total_Op
            // 
            this.lbl_Total_Op.AutoSize = true;
            this.lbl_Total_Op.ForeColor = System.Drawing.Color.White;
            this.lbl_Total_Op.Location = new System.Drawing.Point(165, 270);
            this.lbl_Total_Op.Name = "lbl_Total_Op";
            this.lbl_Total_Op.Size = new System.Drawing.Size(13, 13);
            this.lbl_Total_Op.TabIndex = 27;
            this.lbl_Total_Op.Text = "0";
            // 
            // lbl_Total_You
            // 
            this.lbl_Total_You.AutoSize = true;
            this.lbl_Total_You.ForeColor = System.Drawing.Color.White;
            this.lbl_Total_You.Location = new System.Drawing.Point(110, 270);
            this.lbl_Total_You.Name = "lbl_Total_You";
            this.lbl_Total_You.Size = new System.Drawing.Size(13, 13);
            this.lbl_Total_You.TabIndex = 26;
            this.lbl_Total_You.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(25, 270);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 25;
            this.label19.Text = "Total";
            // 
            // lbl_Submarine_You
            // 
            this.lbl_Submarine_You.AutoSize = true;
            this.lbl_Submarine_You.ForeColor = System.Drawing.Color.White;
            this.lbl_Submarine_You.Location = new System.Drawing.Point(110, 245);
            this.lbl_Submarine_You.Name = "lbl_Submarine_You";
            this.lbl_Submarine_You.Size = new System.Drawing.Size(13, 13);
            this.lbl_Submarine_You.TabIndex = 24;
            this.lbl_Submarine_You.Text = "0";
            // 
            // lbl_Submarine_Op
            // 
            this.lbl_Submarine_Op.AutoSize = true;
            this.lbl_Submarine_Op.ForeColor = System.Drawing.Color.White;
            this.lbl_Submarine_Op.Location = new System.Drawing.Point(165, 245);
            this.lbl_Submarine_Op.Name = "lbl_Submarine_Op";
            this.lbl_Submarine_Op.Size = new System.Drawing.Size(13, 13);
            this.lbl_Submarine_Op.TabIndex = 24;
            this.lbl_Submarine_Op.Text = "0";
            // 
            // lbl_Destroyer_Op
            // 
            this.lbl_Destroyer_Op.AutoSize = true;
            this.lbl_Destroyer_Op.ForeColor = System.Drawing.Color.White;
            this.lbl_Destroyer_Op.Location = new System.Drawing.Point(165, 220);
            this.lbl_Destroyer_Op.Name = "lbl_Destroyer_Op";
            this.lbl_Destroyer_Op.Size = new System.Drawing.Size(13, 13);
            this.lbl_Destroyer_Op.TabIndex = 23;
            this.lbl_Destroyer_Op.Text = "0";
            // 
            // lbl_Destroyer_You
            // 
            this.lbl_Destroyer_You.AutoSize = true;
            this.lbl_Destroyer_You.ForeColor = System.Drawing.Color.White;
            this.lbl_Destroyer_You.Location = new System.Drawing.Point(110, 220);
            this.lbl_Destroyer_You.Name = "lbl_Destroyer_You";
            this.lbl_Destroyer_You.Size = new System.Drawing.Size(13, 13);
            this.lbl_Destroyer_You.TabIndex = 22;
            this.lbl_Destroyer_You.Text = "0";
            // 
            // lbl_Cruiser_Op
            // 
            this.lbl_Cruiser_Op.AutoSize = true;
            this.lbl_Cruiser_Op.ForeColor = System.Drawing.Color.White;
            this.lbl_Cruiser_Op.Location = new System.Drawing.Point(165, 195);
            this.lbl_Cruiser_Op.Name = "lbl_Cruiser_Op";
            this.lbl_Cruiser_Op.Size = new System.Drawing.Size(13, 13);
            this.lbl_Cruiser_Op.TabIndex = 21;
            this.lbl_Cruiser_Op.Text = "0";
            // 
            // lbl_Battleship_Op
            // 
            this.lbl_Battleship_Op.AutoSize = true;
            this.lbl_Battleship_Op.ForeColor = System.Drawing.Color.White;
            this.lbl_Battleship_Op.Location = new System.Drawing.Point(165, 170);
            this.lbl_Battleship_Op.Name = "lbl_Battleship_Op";
            this.lbl_Battleship_Op.Size = new System.Drawing.Size(13, 13);
            this.lbl_Battleship_Op.TabIndex = 20;
            this.lbl_Battleship_Op.Text = "0";
            // 
            // lbl_Cruiser_You
            // 
            this.lbl_Cruiser_You.AutoSize = true;
            this.lbl_Cruiser_You.ForeColor = System.Drawing.Color.White;
            this.lbl_Cruiser_You.Location = new System.Drawing.Point(110, 195);
            this.lbl_Cruiser_You.Name = "lbl_Cruiser_You";
            this.lbl_Cruiser_You.Size = new System.Drawing.Size(13, 13);
            this.lbl_Cruiser_You.TabIndex = 20;
            this.lbl_Cruiser_You.Text = "0";
            // 
            // lbl_Battleship_You
            // 
            this.lbl_Battleship_You.AutoSize = true;
            this.lbl_Battleship_You.ForeColor = System.Drawing.Color.White;
            this.lbl_Battleship_You.Location = new System.Drawing.Point(110, 170);
            this.lbl_Battleship_You.Name = "lbl_Battleship_You";
            this.lbl_Battleship_You.Size = new System.Drawing.Size(13, 13);
            this.lbl_Battleship_You.TabIndex = 19;
            this.lbl_Battleship_You.Text = "0";
            // 
            // lbl_Carrier_Op
            // 
            this.lbl_Carrier_Op.AutoSize = true;
            this.lbl_Carrier_Op.ForeColor = System.Drawing.Color.White;
            this.lbl_Carrier_Op.Location = new System.Drawing.Point(165, 145);
            this.lbl_Carrier_Op.Name = "lbl_Carrier_Op";
            this.lbl_Carrier_Op.Size = new System.Drawing.Size(13, 13);
            this.lbl_Carrier_Op.TabIndex = 18;
            this.lbl_Carrier_Op.Text = "0";
            // 
            // lbl_Carrier_You
            // 
            this.lbl_Carrier_You.AutoSize = true;
            this.lbl_Carrier_You.ForeColor = System.Drawing.Color.White;
            this.lbl_Carrier_You.Location = new System.Drawing.Point(110, 145);
            this.lbl_Carrier_You.Name = "lbl_Carrier_You";
            this.lbl_Carrier_You.Size = new System.Drawing.Size(13, 13);
            this.lbl_Carrier_You.TabIndex = 17;
            this.lbl_Carrier_You.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(25, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Destroyer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(25, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Cruiser";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(25, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Battleship";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(25, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Carrier";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Submarine";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(105, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "You";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(145, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Opponent";
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
            // pnl_PlaceShips
            // 
            this.pnl_PlaceShips.BackColor = System.Drawing.Color.Transparent;
            this.pnl_PlaceShips.BackgroundImage = global::Battleship2pMP.Properties.Resources.Menu_Board;
            this.pnl_PlaceShips.Controls.Add(this.lbl_Waiting_For_Opponent);
            this.pnl_PlaceShips.Controls.Add(this.Btn_Ship_Placement_Done);
            this.pnl_PlaceShips.Controls.Add(this.Rbtn_Remove);
            this.pnl_PlaceShips.Controls.Add(this.Rbtn_Submarine);
            this.pnl_PlaceShips.Controls.Add(this.Rbtn_Destroyer);
            this.pnl_PlaceShips.Controls.Add(this.Rbtn_Cruiser);
            this.pnl_PlaceShips.Controls.Add(this.Rbtn_Battleship);
            this.pnl_PlaceShips.Controls.Add(this.Rbtn_Carrier);
            this.pnl_PlaceShips.Location = new System.Drawing.Point(78, 167);
            this.pnl_PlaceShips.Name = "pnl_PlaceShips";
            this.pnl_PlaceShips.Size = new System.Drawing.Size(246, 312);
            this.pnl_PlaceShips.TabIndex = 2;
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
            // Btn_Ship_Placement_Done
            // 
            this.Btn_Ship_Placement_Done.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_Ship_Placement_Done.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Btn_Ship_Placement_Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Btn_Ship_Placement_Done.Location = new System.Drawing.Point(82, 253);
            this.Btn_Ship_Placement_Done.Name = "Btn_Ship_Placement_Done";
            this.Btn_Ship_Placement_Done.Size = new System.Drawing.Size(79, 36);
            this.Btn_Ship_Placement_Done.TabIndex = 6;
            this.Btn_Ship_Placement_Done.Text = "Done";
            this.Btn_Ship_Placement_Done.UseCompatibleTextRendering = true;
            this.Btn_Ship_Placement_Done.UseVisualStyleBackColor = false;
            this.Btn_Ship_Placement_Done.Click += new System.EventHandler(this.Btn_Ship_Placement_Done_Click);
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
            // lbl_WhosGameBoard
            // 
            this.lbl_WhosGameBoard.AutoSize = true;
            this.lbl_WhosGameBoard.BackColor = System.Drawing.SystemColors.Highlight;
            this.lbl_WhosGameBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_WhosGameBoard.Location = new System.Drawing.Point(681, 4);
            this.lbl_WhosGameBoard.Name = "lbl_WhosGameBoard";
            this.lbl_WhosGameBoard.Size = new System.Drawing.Size(93, 15);
            this.lbl_WhosGameBoard.TabIndex = 11;
            this.lbl_WhosGameBoard.Text = "Your Game Board";
            // 
            // MDI_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.Controls.Add(this.lbl_WhosGameBoard);
            this.Controls.Add(this.pnl_GameOver);
            this.Controls.Add(this.Btn_Surrender);
            this.Controls.Add(this.pnl_ScoreBoard);
            this.Controls.Add(this.pnl_PlaceShips);
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
            this.pnl_GameOver.ResumeLayout(false);
            this.pnl_GameOver.PerformLayout();
            this.pnl_ScoreBoard.ResumeLayout(false);
            this.pnl_ScoreBoard.PerformLayout();
            this.pnl_PlaceShips.ResumeLayout(false);
            this.pnl_PlaceShips.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel pnl_PlaceShips;
        private System.Windows.Forms.Button Btn_Ship_Placement_Done;
        private System.Windows.Forms.RadioButton Rbtn_Remove;
        private System.Windows.Forms.RadioButton Rbtn_Submarine;
        private System.Windows.Forms.RadioButton Rbtn_Destroyer;
        private System.Windows.Forms.RadioButton Rbtn_Cruiser;
        private System.Windows.Forms.RadioButton Rbtn_Battleship;
        private System.Windows.Forms.RadioButton Rbtn_Carrier;
        private System.Windows.Forms.PictureBox pbx_Selected_Ship;
        private System.Windows.Forms.Label lbl_Waiting_For_Opponent;
        private System.Windows.Forms.PictureBox pbx_Reticle;
        private System.Windows.Forms.Panel pnl_ScoreBoard;
        private System.Windows.Forms.Label lbl_YourTurn;
        private System.Windows.Forms.Label lbl_OpponentsTurn;
        private System.Windows.Forms.Label lbl_Submarine_You;
        private System.Windows.Forms.Label lbl_Submarine_Op;
        private System.Windows.Forms.Label lbl_Destroyer_Op;
        private System.Windows.Forms.Label lbl_Destroyer_You;
        private System.Windows.Forms.Label lbl_Cruiser_Op;
        private System.Windows.Forms.Label lbl_Battleship_Op;
        private System.Windows.Forms.Label lbl_Cruiser_You;
        private System.Windows.Forms.Label lbl_Battleship_You;
        private System.Windows.Forms.Label lbl_Carrier_Op;
        private System.Windows.Forms.Label lbl_Carrier_You;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Surrender;
        private System.Windows.Forms.Label lbl_Total_Op;
        private System.Windows.Forms.Label lbl_Total_You;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel pnl_GameOver;
        private System.Windows.Forms.Label lbl_Defeat;
        private System.Windows.Forms.Label lbl_Victory;
        private System.Windows.Forms.Label lbl_Opponent_Accuracy;
        private System.Windows.Forms.Label lbl_You_Accuracy;
        private System.Windows.Forms.Label lbl_Opponent_Hits;
        private System.Windows.Forms.Label lbl_You_Hits;
        private System.Windows.Forms.Label lbl_Opponent_ShotsFired;
        private System.Windows.Forms.Label lbl_You_ShotsFired;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Btn_LeaveGame;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_Turns;
        private System.Windows.Forms.Button Btn_SwitchGameBoard;
        private System.Windows.Forms.Button Btn_Rematch;
        private System.Windows.Forms.Label lbl_OpLeftGame;
        private System.Windows.Forms.Label lbl_WaitingForRematch;
        private System.Windows.Forms.Label lbl_OpWantsRematch;
        private System.Windows.Forms.Label lbl_WhosGameBoard;
        private System.Windows.Forms.Label lbl_YouSurrenderd;
        private System.Windows.Forms.Label lbl_OpSurrenderd;
    }
}