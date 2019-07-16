using System;
using System.Collections.Generic;

namespace Ex02_Othelo
{
    public delegate void ValidMovesEventHandler(List<Coordinates> validMoveCoordinate);
    public delegate void CellsChangeTeamEventHandler(List<Piece> listOfPiecesThatNeedToChangeTeam);
    public delegate void AddedPieceOnBoardEventHandler(Piece pieceAddedOnBoard);

    public class OtheloGameLogic
    {
        //--------------------------------------------------------------------------------------//
        //                                   Conts & Enum                                       //
        //--------------------------------------------------------------------------------------//
        private const byte k_RightUpBlack    = 0,
                           k_LeftUpWhite     = 1,
                           k_LeftDownBlack   = 2,
                           k_RightDownWhite  = 3,
                           k_NumOfDirections = 8;

        private enum eMoveDirection
        {
            TopRightDirection  = 0,
            TopDirection       = 1,
            TopLeftDirection   = 2,
            LeftDirection      = 3,
            LeftDownDirection  = 4,
            DownDirection      = 5,
            RightDownDirection = 6,
            RightDirection     = 7
        }

        //--------------------------------------------------------------------------------------//
        //                                   Data Members                                       //
        //--------------------------------------------------------------------------------------//
        private GamePanel      m_GamePanel;
        private Player         m_Player1;
        private Player         m_Player2;
        private Player         m_Winner = null;
        private List<Piece>[,] m_ChangeTeamPieces;
        private Player.eTeam   m_Turn = Player.eTeam.Black;

        public event AddedPieceOnBoardEventHandler PieceAddedOnBoard;
        public event CellsChangeTeamEventHandler   CellsChangedTeam;
        public event ValidMovesEventHandler        ValidMovesCoordinateChange;


        //--------------------------------------------------------------------------------------//
        //                                 Event Handler                                        //
        //--------------------------------------------------------------------------------------//
        protected virtual void OnPieceAddedOnBoard(Piece i_PieceAddedOnBoard)
        {
            PieceAddedOnBoard.Invoke(i_PieceAddedOnBoard);
        }

        protected virtual void OnCellsChangedTeam(List<Piece> listOfPiecesThatNeedToChangeTeam)
        {
            CellsChangedTeam.Invoke(listOfPiecesThatNeedToChangeTeam);
        }

        protected virtual void OnValidMovesChanges()
        {
            List<Coordinates> validMoveCoordinate = new List<Coordinates>();
            for (byte row = 0; row < m_GamePanel.Size; row++) 
            {
                for (byte column = 0; column < m_GamePanel.Size; column++) 
                {
                    if (m_ChangeTeamPieces[row, column].Count != 0) 
                    {
                        Coordinates currentValidCoordinate = new Coordinates(row, column);
                        validMoveCoordinate.Add(currentValidCoordinate);
                    }
                }
            }

            ValidMovesCoordinateChange.Invoke(validMoveCoordinate);
        }

        //--------------------------------------------------------------------------------------//
        //                              Run Game - Constractur                                  //
        //--------------------------------------------------------------------------------------//
        public OtheloGameLogic(byte i_BoardSize, string i_Player1Name, string i_Player2Name, bool i_IsPlayer2IsComputer)
        {
            const bool v_Player1IsAlwaysNotComputer = false;

            m_GamePanel = new GamePanel(i_BoardSize);
            m_Player1 = new Player(i_Player1Name, v_Player1IsAlwaysNotComputer, Player.eTeam.Black);
            m_Player2 = new Player(i_Player2Name, i_IsPlayer2IsComputer, Player.eTeam.White);
            initializeChangeTeamPiecesMember();
        }

        //--------------------------------------------------------------------------------------//
        //                              Initialize Function                                     //
        //--------------------------------------------------------------------------------------//
        public void InitializeGame()
        {
            m_Player1.Pieces.Clear();
            m_Player2.Pieces.Clear();
            m_Winner = null;
            m_Turn = Player.eTeam.Black;
            initializeStartPositionOfPiecesOnBoard();
            makeAListOfCurrectMoves();
            OnValidMovesChanges();
        }

