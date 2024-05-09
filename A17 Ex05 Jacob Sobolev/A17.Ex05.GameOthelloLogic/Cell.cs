namespace A17.Ex05.GameOthelloLogic
{
    public struct Cell
    {
        private BoardCellType m_BoardCell;

        public BoardCellType BoardCell
        {
            get { return m_BoardCell; }
            set { m_BoardCell = value; }
        }

        public override string ToString()
        {
            string returnValue = string.Empty;

            if (m_BoardCell == BoardCellType.Black)
            {
                returnValue = "Black";
            }
            else if (m_BoardCell == BoardCellType.White)
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
