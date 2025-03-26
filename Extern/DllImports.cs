using System;
using System.Runtime.InteropServices;

namespace Extern
{
    public class DllImports
    {
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public class WindowsHooks
        {
            /// <summary>
            /// Retrieves the window handle used by the console associated with the calling process.
            /// </summary>
            /// <returns>The return value is a handle to the window used by the console associated with the calling process.</returns>
            [DllImport("kernel32.dll", ExactSpelling = true)]
            public static extern IntPtr GetConsoleWindow();

            /// <summary>
            /// Sets the specified window's show state.
            /// </summary>
            /// <param name="hWnd">A handle to the window.</param>
            /// <param name="nCmdShow">Controls how the window is to be shown.</param>
            /// <returns>If the window was previously visible/hidden</returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            /// <summary>
            /// Installs an application-defined hook procedure into a hook chain.
            /// </summary>
            /// <param name="idHook">The type of hook procedure to be installed.</param>
            /// <param name="lpfn">A pointer to the hook procedure.</param>
            /// <param name="hMod">A handle to the DLL containing the hook procedure pointed to by the lpfn parameter.</param>
            /// <param name="dwThreadId">The identifier of the thread with which the hook procedure is to be associated.</param>
            /// <returns></returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

            /// <summary>
            /// Removes a hook procedure installed in a hook chain.
            /// </summary>
            /// <param name="hhk">A handle to the hook to be removed.</param>
            /// <returns>If the function succeeds, the return value is nonzero.</returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            /// <summary>
            /// Passes the hook information to the next hook procedure in the current hook chain.
            /// </summary>
            /// <param name="hhk">This parameter is ignored.</param>
            /// <param name="nCode">The hook code passed to the current hook procedure.</param>
            /// <param name="wParam">The wParam value passed to the current hook procedure.</param>
            /// <param name="lParam">The lParam value passed to the current hook procedure.</param>
            /// <returns>This value is returned by the next hook procedure in the chain.</returns>
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            /// <summary>
            /// Retrieves a module handle for the specified module.
            /// </summary>
            /// <param name="lpModuleName">The name of the loaded module (either a .dll or .exe file). If the file name extension is omitted</param>
            /// <returns>If the function succeeds, the return value is a handle to the specified module otherwise NULL will be returned</returns>
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr GetModuleHandle(string lpModuleName);
        }

        public class WindowsConsole
        {
            /// <summary>
            /// Perform certain special effects when showing or hiding a window
            /// </summary>
            public class CmdShow
            {
                /// <summary>
                /// Hides the window and activates another window.
                /// </summary>
                public const int SW_HIDE = 0;

                /// <summary>
                /// Activates and displays a window. If the window is minimized, maximized, or arranged, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
                /// </summary>
                public const int SW_SHOWNORMAL = 1;
                /// <summary>
                /// Activates and displays a window. If the window is minimized, maximized, or arranged, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
                /// </summary>
                public const int SW_NORMAL = SW_SHOWNORMAL;

                /// <summary>
                /// Activates the window and displays it as a minimized window.
                /// </summary>
                public const int SW_SHOWMINIMIZED = 2;

                /// <summary>
                /// Activates the window and displays it as a maximized window.
                /// </summary>
                public const int SW_SHOWMAXIMIZED = 3;
                /// <summary>
                /// Activates the window and displays it as a maximized window.
                /// </summary>
                public const int SW_MAXIMIZE = SW_SHOWMAXIMIZED;

                /// <summary>
                /// Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except that the window is not activated.
                /// </summary>
                public const int SW_SHOWNOACTIVATE = 4;

                /// <summary>
                /// Activates the window and displays it in its current size and position.
                /// </summary>
                public const int SW_SHOW = 5;

                /// <summary>
                /// Minimizes the specified window and activates the next top-level window in the Z order.
                /// </summary>
                public const int SW_MINIMIZE = 6;

                /// <summary>
                /// Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
                /// </summary>
                public const int SW_SHOWMINNOACTIVE = 7;

                /// <summary>
                /// Displays the window in its current size and position. This value is similar to SW_SHOW, except that the window is not activated.
                /// </summary>
                public const int SW_SHOWNA = 8;

                /// <summary>
                /// Activates and displays the window. If the window is minimized, maximized, or arranged, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
                /// </summary>
                public const int SW_RESTORE = 9;

                /// <summary>
                /// Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
                /// </summary>
                public const int SW_SHOWDEFAULT = 10;

                /// <summary>
                /// Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
                /// </summary>
                public const int SW_FORCEMINIMIZE = 11;
            }
            
        }
    }
}
