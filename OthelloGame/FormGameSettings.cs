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
    public enum eGameMode : byte
    {
        AgainstComputer,
        AgainstPlayer,
        AgainstPlayerOnline,
    }
   
    public partial class FormGameSettings : Form
    {
        eGameMode m_GameMode;

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
    }
}
