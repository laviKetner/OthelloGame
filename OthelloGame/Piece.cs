namespace Ex02_Othelo
{
    public class Piece
    {
        private Player.eTeam m_Team;
        private Coordinates  m_CoordinatesOnBoard;

        // Piece Constructor
        public Piece(Player.eTeam i_Team, Coordinates i_Coordinates)
        {
            m_Team = i_Team;
            m_CoordinatesOnBoard = i_Coordinates;
        }

        //-------------------------------------------------------------------------------//
        //                                 Properties                                    //
        //-------------------------------------------------------------------------------//
        public Player.eTeam Team
        {
            get{ return m_Team; }
            set{ m_Team = value; }
        }

        public Coordinates CoordinatesOnBoard
        {
            get{ return m_CoordinatesOnBoard; }
            set{ m_CoordinatesOnBoard = value; }
        }

        public Player.eTeam Symbol
        {
            get{ return m_Team; }
        }

        //-------------------------------------------------------------------------------//
        //                                 Other functions                               //
        //-------------------------------------------------------------------------------//

        public void ChangePieceTeam()
        {
           m_Team = m_Team == Player.eTeam.Black ? Player.eTeam.White : Player.eTeam.Black;
        }

        public Piece ShallowClone()
        {
            return new Piece(m_Team, m_CoordinatesOnBoard);
        }
    }
}
