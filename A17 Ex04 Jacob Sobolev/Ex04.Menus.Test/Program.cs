using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            runDelegateMenu();
            runInterfaceMenu();
        }

        private static void runInterfaceMenu()
        {
            Interfaces.MainMenu mainMenuInterface = new Interfaces.MainMenu("Main Menu - Interfaces");
            Interfaces.ListOfMenuItems dateAndTimeMenuInterface = new Interfaces.ListOfMenuItems("Show Date/Time");
            Interfaces.ListOfMenuItems versionsAndActionsMenuInterface = new Interfaces.ListOfMenuItems("Version And Actions");
            Interfaces.ListOfMenuItems actionsMenuInterface = new Interfaces.ListOfMenuItems("Actions");
            Interfaces.ExecutableMenuItem showTimeItemInterface = new Interfaces.ExecutableMenuItem("Show Time", new ShowTime());
            Interfaces.ExecutableMenuItem showDateItemInterface = new Interfaces.ExecutableMenuItem("Show Date", new ShowDate());
            Interfaces.ExecutableMenuItem countSpacesItemInterface = new Interfaces.ExecutableMenuItem("Count Spaces", new CountSpaces());
            Interfaces.ExecutableMenuItem charCountItemInterface = new Interfaces.ExecutableMenuItem("Chars Count", new CharsCount());
            Interfaces.ExecutableMenuItem showVersionItemInterface = new Interfaces.ExecutableMenuItem("Show Version", new ShowVersion());

            dateAndTimeMenuInterface.AddItem(showTimeItemInterface);
            dateAndTimeMenuInterface.AddItem(showDateItemInterface);
            versionsAndActionsMenuInterface.AddItem(actionsMenuInterface);
            versionsAndActionsMenuInterface.AddItem(showVersionItemInterface);
            actionsMenuInterface.AddItem(countSpacesItemInterface);
            actionsMenuInterface.AddItem(charCountItemInterface);
            mainMenuInterface.AddItem(dateAndTimeMenuInterface);
            mainMenuInterface.AddItem(versionsAndActionsMenuInterface);

            mainMenuInterface.Show();
        }

        private static void runDelegateMenu()
        {
            Delegates.MainMenu mainMenuDelegate = new Delegates.MainMenu("Main Menu - Delegates");
            Delegates.ListOfMenuItems dateAndTimeMenuDelegate = new Delegates.ListOfMenuItems("Show Date/Time");
            Delegates.ListOfMenuItems versionsAndActionsMenuDelegate = new Delegates.ListOfMenuItems("Version And Actions");
            Delegates.ListOfMenuItems actionsMenuDelegate = new Delegates.ListOfMenuItems("Actions");
            Delegates.ExecutableMenuItem showTimeItemDelegate = new Delegates.ExecutableMenuItem("Show Time");
            Delegates.ExecutableMenuItem showDateItemDelegate = new Delegates.ExecutableMenuItem("Show Date");
            Delegates.ExecutableMenuItem countSpacesItemDelegate = new Delegates.ExecutableMenuItem("Count Spaces");
            Delegates.ExecutableMenuItem charCountItemDelegate = new Delegates.ExecutableMenuItem("Chars Count");
            Delegates.ExecutableMenuItem showVersionItemDelegate = new Delegates.ExecutableMenuItem("Show Version");

            showTimeItemDelegate.ExecuteUserChoice += showTime;
            showDateItemDelegate.ExecuteUserChoice += showDate;
            countSpacesItemDelegate.ExecuteUserChoice += countSpaces;
            charCountItemDelegate.ExecuteUserChoice += charsCount;
            showVersionItemDelegate.ExecuteUserChoice += showVersion;

            dateAndTimeMenuDelegate.AddItem(showTimeItemDelegate);
            dateAndTimeMenuDelegate.AddItem(showDateItemDelegate);
            versionsAndActionsMenuDelegate.AddItem(actionsMenuDelegate);
            versionsAndActionsMenuDelegate.AddItem(showVersionItemDelegate);
            actionsMenuDelegate.AddItem(countSpacesItemDelegate);
            actionsMenuDelegate.AddItem(charCountItemDelegate);
            mainMenuDelegate.AddItem(dateAndTimeMenuDelegate);
            mainMenuDelegate.AddItem(versionsAndActionsMenuDelegate);

            mainMenuDelegate.Show();
        }

        private static void showTime()
        {
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private static void showDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        private static void countSpaces()
        {
            int numOfSpaces = 0;

            Console.WriteLine("Please enter a sentence:");
            string userInput = Console.ReadLine();

            foreach (char character in userInput)
            {
                if (char.IsWhiteSpace(character))
                {
                    numOfSpaces++;
                }
            }

            Console.WriteLine("There are {0} spaces in the sentence", numOfSpaces);
        }

        private static void charsCount()
        {
            int numOfChars = 0;

            Console.WriteLine("Please enter a sentence:");
            string userInput = Console.ReadLine();

            foreach (char character in userInput)
            {
                if (char.IsLetter(character))
                {
                    numOfChars++;
                }
            }

            Console.WriteLine("There are {0} letters in the sentence", numOfChars);
        }

        private static void showVersion()
        {
            Console.WriteLine("Version: 17.1.4.0");
        }
    }
}
