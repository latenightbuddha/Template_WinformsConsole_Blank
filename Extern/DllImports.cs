﻿using System;
using System.Runtime.InteropServices;

namespace Extern
{
    public class DllImports
    {
        public class WindowsConsole
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
