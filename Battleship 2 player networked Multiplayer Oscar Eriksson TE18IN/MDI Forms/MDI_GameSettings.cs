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
    public partial class MDI_GameSettings : Form
    {
        public MDI_GameSettings()
        {
            InitializeComponent();
            Btn_Back.SetMilitaryFont();
            Btn_Reset.SetMilitaryFont();
            lbl_Title.SetMilitaryFont();

            pictureBox1.BackgroundImage = Program.MainMenuImg;

            LoadValuesFromSettings();
        }

        void LoadValuesFromSettings()
        {
            num_Carriers.Value = Properties.Settings.Default.Carriers;
            num_Battleships.Value = Properties.Settings.Default.Battleships;
            num_Cruisers.Value = Properties.Settings.Default.Cruisers;
            num_Destroyers.Value = Properties.Settings.Default.Destroyers;
            num_Submarines.Value = Properties.Settings.Default.Submarines;

            num_ShotsFirstTurn.Value = Properties.Settings.Default.ShotsFirstTurn;
            num_ShotsPerTurn.Value = Properties.Settings.Default.ShotsPerTurn;

            num_PostTurnDelay.Value = decimal.Divide(Properties.Settings.Default.PostTurnDelay, 1000);
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you sure that you want to reset all settings to their defaults?", "Reset all settings?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            string LastIP = Properties.Settings.Default.LastIP;
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.LastIP = LastIP;
            Properties.Settings.Default.Save();
            LoadValuesFromSettings();
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            if(num_Carriers.Value + num_Battleships.Value + num_Cruisers.Value + num_Destroyers.Value + num_Submarines.Value == 0)
            {
                MessageBox.Show("You need to have at minimum 1 ship", "No Ships", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default.Carriers = (int)num_Carriers.Value;
            Properties.Settings.Default.Battleships = (int)num_Battleships.Value;
            Properties.Settings.Default.Cruisers = (int)num_Cruisers.Value;
            Properties.Settings.Default.Destroyers = (int)num_Destroyers.Value;
            Properties.Settings.Default.Submarines = (int)num_Submarines.Value;

            Properties.Settings.Default.ShotsFirstTurn = (int)num_ShotsFirstTurn.Value;
            Properties.Settings.Default.ShotsPerTurn = (int)num_ShotsPerTurn.Value;

            Properties.Settings.Default.PostTurnDelay = (int)(num_PostTurnDelay.Value * 1000);

            Properties.Settings.Default.Save();

            MDI_Container.SwitchMDI(MDI_Form_Enum.MDI_Host);

        }
    }
}
