using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class ListOfMenuItems : MenuItem
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        protected string m_BackOrExit = "Back";

        public ListOfMenuItems(string i_MenuName)
            : base(i_MenuName)
        {
        }

        internal override void ExecuteActionOrOpenSubMenu()
        {
            if (r_MenuItems != null)
            {
                int index;

                do
                {
                    index = 1;

                    Console.WriteLine(
@"{0}
============
", MenuName);
                    foreach (MenuItem currentMenuItem in r_MenuItems)
                    {
                        Console.WriteLine("{0}: {1}{2}", index++, currentMenuItem.MenuName, Environment.NewLine);
                    }

                    Console.WriteLine("0: {0}{1}", m_BackOrExit, Environment.NewLine);
                    Console.WriteLine("========================");
                    Console.WriteLine("Select the menu (0 - {0} is valid){1}", r_MenuItems.Count, Environment.NewLine);
                }
                while (!getUserInputToExecute());

                Console.Clear();
            }
            else
            {
                throw new NoSubMenuOrOperationException("There is no operation or submenu!");
            }
        }

        private bool getUserInputToExecute()
        {
            bool isBackOrExit = false;
            int userChoice;

            userChoice = getValidInput();

            if (userChoice == 0)
            {
                isBackOrExit = true;
            }
            else
            {
                try
                {
                    Console.Clear();
                    r_MenuItems[userChoice - 1].ExecuteActionOrOpenSubMenu();
                }
                catch (NoSubMenuOrOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            return isBackOrExit;
        }

        private int getValidInput()
        {
            bool isInputValid = true;
            int userInput;
            do
            {
                isInputValid = int.TryParse(Console.ReadLine(), out userInput) && userInput >= 0 && userInput <= r_MenuItems.Count;

                if (!isInputValid)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
            while (!isInputValid);

            return userInput;
        }

        public void AddItem(MenuItem i_MenuItemToAdd)
        {
            r_MenuItems.Add(i_MenuItemToAdd);
        }
    }
}
