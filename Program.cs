using System;
using System.Windows.Forms;
using static Extern.DllImports.WindowsHooks;
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

        // Local assignment for IsConsoleDisplayed
        private static bool _localIsConsoleDisplayed;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set initial console window to be hidden.
            ShowConsoleWindow(false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create Form
            mainForm = new Form1();

            // Set window to be active once the Form is loaded
            mainForm.Load += new EventHandler(delegate (Object sender, EventArgs e) { mainForm.Activate(); });

            // Runs Form1 in the main thread.
            Application.Run(mainForm);

            // ------------------------------------------------
            // All code below will be ran after the main thread with Form1 has ended.
            // ------------------------------------------------

            // Display console during closing.
            ShowConsoleWindow(true);

            // Print default message once the main form is closed.
            Console.Write(Environment.NewLine + "Press any key to close this window . . .");

            // Hold the window open so the user can read the screen before exiting.
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