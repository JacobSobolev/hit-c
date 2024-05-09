namespace Ex04.Menus.Interfaces
{
    public class ExecutableMenuItem : MenuItem
    {
        private IExecuteUserChoice m_UserChoiceMethod;

        public ExecutableMenuItem(string i_ItemName, IExecuteUserChoice i_ExecuteUserChoice)
            : base(i_ItemName)
        {
            m_UserChoiceMethod = i_ExecuteUserChoice;
        }

        internal override void ExecuteActionOrOpenSubMenu()
        {
            m_UserChoiceMethod.ExecuteUserChoice();
        }
    }
}
