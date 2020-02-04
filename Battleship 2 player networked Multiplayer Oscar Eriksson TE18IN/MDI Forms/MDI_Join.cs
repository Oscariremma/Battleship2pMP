using NetworkCommsDotNet;
using NetworkCommsDotNet.Tools;
using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Battleship2pMP.MDI_Forms
{
    public partial class MDI_Join : Form
    {
        public delegate void DelJoinResult(bool ConnectionSuccessful);

        public static DelJoinResult DJoinResult;

        /// <summary>
        ///
        /// </summary>

        public MDI_Join()
        {
            InitializeComponent();
            //Set fonts to memory font loaded in main
            lbl_Title.SetMilitaryFont();
            btn_Back_To_MainMenu.SetMilitaryFont();
            Btn_Join.SetMilitaryFont();

            pbx_SideBackround.BackgroundImage = Program.MainMenuImg;

            DJoinResult = new DelJoinResult(JoinResult);

            tbx_IP.Text = Settings.Default.LastIP;
            tbx_IP.KeyDown += new KeyEventHandler(Tbx_IP_KeyDown);
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
                iPEndPoint = IPTools.ParseEndPointFromString(tbx_IP.Text + ":" + Settings.Default.Port.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Check IP format", "IP format invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread thread = new Thread(() => Networking.NetworkClient.ConnectToServer(new ConnectionInfo(iPEndPoint)));
            thread.Start();
            tbx_IP.Enabled = false;
            Btn_Join.Enabled = false;
            Btn_Join.Text = "Connecting...";
            Settings.Default.LastIP = tbx_IP.Text;
            Settings.SaveSettings();
        }

        void Tbx_IP_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && Btn_Join.Enabled)
            {
                Btn_Join_Click(null, null);
            }
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
                Btn_Join.Enabled = true;
                Btn_Join.Text = "Join Game";
                MessageBox.Show("Failed to connect to server, is the server running and reachable?", "Failed to connect!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}