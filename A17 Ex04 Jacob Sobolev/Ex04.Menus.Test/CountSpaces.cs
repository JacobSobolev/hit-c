using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountSpaces : IExecuteUserChoice
    {
        public void ExecuteUserChoice()
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
    }
}
