using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Battleship2pMP
{
    internal static class Program
    {
        static public PrivateFontCollection pfc = new PrivateFontCollection();
        static public Image MainMenuImg;
        static public Image GameBackground;
        static public Image Green_Reticle;
        static public Image Red_Reticle;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///
        [STAThread]
        private static void Main()
        {
            // Read the byte length of the font data
            int fontByteLength = Properties.Resources.font_armalite.Length;

            // Read font data in to a new memory buffer
            byte[] fontDataBuffer = Properties.Resources.font_armalite;

            // Allocate a unsafe memory block for the font data
            IntPtr fontDataPointer = Marshal.AllocCoTaskMem(fontByteLength);

            // Copy the font data to the unsafe memory block
            Marshal.Copy(fontDataBuffer, 0, fontDataPointer, fontByteLength);

            // Add the memory font to the private font collection
            pfc.AddMemoryFont(fontDataPointer, fontByteLength);

            //Load the main menu image in to ram
            MainMenuImg = Image.FromHbitmap(Properties.Resources._1695px_BB61_USS_Iowa_BB61_broadside_USN.GetHbitmap());
            //Load the game background image in to ram
            GameBackground = Image.FromHbitmap(Properties.Resources.Water_texture_1380389_Nevit.GetHbitmap());

            Green_Reticle = (Image)Properties.Resources.Green_Reticle.Clone();
            Red_Reticle = (Image)Properties.Resources.Red_Reticle.Clone();

            //Load all ship sprites in to memory
            Ships.Ship.LoadShips();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDI_Container());
        }
    }
}