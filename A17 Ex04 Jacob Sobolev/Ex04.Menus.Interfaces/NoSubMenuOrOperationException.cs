using System;

namespace Ex04.Menus.Interfaces
{
    public class NoSubMenuOrOperationException : Exception
    {
        public NoSubMenuOrOperationException(string i_ErrorMsg)
            : base(i_ErrorMsg)
        {
        }
    }
}
