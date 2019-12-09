﻿using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkCommsDotNet.Tools;
using NetworkCommsDotNet;
using System.Threading;


namespace Battleship2pMP.MDI_Forms
{
    public partial class MDI_Join : Form
    {

        public delegate void DelJoinResult(bool ConnectionSuccessful);
        public static DelJoinResult DJoinResult;
        readonly string port = ":30664";


        public MDI_Join()
        {
            InitializeComponent();
            //Set fonts to memory font loaded in main
            lbl_Title.Font = new Font(Program.pfc.Families[0], lbl_Title.Font.Size);
            btn_Back_To_MainMenu.Font = new Font(Program.pfc.Families[0], btn_Back_To_MainMenu.Font.Size);

            pictureBox1.BackgroundImage = Program.MainMenuImg;

            DJoinResult = new DelJoinResult(JoinResult);
        }

        private void Btn_Back_To_MainMenu_Click(object sender, EventArgs e)
        {
            //Ask if user wants to return to Main Menu
            if (MessageBox.Show("Are you sure you want to return to the main menu?", "Return to Main Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MDI_Container.SwitchMDI(MDI_Form_Enum.MDI_MainMenu);
            }
        }

        private void Btn_Join_Click(object sender, EventArgs e)
        {
            IPEndPoint iPEndPoint;

            try
            {
                iPEndPoint = IPTools.ParseEndPointFromString(tbx_IP.Text + port);
            }
            catch (Exception)
            {
                MessageBox.Show("Check IP format", "IP format invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread thread = new Thread(() => Networking.NetworkClient.ConnectToServer(new ConnectionInfo(iPEndPoint), this));
            thread.Start();
            tbx_IP.Enabled = false;
            btn_Join.Enabled = false;
            btn_Join.Text = "Connecting...";
        }

        public void JoinResult(bool ConnectionSuccessful)
        {
            if (ConnectionSuccessful)
            {
                MessageBox.Show("Connected");
                Networking.NetworkClient.RemoteServerInterface.StartGame();
            }
            else
            {
                tbx_IP.Enabled = true;
                btn_Join.Enabled = true;
                btn_Join.Text = "Join Game";
                MessageBox.Show("Fail");
            }
        }
    }
}