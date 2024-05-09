using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace A17.Ex05.GameOthelloUI
{
    public class PictureImageGrid : PictureBox
    {
        private Point m_Position;

        public Point Position
        {
            get { return m_Position; }
        }

        public int X
        {
            get { return m_Position.X; }
        }

        public int Y
        {
            get { return m_Position.Y; }
        }

        public PictureImageGrid(Point i_Position) : base()
        {
            m_Position = i_Position;
        }

        public override string ToString()
        {
            return string.Format("Position :{0} {1}", m_Position.X, m_Position.Y);
        }
    }
}
