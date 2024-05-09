using System;
using System.Windows.Forms;
using System.Drawing;
using A17.Ex05.GameOthelloLogic;

namespace A17.Ex05.GameOthelloUI
{
    public partial class GameMain : Form
    {
        private const int k_CellButtonSize = 60;
        private const int k_CellMargin = 5;
        private PictureImageGrid[,] m_ButtonGrid;
        private GameSettings m_GameSettings;
        private Game m_GameLogic;

        public GameMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            m_GameSettings = new GameSettings();
            
            if (m_GameSettings.ShowDialog() != DialogResult.Cancel)
            {
                if (m_GameSettings.Player2Type == PlayerType.Pc)
                {
                    m_GameLogic = new Game(m_GameSettings.BoardSize);
                }
                else
                {
                    m_GameLogic = new Game(m_GameSettings.BoardSize, "Player 1", "Player 2", m_GameSettings.Player2Type);
                }
                
                m_GameLogic.BoardChanged += GameLogic_BoardChanged;
                m_GameLogic.GameFinished += GameLogic_GameFinished;
                initButtonGrid();
                initLocationToCenterScreen();
                GameLogic_BoardChanged();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void GameLogic_GameFinished()
        {
            string dialogMsg;
            if (m_GameLogic.GetWinResult() > 0)
            {
                dialogMsg = string.Format("{0} Won!!({1}/{2}) ({3}/{4}){5}Would you like another round?", m_GameLogic.Player1, m_GameLogic.Player1.GetScore(), m_GameLogic.Player2.GetScore(), m_GameLogic.Player1.GamesWon, m_GameLogic.Player2.GamesWon, Environment.NewLine);
            }
            else if (m_GameLogic.GetWinResult() < 0)
            {
                dialogMsg = string.Format("{0} Won!!({1}/{2}) ({3}/{4}){5}Would you like another round?", m_GameLogic.Player2, m_GameLogic.Player2.GetScore(), m_GameLogic.Player1.GetScore(), m_GameLogic.Player2.GamesWon, m_GameLogic.Player1.GamesWon, Environment.NewLine);
            }
            else
            {
                dialogMsg = string.Format("It's a tie ({0}/{1}){2}Would you like another round?", m_GameLogic.Player2.GamesWon, m_GameLogic.Player1.GamesWon, Environment.NewLine);
            }

            if (MessageBox.Show(dialogMsg, "Othello", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                m_GameLogic.ResetGame();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void GameLogic_BoardChanged()
        {
            updateTitle();
            updateButtonGrid();
            updateValidUserMoves();
        }

        private void initButtonGrid()
        {
            m_ButtonGrid = new PictureImageGrid[m_GameLogic.Board.BoardSize, m_GameLogic.Board.BoardSize];

            int newPosX = 0;
            int newPosY = 0;
            for (int i = 0; i < m_GameLogic.Board.BoardSize; i++)
            {
                for (int j = 0; j < m_GameLogic.Board.BoardSize; j++)
                {
                    newPosX = (i * k_CellButtonSize) + ((i + 1) * k_CellMargin);
                    newPosY = (j * k_CellButtonSize) + ((j + 1) * k_CellMargin);
                    PictureImageGrid pictureImageCell = new PictureImageGrid(new Point(i, j));
                    pictureImageCell.Enabled = false;
                    pictureImageCell.Size = new Size(k_CellButtonSize, k_CellButtonSize);
                    pictureImageCell.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureImageCell.Location = new Point(newPosX, newPosY);
                    pictureImageCell.Click += gridButton_Clicked;
                    Controls.Add(pictureImageCell);
                    m_ButtonGrid[i, j] = pictureImageCell;
                }
            }
        }

        private void gridButton_Clicked(object sender, EventArgs e)
        {
            PictureImageGrid buttonClicked = sender as PictureImageGrid;
            if (m_GameLogic.CurrentPlayer == m_GameLogic.Player1)
            {
                m_ButtonGrid[buttonClicked.X, buttonClicked.Y].Image = Properties.Resources.CoinRed;
            }
            else
            {
                m_ButtonGrid[buttonClicked.X, buttonClicked.Y].Image = Properties.Resources.CoinYellow;
            }

            makeMove(buttonClicked.Position);
        }

        private void initLocationToCenterScreen()
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
        }

        private void updateTitle()
        {
            this.Text = string.Format("Othello - {0} turn", m_GameLogic.CurrentPlayer.ToString());
        }

        private void updateButtonGrid()
        {
            for (int i = 0; i < m_GameLogic.Board.BoardSize; i++)
            {
                for (int j = 0; j < m_GameLogic.Board.BoardSize; j++)
                {
                    if (m_GameLogic.Board.CellMatrix[i, j].BoardCell == BoardCellType.None)
                    {
                        m_ButtonGrid[i, j].Enabled = false;
                        m_ButtonGrid[i, j].BackColor = Color.LightGray;
                        m_ButtonGrid[i, j].Image = null;
                    }
                    else if (m_GameLogic.Board.CellMatrix[i, j].BoardCell == BoardCellType.Black)
                    {
                        m_ButtonGrid[i, j].Enabled = false;
                        m_ButtonGrid[i, j].Image = Properties.Resources.CoinRed;
                        m_ButtonGrid[i, j].BackColor = Color.LightGray;
                    }
                    else
                    {
                        m_ButtonGrid[i, j].Enabled = false;
                        m_ButtonGrid[i, j].Image = Properties.Resources.CoinYellow;
                        m_ButtonGrid[i, j].BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void updateValidUserMoves()
        {
            int x = 0; // debug every cell in false
            if (m_GameLogic.CurrentPlayer.ValidMoves != null && m_GameLogic.CurrentPlayer.ValidMoves.Count > 0 && m_GameLogic.CurrentPlayer.PType != PlayerType.Pc)
            {
                foreach (GameValidMoves move in m_GameLogic.CurrentPlayer.ValidMoves)
                {
                    m_ButtonGrid[move.EndPoint.X, move.EndPoint.Y].BackColor = Color.Green;
                    m_ButtonGrid[move.EndPoint.X, move.EndPoint.Y].Enabled = true;
                    x++;
                }
            }
        }

        private void makeMove(Point i_Move)
        {
            if (!m_GameLogic.IsGameOver())
            {
                m_GameLogic.MakeHumanMove(i_Move);
                if (!m_GameLogic.IsGameOver())
                {
                    if (m_GameLogic.Player2 == m_GameLogic.CurrentPlayer && m_GameLogic.CurrentPlayer.PType == PlayerType.Pc)
                    {
                        timerPcMove.Tick += TimerPcMove_Tick;
                        timerPcMove.Enabled = true;
                    }
                }
            }
        }

        private void TimerPcMove_Tick(object sender, EventArgs e)
        {
            timerPcMove.Tick -= TimerPcMove_Tick;
            timerPcMove.Enabled = false;
            m_GameLogic.MakePcMove();
        }
    }
}
