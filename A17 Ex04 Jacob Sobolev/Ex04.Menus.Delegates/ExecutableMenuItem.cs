namespace Ex04.Menus.Delegates
{
    public delegate void ActionExecutionDelegate();

    public class ExecutableMenuItem : MenuItem
    {
        public event ActionExecutionDelegate ExecuteUserChoice;

        public ExecutableMenuItem(string i_ItemName)
            : base(i_ItemName)
        {
        }

        internal override void ExecuteActionOrOpenSubMenu()
        {
            if (ExecuteUserChoice != null)
            {
                ExecuteUserChoice.Invoke();
            }
        }
    }
}
