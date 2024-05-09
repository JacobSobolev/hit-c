namespace Ex02_Othelo
{
    public struct Cell
    {
        private BoardCellType m_Piece;

        public BoardCellType Piece
        {
            get { return m_Piece; }
            set { m_Piece = value; }
        }

        public override string ToString()
        {
            string returnValue = string.Empty;

            if (m_Piece == BoardCellType.Black)
            {
                returnValue = "Black";
            }
            else if (m_Piece == BoardCellType.White)
            {
                returnValue = "White";
            }
            else
            {
                returnValue = "None";
            }

            return returnValue;
        }
    }
}
