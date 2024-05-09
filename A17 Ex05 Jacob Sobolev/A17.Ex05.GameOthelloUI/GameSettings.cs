using System;
using System.Windows.Forms;
using A17.Ex05.GameOthelloLogic;

namespace A17.Ex05.GameOthelloUI
{
    public partial class GameSettings : Form
    {
        private const int k_maxBoardSize = 20;
        private const int k_minBoardSize = 6;
        private int m_BoardSize;
        private PlayerType m_player2Type;

        public int BoardSize
        {
            get { return m_BoardSize; }
        }

        public PlayerType Player2Type
        {
            get { return m_player2Type; }
        }

        public GameSettings()
        {
            InitializeComponent();
            initVariables();
            updateBoardSizeButtonText();
        }

        private void initVariables()
        {
            m_BoardSize = k_minBoardSize;
        }

        private void updateBoardSizeButtonText()
        {
            buttonIncBoardSize.Text = string.Format("Board Size : {0}x{0} (click to increase)", m_BoardSize);
        }

        private void buttonIncBoardSize_Click(object sender, EventArgs e)
        {
            if (m_BoardSize < k_maxBoardSize)
            {
                m_BoardSize += 2;
            }
            else
            {
                m_BoardSize = k_minBoardSize;
            }

            updateBoardSizeButtonText();
        }

        private void buttonGameStart_Click(object sender, EventArgs e)
        {
            Button buttonClicked = sender as Button;
            if (buttonClicked.Equals(buttonGamePlayPc))
            {
                m_player2Type = PlayerType.Pc;
            }
            else
            {
                m_player2Type = PlayerType.Human;
            }
        }
    }
}
