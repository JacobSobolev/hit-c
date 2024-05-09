using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02_Othelo
{
    public class Game
    {
        private const string k_PcName = "Pc";
        private const BoardCellType k_Player1PieceDefualt = BoardCellType.Black;
        private const BoardCellType k_Player2PieceDefualt = BoardCellType.White;
        private const int k_BoardSizeDefualt = 8;
        private const string k_Player1NameDefualt = "Player1 - Human";
        private const string k_Player2NameDefualt = "Player2 - Pc";
        private const PlayerType k_Player1TypeDefualt = PlayerType.Human;
        private const PlayerType k_Player2TypeDefualt = PlayerType.Pc;
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;

        public string PcName
        {
            get { return k_PcName; }
        }

        public Board Board
        {
            get { return m_Board; }
        }

        public Player Player1
        {
            get { return m_Player1; }
        }

        public Player Player2
        {
            get { return m_Player2; }
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
        }

        public Game(int i_ValidBoardSize, string i_Player1Name, string i_Player2Name, PlayerType i_Player2Type)
        {
            m_Board = new Board(i_ValidBoardSize);
            m_Player1 = new Player(i_Player1Name, k_Player1PieceDefualt, k_Player1TypeDefualt);
            m_Player2 = new Player(i_Player2Name, k_Player2PieceDefualt, i_Player2Type);
            initStartPlayer();
            InitFirstMoves();
            calcValidPlayerMoves(m_Player1);
            calcValidPlayerMoves(m_Player2);
        }

        public Game() : this(k_BoardSizeDefualt, k_Player1NameDefualt, k_Player2NameDefualt, k_Player2TypeDefualt)
        {
        }

        private void initStartPlayer()
        {
            m_CurrentPlayer = m_Player1;
        }

        public void ResetGame()
        {
            Player1.InitPlayer();
            Player2.InitPlayer();
            initStartPlayer();
            m_Board.InitBoard();
            InitFirstMoves();
            calcValidPlayerMoves(m_Player1);
            calcValidPlayerMoves(m_Player2);
        }

        private void InitFirstMoves()
        {
            int startIndex = (m_Board.BoardSize / 2) - 1;
            int endIndex = startIndex + 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                for (int j = startIndex; j <= endIndex; j++)
                {
                    Point currentPoint = new Point(i, j);
                    if ((i == startIndex && j == endIndex) || (i == endIndex && j == startIndex))
                    {
                        m_Board.SetCell(currentPoint, k_Player1PieceDefualt);
                        m_Player1.AddPiecesOnBoard(currentPoint);
                    }
                    else if ((i == startIndex && j == startIndex) || (i == endIndex && j == endIndex))
                    {
                        m_Board.SetCell(currentPoint, k_Player2PieceDefualt);
                        m_Player2.AddPiecesOnBoard(currentPoint);
                    }
                }
            }
        }

        private void calcValidPlayerMoves(Player i_Player)
        {
            i_Player.ValidMoves = null;
            List<Point> pointsToCheck;
            List<GameValidMoves> validPlayerMoves = null;

            if (i_Player == Player1)
            {
                pointsToCheck = Player1.PiecesOnBoard;                
            }
            else
            {
                pointsToCheck = Player2.PiecesOnBoard;
            }

            for (int i = 0; i < pointsToCheck.Count; i++)
            {
                List<GameValidMoves> validCurrentMoves = null;

                validCurrentMoves = checkMoveDirection(pointsToCheck[i], GameMoveDirectionType.Horizontal, getOpponentPlayerPiece());
                addValidGameMoves(validCurrentMoves, ref validPlayerMoves);
                validCurrentMoves = checkMoveDirection(pointsToCheck[i], GameMoveDirectionType.Vertical, getOpponentPlayerPiece());
                addValidGameMoves(validCurrentMoves, ref validPlayerMoves);
                validCurrentMoves = checkMoveDirection(pointsToCheck[i], GameMoveDirectionType.DiagonalLeftTopToBottomRight, getOpponentPlayerPiece());
                addValidGameMoves(validCurrentMoves, ref validPlayerMoves);
                validCurrentMoves = checkMoveDirection(pointsToCheck[i], GameMoveDirectionType.DiagonalLeftBottomToTopRight, getOpponentPlayerPiece());
                addValidGameMoves(validCurrentMoves, ref validPlayerMoves);
            }

            i_Player.ValidMoves = validPlayerMoves;
        }

        private List<GameValidMoves> checkMoveDirection(Point i_Point, GameMoveDirectionType i_DirectionToCheck, BoardCellType i_OpponentPlayerPiece)
        {
            List<GameValidMoves> validReturnMoves = null;
            GameValidMoves backwardsMoveToCheck = new GameValidMoves(i_Point, i_DirectionToCheck);
            GameValidMoves forwardsMoveToCheck = new GameValidMoves(i_Point, i_DirectionToCheck);
            bool endPointFound = false;
            int indexI;
            int indexJ;

            if (i_DirectionToCheck == GameMoveDirectionType.Horizontal)
            {
                backwardsMoveToCheck.Dx = -1;
                backwardsMoveToCheck.Dy = 0;
                forwardsMoveToCheck.Dx = 1;
                forwardsMoveToCheck.Dy = 0;
            }
            else if (i_DirectionToCheck == GameMoveDirectionType.Vertical)
            {
                backwardsMoveToCheck.Dx = 0;
                backwardsMoveToCheck.Dy = -1;
                forwardsMoveToCheck.Dx = 0;
                forwardsMoveToCheck.Dy = 1;
            }
            else if (i_DirectionToCheck == GameMoveDirectionType.DiagonalLeftTopToBottomRight)
            {
                backwardsMoveToCheck.Dx = -1;
                backwardsMoveToCheck.Dy = -1;
                forwardsMoveToCheck.Dx = 1;
                forwardsMoveToCheck.Dy = 1;
            }
            else
            {
                backwardsMoveToCheck.Dx = -1;
                backwardsMoveToCheck.Dy = 1;
                forwardsMoveToCheck.Dx = 1;
                forwardsMoveToCheck.Dy = -1;
            }

            indexI = i_Point.IndexI;
            indexJ = i_Point.IndexJ;

            while (!endPointFound && (indexI > 0 && indexJ > 0))
            {
                indexI += backwardsMoveToCheck.Dy;
                indexJ += backwardsMoveToCheck.Dx;

                checkSignleMove(indexI, indexJ, i_OpponentPlayerPiece, backwardsMoveToCheck, ref validReturnMoves, ref endPointFound);
            }

            indexI = i_Point.IndexI;
            indexJ = i_Point.IndexJ;
            endPointFound = false;

            while (!endPointFound && (indexI < m_Board.BoardSize && indexJ < m_Board.BoardSize))
            {
                indexI += forwardsMoveToCheck.Dy;
                indexJ += forwardsMoveToCheck.Dx;

                checkSignleMove(indexI, indexJ, i_OpponentPlayerPiece, forwardsMoveToCheck, ref validReturnMoves, ref endPointFound);
            }

            return validReturnMoves;
        }

        private void checkSignleMove(int i_IndexI, int i_IndexJ, BoardCellType i_OpponentPlayerPiece, GameValidMoves io_ValidSignleMove, ref List<GameValidMoves> io_ValidMoves, ref bool io_endPointFound)
        {
            if (IsVaildPoint(i_IndexI, i_IndexJ) && m_Board.GetCellType(i_IndexI, i_IndexJ) == i_OpponentPlayerPiece)
            {
                Point pointToAssign = new Point(i_IndexI + io_ValidSignleMove.Dy, i_IndexJ + io_ValidSignleMove.Dx);

                if (IsVaildPoint(pointToAssign) && m_Board.GetCellType(pointToAssign) == BoardCellType.None)
                {
                    if (io_ValidMoves == null)
                    {
                        io_ValidMoves = new List<GameValidMoves>();
                    }

                    io_endPointFound = true;
                    io_ValidSignleMove.EndPoint = pointToAssign;
                    io_ValidMoves.Add(io_ValidSignleMove);
                }
            }
        }

        private void addValidGameMoves(List<GameValidMoves> i_MovesToAdd, ref List<GameValidMoves> i_MovesToBeAdded)
        {
            if (i_MovesToAdd != null && i_MovesToAdd.Count > 0)
            {
                if (i_MovesToBeAdded == null)
                {
                    i_MovesToBeAdded = new List<GameValidMoves>();
                }

                for (int i = 0; i < i_MovesToAdd.Count; i++)
                {
                    i_MovesToBeAdded.Add(i_MovesToAdd[i]);
                }
            }
        }

        public bool IsVaildPoint(Point i_Point)
        {
            return i_Point.IndexI >= 0 && i_Point.IndexI < m_Board.BoardSize && i_Point.IndexJ >= 0 && i_Point.IndexJ < m_Board.BoardSize;
        }

        public bool IsVaildPoint(int i_IndexI, int i_IndexJ)
        {
            return i_IndexI >= 0 && i_IndexI < m_Board.BoardSize && i_IndexJ >= 0 && i_IndexJ < m_Board.BoardSize;
        }

        public bool IsVaildMove(Point i_Point)
        {
            bool returnValue = false;

            return returnValue;
        }

        private BoardCellType getOpponentPlayerPiece()
        {
            return getOpponentPlayer().PlayerPiece;
        }

        private Player getOpponentPlayer()
        {
            Player valueToReturn;

            if (m_CurrentPlayer == m_Player1)
            {
                valueToReturn = m_Player2;
            }
            else
            {
                valueToReturn = m_Player1;
            }

            return valueToReturn;
        }

        public bool CanMakeMove(Point i_Point)
        {
            return findVaildGameMove(i_Point, m_CurrentPlayer) != null ? true : false;
        }

        public void MakeHumanMove(Point i_Point)
        {
            List<GameValidMoves> validMoves = findVaildGameMove(i_Point, CurrentPlayer);
            FlipPieces(validMoves, m_CurrentPlayer, getOpponentPlayer());

            NextPlayer();
            calcValidPlayerMoves(m_Player1);
            calcValidPlayerMoves(m_Player2);
        }

        public void MakePcMove()
        {
            List<GameValidMoves> validMoves = findVaildGameMove(getRandomValidMoveFromPlayer(m_CurrentPlayer), CurrentPlayer);
            FlipPieces(validMoves, m_CurrentPlayer, getOpponentPlayer());

            NextPlayer();
            calcValidPlayerMoves(m_Player1);
            calcValidPlayerMoves(m_Player2);
        }

        private Point getRandomValidMoveFromPlayer(Player i_CurrentPlayer)
        {
            Random rand = new Random();
            Point returnPoint = new Point();
            int randomIndexI = rand.Next(0, i_CurrentPlayer.ValidMoves.Count - 1);
            returnPoint = i_CurrentPlayer.ValidMoves[randomIndexI].EndPoint;

            return returnPoint;
        }

        private List<GameValidMoves> findVaildGameMove(Point i_Point, Player i_Player)
        {
            List<GameValidMoves> returnVaule = null;

            for (int i = 0; i < i_Player.ValidMoves.Count; i++)
            {
                if (i_Player.ValidMoves[i].EndPoint.IndexI == i_Point.IndexI && i_Player.ValidMoves[i].EndPoint.IndexJ == i_Point.IndexJ)
                {
                    if (returnVaule == null)
                    {
                        returnVaule = new List<GameValidMoves>();
                    }

                    returnVaule.Add(i_Player.ValidMoves[i]);
                }
            }

            return returnVaule;
        }

        private void FlipPieces(List<GameValidMoves> i_ValidMoves, Player i_CurrentPlayer, Player i_OpponentPlayer)
        {
            for (int i = 0; i < i_ValidMoves.Count; i++)
            {
                int indexI = i_ValidMoves[i].StartPoint.IndexI;
                int indexJ = i_ValidMoves[i].StartPoint.IndexJ;
                int endI = i_ValidMoves[i].EndPoint.IndexI;
                int endJ = i_ValidMoves[i].EndPoint.IndexJ;

                while ((indexI != endI) || (indexJ != endJ))
                {
                    indexI += i_ValidMoves[i].Dy;
                    indexJ += i_ValidMoves[i].Dx;
                    Point currentPoint = new Point(indexI, indexJ);
                    BoardCellType currentCellPiece = m_Board.GetCellType(currentPoint);

                    if (currentCellPiece == i_OpponentPlayer.PlayerPiece)
                    {
                        i_OpponentPlayer.RemovePiecesOnBoard(currentPoint);
                        CurrentPlayer.AddPiecesOnBoard(currentPoint);
                    }

                    if (currentCellPiece == BoardCellType.None)
                    {
                        CurrentPlayer.AddPiecesOnBoard(currentPoint);
                    }

                    m_Board.SetCell(currentPoint, i_CurrentPlayer.PlayerPiece);
                }
            }
        }

        public void NextPlayer()
        {
            if (m_CurrentPlayer == Player1)
            {
                m_CurrentPlayer = m_Player2;
            }
            else
            {
                m_CurrentPlayer = m_Player1;
            }
        }

        public bool IsGameOver()
        {
            bool returnValue = false;

            if (m_Board.UnUsedCells == 0 || (m_Player1.ValidMoves == null && m_Player2.ValidMoves == null))
            {
                returnValue = true;
            }

            return returnValue;
        }

        public int GetWinResult()
        {
            return m_Player1.GetScore() - m_Player2.GetScore();
        }
    }
}