        private void initializeStartPositionOfPiecesOnBoard()
        {
            Coordinates[] fourInitializeCoordinates = new Coordinates[4];
            initializeFourCoordinats(fourInitializeCoordinates);

            Piece[] fourInitializePieces = new Piece[4];
            initializeFourPieces(fourInitializePieces, fourInitializeCoordinates);

            assignTheFourInitializePiecesToPlayers(fourInitializePieces);

            placeTheFourInitializePiecesOnBoard(fourInitializePieces, fourInitializeCoordinates);
        }

        private void initializeFourPieces(Piece[] io_fourInitializePieces, Coordinates[] io_fourInitializeCoordinates)
        {
            io_fourInitializePieces[k_RightUpBlack]   = new Piece(Player.eTeam.Black, io_fourInitializeCoordinates[k_RightUpBlack]);
            io_fourInitializePieces[k_LeftUpWhite]    = new Piece(Player.eTeam.White, io_fourInitializeCoordinates[k_LeftUpWhite]);
            io_fourInitializePieces[k_LeftDownBlack]  = new Piece(Player.eTeam.Black, io_fourInitializeCoordinates[k_LeftDownBlack]);
            io_fourInitializePieces[k_RightDownWhite] = new Piece(Player.eTeam.White, io_fourInitializeCoordinates[k_RightDownWhite]);
        }

        private void initializeFourCoordinats(Coordinates[] io_fourInitializeCoordinate)
        {
            byte middleRow = (byte)((m_GamePanel.Size / 2) - 1);
            byte middleColumn = middleRow;

            io_fourInitializeCoordinate[k_RightUpBlack] = new Coordinates(middleRow, (byte)(middleColumn + 1));
            io_fourInitializeCoordinate[k_LeftUpWhite] = new Coordinates(middleRow, middleColumn);
            io_fourInitializeCoordinate[k_LeftDownBlack] = new Coordinates((byte)(middleRow + 1), (byte)middleColumn);
            io_fourInitializeCoordinate[k_RightDownWhite] = new Coordinates((byte)(middleRow + 1), (byte)(middleColumn + 1));
        }

        private void assignTheFourInitializePiecesToPlayers(Piece[] i_fourInitializePiece)
        {
            m_Player1.AddPiece(i_fourInitializePiece[k_RightUpBlack]);
            m_Player2.AddPiece(i_fourInitializePiece[k_LeftUpWhite]);
            m_Player1.AddPiece(i_fourInitializePiece[k_LeftDownBlack]);
            m_Player2.AddPiece(i_fourInitializePiece[k_RightDownWhite]);
        }

        private void placeTheFourInitializePiecesOnBoard(Piece[] i_fourInitializePieces, Coordinates[] i_fourInitializeCoordinates)
        {
            m_GamePanel[i_fourInitializeCoordinates[k_RightUpBlack]] = i_fourInitializePieces[k_RightUpBlack];
            m_GamePanel[i_fourInitializeCoordinates[k_LeftUpWhite]] = i_fourInitializePieces[k_LeftUpWhite];
            m_GamePanel[i_fourInitializeCoordinates[k_RightDownWhite]] = i_fourInitializePieces[k_RightDownWhite];
            m_GamePanel[i_fourInitializeCoordinates[k_LeftDownBlack]] = i_fourInitializePieces[k_LeftDownBlack];
        }


        //--------------------------------------------------------------------------------------//
        //        Make list of currect movment and Sequence lists for change team pieces        //
        //--------------------------------------------------------------------------------------//
        private void makeAListOfCurrectMoves()
        {
            GetCurrentPlayerTurn().IsHaveValidMove = false;

            List<Piece> allThePiecesFormCurrentPlayer = GetCurrentPlayerTurn().Pieces;

            foreach (Piece currentPieceOnPlayerList in allThePiecesFormCurrentPlayer)
            {
                Coordinates currentPieceCoordinate = currentPieceOnPlayerList.CoordinatesOnBoard;

                for (eMoveDirection currentDirection = eMoveDirection.TopRightDirection; (byte)currentDirection < k_NumOfDirections; currentDirection++)
                {
                    List<Piece> currentListOfsequencePieces = new List<Piece>();
                    Coordinates currentCoordinate = currentPieceCoordinate;
                    currentCoordinate = getCellCoordinateToProcced(currentCoordinate, currentDirection);

                    while (isAValidMove(currentCoordinate))
                    {
                        Piece currentRivalPiece = m_GamePanel[currentCoordinate];
                        currentListOfsequencePieces.Add(currentRivalPiece);
                        currentCoordinate = getCellCoordinateToProcced(currentCoordinate, currentDirection);

                        if (checkIfArriveToEmptyCellOnBoard(currentCoordinate))
                        {
                            saveTheSequenceListToChangeTeamPiecesMember(ref currentListOfsequencePieces, currentCoordinate);
                            GetCurrentPlayerTurn().IsHaveValidMove = true;
                            currentListOfsequencePieces.Clear();
                        }
                        else if (isCurrentCoordinateContainAllyPiece(currentCoordinate)) 
                        {
                            currentListOfsequencePieces.Clear();
                            break;
                        }
                    }

                    currentListOfsequencePieces.Clear();
                }
            }
        }

