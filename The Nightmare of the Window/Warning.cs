using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static The_Nightmare_of_the_Window.api;
using static The_Nightmare_of_the_Window.function;
using System.Threading;
using System.Diagnostics;

namespace The_Nightmare_of_the_Window
{
    public partial class Warning : Form
    {
        public void ColorTool()
        {
            int color = 0;
            while (true)
            {
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        this.label4.ForeColor = Color.FromArgb((int)(HSV(color)));
                        color++;
                        if (color > 360)
                            color = 0;
                    }
                    ));
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
                Sleep(10);
            }
        }
        public Warning()
        {
            InitializeComponent();
        }
        public static SoundPlayer player = new SoundPlayer(Properties.Resources.title);
        public void CloseAnyWindow()
        {
            player.Stop();
            Variables.RunPingPong = checkBox3.Checked;
            Close();
        }

        private void Warning_Load(object sender, EventArgs e)
        {
            player.Play();
            Left = ScrWidthHalf - Width / 2;
            Top = ScrHeightHalf - Height / 2;
            NewThread(ColorTool);
        }

        private void Warning_FormClosing(object sender, FormClosingEventArgs e)
        {
            Background.Instance.Close_this();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseAnyWindow();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = checkBox1.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string text = @"1. It is recommended to run virtual machine software such as VMware Workstation or VirtualBox within the virtual machine to prevent any accidents.
2. Please save your files first.
3. This program will traverse every window. Don't worry, it won't steal your content. Therefore, the more windows there are, the better the effect will be. Do not run this program.
";
            MessageBox(this.Handle, text, "", 0x00000040);
        }
        public static IntPtr Hook;
        public static void ThreadForWarning(Object wnd)
        {
            IntPtr hwnd = (IntPtr)wnd;
            while (IsWindow(hwnd))
            {
                IntPtr hdc = GetWindowDC(hwnd);
                RECT rc;
                GetWindowRect(hwnd, out rc);
                int w = rc.right - rc.left;
                int h = rc.bottom - rc.top;
                BitBlt(hdc, 0, 0, w, h, hdc, 0, 0, TernaryRasterOperations.NOTSRCCOPY);
                ReleaseDC(hwnd, hdc);
                Sleep(500);
            }
        }
        public static IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == 5)
            {
                Thread t = new Thread(ThreadForWarning);
                t.IsBackground = true;
                t.Start(wParam);
                UnhookWindowsHookEx(Hook);
                return IntPtr.Zero; 
            }
            return CallNextHookEx(Hook, nCode, wParam, lParam);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hook = SetWindowsHookEx(5, HookProc, IntPtr.Zero, GetCurrentThreadId());
            if (MessageBox(this.Handle, "This is the final warning. \nDo you want to run?", "No title", 0x00000030| 0x00000004| 0x00000100) == 0x7)
            {
                this.Show();
            }
            else
            {
                Variables.dontrun = false;
                if (radioButton1.Checked && checkBox2.Checked == false)
                    Variables.SafeMode = true;
                if (radioButton2.Checked || checkBox2.Checked)
                    Variables.SafeMode = false;
                CloseAnyWindow();
            }
        }
        public void SetEnabled(bool Enabled)
        {
            radioButton1.Enabled = Enabled;
            radioButton2.Enabled = Enabled;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (MessageBox(this.Handle, "Are you sure you want to use the dangerous mode? \r\nIf you still don't know what happened, please click 'No' immediately to exit.\r\nIf you are clear about what this is for, \r\nplease think it over carefully.\r\nAs for all the problems caused by this system, the operator will be responsible for them.", "Warning - This operation is very dangerous", 0x00000030| 0x00000100| 0x00040000| 0x00000004) == 0x6)
                {
                    if (MessageBox(this.Handle, "！ This is the final warning! \r\n\r\nAre you sure you want to use the dangerous mode? \r\nIf you still don't know what happened, immediately click 'No' to exit \r\nIf you are clear about what this is for, \r\nplease think carefully \r\nAs for all the problems caused by this city, the operator will be responsible for them. \r\nWarning - This operation is very dangerous", "Still run?", 0x00000030 | 0x00000100 | 0x00040000 | 0x00000004) == 0x6)
                    {
                        Variables.UnSafeMode = true;
                        SetEnabled(false);
                    }
                    else
                    {
                        Variables.UnSafeMode = false;
                        checkBox2.Checked = false;
                        SetEnabled(true);
                    }
                }
                else
                {
                    Variables.UnSafeMode = false;
                    checkBox2.Checked = false;
                    SetEnabled(true);
                }
            }
            else
            {
                SetEnabled(true);
            }
        }
    }
}
