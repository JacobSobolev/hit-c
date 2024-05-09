using System;
using System.Text;

namespace Ex02_Othelo
{
    public class UserInterface
    {
        private const int k_LegalBoardSize1 = 6;
        private const int k_LegalBoardSize2 = 8;
        private const string k_BlackPieceRepresentation = "X";
        private const string k_WhitePieceRepresentation = "O";
        private const string k_PcName = "Pc";
        private const string k_ValidEndGameInputYes = "Y";
        private const string k_ValidEndGameInputNo = "N";
        private Game m_Game;
        private bool m_playerWantToQuit;

        public UserInterface()
        {
            m_playerWantToQuit = false;
        }

        public void RunGame()
        {
            string player1Name;
            string player2Name;
            int validGameSize;
            int validPlaySelection;
            PlayerType player2Type;

            showWellcomeMsg();
            player1Name = getPlayer1Name();
            validGameSize = userGridSizeSelection();
            validPlaySelection = userPlaySelection();
            player2Name = getPlayer2Name(validPlaySelection);
            player2Type = getPlayer2Type(validPlaySelection);
            createGame(validGameSize, player1Name, player2Name, player2Type);
            showGoodLuckMsg();
            play();
        }

        private void showWellcomeMsg()
        {
            Console.WriteLine(
@"Wellcome to the game othello aka Reversi
=========================================");
        }

        private string getPlayer1Name()
        {
            Console.WriteLine("Please enter your name");

            return Console.ReadLine();
        }

        private int userGridSizeSelection()
        {
            bool isUserInputValid;
            int returnValidInput;

            do
            {
                Console.WriteLine("Please Select the gird size 6 or 8");
                isUserInputValid = int.TryParse(Console.ReadLine(), out returnValidInput) && (returnValidInput == k_LegalBoardSize1 || returnValidInput == k_LegalBoardSize2);
                if (!isUserInputValid)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            while (!isUserInputValid);

            return returnValidInput;
        }

        private int userPlaySelection()
        {
            bool isUserInputValid;
            int returnValidInput;

            do
            {
                Console.WriteLine(
@"To play against another Human press 1
To play against the Pc press 2");
                isUserInputValid = int.TryParse(Console.ReadLine(), out returnValidInput) && (returnValidInput == 1 || returnValidInput == 2);
                if (!isUserInputValid)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            while (!isUserInputValid);

            return returnValidInput;
        }

        private string userPlaySelectionHuman()
        {
            Console.WriteLine("you choose to play against human player");
            Console.WriteLine("Please enter second player`s name");
            return Console.ReadLine();
        }

        private string userPlaySelectionPc()
        {
            Console.WriteLine("you choose to play against pc player");
            return k_PcName;
        }

        private string getPlayer2Name(int i_ValidUserSlectsion)
        {
            string returnValue = string.Empty;

            if (i_ValidUserSlectsion == 1)
            {
                returnValue = userPlaySelectionHuman();
            }
            else
            {
                returnValue = userPlaySelectionPc();
            }

            return returnValue;
        }

        private PlayerType getPlayer2Type(int i_ValidUserSlectsion)
        {
            PlayerType returnValue;

            if (i_ValidUserSlectsion == 1)
            {
                returnValue = PlayerType.Human;
            }
            else
            {
                returnValue = PlayerType.Pc;
            }

            return returnValue;
        }

        private void createGame(int i_ValidBoardSize, string i_Player1Name, string i_Player2Name, PlayerType i_Player2Type) 
        {
            m_Game = new Game(i_ValidBoardSize, i_Player1Name, i_Player2Name, i_Player2Type);
        }

        private void showGoodLuckMsg()
        {
            Console.WriteLine(
@"=================
player 1 is {0}
player 2 is {1} 
gird size is {2}
Good Luck!
Press any key to continue...", m_Game.Player1.Name, m_Game.Player2.Name, m_Game.Board.BoardSize);
            Console.ReadKey();
        }

        private void play()
        {
            Point validUserInput = new Point();
            while (!m_playerWantToQuit)
            {
                if (!m_Game.IsGameOver())
                {
                    drawBoard();
                    drawScores();
                    drawPlayerTurn();
                    if (m_Game.CurrentPlayer.ValidMoves != null)
                    {
                        if (m_Game.CurrentPlayer.PType == PlayerType.Pc)
                        {
                            getUserInputPc();
                            m_Game.MakePcMove();
                        }
                        else
                        {
                            validUserInput = getUserInputHuman();
                            if (!m_playerWantToQuit)
                            {
                                m_Game.MakeHumanMove(validUserInput);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Valid Moves Skiping this turn press any key to countine...");
                        Console.ReadKey();
                    }
                }
                else 
                {
                    drawBoard();
                    drawScores();
                    drawPlayerWinner();
                    getUserInputEndGame();
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void drawBoard()
        {
            StringBuilder outputBoard = new StringBuilder();
            BoardCellType tmpIterationCellType;
            Point tmpIterationPoint = new Point();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < m_Game.Board.BoardSize; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            outputBoard.Append(' ', 2);
                        }

                        outputBoard.Append(' ', 2);
                        outputBoard.Append((char)('A' + j));
                        outputBoard.Append(' ', 1);
                    }
                    else
                    {
                        if (j == 0)
                        {
                            outputBoard.Append(' ', 2);
                        }

                        if (j == m_Game.Board.BoardSize - 1)
                        {
                            outputBoard.Append('=', 1);
                        }

                        outputBoard.Append('=', 4);
                    }
                }

                outputBoard.AppendLine();   
            }

            for (int i = 0; i < m_Game.Board.BoardSize; i++)
            {
                outputBoard.Append(string.Format("{0} |", i + 1));
                for (int j = 0; j < m_Game.Board.BoardSize; j++)
                {
                    tmpIterationPoint.IndexI = i;
                    tmpIterationPoint.IndexJ = j;
                    tmpIterationCellType = m_Game.Board.GetCellType(tmpIterationPoint);

                    if (tmpIterationCellType == BoardCellType.Black)
                    {
                        outputBoard.Append(string.Format(" {0} |", k_BlackPieceRepresentation));
                    }
                    else if (tmpIterationCellType == BoardCellType.White)
                    {
                        outputBoard.Append(string.Format(" {0} |", k_WhitePieceRepresentation));
                    }
                    else
                    {
                        outputBoard.Append("   |");
                    }
                }

                outputBoard.AppendLine();
                outputBoard.Append(' ', 2);
                outputBoard.Append('=', (4 * m_Game.Board.BoardSize) + 1);
                outputBoard.AppendLine();
            }

            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(outputBoard);
        }

        private void drawScores()
        {
            Console.Write(
@"+++++++++++++++++++++++
{0}    {1}
+++++++++++++++++++++++++", m_Game.Player1.ToString(), m_Game.Player2.ToString());
        }

        private void drawPlayerTurn()
        {
            Console.Write(
@"
{0}`s turn, your piece is {1}
+++++++++++++++++++++++++
", m_Game.CurrentPlayer.Name, m_Game.CurrentPlayer.PlayerPiece == BoardCellType.Black ? k_BlackPieceRepresentation : k_WhitePieceRepresentation);
        }

        private void drawPlayerWinner()
        {
            Console.WriteLine(
@"+++++++++++++++++++++++++
    GAME OVER
+++++++++++++++++++++++++
");
            if (m_Game.GetWinResult() != 0)
            {
                Player Winner;
                Console.Write("The Winner is ");

                if (m_Game.GetWinResult() > 0)
                {
                    Winner = m_Game.Player1;    
                }
                else
                {
                    Winner = m_Game.Player2;
                }

                Console.Write("{0}", Winner.Name);
            }
            else
            {
                Console.Write("No One Wins, It's A Tie!");
            }

            Console.WriteLine();
        }

        private void getUserInputEndGame()
        {
            string userInput = string.Empty;
            bool validUserInput = false;

            do
            {
                Console.WriteLine("Would you like to play again press Y for Yes N for No? (Y/N)");
                userInput = Console.ReadLine();

                if (userInput.Length == 1 && userInput == k_ValidEndGameInputYes)
                {
                    validUserInput = true;
                    m_Game.ResetGame();
                }
                else if (userInput.Length == 1 && userInput == k_ValidEndGameInputNo)
                {
                    validUserInput = true;
                    m_playerWantToQuit = true;
                    Console.WriteLine("Bye Bye");
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
            while (!validUserInput);
        }

        private Point getUserInputHuman()
        {
            string userInput;
            bool validUserInput = false;
            char indexIChar;
            Point returnPoint = new Point();
            int validUserIndexJ;
            int validUserIndexI;

            Console.Write(
@"
Please enter a row number(1-{0}) followed column name(A-{1}).
For example 1A, or press Q to quit the game: ", m_Game.Board.BoardSize, (char)('A' + m_Game.Board.BoardSize - 1));

            do
            {    
                userInput = Console.ReadLine();
                if (userInput.Length == 1 && userInput == "Q")
                {
                    Console.WriteLine("Bye Bye");
                    m_playerWantToQuit = true;
                    validUserInput = true;
                }
                else
                {
                    if (userInput.Length == 2 && int.TryParse(userInput[0].ToString(), out validUserIndexI) && char.TryParse(userInput[1].ToString(), out indexIChar))
                    {
                        validUserIndexJ = (int)(indexIChar - 'A');
                        validUserIndexI--;
                        returnPoint.IndexI = validUserIndexI;
                        returnPoint.IndexJ = validUserIndexJ;

                        if (m_Game.IsVaildPoint(returnPoint))
                        {
                            if (!m_Game.Board.IsCellTaken(returnPoint))
                            {
                                if (m_Game.CanMakeMove(returnPoint))
                                {
                                    validUserInput = true;
                                }
                                else
                                {
                                    Console.WriteLine("This is invalid move please learn the rules! and try again");
                                }
                            }
                            else
                            {
                                Console.WriteLine("The cell is already taken! try again");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please a choose cell from the correct range! try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid input! try again");
                    }
                }
            }
            while (!validUserInput);

            return returnPoint;
        }

        private void getUserInputPc()
        {
            Console.WriteLine("The {0} will make it's turn after you press a key...", m_Game.CurrentPlayer.Name);
            Console.ReadKey();
        }
    }
}
