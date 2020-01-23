using System;
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
    public partial class MDI_MainMenu : Form
    {
        public MDI_MainMenu()
        {
            InitializeComponent();
            //Set fonts to memory font loaded in main
            lbl_Title.SetMilitaryFont();
            btn_Host.SetMilitaryFont();
            btn_Join.SetMilitaryFont();
            btn_Quit.SetMilitaryFont();

            pbx_SideBackround.BackgroundImage = Program.MainMenuImg;

        }



        private void Btn_Host_Click(object sender, EventArgs e)
        {
            //Switch to the Host MDI
            MDI_Container.SwitchMDI(MDI_Form_Enum.MDI_Host, true);
        }

        private void Btn_Join_Click(object sender, EventArgs e)
        {
            //Switch to the Join MDI
            MDI_Container.SwitchMDI(MDI_Form_Enum.MDI_Join, true);
        }

        private void Btn_Quit_Click(object sender, EventArgs e)
        {
            //Ask if user wants to quit
            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
