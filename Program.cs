using System;
using System.Windows.Forms;
using static Extern.DllImports.WindowsConsole;

namespace WinformsConsole
{
    public static class Program
    {
        /// <summary>
        /// Main Form Entrypoint
        /// </summary>
        public static Form1 mainForm;

        /// <summary>
        /// Read-Only Bool State (Managed) of IsConsoleDisplayed
        /// </summary>
        public static bool IsConsoleDisplayed => _localIsConsoleDisplayed;
        
        private static bool _localIsConsoleDisplayed;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ShowConsoleWindow(false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new Form1();
            mainForm.Load += new EventHandler(delegate (Object sender, EventArgs e) { mainForm.Activate(); });
            Application.Run(mainForm);

            ShowConsoleWindow(true);
            Console.Write(Environment.NewLine + "Press any key to close this window . . .");
            Console.ReadKey();
        }


        /// <summary>
        /// Show/Hide Console Window
        /// </summary>
        /// <param name="showConsoleWindow">Boolean: if true SW_RESTORE else SW_HIDE</param>
        public static void ShowConsoleWindow(bool showConsoleWindow)
        {
            _localIsConsoleDisplayed = showConsoleWindow;

            switch (showConsoleWindow)
            {
                case true:
                    ShowWindow(GetConsoleWindow(), CmdShow.SW_RESTORE);
                    break;
                default:
                    ShowWindow(GetConsoleWindow(), CmdShow.SW_HIDE);
                    break;
            }
        }

        //end of
    }
}