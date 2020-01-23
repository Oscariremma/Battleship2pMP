using Battleship2pMP.MDI_Forms;
using System;
using System.Windows.Forms;

namespace Battleship2pMP
{
    /// <summary>
    /// The main game window, acts as an MDI container
    /// </summary>
    public partial class MDI_Container : Form
    {
        public static MDI_Container staticMdi_Container;

        public delegate void DelLostConnection();

        public delegate void DelLeaveGame();

        public DelLostConnection DLostConnection;
        public DelLeaveGame DLeaveGame;

        private MDI_MainMenu mdi_MainMenu;
        private MDI_Game mdi_Game;
        private MDI_Host mdi_Host;
        public MDI_Join mdi_Join;
        private MDI_GameSettings mdi_GameSettings;

        private Form CurrentMDI;

        public delegate void DelSwitchMDI(MDI_Form_Enum MDI, bool ResetMDI = false);

        public static DelSwitchMDI DSwitchMDI;

        public static bool OpponentHasLeftGame;
        public static bool GameIsFinished;

        public MDI_Container()
        {
            InitializeComponent();
            staticMdi_Container = this;
            DSwitchMDI = new DelSwitchMDI(SwitchMDI);
            DLostConnection = new DelLostConnection(LostConnection);
            DLeaveGame = new DelLeaveGame(LeaveGame);
            this.FormClosing += new FormClosingEventHandler(GameClosing);
        }

        /// <summary>
        /// Switch to the MainMenu MDI when the MDI Container has loaded
        /// </summary>
        private void MDI_Container_Load(object sender, EventArgs e)
        {
            SwitchMDI(MDI_Form_Enum.MDI_MainMenu, true);
        }

        /// <summary>
        /// Switch to the MDI displayed to the MDI corresponding to the MDI enum, ResetMDI causes a new instance of the selected MDI to created and the old to be disposed
        /// </summary>
        public static void SwitchMDI(MDI_Form_Enum MDI, bool ResetMDI = false)
        {
            if (staticMdi_Container.CurrentMDI != null)
            {
                staticMdi_Container.CurrentMDI.Hide();
            }

            switch (MDI)
            {
                case MDI_Form_Enum.MDI_MainMenu:
                    if (ResetMDI || staticMdi_Container.mdi_MainMenu == null)
                    {
                        if (staticMdi_Container.mdi_MainMenu != null) staticMdi_Container.mdi_MainMenu.Dispose();
                        staticMdi_Container.mdi_MainMenu = new MDI_MainMenu();
                    }
                    staticMdi_Container.CurrentMDI = staticMdi_Container.mdi_MainMenu;
                    break;

                case MDI_Form_Enum.MDI_Game:
                    if (ResetMDI || staticMdi_Container.mdi_Game == null)
                    {
                        if (staticMdi_Container.mdi_Game != null)
                        {
                            staticMdi_Container.mdi_Game.Invoke(staticMdi_Container.mdi_Game.DStopUpdateTimer);
                            staticMdi_Container.mdi_Game.Close();
                            staticMdi_Container.mdi_Game.Dispose();
                        }
                        staticMdi_Container.mdi_Game = new MDI_Game();
                    }
                    staticMdi_Container.CurrentMDI = staticMdi_Container.mdi_Game;
                    break;

                case MDI_Form_Enum.MDI_Host:
                    if (ResetMDI || staticMdi_Container.mdi_Host == null)
                    {
                        if (staticMdi_Container.mdi_Host != null) staticMdi_Container.mdi_Host.Dispose();
                        staticMdi_Container.mdi_Host = new MDI_Host();
                    }
                    staticMdi_Container.CurrentMDI = staticMdi_Container.mdi_Host;
                    break;

                case MDI_Form_Enum.MDI_Join:
                    if (ResetMDI || staticMdi_Container.mdi_Join == null)
                    {
                        if (staticMdi_Container.mdi_Join != null) staticMdi_Container.mdi_Join.Dispose();
                        staticMdi_Container.mdi_Join = new MDI_Join();
                    }
                    staticMdi_Container.CurrentMDI = staticMdi_Container.mdi_Join;
                    break;

                case MDI_Form_Enum.MDI_GameSettings:
                    if (ResetMDI || staticMdi_Container.mdi_GameSettings == null)
                    {
                        if (staticMdi_Container.mdi_GameSettings != null) staticMdi_Container.mdi_GameSettings.Dispose();
                        staticMdi_Container.mdi_GameSettings = new MDI_GameSettings();
                    }
                    staticMdi_Container.CurrentMDI = staticMdi_Container.mdi_GameSettings;
                    break;
            }

            staticMdi_Container.CurrentMDI.MdiParent = staticMdi_Container;
            staticMdi_Container.CurrentMDI.Dock = DockStyle.Fill;
            staticMdi_Container.CurrentMDI.Show();
        }

