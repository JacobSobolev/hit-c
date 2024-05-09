namespace Ex02_Othelo
{
    public class Board
    {
        private const int k_BoardSizeDefualt = 8;
        private readonly int r_BoardSize;
        private readonly Cell[,] r_CellMatrix;
        private int m_UnUsedCells;
        
        public Board(int i_BaordSize)
        {
            if (i_BaordSize % 2 == 1)
            {
                i_BaordSize++;
            }

            r_BoardSize = i_BaordSize;
            m_UnUsedCells = r_BoardSize * r_BoardSize;
            r_CellMatrix = new Cell[r_BoardSize, r_BoardSize];
            InitBoard();
        }

        public Board() : this(k_BoardSizeDefualt)
        {
        }

        public int BoardSize
        {
            get { return r_BoardSize; }
        }

        public Cell[,] CellMatrix
        {
            get { return r_CellMatrix; }
        }

        public int UnUsedCells
        {
            get { return m_UnUsedCells; }
        }

        public void InitBoard()
        {
            m_UnUsedCells = r_BoardSize * r_BoardSize;

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    Point currentPoint = new Point(i, j);
                    SetCell(currentPoint, BoardCellType.None);
                }
            }
        }

        public void SetCell(Point i_Point, BoardCellType i_Piece)
        {
            SetCell(i_Point.IndexI, i_Point.IndexJ, i_Piece);
        }

        public void SetCell(int i_IndexI, int i_IndexJ, BoardCellType i_Piece)
        {
            if (i_Piece != BoardCellType.None && r_CellMatrix[i_IndexI, i_IndexJ].Piece == BoardCellType.None)
            {
                m_UnUsedCells--;
            }

            r_CellMatrix[i_IndexI, i_IndexJ].Piece = i_Piece;
        }

        public BoardCellType GetCellType(Point i_Point)
        {
            return r_CellMatrix[i_Point.IndexI, i_Point.IndexJ].Piece;
        }

        public BoardCellType GetCellType(int i_IndexI, int i_IndexJ)
        {
            return r_CellMatrix[i_IndexI, i_IndexJ].Piece;
        }

        public bool IsCellTaken(Point i_Point)
        {
            return r_CellMatrix[i_Point.IndexI, i_Point.IndexJ].Piece != BoardCellType.None;
        }
    }
}
