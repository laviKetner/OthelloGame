using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_Othelo
{
    class Node
    {
        OtheloGameLogic m_BoardPiecesPosition;
        int m_ScoreResult;

        public OtheloGameLogic BoardPiecesPosition
        {
            get { return m_BoardPiecesPosition; }
            set { m_BoardPiecesPosition = value; }
        }

        public int ScoreResult
        {
            get { return m_ScoreResult; }
            set { m_ScoreResult = value; }
        }
    }

    class AI
    {
        public Node minimax(OtheloGameLogic i_BoardPiecesPosition, int i_Depth, bool i_MaximizingPlayer)
        {
            if (i_Depth == 0 || (!i_BoardPiecesPosition.GetCurrentPlayerTurn().IsHaveValidMove && !i_BoardPiecesPosition.GetOpposingPlayer().IsHaveValidMove))
            {
                return boardPositionAIScore(i_BoardPiecesPosition);
            }

            if (i_MaximizingPlayer)
            {
                int maxEval = int.MinValue;
                Node resMaxEval = new Node();
                resMaxEval.ScoreResult = maxEval;
                resMaxEval.BoardPiecesPosition = i_BoardPiecesPosition;

                foreach (Coordinates child in i_BoardPiecesPosition.ValidCoordinatesToAddPieces())
                {
                    i_BoardPiecesPosition.SetInputPieceAndFlipAllTheInfluencedPieces(child, true);
                    Node eval = minimax(i_BoardPiecesPosition, i_Depth - 1, false);

                    if (maxEval < eval.ScoreResult)
                    {
                        resMaxEval.ScoreResult = eval.ScoreResult;
                        resMaxEval.BoardPiecesPosition = i_BoardPiecesPosition;
                    }
                }
                return resMaxEval;
            }
            else
            {
                int minEval = int.MaxValue;
                Node resMinEval = new Node();
                resMinEval.ScoreResult = minEval;
                resMinEval.BoardPiecesPosition = i_BoardPiecesPosition;

                foreach (Coordinates child in i_BoardPiecesPosition.ValidCoordinatesToAddPieces())
                {
                    i_BoardPiecesPosition.SetInputPieceAndFlipAllTheInfluencedPieces(child, true);
                    Node eval = minimax(i_BoardPiecesPosition, i_Depth - 1, true);

                    if (minEval > eval.ScoreResult)
                    {
                        resMinEval.ScoreResult = eval.ScoreResult;
                        resMinEval.BoardPiecesPosition = i_BoardPiecesPosition;
                    }
                }
                return resMinEval;
            }
        }
        
        private Node boardPositionAIScore(OtheloGameLogic i_BoardPosition)
        {
            int ScoreOfCurrentBoard = 0;

            switch (i_BoardPosition.GamePanel.Size)
            {
                case (byte)eBoardSize.Small:
                    {
                        int[,] scoreBoard = new int[(byte)eBoardSize.Small, (byte)eBoardSize.Small]
                        { { 0 ,0, 0, 0 ,0, 0},
                          { 0 ,0, 0, 0 ,0, 0},
                          { 0 ,0, 0, 0 ,0, 0},
                          { 0 ,0, 0, 0 ,0, 0},
                          { 0 ,0, 0, 0 ,0, 0},
                          { 0 ,0, 0, 0 ,0, -10000000} };
                        ScoreOfCurrentBoard = calculateScoreOfBoard(scoreBoard, i_BoardPosition);

                        break;
                    }
                    //case (byte)eBoardSize.Medium:
                    //    {
                    //        break;
                    //    }
                    //case (byte)eBoardSize.Large:
                    //    {
                    //        break;
                    //    }
            }

            Node result = new Node();
            result.ScoreResult = ScoreOfCurrentBoard;
            result.BoardPiecesPosition = i_BoardPosition;
            return result;
        }

        private int calculateScoreOfBoard(int[,] i_scoreBoard, OtheloGameLogic i_BoardPosition)
        {
            int score = 0;

            for (byte row=0;row<i_BoardPosition.GamePanel.Size;row++)
            {
                for(byte column=0;column<i_BoardPosition.GamePanel.Size;column++)
                {
                    if (i_BoardPosition.GamePanel[new Coordinates(row, column)] != null) 
                    {
                        if (i_BoardPosition.GamePanel[new Coordinates(row, column)].Team == Player.eTeam.White)
                        {
                            score += i_scoreBoard[row, column];
                            score += 500;
                        }
                        else if (i_BoardPosition.GamePanel[new Coordinates(row, column)].Team == Player.eTeam.Black)
                        {
                            score += i_scoreBoard[row, column];
                            score -= 500;
                        }
                    }
                }
            }

            return score;
        }

        //function minimax(position, depth, maximizingPlayer)
        //    if depth == 0 or game over in position
        //        return static evaluation of position

        //    if maximizingPlayer
        //        maxEval = -infinity
        //        for each child of position
        //            eval = minimax(child, depth - 1, false)
        //            maxEval = max(maxEval, eval)
        //        return maxEval

        //    else
        //        minEval = +infinity
        //        for each child of position
        //            eval = minimax(child, depth - 1, true)
        //            minEval = min(minEval, eval)
        //        return minEval


        //// initial call
        //minimax(currentPosition, 3, true)
    }
}
