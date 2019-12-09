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
            lbl_Title.Font = new Font(Program.pfc.Families[0], lbl_Title.Font.Size);
            btn_Host.Font = new Font(Program.pfc.Families[0], btn_Host.Font.Size);
            btn_Join.Font = new Font(Program.pfc.Families[0], btn_Join.Font.Size);
            btn_Quit.Font = new Font(Program.pfc.Families[0], btn_Quit.Font.Size);

            pictureBox1.BackgroundImage = Program.MainMenuImg;

        }



        private void Btn_Host_Click(object sender, EventArgs e)
        {
            //Switch to game host MDI
            MDI_Container.SwitchMDI(MDI_Form_Enum.MDI_Host, true);
        }

        private void Btn_Join_Click(object sender, EventArgs e)
        {
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
