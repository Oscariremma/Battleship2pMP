using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battleship2pMP.MDI_Forms;

namespace Battleship2pMP
{
    public partial class MDI_Container : Form
    {
        public static MDI_Container staticMdi_Container;
        public delegate void DelLostConnection();
        public DelLostConnection DLostConnection;
        MDI_MainMenu mdi_MainMenu;
        MDI_Game mdi_Game;
        MDI_Host mdi_Host;
        MDI_Join mdi_Join;

        Form CurrentMDI;

        public delegate void DelSwitchMDI(MDI_Form_Enum MDI, bool ResetMDI = false);
        public static DelSwitchMDI DSwitchMDI;

        public MDI_Container()
        {
            InitializeComponent();
            staticMdi_Container = this;
            DSwitchMDI = new DelSwitchMDI(SwitchMDI);
            DLostConnection = new DelLostConnection(LostConnection);
        }

        private void MDI_Container_Load(object sender, EventArgs e)
        {

            SwitchMDI(MDI_Form_Enum.MDI_MainMenu, true);

        }

        public static void SwitchMDI(MDI_Form_Enum MDI, bool ResetMDI = false)
        {

            if(staticMdi_Container.CurrentMDI != null)
            {
                staticMdi_Container.CurrentMDI.Hide();
            }

            switch (MDI)
            {
                case MDI_Form_Enum.MDI_MainMenu:
                    if (ResetMDI)
                    {
                        if(staticMdi_Container.mdi_MainMenu != null) staticMdi_Container.mdi_MainMenu.Dispose();
                        staticMdi_Container.mdi_MainMenu = new MDI_MainMenu();
                    }
                    staticMdi_Container.CurrentMDI = staticMdi_Container.mdi_MainMenu;
                    break;
                case MDI_Form_Enum.MDI_Game:
                    if (ResetMDI)
                    {
                        if (staticMdi_Container.mdi_Game != null)
                        {
                            staticMdi_Container.mdi_Game.Invoke(staticMdi_Container.mdi_Game.DStopUpdateTimer);
                            System.Threading.Thread.Sleep(30);
                            staticMdi_Container.mdi_Game.Close();
                            staticMdi_Container.mdi_Game.Dispose();
                        }
                        staticMdi_Container.mdi_Game = new MDI_Game();
                    }
                    staticMdi_Container.CurrentMDI = staticMdi_Container.mdi_Game;
                    break;
                case MDI_Form_Enum.MDI_Host:
                    if (ResetMDI)
                    {
                        if (staticMdi_Container.mdi_Host != null) staticMdi_Container.mdi_Host.Dispose();
                        staticMdi_Container.mdi_Host = new MDI_Host();
                    }
                    staticMdi_Container.CurrentMDI = staticMdi_Container.mdi_Host;
                    break;
                case MDI_Form_Enum.MDI_Join:
                    if (ResetMDI)
                    {
                        if (staticMdi_Container.mdi_Join != null) staticMdi_Container.mdi_Join.Dispose();
                        staticMdi_Container.mdi_Join = new MDI_Join();
                    }
                    staticMdi_Container.CurrentMDI = staticMdi_Container.mdi_Join;
                    break;

            }

            staticMdi_Container.CurrentMDI.MdiParent = staticMdi_Container;
            staticMdi_Container.CurrentMDI.Dock = DockStyle.Fill;
            staticMdi_Container.CurrentMDI.Show();

        }

        public void LostConnection()
        {

            SwitchMDI(MDI_Form_Enum.MDI_MainMenu, true);
            if (staticMdi_Container.mdi_Game != null)
            {
                staticMdi_Container.mdi_Game.Invoke(staticMdi_Container.mdi_Game.DStopUpdateTimer);
                System.Threading.Thread.Sleep(30);
                staticMdi_Container.mdi_Game.Close();
                staticMdi_Container.mdi_Game.Dispose();
            }
            staticMdi_Container.mdi_Game = null;
            RemoteProcedureCalls.Server.ShutdownAllRPC();
            try
            {
                RemoteProcedureCalls.Server.serverConnection.CloseConnection(true);
            }
            catch
            {

            }
            RemoteProcedureCalls.Server.serverConnection = null;
            MessageBox.Show("The Game has lost the connection to your opponent. Returning to the Main Menu", "Network Communication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }


    public enum MDI_Form_Enum
    {
        MDI_MainMenu,
        MDI_Game,
        MDI_Host,
        MDI_Join

    }
}
