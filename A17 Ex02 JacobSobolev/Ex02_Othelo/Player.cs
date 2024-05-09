using System.Collections.Generic;

namespace Ex02_Othelo
{
    public class Player
    {
        private readonly string r_Name;
        private readonly PlayerType r_PType;
        private readonly BoardCellType r_PlayerPiece;
        private List<GameValidMoves> m_ValidMoves;
        private List<Point> m_PiecesOnBoard;

        public Player(string i_Name, BoardCellType i_Piece, PlayerType i_PlayerType)
        {
            r_Name = i_Name;
            r_PlayerPiece = i_Piece;
            r_PType = i_PlayerType;
            m_ValidMoves = null;
            InitPlayer();
        }

        public string Name
        {
            get { return r_Name; }
        }

        public PlayerType PType
        {
            get { return r_PType; }
        }

        public BoardCellType PlayerPiece
        {
            get { return r_PlayerPiece; }
        }

        public List<GameValidMoves> ValidMoves
        {
            get { return m_ValidMoves; }
            set { m_ValidMoves = value; }
        }

        public List<Point> PiecesOnBoard
        {
            get { return m_PiecesOnBoard; }
        }

        public void InitPlayer()
        {
            m_PiecesOnBoard = new List<Point>();
        }

        public void AddPiecesOnBoard(Point i_Point)
        {
            PiecesOnBoard.Add(i_Point);
        }

        public void RemovePiecesOnBoard(Point i_Point)
        {
            bool itemFound = false;
            for (int i = 0; i < m_PiecesOnBoard.Count && !itemFound; i++)
            {
                if (m_PiecesOnBoard[i].Equals(i_Point))
                {
                    m_PiecesOnBoard.RemoveAt(i);
                    itemFound = true;
                }
            }
        }

        public int GetScore()
        {
            return m_PiecesOnBoard.Count;
        }

        public override string ToString()
        {
            return string.Format("Player: {0} - Score: {1}", r_Name, GetScore());
        }
    }
}
