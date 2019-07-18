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
    public delegate void clickOnPictureBoxEventHandler(Coordinates ClickedCoordinate);
    public delegate void PlayerWantNewRoundEventHandler(bool firstRoundFlag = false);
    public delegate void PlayerSavedGameEventHandler();

    public partial class FormOthloGameBoard : Form
    {
        //--------------------------------------------------------------------------------------//
        //                                   Data Members                                       //
        //--------------------------------------------------------------------------------------//

        private PiecesPictureBox[,] m_ImageOnBoard;
        private Label               m_Player1LabelScore;
        private Label               m_Player2LabelScore;
        private Label               m_PlayerTurnLabel;
        private PictureBox          m_PlayerTurnPictureBox;

        public event clickOnPictureBoxEventHandler  PlayerMakeAMove;
        public event PlayerWantNewRoundEventHandler NewRound;
        public event PlayerSavedGameEventHandler    SaveGame; 
            
        public FormOthloGameBoard(byte i_BoardSize, string i_Player1Name, string i_Player2Name, bool i_IsLoadedGame, List<Piece> i_ListOfPlayer1Pieces, List<Piece> i_ListOfPlayer2Pieces)
        {
            InitializeComponent();
            FormClosing += FormOthloGameBoard_FormClosing;
            initializeBoard(i_BoardSize, i_Player1Name, i_Player2Name, i_IsLoadedGame, i_ListOfPlayer1Pieces, i_ListOfPlayer2Pieces);
        }

        //--------------------------------------------------------------------------------------//
        //                                initialize UIBoard                                    //
        //--------------------------------------------------------------------------------------//

        private void initializeBoard(byte i_BoardSize, string i_Player1Name, string i_Player2Name, bool i_IsLoadedGame, List<Piece> i_ListOfPlayer1Pieces, List<Piece> i_ListOfPlayer2Pieces)
        {
            resizeBoard(i_BoardSize);
            initializePlayerTurnLabelAndPictureBox();
            initializeScoresLabel(i_BoardSize, i_Player1Name, i_Player2Name);
            m_ImageOnBoard = new PiecesPictureBox[(byte)i_BoardSize,(byte)i_BoardSize];

                for (byte row = 0; row < (byte)i_BoardSize; row++)
                {
                    for (byte column = 0; column < (byte)i_BoardSize; column++)
                    {
                        Coordinates currentCoordinateImage = new Coordinates(row, column);
                        m_ImageOnBoard[row, column] = new PiecesPictureBox(currentCoordinateImage);
                        this.Controls.Add(m_ImageOnBoard[row, column]);
                    }
                }

            if (i_IsLoadedGame == false)
            {
                initializeTheFourFirstImages(i_BoardSize);
            }
            else
            {
                initializeLoadedPiecesAndUpdateScore(i_ListOfPlayer1Pieces);
                initializeLoadedPiecesAndUpdateScore(i_ListOfPlayer2Pieces);
            }
        }

        private void initializeLoadedPiecesAndUpdateScore(List<Piece> i_ListOfPlayerPieces)
        {
            int playerScore = 0;
            foreach (Piece currentPiece in i_ListOfPlayerPieces)
            {
                byte row = currentPiece.CoordinatesOnBoard.X;
                byte column = currentPiece.CoordinatesOnBoard.Y;
                m_ImageOnBoard[row, column].Team = currentPiece.Team;
                Controls.Add(m_ImageOnBoard[row, column]);
                playerScore++;
            }

            ShowUpdatePlayerScore(i_ListOfPlayerPieces[0].Team, playerScore);
        }

        private void initializePlayerTurnLabelAndPictureBox()
        {
            m_PlayerTurnLabel = new Label();
            m_PlayerTurnLabel.AutoSize = true;
            m_PlayerTurnLabel.Location = new System.Drawing.Point(this.Right / 2 - m_PlayerTurnLabel.Right/2, this.Bottom-85);
            m_PlayerTurnLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            m_PlayerTurnLabel.ForeColor = Color.White;
            m_PlayerTurnLabel.BackColor = Color.Transparent;
            this.Controls.Add(m_PlayerTurnLabel);

            m_PlayerTurnPictureBox = new PictureBox();
            m_PlayerTurnPictureBox.Location = new System.Drawing.Point(m_PlayerTurnLabel.Left-50, m_PlayerTurnLabel.Top - 10);
            m_PlayerTurnPictureBox.AutoSize = true;
            m_PlayerTurnPictureBox.BackColor = Color.Transparent;
            this.Controls.Add(m_PlayerTurnPictureBox);
        }

        private void initializeScoresLabel(byte i_BoardSize, string i_Player1Name, string i_Player2Name)
        {
            Label player1LabelName = new Label();
            player1LabelName.Location = new System.Drawing.Point(this.Location.X + 20, this.Location.Y + 25);
            player1LabelName.Text = i_Player1Name + " score";
            player1LabelName.AutoSize = true;
            player1LabelName.Font = new Font("Arial", 12, FontStyle.Regular);
            player1LabelName.ForeColor = Color.White;
            player1LabelName.BackColor = Color.Transparent;
            this.Controls.Add(player1LabelName);

            m_Player1LabelScore = new Label();
            m_Player1LabelScore.Location = new System.Drawing.Point(((player1LabelName.Left + player1LabelName.Right) / 2 - 2), this.Location.Y + 55);
            m_Player1LabelScore.Text = "2";
            m_Player1LabelScore.AutoSize = true;
            m_Player1LabelScore.Font = new Font("Arial", 12, FontStyle.Bold);
            m_Player1LabelScore.ForeColor = Color.White;
            m_Player1LabelScore.BackColor = Color.Transparent;
            this.Controls.Add(m_Player1LabelScore);

            Label player2LabelName = new Label();
            player2LabelName.Text = i_Player2Name + " score";
            player2LabelName.AutoSize = true;
            player2LabelName.Location = new System.Drawing.Point(this.Right - 40 - player2LabelName.Width, this.Location.Y + 25);
            player2LabelName.Font = new Font("Arial", 12, FontStyle.Regular);
            player2LabelName.ForeColor = Color.White;
            player2LabelName.BackColor = Color.Transparent;
            this.Controls.Add(player2LabelName);

            m_Player2LabelScore = new Label();
            m_Player2LabelScore.Location = new System.Drawing.Point(((player2LabelName.Left + player2LabelName.Right) / 2 - 2), this.Location.Y + 55);
            m_Player2LabelScore.Text = "2";
            m_Player2LabelScore.AutoSize = true;
            m_Player2LabelScore.Font = new Font("Arial", 12, FontStyle.Bold);
            m_Player2LabelScore.ForeColor = Color.White;
            m_Player2LabelScore.BackColor = Color.Transparent;
            this.Controls.Add(m_Player2LabelScore);
        }

        private void resizeBoard(byte i_BoardSize)
        {
            int WidthSize = ((int)i_BoardSize * 50) + 38;
            int HeightSize = WidthSize + 120;
            ClientSize = new System.Drawing.Size(WidthSize, HeightSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void initializeTheFourFirstImages(byte i_BoardSize)
        {
            byte middleRow = (byte)((i_BoardSize / 2) - 1);
            byte middleColumn = middleRow;

            m_ImageOnBoard[middleRow, middleColumn + 1].Team = Player.eTeam.Black;
            m_ImageOnBoard[middleRow, middleColumn].Team = Player.eTeam.White;
            m_ImageOnBoard[middleRow + 1, middleColumn].Team = Player.eTeam.Black;
            m_ImageOnBoard[middleRow + 1, middleColumn + 1].Team = Player.eTeam.White;
        }

        //--------------------------------------------------------------------------------------//
        //                                  Public Methods                                      //
        //--------------------------------------------------------------------------------------//

        public void MarkAndAllowToPressOnlyValidMovesPictureBox(List<Coordinates> i_ValidMoveCoordinate, Player i_PlayerTurn, bool i_IsAgainstComputer)
        {
            if (!i_IsAgainstComputer || i_PlayerTurn.Team == Player.eTeam.Black)  
            {
                foreach (Coordinates currectCoordinate in i_ValidMoveCoordinate)
                {
                    m_ImageOnBoard[currectCoordinate.X, currectCoordinate.Y].BackColor = System.Drawing.Color.LightGray;
                    m_ImageOnBoard[currectCoordinate.X, currectCoordinate.Y].BorderStyle = BorderStyle.Fixed3D;
                    m_ImageOnBoard[currectCoordinate.X, currectCoordinate.Y].Click += PlayerClickedImagedOnBoard;
                    m_ImageOnBoard[currectCoordinate.X, currectCoordinate.Y].Cursor = Cursors.Hand;
                }
            }
        }

        public void AddPieceOnBoard(Piece i_NewPieceOnBoard)
        {
            byte XCoordinate = i_NewPieceOnBoard.CoordinatesOnBoard.X;
            byte YCoordinate = i_NewPieceOnBoard.CoordinatesOnBoard.Y;
            m_ImageOnBoard[XCoordinate, YCoordinate].Team = i_NewPieceOnBoard.Team;

            foreach (PiecesPictureBox currectPiecesPictureBox in m_ImageOnBoard)
            {
                currectPiecesPictureBox.SetImageBackColor();
                currectPiecesPictureBox.BorderStyle = BorderStyle.None;
                currectPiecesPictureBox.Click -= PlayerClickedImagedOnBoard;
                currectPiecesPictureBox.Cursor = Cursors.Default;
                currectPiecesPictureBox.Refresh();
            }
        }

        public void ChangeTeamPiece(List<Piece> listOfPiecesThatNeedToChangeTeam)
        {
            foreach (Piece currentFlipedPiece in listOfPiecesThatNeedToChangeTeam)
            {
                byte XCoordinate = currentFlipedPiece.CoordinatesOnBoard.X;
                byte YCoordinate = currentFlipedPiece.CoordinatesOnBoard.Y;
                m_ImageOnBoard[XCoordinate, YCoordinate].Team = currentFlipedPiece.Team;
                System.Threading.Thread.Sleep(700);
                m_ImageOnBoard[XCoordinate, YCoordinate].Refresh();
            }
        }

        public void PrintGameOverWithWinnerMessage(Player i_Winner)
        {
            string GameOverMessage;
            FormClosing -= FormOthloGameBoard_FormClosing;

            if (i_Winner == null)
            {
                GameOverMessage =
                    string.Format(
@"Game is over! - We have a tie!
Want a new game?");
            }
            else
            {
                GameOverMessage = string.Format(
@"Game is over! - The winner is {0}
Want a new game?", i_Winner.Name);
            }

            DialogResult dialogResult = MessageBox.Show(GameOverMessage, "Game Over", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Dispose();
                NewRound.Invoke();
            }
            else if (dialogResult == DialogResult.No)
                Close();
        }

        public void ShowUpdatePlayerTurn(Player i_UpdatedPlayerTurn)
        {
            string updatedPlayerTurnString = string.Format("{0}'s Turn", i_UpdatedPlayerTurn.Name);
            m_PlayerTurnLabel.Text = updatedPlayerTurnString;

            if (i_UpdatedPlayerTurn.Team == Player.eTeam.Black)
                m_PlayerTurnPictureBox.Load(@"...\...\...\Images\BlackPiece.gif");
            else
                m_PlayerTurnPictureBox.Load(@"...\...\...\Images\WhitePiece.gif");
        }

        public void ShowUpdatePlayerScore(Player.eTeam i_PlayerTeam, int i_Score)
        {
            if (i_PlayerTeam == Player.eTeam.Black)
                m_Player1LabelScore.Text = i_Score.ToString();
            else
                m_Player2LabelScore.Text = i_Score.ToString();
        }

        private void OnSaveGame()
        {
            SaveGame.Invoke();
        }

        public void SaveGameToFile(string[] i_GameCurrentPositionOnString)
        {
            SaveFileDialog saver = new SaveFileDialog();
            DialogResult resultFileDialog = saver.ShowDialog();
            
            if (resultFileDialog == DialogResult.OK)
            {
                System.IO.File.WriteAllLines(saver.FileName + ".otlo", i_GameCurrentPositionOnString);
            }
        }

        //--------------------------------------------------------------------------------------//
        //                                Listeners functions                                   //
        //--------------------------------------------------------------------------------------//
        private void PlayerClickedImagedOnBoard(object i_ImagedOnBoard, EventArgs e)
        {
            PiecesPictureBox ImagedOnBoard = i_ImagedOnBoard as PiecesPictureBox;
            PlayerMakeAMove.Invoke(ImagedOnBoard.ImageCoordinate);
        }

        private void FormOthloGameBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogSave = MessageBox.Show("Do you want to Save the game?", "Save", MessageBoxButtons.YesNo);

            if (dialogSave == DialogResult.Yes)
                OnSaveGame();
        }
    }  
}
