using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Battleship2pMP
{
    public class Settings
    {
        /// <summary>
        /// Path to the settings file
        /// </summary>
        private static readonly string SettingsFilePath = ".\\Settings.xml";

        [XmlIgnore]
        public static Settings Default
        {
            get
            {
                if (!SettingsLoaded)
                {
                    LoadSettings();
                }

                return LoadedSettings;
            }
            set
            {
                LoadedSettings = value;
            }
        }

        [XmlIgnore]
        static bool SettingsLoaded = false;

        [XmlIgnore]
        private static Settings LoadedSettings;

        //Settings Variables
        public int Carriers = 1;
        public int Battleships = 1;
        public int Cruisers = 2;
        public int Destroyers = 3;
        public int Submarines = 3;

        public int ShotsFirstTurn = 4;
        public int ShotsPerTurn = 1;
        public int PostTurnDelay = 3000;
        public string LastIP = "";
        public int Port = 30664;


        /// <summary>
        /// Try to load settings from disk
        /// </summary>
        public static void LoadSettings()
        {

            if (File.Exists(SettingsFilePath))
            {
                TextReader reader = new StreamReader(SettingsFilePath);

                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));

                    LoadedSettings = (Settings)xmlSerializer.Deserialize(reader);
                    SettingsLoaded = true;
                }
                catch
                {
                    LoadedSettings = new Settings();
                    SettingsLoaded = true;
                }

                reader.Close();

            }
            else
            {
                LoadedSettings = new Settings();
                SettingsLoaded = true;
            }


        }

        /// <summary>
        /// Save settings to disk
        /// </summary>
        public static void SaveSettings()
        {
            if(LoadedSettings != null)
            {
                TextWriter writer = new StreamWriter(SettingsFilePath);

                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));

                    xmlSerializer.Serialize(writer, LoadedSettings);
                }
                catch
                {

                }

                writer.Close();
            }
        }
    }
}