        private bool isCurrentCoordinateContainAllyPiece(Coordinates i_CurrentCoordinate)
        {
            return m_GamePanel.DoesCellExist(i_CurrentCoordinate) && m_GamePanel[i_CurrentCoordinate].Team == m_Turn;
        }

        private bool checkIfArriveToEmptyCellOnBoard(Coordinates i_CurrentCoordinate)
        {
            return m_GamePanel.DoesCellExist(i_CurrentCoordinate) && m_GamePanel[i_CurrentCoordinate] == null;
        }

        private void saveTheSequenceListToChangeTeamPiecesMember(ref List<Piece> io_CurrentListOfsequencePieces, Coordinates i_CurrentCoordinate)
        {
            foreach (Piece RivalPiece in io_CurrentListOfsequencePieces)
                m_ChangeTeamPieces[i_CurrentCoordinate.X, i_CurrentCoordinate.Y].Add(RivalPiece);
        }
        
        private Coordinates getCellCoordinateToProcced(Coordinates i_CurrentCoordinate, eMoveDirection i_CurrentDirection)
        {
            Coordinates nextCoordinateInDirection = new Coordinates();

            switch (i_CurrentDirection)
            {
                case eMoveDirection.TopRightDirection:
                        moveCoordinateTopRightDirection(ref nextCoordinateInDirection, i_CurrentCoordinate);
                    break;

                case eMoveDirection.TopDirection:
                        moveCoordinateTopDirection(ref nextCoordinateInDirection, i_CurrentCoordinate);
                    break;

                case eMoveDirection.TopLeftDirection:
                        moveCoordinateTopLeftDirection(ref nextCoordinateInDirection, i_CurrentCoordinate);
                    break;

                case eMoveDirection.LeftDirection:
                        moveCoordinateLeftDirection(ref nextCoordinateInDirection, i_CurrentCoordinate);
                    break;

                case eMoveDirection.LeftDownDirection:
                        moveCoordinateLeftDownDirection(ref nextCoordinateInDirection, i_CurrentCoordinate);
                    break;

                case eMoveDirection.DownDirection:
                        moveCoordinateDownDirection(ref nextCoordinateInDirection, i_CurrentCoordinate);
                    break;

                case eMoveDirection.RightDownDirection:
                        moveCoordinateRightDownDirection(ref nextCoordinateInDirection, i_CurrentCoordinate);
                    break;

                case eMoveDirection.RightDirection:
                        moveCoordinateRightDirection(ref nextCoordinateInDirection, i_CurrentCoordinate);
                    break;
            }

            return nextCoordinateInDirection;
        }

        private bool isAValidMove(Coordinates i_CurrentMove)
        {
            bool isValidMove = false;

            if (m_GamePanel.DoesCellExist(i_CurrentMove) && m_GamePanel.DoesCellOccupied(i_CurrentMove))
            {
                if (doesCellOccupiedByEnemey(i_CurrentMove))
                {
                    isValidMove = true;
                }
            }

            return isValidMove;
        }

        private bool doesCellOccupiedByEnemey(Coordinates i_Cell)
        {
            Piece PieceOnCoordinate = m_GamePanel[i_Cell];
            return PieceOnCoordinate.Team != m_Turn;
        }

