using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : IExecuteUserChoice
    {
        public void ExecuteUserChoice()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }
    }
}
