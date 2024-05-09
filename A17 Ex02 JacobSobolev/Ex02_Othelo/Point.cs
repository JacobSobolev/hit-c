namespace Ex02_Othelo
{
    public struct Point
    {
        private int m_indexI;
        private int m_indexJ;

        public Point(int i_indexI, int i_indexJ)
        {
            m_indexI = i_indexI;
            m_indexJ = i_indexJ;
        }

        public int IndexI
        {
            get { return m_indexI; }
            set { m_indexI = value; }
        }

        public int IndexJ
        {
            get { return m_indexJ; }
            set { m_indexJ = value; }
        }

        public override string ToString()
        {
            return string.Format("[I:{0}, J:{1}]", m_indexI, m_indexJ);
        }

        public bool Equals(Point i_Point)
        {
            bool returnValue = false;

            if (i_Point.IndexI == m_indexI && i_Point.IndexJ == m_indexJ)
            {
                returnValue = true;
            }

            return returnValue;
        }
    }
}