        private void moveCoordinateTopRightDirection(ref Coordinates io_NextCoordinateInDirection, Coordinates i_CurrentCoordinate)
        {
            io_NextCoordinateInDirection.X = (byte)(i_CurrentCoordinate.X - 1);
            io_NextCoordinateInDirection.Y = (byte)(i_CurrentCoordinate.Y + 1);
        }

        private void moveCoordinateTopDirection(ref Coordinates io_NextCoordinateInDirection, Coordinates i_CurrentCoordinate)
        {
            io_NextCoordinateInDirection.X = (byte)(i_CurrentCoordinate.X - 1);
            io_NextCoordinateInDirection.Y = (byte)i_CurrentCoordinate.Y;
        }

        private void moveCoordinateTopLeftDirection(ref Coordinates io_NextCoordinateInDirection, Coordinates i_CurrentCoordinate)
        {
            io_NextCoordinateInDirection.X = (byte)(i_CurrentCoordinate.X - 1);
            io_NextCoordinateInDirection.Y = (byte)(i_CurrentCoordinate.Y - 1);
        }

        private void moveCoordinateLeftDirection(ref Coordinates io_NextCoordinateInDirection, Coordinates i_CurrentCoordinate)
        {
            io_NextCoordinateInDirection.X = (byte)i_CurrentCoordinate.X;
            io_NextCoordinateInDirection.Y = (byte)(i_CurrentCoordinate.Y - 1);
        }

        private void moveCoordinateLeftDownDirection(ref Coordinates io_NextCoordinateInDirection, Coordinates i_CurrentCoordinate)
        {
            io_NextCoordinateInDirection.X = (byte)(i_CurrentCoordinate.X + 1);
            io_NextCoordinateInDirection.Y = (byte)(i_CurrentCoordinate.Y - 1);
        }

        private void moveCoordinateDownDirection(ref Coordinates io_NextCoordinateInDirection, Coordinates i_CurrentCoordinate)
        {
            io_NextCoordinateInDirection.X = (byte)(i_CurrentCoordinate.X + 1);
            io_NextCoordinateInDirection.Y = (byte)i_CurrentCoordinate.Y;
        }

        private void moveCoordinateRightDownDirection(ref Coordinates io_NextCoordinateInDirection, Coordinates i_CurrentCoordinate)
        {
            io_NextCoordinateInDirection.X = (byte)(i_CurrentCoordinate.X + 1);
            io_NextCoordinateInDirection.Y = (byte)(i_CurrentCoordinate.Y + 1);
        }

        private void moveCoordinateRightDirection(ref Coordinates io_NextCoordinateInDirection, Coordinates i_CurrentCoordinate)
        {
            io_NextCoordinateInDirection.X = (byte)i_CurrentCoordinate.X;
            io_NextCoordinateInDirection.Y = (byte)(i_CurrentCoordinate.Y + 1);
        }

        private void initializeChangeTeamPiecesMember()
        {
            m_ChangeTeamPieces = new List<Piece>[m_GamePanel.Size, m_GamePanel.Size];

            for (int i = 0; i < m_GamePanel.Size; i++)
                for (int j = 0; j < m_GamePanel.Size; j++)
                    m_ChangeTeamPieces[i, j] = new List<Piece>();
        }

        private void clearListOfCurrectMoves()
        {
            for (int i = 0; i < m_GamePanel.Size; i++)
                for (int j = 0; j < m_GamePanel.Size; j++)
                    m_ChangeTeamPieces[i, j].Clear();
        }

        //--------------------------------------------------------------------------------------//
        //                                  Private Methods                                     //
        //--------------------------------------------------------------------------------------//

        private void updatePlayerScore()
        {
            GetOpposingPlayer().Score = GetOpposingPlayer().Pieces.Count;
            GetCurrentPlayerTurn().Score = GetCurrentPlayerTurn().Pieces.Count;

            if (GetOpposingPlayer().Score > GetCurrentPlayerTurn().Score)
                Winner = GetOpposingPlayer();
            else if(GetOpposingPlayer().Score < GetCurrentPlayerTurn().Score)
                Winner = GetCurrentPlayerTurn();
            else
                Winner = null;
        }

