using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex02_Othelo
{

    public delegate void ClickOnLoadGameEventHandler(string[] i_StringOfstateOfGameToLoad);

    public partial class FormGameSettings : Form
    {
        private eGameMode m_GameMode;
        public event ClickOnLoadGameEventHandler LoadGame;

        public eGameMode GameMode
        {
            get{ return m_GameMode; }
        }

        public FormGameSettings()
        {
            InitializeComponent();
            FormClosing += FormGameSettings_FormClosing;
        }

        private void button_TwoPlayers_Click(object sender, EventArgs e)
        {
            m_GameMode = eGameMode.AgainstPlayer;
            FormClosing -= FormGameSettings_FormClosing;
            Close();
        }

        private void button_SinglePlayer_Click(object sender, EventArgs e)
        {
            m_GameMode = eGameMode.AgainstComputer;
            FormClosing -= FormGameSettings_FormClosing;
            Close();
        }

        private void FormGameSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void LoadGame_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog loader = new OpenFileDialog();

            if (loader.ShowDialog() == DialogResult.OK) 
            {
                if (System.IO.Path.GetExtension(loader.FileName).Equals(".otlo"))
                {
                    string[] filesToOpen = new string[1];
                    filesToOpen = System.IO.File.ReadAllLines(loader.FileName);
                    LoadGame.Invoke(filesToOpen);
                }
                else
                {
                    MessageBox.Show("Unrecognized File");
                }  
            }
            else
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                this.Close(); 
            }

            FormClosing -= FormGameSettings_FormClosing;
        }
    }
}
