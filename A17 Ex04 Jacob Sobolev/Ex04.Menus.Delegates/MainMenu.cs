namespace Ex04.Menus.Delegates
{
    public class MainMenu : ListOfMenuItems
    {
        public MainMenu(string i_MenuName)
            : base(i_MenuName)
        {
            m_BackOrExit = "Exit";
        }

        public void Show()
        {
            ExecuteActionOrOpenSubMenu();
        }
    }
}