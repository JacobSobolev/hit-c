using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : IExecuteUserChoice
    {
        public void ExecuteUserChoice()
        {
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
        }
    }
}
