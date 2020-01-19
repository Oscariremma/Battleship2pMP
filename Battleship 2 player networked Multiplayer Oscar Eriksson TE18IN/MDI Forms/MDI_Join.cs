using System;
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
            lbl_Title.SetMilitaryFont();
            btn_Back_To_MainMenu.SetMilitaryFont();
            btn_Join.SetMilitaryFont();

            pictureBox1.BackgroundImage = Program.MainMenuImg;

            DJoinResult = new DelJoinResult(JoinResult);

            tbx_IP.Text = Properties.Settings.Default.LastIP;

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
            Properties.Settings.Default.LastIP = tbx_IP.Text;
            Properties.Settings.Default.Save();
        }

        public void JoinResult(bool ConnectionSuccessful)
        {
            if (ConnectionSuccessful)
            {
                Networking.NetworkClient.RemoteServerInterface.StartGame();
            }
            else
            {
                tbx_IP.Enabled = true;
                btn_Join.Enabled = true;
                btn_Join.Text = "Join Game";
                MessageBox.Show("Failed to connect to server, is the server running and reachable?", "Failed to connect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
