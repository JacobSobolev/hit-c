using System;
using System.Windows.Forms;

namespace A17.Ex05.GameOthelloUI
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameMain());
        }
    }
}
