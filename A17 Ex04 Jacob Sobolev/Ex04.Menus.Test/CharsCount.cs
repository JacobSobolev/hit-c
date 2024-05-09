using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CharsCount : IExecuteUserChoice
    {
        public void ExecuteUserChoice()
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
    }
}
