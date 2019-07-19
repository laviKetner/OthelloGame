using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Ex02_Othelo
{
    public enum eBoardSize : byte
    {
        Small  = 6,
        Medium = 8,
        Large  = 10
    }

    public enum eDifficulty : byte
    {
        Empty_AgainstHuman = 0,
        Easy               = 1,
        Medium             = 2,
        Hard               = 3,
    }

    public enum eGameMode : byte
    {
        AgainstComputer     = 0,
        AgainstPlayer       = 1,
        AgainstPlayerOnline = 2
    }

    class OtheloGameManager
    {
        //--------------------------------------------------------------------------------------//
        //                                   Data Members                                       //
        //--------------------------------------------------------------------------------------//

        private FormGameSettings   m_FormGameSettings;
        private FormOthloGameBoard m_FormOthloGameBoard;
        private OtheloGameLogic    m_OtheloGameLogic;
        private byte               m_BoardSize;
        private byte               m_GameMode;
        private string             m_Player1Name ;
        private string             m_Player2Name = "Computer";
        private bool               m_IsAgainstComputer = false;
        private byte               m_Difficulty;
        private bool               m_LoadedGame = false;
        private Player.eTeam       m_Turn;

        private List<Piece>        m_ListOfPlayer1Pieces; //Incase of loaded game we need to load this lists and bring them to GameLogic
        private List<Piece>        m_ListOfPlayer2Pieces; //Incase of loaded game we need to load this lists and bring them to GameLogic

        //--------------------------------------------------------------------------------------//
        //                                   Initialize Game                                    //
        //--------------------------------------------------------------------------------------//

        public void RunGame()
        {
            initializeGame();
        }

        private void initializeGame(bool i_IsFirstRoundFlag = true)
        {
            if (i_IsFirstRoundFlag)
            {
                showGameSettingForm();

                if (m_LoadedGame == false)
                {
                    m_GameMode = (byte)m_FormGameSettings.GameMode;
                    openGameModeFormAndGetInitializeInfo();
                }
            }

            initializeGameLogic();
            initializeGameBoard();//UI
            startPlaying();
        }

        private void initializeGameBoard()
        {
            m_FormOthloGameBoard = new FormOthloGameBoard(m_BoardSize, m_Player1Name, m_Player2Name, m_LoadedGame, m_ListOfPlayer1Pieces, m_ListOfPlayer2Pieces);
            m_FormOthloGameBoard.NewRound += initializeGame;
            m_FormOthloGameBoard.PlayerMakeAMove += doPlayersMove;
            m_FormOthloGameBoard.SaveGame += PlayerSavedGame;
        }

        private void initializeGameLogic()
        {
            m_OtheloGameLogic = new OtheloGameLogic(m_BoardSize, m_Player1Name, m_Player2Name, m_IsAgainstComputer, m_Turn, (eDifficulty)m_Difficulty);
            m_OtheloGameLogic.ValidMovesCoordinateChange += sendToFormOthloGameBoardTheCurrentValidMovesCoordinate;
            m_OtheloGameLogic.PieceAddedOnBoard += pieceAddedOnBoard;
            m_OtheloGameLogic.CellsChangedTeam += cellsChangedTeam;
        }

        private void openGameModeFormAndGetInitializeInfo()
        {
            switch ((eGameMode)m_GameMode)
            {
                case eGameMode.AgainstComputer:
                    {
                        FormSinglePlayer formSinglePlayer = new FormSinglePlayer();
                        formSinglePlayer.ShowDialog();
                        m_Player1Name = formSinglePlayer.Player1Name;
                        m_BoardSize = (byte)formSinglePlayer.BoardSize;
                        m_Difficulty = (byte)formSinglePlayer.Difficulty;
                        m_IsAgainstComputer = true;
                        break;
                    }
                case eGameMode.AgainstPlayer:
                    {
                        FormTwoPlayers formTwoPlayer = new FormTwoPlayers();
                        formTwoPlayer.ShowDialog();
                        m_Player1Name = formTwoPlayer.Player1Name;
                        m_Player2Name = formTwoPlayer.Player2Name;
                        m_BoardSize = (byte)formTwoPlayer.BoardSize;
                        break;
                    }
                case eGameMode.AgainstPlayerOnline:
                    {
                        FormPlayOnline formPlayOnline = new FormPlayOnline();
                        formPlayOnline.ShowDialog();
                        break;
                    }
            }
        }

        private void showGameSettingForm()
        {
            bool isUserChooseCorrectSettings = false;

            while (!isUserChooseCorrectSettings)
            {
                try
                {
                    m_FormGameSettings = new FormGameSettings();
                    m_FormGameSettings.LoadGame += loadGame;
                    m_FormGameSettings.ShowDialog();
                    isUserChooseCorrectSettings = true;
                }
                catch
                {
                    isUserChooseCorrectSettings = false;
                }
            }
        }

        private void startPlaying()
        {
            // ---- Run Logic game ---- //
            m_OtheloGameLogic.RunLogicGame(m_LoadedGame, m_ListOfPlayer1Pieces, m_ListOfPlayer2Pieces);
            m_LoadedGame = false;

            // ---- Run UI game ---- //
            m_FormOthloGameBoard.ShowDialog(); 
        }

        //--------------------------------------------------------------------------------------//
        //                                Listeners functions                                   //
        //--------------------------------------------------------------------------------------//

        private void cellsChangedTeam(List<Piece> i_ListOfPiecesThatNeedToChangeTeam)
        {
            m_FormOthloGameBoard.ChangeTeamPiece(i_ListOfPiecesThatNeedToChangeTeam);
        }

        private void sendToFormOthloGameBoardTheCurrentValidMovesCoordinate(List<Coordinates> i_ValidMoveCoordinate)
        {
            Player playerTurn = m_OtheloGameLogic.GetCurrentPlayerTurn();          
            bool isAgainstComputer = m_OtheloGameLogic.Player2.IsPlayerIsComputer; //need to send if isAgainstComputer to the func below, because we *dont* want to mark in gray computer cells options

            m_FormOthloGameBoard.ShowUpdatePlayerTurn(playerTurn);
            m_FormOthloGameBoard.MarkAndAllowToPressOnlyValidMovesPictureBox(i_ValidMoveCoordinate, playerTurn, isAgainstComputer);
        }

        //This func do player move and immediately computer move (if we agains computer).
        private async void doPlayersMove(Coordinates i_PlayerMoveCoordinate)
        {
            bool isGameOver = true;

            // Can be player1 or player2 (player 2 do this func only if he human.
            doPlayerHumanMove(ref isGameOver, i_PlayerMoveCoordinate);

            //if player2 is computer - we play in single mode - we will do computer move.
            if(m_OtheloGameLogic.Player2.IsPlayerIsComputer)
            {
                await Task.Delay(1200);
                doComputerMove(ref isGameOver);
            }

            //else player2 isn't computer - we play Two player mode, than we need to change turn, and we will enter this func again with the other player.
            else
            {
                if (!m_OtheloGameLogic.GetCurrentPlayerTurn().IsHaveValidMove)
                {
                    m_OtheloGameLogic.ChangeTurn();
                    if (!m_OtheloGameLogic.GetCurrentPlayerTurn().IsHaveValidMove)
                    {
                        isGameOver = true;
                    }
                }
            }

            if (isGameOver)
                m_FormOthloGameBoard.PrintGameOverWithWinnerMessage(m_OtheloGameLogic.Winner);
        }

        private void doComputerMove(ref bool io_IsGameOver)
        {
            if (m_OtheloGameLogic.Player2.IsHaveValidMove)
            {
                io_IsGameOver = false;
                if (m_OtheloGameLogic.Player2.IsPlayerIsComputer)
                    m_OtheloGameLogic.SetComputerPieceAndFlipAllTheInfluencedPieces();

                m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.Player1.Team, m_OtheloGameLogic.Player1.Score);
                m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.Player2.Team, m_OtheloGameLogic.Player2.Score);
            }
            else
                m_OtheloGameLogic.ChangeTurn();

            while (!m_OtheloGameLogic.Player1.IsHaveValidMove)
            {
                m_OtheloGameLogic.ChangeTurn();

                if (m_OtheloGameLogic.Player2.IsHaveValidMove)
                {
                    m_OtheloGameLogic.SetComputerPieceAndFlipAllTheInfluencedPieces();
                    m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.Player1.Team, m_OtheloGameLogic.Player1.Score);
                    m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.Player2.Team, m_OtheloGameLogic.Player2.Score);
                }
                else
                {
                    io_IsGameOver = true;
                    break;
                }
            }
        }

        private void doPlayerHumanMove(ref bool io_IsGameOver, Coordinates i_PlayerMoveCoordinate)
        {
            if (m_OtheloGameLogic.GetCurrentPlayerTurn().IsHaveValidMove)
            {
                io_IsGameOver = false;
                m_OtheloGameLogic.SetInputPieceAndFlipAllTheInfluencedPieces(i_PlayerMoveCoordinate);
                m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.GetCurrentPlayerTurn().Team, m_OtheloGameLogic.GetCurrentPlayerTurn().Score);
                m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.GetOpposingPlayer().Team, m_OtheloGameLogic.GetOpposingPlayer().Score);
            }
            else
                m_OtheloGameLogic.ChangeTurn();
        }

        private void pieceAddedOnBoard(Piece i_PieceAddedOnBoard)
        {
            m_FormOthloGameBoard.AddPieceOnBoard(i_PieceAddedOnBoard);
        }

        private void loadGame(string[] i_StringOfstateOfGameToLoad)
        {
            m_LoadedGame = true;
            XmlDocument xmlStateOfGame = new XmlDocument();
            xmlStateOfGame.LoadXml(i_StringOfstateOfGameToLoad[0]);

            getSettingInfoFromXml(xmlStateOfGame);
            m_ListOfPlayer1Pieces = getListOfPiecesFromXml(xmlStateOfGame, "Player1Pieces");
            m_ListOfPlayer2Pieces = getListOfPiecesFromXml(xmlStateOfGame, "Player2Pieces");
        }

        private void getSettingInfoFromXml(XmlDocument i_XmlStateOfGame)
        {
            XmlNode XmlNodeBoardSize = i_XmlStateOfGame.SelectSingleNode("LoadGame/GameSettings/BoardSize");
            m_BoardSize = byte.Parse(XmlNodeBoardSize.InnerText);

            XmlNode XmlNodeGameMode = i_XmlStateOfGame.SelectSingleNode("LoadGame/GameSettings/GameMode");
            m_GameMode = byte.Parse(XmlNodeGameMode.InnerText);
            if((eGameMode)m_GameMode == eGameMode.AgainstComputer)
            {
                m_IsAgainstComputer = true;
            }

            XmlNode XmlNodeDifficulty = i_XmlStateOfGame.SelectSingleNode("LoadGame/GameSettings/Difficulty");
            m_Difficulty = byte.Parse(XmlNodeDifficulty.InnerText);

            XmlNode XmlNodePlayer1Name = i_XmlStateOfGame.SelectSingleNode("LoadGame/GameSettings/Player1Name");
            m_Player1Name = XmlNodePlayer1Name.InnerText;

            XmlNode XmlNodePlayer2Name = i_XmlStateOfGame.SelectSingleNode("LoadGame/GameSettings/Player2Name");
            m_Player2Name = XmlNodePlayer2Name.InnerText;

            XmlNode XmlNodeTurn = i_XmlStateOfGame.SelectSingleNode("LoadGame/GameSettings/Turn");
            m_Turn = XmlNodeTurn.InnerText == "Black" ? Player.eTeam.Black : Player.eTeam.White;
        }

        private List<Piece> getListOfPiecesFromXml(XmlDocument i_XmlStateOfGame, string i_Player)
        {
            string Path = string.Format("LoadGame/GamePanel/{0}", i_Player);
            Player.eTeam team = i_Player == "Player1Pieces" ? Player.eTeam.Black : Player.eTeam.White;

            XmlNode XmlNodesPlayerPiece = i_XmlStateOfGame.SelectSingleNode(Path);
            List<Piece> listOfPlayerPieces = new List<Piece>();

            for (int index = 0; index < XmlNodesPlayerPiece.ChildNodes.Count; index += 2)
            {
                byte XLocation = byte.Parse(XmlNodesPlayerPiece.ChildNodes[index].InnerText);
                byte YLocation = byte.Parse(XmlNodesPlayerPiece.ChildNodes[index + 1].InnerText);

                Coordinates currentCoordinateOfPiece = new Coordinates(XLocation, YLocation);
                Piece currentPiece = new Piece(team, currentCoordinateOfPiece);
                listOfPlayerPieces.Add(currentPiece);
            }

            return listOfPlayerPieces;
        }

        private void PlayerSavedGame(string i_FileNamePath)
        {
            string fileNamePath = i_FileNamePath + ".otlo";
            XmlWriter xmlWriteGameState = XmlWriter.Create(fileNamePath);
           
            xmlWriteGameState.WriteStartDocument();
            xmlWriteGameState.WriteStartElement("LoadGame");

            // --- Write the settings of the game --- //

            xmlWriteGameState.WriteStartElement("GameSettings");
            xmlWriteGameState.WriteStartElement("BoardSize");
            xmlWriteGameState.WriteString(m_BoardSize.ToString());
            xmlWriteGameState.WriteEndElement();
            xmlWriteGameState.WriteStartElement("GameMode");
            xmlWriteGameState.WriteString(m_GameMode.ToString());
            xmlWriteGameState.WriteEndElement();
            xmlWriteGameState.WriteStartElement("Difficulty");
            xmlWriteGameState.WriteString(m_Difficulty.ToString());
            xmlWriteGameState.WriteEndElement();
            xmlWriteGameState.WriteStartElement("Player1Name");
            xmlWriteGameState.WriteString(m_Player1Name);
            xmlWriteGameState.WriteEndElement();
            xmlWriteGameState.WriteStartElement("Player2Name");
            xmlWriteGameState.WriteString(m_Player2Name);
            xmlWriteGameState.WriteEndElement();
            xmlWriteGameState.WriteStartElement("Turn");
            xmlWriteGameState.WriteString(m_OtheloGameLogic.GetCurrentPlayerTurn().Team.ToString());
            xmlWriteGameState.WriteEndElement();
            xmlWriteGameState.WriteEndElement(); //end GameSettings

            xmlWriteGameState.WriteStartElement("GamePanel");

            // --- Write the Player1 pieces --- //
            xmlWriteGameState.WriteStartElement("Player1Pieces");

            foreach(Piece CurrentPiece in m_OtheloGameLogic.Player1.Pieces)
            {
                xmlWriteGameState.WriteStartElement("X");
                xmlWriteGameState.WriteString(CurrentPiece.CoordinatesOnBoard.X.ToString());
                xmlWriteGameState.WriteEndElement();
                xmlWriteGameState.WriteStartElement("Y");
                xmlWriteGameState.WriteString(CurrentPiece.CoordinatesOnBoard.Y.ToString());
                xmlWriteGameState.WriteEndElement();
            }

            xmlWriteGameState.WriteEndElement(); //end Player1Pieces

            // --- Write the Player2 pieces --- //
            xmlWriteGameState.WriteStartElement("Player2Pieces");

            foreach (Piece CurrentPiece in m_OtheloGameLogic.Player2.Pieces)
            {
                xmlWriteGameState.WriteStartElement("X");
                xmlWriteGameState.WriteString(CurrentPiece.CoordinatesOnBoard.X.ToString());
                xmlWriteGameState.WriteEndElement();
                xmlWriteGameState.WriteStartElement("Y");
                xmlWriteGameState.WriteString(CurrentPiece.CoordinatesOnBoard.Y.ToString());
                xmlWriteGameState.WriteEndElement();
            }

            xmlWriteGameState.WriteEndElement(); //end Player2Pieces
            xmlWriteGameState.WriteEndElement(); //end GamePanel
            xmlWriteGameState.WriteEndElement(); //end LoadGame
            xmlWriteGameState.WriteEndDocument();
            xmlWriteGameState.Close();
        }
    }
}
