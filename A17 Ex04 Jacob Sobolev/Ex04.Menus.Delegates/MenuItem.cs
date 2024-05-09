namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        private string m_MenuName = string.Empty;

        public MenuItem(string i_MenuName)
        {
            this.MenuName = i_MenuName;
        }

        public string MenuName
        {
            get { return m_MenuName; }
            set { m_MenuName = value; }
        }

        internal abstract void ExecuteActionOrOpenSubMenu();
    }
}