        /// <summary>
        /// Called if a connection is unexpectedly closed, gracefully exits the game if it can not continue
        /// </summary>
        public void LostConnection()
        {
            if (staticMdi_Container.mdi_Game != null && GameIsFinished && !OpponentHasLeftGame)
            {
                MDI_Game.staticGame.BeginInvoke(MDI_Game.staticGame.DOpponentHasLeftGame);
                OpponentHasLeftGame = true;
            }

            if (staticMdi_Container.mdi_Game != null && !OpponentHasLeftGame)
            {
                SwitchMDI(MDI_Form_Enum.MDI_MainMenu, false);

                staticMdi_Container.mdi_Game.Invoke(staticMdi_Container.mdi_Game.DStopUpdateTimer);
                staticMdi_Container.mdi_Game.Close();
                staticMdi_Container.mdi_Game.Dispose();
                staticMdi_Container.mdi_Game = null;
                Networking.ShutdownAllNetworking();
                MessageBox.Show("The Game has lost the connection to your opponent. Returning to the Main Menu", "Network Communication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Shutsdown all networking and returns to game to the main menu
        /// </summary>
        public void LeaveGame()
        {
            SwitchMDI(MDI_Form_Enum.MDI_MainMenu, false);
            if (staticMdi_Container.mdi_Game != null)
            {
                staticMdi_Container.mdi_Game.Invoke(staticMdi_Container.mdi_Game.DStopUpdateTimer);
                staticMdi_Container.mdi_Game.Close();
                staticMdi_Container.mdi_Game.Dispose();
            }
            staticMdi_Container.mdi_Game = null;
            Networking.ShutdownAllNetworking();
        }

        /// <summary>
        /// Catch when the user clicks on the X button and check if it is OK to leave and exit the game
        /// </summary>
        void GameClosing(object sender, FormClosingEventArgs formClosingEventArgs)
        {
            if(CurrentMDI.GetType() == typeof(MDI_Game))
            {
                if (GameIsFinished)
                {
                    if(MessageBox.Show("Are you sure you want to quit the game?","Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!OpponentHasLeftGame)
                        {
                            if (Networking.IsServer)
                            {
                                Networking.NetworkServer.StaticgameLogic.LeaveGame(true);
                                Networking.ShutdownAllNetworking();
                            }
                            else
                            {
                                Networking.NetworkClient.RemoteServerInterface.LeaveGame();
                                Networking.ShutdownAllNetworking();
                            }
                        }
                    }
                    else
                    {
                        formClosingEventArgs.Cancel = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to surrender and quit the game?", "Surrender and Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!OpponentHasLeftGame)
                        {
                            if (Networking.IsServer)
                            {
                                Networking.NetworkServer.StaticgameLogic.Surrender(true);
                                Networking.NetworkServer.StaticgameLogic.LeaveGame(true);
                                Networking.ShutdownAllNetworking();
                            }
                            else
                            {
                                Networking.NetworkClient.RemoteServerInterface.Surrender();
                                Networking.NetworkClient.RemoteServerInterface.LeaveGame();
                                Networking.ShutdownAllNetworking();
                            }
                        }
                    }
                    else
                    {
                        formClosingEventArgs.Cancel = true;
                    }
                }
            }
            else
            {
                Networking.ShutdownAllNetworking();
            }
        }

    }

    /// <summary>
    /// Enum corresponding to all available MDI forms
    /// </summary>
    public enum MDI_Form_Enum
    {
        MDI_MainMenu,
        MDI_Game,
        MDI_Host,
        MDI_Join,
        MDI_GameSettings
    }
}