        private void resertListOfCurrectMoves(bool i_FlagToKnowIfPlayerHaveValidMoveOnNextTurn)
        {
            clearListOfCurrectMoves();
            makeAListOfCurrectMoves();

            if (!i_FlagToKnowIfPlayerHaveValidMoveOnNextTurn)
                OnValidMovesChanges();
        }

        private Coordinates getMaxPiecesToFlipCoordinate(ref short io_MaxPiecesToFlip)
        {
            Coordinates maxPiecesToFlipCoordinate = new Coordinates(0, 0);
            List<Coordinates> maxListPiecesToFlipCoordinate = new List<Coordinates>();

            for (byte row = 0; row < m_GamePanel.Size; row++)
            {
                for (byte column = 0; column < m_GamePanel.Size; column++)
                {
                    if (m_ChangeTeamPieces[row, column].Count > io_MaxPiecesToFlip)
                    {
                        io_MaxPiecesToFlip = (short)m_ChangeTeamPieces[row, column].Count;
                        maxPiecesToFlipCoordinate = new Coordinates(row, column);
                        maxListPiecesToFlipCoordinate.Add(maxPiecesToFlipCoordinate);
                    }
                }
            }

            System.Random randomMaxCoordinate = new System.Random();
            int randomMaxCoordinateLocation = randomMaxCoordinate.Next(0, maxListPiecesToFlipCoordinate.Count);

            return maxListPiecesToFlipCoordinate[randomMaxCoordinateLocation];
        }

        //--------------------------------------------------------------------------------------//
        //                                   Properties                                         //
        //--------------------------------------------------------------------------------------//
        public GamePanel GamePanel
        {
            get{ return m_GamePanel; }
        }

        public Player Winner
        {
            get{ return m_Winner; }
            set{ m_Winner = value; }
        }

        public Player Player1
        {
            get{ return m_Player1; }
        }

        public Player Player2
        {
            get{ return m_Player2; }
        }

        //--------------------------------------------------------------------------------------//
        //                                  Public Methods                                      //
        //--------------------------------------------------------------------------------------//

        public Player GetCurrentPlayerTurn()
        {
            return m_Turn == m_Player1.Team ? m_Player1 : m_Player2;
        }

        public void SetComputerPieceAndFlipAllTheInfluencedPieces()
        {         
            short maxPiecesToFlip = 0;

            if(Player2.IsHaveValidMove)
            {
                Coordinates maxPiecesToFlipCoordinate = getMaxPiecesToFlipCoordinate(ref maxPiecesToFlip);
                SetInputPieceAndFlipAllTheInfluencedPieces(maxPiecesToFlipCoordinate);
            }
        }

        public void SetInputPieceAndFlipAllTheInfluencedPieces(Coordinates i_InputCoordinate)
        {
            Piece newPiece = new Piece(m_Turn, i_InputCoordinate);
            m_GamePanel[i_InputCoordinate] = newPiece;

            OnPieceAddedOnBoard(newPiece);

            GetCurrentPlayerTurn().AddPiece(m_GamePanel[i_InputCoordinate]);
            
            foreach (Piece currentPieceToFlip in m_ChangeTeamPieces[i_InputCoordinate.X, i_InputCoordinate.Y])
            {
                currentPieceToFlip.ChangePieceTeam();
                GetCurrentPlayerTurn().AddPiece(currentPieceToFlip);
                GetOpposingPlayer().RemovePiece(currentPieceToFlip);
            }

            OnCellsChangedTeam(m_ChangeTeamPieces[i_InputCoordinate.X, i_InputCoordinate.Y]);
            ChangeTurn();
        }

        public void ChangeTurn(bool i_FlagToKnowIfPlayerHaveValidMoveOnNextTurn = false)
        {
            m_Turn = m_Turn == Player.eTeam.Black ? Player.eTeam.White : Player.eTeam.Black;
            updatePlayerScore();
            resertListOfCurrectMoves(i_FlagToKnowIfPlayerHaveValidMoveOnNextTurn);
        }

        public bool IsValidPlaceToChoose(Coordinates i_InputCoordinate)
        {
            return m_ChangeTeamPieces[i_InputCoordinate.X, i_InputCoordinate.Y].Count != 0;
        }

        public Player GetOpposingPlayer()
        {
            return m_Turn == m_Player1.Team ? m_Player2 : m_Player1;
        }
    }
}