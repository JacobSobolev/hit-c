using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IExecuteUserChoice
    {
        public void ExecuteUserChoice()
        {
            Console.WriteLine("Version: 17.1.4.0");
        }
    }
}
