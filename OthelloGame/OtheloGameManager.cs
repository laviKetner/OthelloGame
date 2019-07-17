using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
    public enum eBoardSize : byte
    {
        Small = 6,
        Medium = 8,
        Large = 10
    }

    public enum eDifficulty : byte
    {
        Easy,
        Medium,
        Hard,
        Empty_AgainstHuman,
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
        private eGameMode          m_GameMode;
        private string             m_Player1Name = null;
        private string             m_Player2Name = "Computer";
        private bool               m_IsAgainstComputer = false;
        private eDifficulty        m_Difficulty;

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
                m_FormGameSettings = new FormGameSettings();
                m_FormGameSettings.ShowDialog();
                m_GameMode = m_FormGameSettings.GameMode;

                switch (m_GameMode)
                {
                    case eGameMode.AgainstComputer:
                        {
                            FormSinglePlayer formSinglePlayer = new FormSinglePlayer();
                            formSinglePlayer.ShowDialog();
                            m_Player1Name = formSinglePlayer.Player1Name;
                            m_BoardSize = (byte)formSinglePlayer.BoardSize;
                            m_Difficulty = formSinglePlayer.Difficulty;
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

            //initializeGameLogic
            m_OtheloGameLogic = new OtheloGameLogic(m_BoardSize, m_Player1Name, m_Player2Name, m_IsAgainstComputer,m_Difficulty);
            m_OtheloGameLogic.ValidMovesCoordinateChange += sendToFormOthloGameBoardTheCurrentValidMovesCoordinate;
            m_OtheloGameLogic.PieceAddedOnBoard += pieceAddedOnBoard;
            m_OtheloGameLogic.CellsChangedTeam += cellsChangedTeam;

            //initializeGameUI
            m_FormOthloGameBoard = new FormOthloGameBoard(m_BoardSize, m_Player1Name, m_Player2Name);
            m_FormOthloGameBoard.newRound += initializeGame;
            m_FormOthloGameBoard.PlayerMakeAMove += doPlayersMove;

            m_OtheloGameLogic.InitializeGame();
            startPlaying();         
        }

        private void startPlaying()
        {
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

                m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.Player1);
                m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.Player2);
            }
            else
                m_OtheloGameLogic.ChangeTurn();

            while (!m_OtheloGameLogic.Player1.IsHaveValidMove)
            {
                m_OtheloGameLogic.ChangeTurn();

                if (m_OtheloGameLogic.Player2.IsHaveValidMove)
                {
                    m_OtheloGameLogic.SetComputerPieceAndFlipAllTheInfluencedPieces();
                    m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.Player1);
                    m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.Player2);
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
                m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.GetCurrentPlayerTurn());
                m_FormOthloGameBoard.ShowUpdatePlayerScore(m_OtheloGameLogic.GetOpposingPlayer());
            }
            else
                m_OtheloGameLogic.ChangeTurn();
        }

        private void pieceAddedOnBoard(Piece i_PieceAddedOnBoard)
        {
            m_FormOthloGameBoard.AddPieceOnBoard(i_PieceAddedOnBoard);
        }
    }

}
