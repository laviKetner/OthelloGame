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
    public partial class FormSinglePlayer : Form
    {
        private eBoardSize  m_BoardSize   = eBoardSize.Medium;
        private eDifficulty m_Difficulty  = eDifficulty.Medium;
        private string      m_Player1Name = null;

        public string Player1Name
        {
            get{ return m_Player1Name; }
        }

        public eBoardSize BoardSize
        {
            get{ return m_BoardSize; }
        }

        public eDifficulty Difficulty
        {
            get { return m_Difficulty; }
        }

        public FormSinglePlayer()
        {
            InitializeComponent();
            backColorToAllComponent();
            FormClosing += FormSinglePlayer_FormClosing;
        }

        private void backColorToAllComponent()
        {
            singlePlayer_Panel.BackColor = Color.FromArgb(140, Color.Black);
            Difficulty_Panel.BackColor = Color.FromArgb(140, Color.Black);
            PlayerName_Label.BackColor = Color.Transparent;
            radioButton_10X10.BackColor = Color.Transparent;
            radioButton_8X8.BackColor = Color.Transparent;
            radioButton_6X6.BackColor = Color.Transparent;
            BoardSize_groupBox.BackColor = Color.Transparent;
        }

        private void button_Play_Click(object sender, EventArgs e)
        {
            //User input player name:
            m_Player1Name = Player1Name_TextBox.Text;

            //User input board size:
            if(radioButton_6X6.Checked)
                m_BoardSize = eBoardSize.Small;
            else if (radioButton_8X8.Checked)
                m_BoardSize = eBoardSize.Medium;
            else if (radioButton_10X10.Checked)
                m_BoardSize = eBoardSize.Large;

            //User input difficulty
            if (Easy_RadioButton.Checked)
                m_Difficulty = eDifficulty.Easy;
            else if (Medium_RadioButton.Checked)
                m_Difficulty = eDifficulty.Medium;
            else if (Hard_RadioButton.Checked)
                m_Difficulty = eDifficulty.Hard;

            FormClosing -= FormSinglePlayer_FormClosing;
            Close();
        }

        private void FormSinglePlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
