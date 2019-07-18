using System;
using System.Windows.Forms;

namespace Ex02_Othelo
{
    class PiecesPictureBox : PictureBox
    {
        private Player.eTeam m_Team;
        private Coordinates m_Coordinates;

        public PiecesPictureBox(Coordinates i_Coordinates)
        {
            m_Coordinates = i_Coordinates;

            SetImageBackColor();
            setImageLocation();
            setImageLocationOnBoard();
            setImageSize();
            setImageBoardStyle();
        }

        public Coordinates ImageCoordinate
        {
            get { return m_Coordinates; }
        }

        public Player.eTeam Team
        {
            get { return m_Team; }
            set
            {
                m_Team = value;
                setImageLocation();
            }
        }

        public void SetImageBackColor()
        {
            if (m_Coordinates.X % 2 == 0 && m_Coordinates.Y % 2 ==0 || m_Coordinates.X % 2 != 0 && m_Coordinates.Y % 2 != 0) 
                BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
            else
                BackColor = System.Drawing.Color.FromArgb(0, 204, 0);

        }

        private void setImageBoardStyle()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Padding = new System.Windows.Forms.Padding(6);
           // ControlPaint.DrawBorder(this.System.Drawing.Graphics,this.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void setImageSize()
        {
            this.Size = new System.Drawing.Size(48, 48);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void setImageLocationOnBoard()
        {
            this.Location = new System.Drawing.Point(20 + m_Coordinates.X * 50, 90 + m_Coordinates.Y * 50);
        }

        private void setImageLocation()
        {
            if (m_Team == Player.eTeam.Black) 
            {
                this.Load(@"...\...\...\Images\BlackPiece.gif");
                //this.ImageLocation = @"...\...\...\Images\BlackPiece.gif";
            }
            else if (m_Team == Player.eTeam.White)
            {
                this.Load(@"...\...\...\Images\WhitePiece.gif");
                //this.ImageLocation = @"...\...\...\Images\WhitePiece.gif";
            }
        }
    }
}
