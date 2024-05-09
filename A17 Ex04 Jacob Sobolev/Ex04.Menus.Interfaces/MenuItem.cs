namespace Ex04.Menus.Interfaces
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
            get { return this.m_MenuName; }
            set { this.m_MenuName = value; }
        }

        internal abstract void ExecuteActionOrOpenSubMenu();
    }
}
