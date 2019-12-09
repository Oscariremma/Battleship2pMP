﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship2pMP.MDI_Forms
{
    public partial class MDI_Host : Form
    {
        public MDI_Host()
        {
            InitializeComponent();
            //Set fonts to memory font loaded in main
            lbl_Title.Font = new Font(Program.pfc.Families[0], lbl_Title.Font.Size);
            btn_Back_To_MainMenu.Font = new Font(Program.pfc.Families[0], btn_Back_To_MainMenu.Font.Size);

            pictureBox1.BackgroundImage = Program.MainMenuImg;

        }

        private void Btn_Back_To_MainMenu_Click(object sender, EventArgs e)
        {
            //Ask if user wants to return to Main Menu
            if (MessageBox.Show("Are you sure you want to return to the main menu?", "Return to Main Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MDI_Container.SwitchMDI(MDI_Form_Enum.MDI_MainMenu);
            }
        }



        private void Button4_Click(object sender, EventArgs e)
        {
            MDI_Container.SwitchMDI(MDI_Form_Enum.MDI_Game, true);
        }

        private void Btn_Host_Click(object sender, EventArgs e)
        {
            if (!Networking.NetworkServer.ServerListening)
            {
                tbx_IPs.Lines = Networking.NetworkServer.StartServer(30664);
                btn_Host.Text = "Stop Server";
                lbl_IP.Visible = true;
                tbx_IPs.Visible = true;
                lbl_GameStart.Visible = true;
                
            }
            else
            {
                Networking.NetworkServer.StopServerListener();
                btn_Host.Text = "Start Server";
                lbl_IP.Visible = false;
                tbx_IPs.Visible = false;
                lbl_GameStart.Visible = false;

            }




        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MDI_Container.SwitchMDI(MDI_Form_Enum.MDI_Game, true);
        }
    }
}