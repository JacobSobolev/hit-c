using System.Drawing;

namespace A17.Ex05.GameOthelloLogic
{
    public class GameValidMoves
    {
        private Point m_StartPoint;
        private Point m_EndPoint;
        private eGameMoveDirectionType m_Direction;
        private int m_Dx;
        private int m_Dy;

        public GameValidMoves(Point i_StartPoint, eGameMoveDirectionType i_Direction)
        {
            m_StartPoint = i_StartPoint;
            m_EndPoint = new Point();
            m_Direction = i_Direction;
            m_Dx = 0;
            m_Dy = 0;
        }

        public Point StartPoint
        {
            get { return m_StartPoint; }
            set { m_StartPoint = value; }
        }

        public Point EndPoint
        {
            get { return m_EndPoint; }
            set { m_EndPoint = value; }
        }

        public eGameMoveDirectionType Direction
        {
            get { return m_Direction; }
            set { m_Direction = value; }
        }

        public int Dx
        {
            get { return m_Dx; }
            set { m_Dx = value; }
        }

        public int Dy
        {
            get { return m_Dy; }
            set { m_Dy = value; }
        }

        public void SetEndPoint(int i_X, int i_Y)
        {
            m_EndPoint.X = i_X;
            m_EndPoint.Y = i_Y;
        }

        public override string ToString()
        {
            return string.Format("Start : {0}, End: {1}, Dx: {2}, Dy: {3}", m_StartPoint, m_EndPoint, m_Dx, m_Dy);
        }
    }
}
