using System;
using System.Windows.Forms;

namespace Battleship2pMP.MDI_Forms
{
    public partial class MDI_Host : Form
    {
        public MDI_Host()
        {
            InitializeComponent();
            //Set fonts to memory font loaded in main
            lbl_Title.SetMilitaryFont();
            Btn_Back_To_MainMenu.SetMilitaryFont();
            btn_Host.SetMilitaryFont();
            Btn_GameSettings.SetMilitaryFont();

            pictureBox1.BackgroundImage = Program.MainMenuImg;
        }

        private void Btn_Back_To_MainMenu_Click(object sender, EventArgs e)
        {
            //Ask if user wants to return to Main Menu
            if (MessageBox.Show("Are you sure you want to return to the main menu?", "Return to Main Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Networking.NetworkServer.ServerListening)
                {
                    Networking.NetworkServer.StopServerListener();
                    btn_Host.Text = "Start Server";
                    lbl_IP.Visible = false;
                    tbx_IPs.Visible = false;
                    lbl_GameStart.Visible = false;
                    Btn_GameSettings.Enabled = true;
                }

                MDI_Container.SwitchMDI(MDI_Form_Enum.MDI_MainMenu);
            }
        }

        private void Btn_Host_Click(object sender, EventArgs e)
        {
            //Start/stop the server listening
            if (!Networking.NetworkServer.ServerListening)
            {
                tbx_IPs.Lines = Networking.NetworkServer.StartServer(Settings.Default.Port);
                btn_Host.Text = "Stop Server";
                lbl_IP.Visible = true;
                tbx_IPs.Visible = true;
                lbl_GameStart.Visible = true;
                Btn_GameSettings.Enabled = false;
            }
            else
            {
                Networking.NetworkServer.StopServerListener();
                btn_Host.Text = "Start Server";
                lbl_IP.Visible = false;
                tbx_IPs.Visible = false;
                lbl_GameStart.Visible = false;
                Btn_GameSettings.Enabled = true;
            }
        }

        private void Btn_GameSettings_Click(object sender, EventArgs e)
        {
            //Go to the settings MDI
            MDI_Container.SwitchMDI(MDI_Form_Enum.MDI_GameSettings);
        }
    }
}