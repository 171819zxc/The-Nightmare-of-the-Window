using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static The_Nightmare_of_the_Window.api;
using static The_Nightmare_of_the_Window.function;
using static The_Nightmare_of_the_Window.Variables;

namespace The_Nightmare_of_the_Window
{
    internal class payloads
    {
        public static IntPtr dsk = GetDesktopWindow();
        public static void RedScreen()
        {
            IntPtr hdc = GetWindowDC(dsk);
            IntPtr hBrush = CreateSolidBrush((uint)RandRed());
            IntPtr hOldBrush = SelectObject(hdc, hBrush);
            PatBlt(hdc, 0, 0, ScrWidth, ScrHeight, TernaryRasterOperations.PATINVERT);
            SelectObject(hdc, hOldBrush);
            DeleteObject(hBrush);
            ReleaseDC(dsk, hdc);
        }
        public static void DrawCursor()
        {
            IntPtr hCursor = LoadCursor(IntPtr.Zero, IDC_ARROW);//IDC_ARROW是箭头光标，而且是系统资源无需释放
            while (true)
            {
                IntPtr hdc = GetWindowDC(dsk);
                DrawIcon(hdc, RandX(), RandY(), hCursor);
                if (Randint(0, 50) == 0)
                {
                    BitBlt(hdc, -1, -1, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.SRCPAINT);
                    if (Randint(0, 5) == 0)
                        BitBlt(hdc, Randint(-2, 2), Randint(-2, 2), ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                }
                ReleaseDC(dsk, hdc);
                Sleep(5);
            }
        }
        public static void PingPong()
        {
            int color = 0;
            int x = 0;
            int y = 0;
            int x1 = 1;
            int y1 = 1;
            int w = (ScrWidth / 10);
            int h = (ScrHeight / 10);
            int angle = 0;
            IntPtr hError = LoadIcon(IntPtr.Zero, IDI_ERROR);
            IntPtr hWarning = LoadIcon(IntPtr.Zero, IDI_WARNING);
            IntPtr hQuestion = LoadIcon(IntPtr.Zero, IDI_QUESTION);
            while (true)
            {
                IntPtr hdc = GetWindowDC(dsk);
                IntPtr hBrush = CreateSolidBrush((uint)HSV(color));
                IntPtr hOldBrush = SelectObject(hdc, hBrush);
                Ellipse(hdc, x, y, x + w, y + h);
                SelectObject(hdc, hOldBrush);
                DeleteObject(hBrush);
                /*
                POINT pt;
                pt.x = x + ((w / 2) - 16);
                pt.y = y + ((h / 2) - 16);
                DrawIcon(hdc, pt.x, pt.y, hError);
                DrawIcon(
                    hdc,
                    (int)(pt.x + (Math.Cos(Convert_degrees_to_radians(angle)) * 100)),
                    (int)(pt.y + (Math.Sin(Convert_degrees_to_radians(angle)) * 100)),
                    hWarning
                    );
                DrawIcon(
                    hdc,
                    (int)(pt.x + -(Math.Cos(Convert_degrees_to_radians(angle)) * 100)),
                    (int)(pt.y + -(Math.Sin(Convert_degrees_to_radians(angle)) * 100)),
                    hWarning
                    );
                DrawIcon(
                    hdc,
                    ((int)(pt.x + Math.Sin(Convert_degrees_to_radians(angle)) * 200)),
                    ((int)(pt.y + Math.Cos(Convert_degrees_to_radians(angle)) * 200)),
                    hQuestion
                    );
                DrawIcon(
                    hdc,
                    ((int)(pt.x + -Math.Sin(Convert_degrees_to_radians(angle)) * 200)),
                    ((int)(pt.y + -Math.Cos(Convert_degrees_to_radians(angle)) * 200)),
                    hQuestion
                    );
                */
                ReleaseDC(dsk,hdc);
                color++;
                x+=x1;
                y+=y1;
                if (color > 360)
                    color = 0;
                if (x + ScrWidth / 10 > ScrWidth || x < 0)
                    x1 = -x1;
                if (y + ScrHeight / 10 > ScrHeight || y < 0)
                    y1 = -y1;
                Sleep(5);
                angle += 5;
            } 
        }
        public static void fanshaped()
        {
            while (true) 
            {
                for (int w = 10;w < ScrHeightHalf;w += 30)
                {
                    IntPtr hdc  = GetWindowDC(dsk);
                    IntPtr hRgn = CreateEllipticRgn(-w, -w, w, w);
                    IntPtr hOldRgn = (IntPtr)SelectClipRgn(hdc, hRgn);
                    BitBlt(hdc, 0, 0, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.NOTSRCCOPY);
                    SelectClipRgn(hdc, hOldRgn);
                    DeleteObject(hRgn);
                    ReleaseDC(dsk,hdc);
                    Sleep(50);
                }
            }
        }
        public static void GDI1()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                BitBlt(hdc, RandX(), RandY(), Randint(0, 800), Randint(0, 600), hdc, RandX(), RandY(), TernaryRasterOperations.SRCCOPY);
                ReleaseDC(dsk, hdc);
                RedScreen();
                Sleep(3);
            }
        }
        public static void GDI2()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                IntPtr hBrush = CreateSolidBrush((uint)RandColor());
                IntPtr hOldBrush = SelectObject(hdc, hBrush);
                PatBlt(hdc, 0, 0, ScrWidth, ScrHeight, TernaryRasterOperations.PATINVERT);
                SelectObject(hdc, hOldBrush);
                DeleteObject(hBrush);
                IntPtr hPen = CreatePen(0, Randint(5, 10), (uint)RandColor());
                IntPtr hOldPen = SelectObject(hdc, hPen);
                POINT pt;
                MoveToEx(hdc, RandX(), RandY(), out pt);
                LineTo(hdc, RandX(), RandY());
                SelectObject(hdc, hOldPen);
                DeleteObject(hPen);
                ReleaseDC(dsk,hdc);
                Sleep(3);
            }
        }
        public static void GDI3()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                BitBlt(hdc, RandX(), 0, 10, ScrHeight, hdc, RandX(),0,TernaryRasterOperations.SRCCOPY);
                BitBlt(hdc, 0, RandY(), ScrWidth, 10, hdc, 0, RandY(), TernaryRasterOperations.SRCCOPY);
                ReleaseDC(dsk, hdc);
                Sleep(3);
            }
        }
        public static void GDI4()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                BitBlt(hdc, 0, 0, ScrWidth, ScrHeight / 4, hdc, Randint(-1, 1), Randint(-1, 1), TernaryRasterOperations.SRCINVERT);
                BitBlt(hdc, 0, 0, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.NOTSRCCOPY);
                ReleaseDC(dsk, hdc);
                Sleep(3);
            }
        }
        public static void GDI5()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                IntPtr hMemDC = CreateCompatibleDC(hdc);
                IntPtr hBitMap = CreateCompatibleBitmap(hdc, ScrWidth, ScrHeight);
                IntPtr hOldBitmap = SelectObject(hMemDC, hBitMap);
                BitBlt(hMemDC, 0, 0, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                RotateDC(hdc, Randint(1, 3), new POINT() { x = ScrWidthHalf, y = ScrHeightHalf });
                _BLENDFUNCTION bLENDFUNCTION;
                bLENDFUNCTION.BlendOp = 0;
                bLENDFUNCTION.BlendFlags = 0;
                bLENDFUNCTION.SourceConstantAlpha = 128;
                bLENDFUNCTION.AlphaFormat = 0;
                AlphaBlend(hdc, 0, 0, ScrWidth, ScrHeight, hMemDC, 0, 0, ScrWidth, ScrHeight, bLENDFUNCTION);
                SelectObject(hMemDC, hOldBitmap);
                DeleteObject(hBitMap);
                DeleteDC(hMemDC);
                ReleaseDC(dsk, hdc);
                Sleep(1);
            }
        }
        public static void GDI6()
        {
            int w = 100;
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                IntPtr hRgn = CreateEllipticRgn(w, w, ScrHeight - w, ScrHeight - w);
                IntPtr hOldRgn = (IntPtr)SelectClipRgn(hdc, hRgn);
                BitBlt(hdc, 0, Randint(-3, 3), ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                RedScreen();
                IntPtr hIcon = LoadIcon(IntPtr.Zero, Randint(32512, 32513));
                if (Randint(0,1) == 0)
                {
                    DrawIconEx(hdc, RandX(), RandY(), hIcon, Randint(50, 100), Randint(50, 100), 0, IntPtr.Zero, 0x3);
                }
                else
                {
                    DrawIconEx(hdc, RandX(), RandY(), hIcon, Randint(50, 100), Randint(50, 100), 0, IntPtr.Zero, 0x1);
                }
                SelectClipRgn(hdc, hOldRgn);
                DeleteObject(hRgn);
                ReleaseDC(dsk, hdc);
                Sleep(1);
            }
        }
        public static void GDI7()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                int x = RandX();
                int y = RandY();
                BitBlt(hdc, x + Randint(-2, 2), y + Randint(-2, 2), Randint(0, 800), Randint(0, 600), hdc, x, y, TernaryRasterOperations.SRCCOPY);
                ReleaseDC(dsk, hdc);
                Sleep(3);
            }
        }
        public static void GDI8()
        {
            int h1 = 1;
            int h = 100;
            for (int _ = 0;_ < 2; _++)
            {
                for (int y = 0;y < ScrHeight; y+=h1)
                {
                    IntPtr hdc = GetWindowDC(dsk);
                    BitBlt(
                        hdc,
                        (int)(Math.Sin(y * Math.PI / 180) * 40),
                        y,
                        ScrWidth,
                        h,
                        hdc,
                        0,
                        y,
                        TernaryRasterOperations.SRCCOPY
                        );
                    ReleaseDC(dsk, hdc);
                    Sleep(3);
                }
            }
        }
        public static void GDI9()
        {
            int a = 10;
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                IntPtr hBrush = CreateSolidBrush((uint)RandColor());
                IntPtr hOldBrush = SelectObject(hdc, hBrush);
                PatBlt(hdc, 0, 0, ScrWidth, ScrHeight, TernaryRasterOperations.PATINVERT);
                StretchBlt(hdc, -a, -a, ScrWidth + a * 2, ScrHeight + 2 * a, hdc, 0, 0, ScrWidth, ScrHeight, TernaryRasterOperations.SRCPAINT);
                hBrush = CreateSolidBrush((uint)RandColor());
                hOldBrush = SelectObject(hdc, hBrush);
                RoundRect(hdc, RandX(), RandY(), RandX(), RandY(), Randint(0, 100), Randint(0, 100));
                SelectObject(hdc, hOldBrush);
                DeleteObject(hBrush);
                if (Randint(0,5) == 0)
                {
                    IntPtr hMemDC = CreateCompatibleDC(hdc);//使用内存DC，这样可以防止刷新
                    IntPtr hBitMap = CreateCompatibleBitmap(hdc, ScrWidth, ScrHeight);
                    IntPtr hOldBitMap = SelectObject(hMemDC, hBitMap);
                    BitBlt(hMemDC, 0, 0, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                    for (int x = 0;x < ScrWidth; x += 100)
                    {
                        BitBlt(hMemDC, x, 0, 10, ScrHeight, hdc, x, 0, TernaryRasterOperations.NOTSRCCOPY);
                    }
                    BitBlt(hdc, 0, 0, ScrWidth, ScrHeight, hMemDC, 0, 0, TernaryRasterOperations.SRCCOPY);
                    SelectObject(hMemDC, hOldBitMap);
                    DeleteObject(hBitMap);
                    DeleteDC(hMemDC);
                }
                ReleaseDC(dsk, hdc);
                Sleep(500);
            }
        }
        public static void GDI10()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                IntPtr hMemDC = CreateCompatibleDC(hdc);
                IntPtr hBitMap = CreateCompatibleBitmap(hdc, ScrWidth, ScrHeight);
                IntPtr hOldBitMap = SelectObject(hMemDC, hBitMap);
                BitBlt(hMemDC, 0, 0, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                List<POINT> pt = new List<POINT>//直角三角形(屏幕的一半)
                {
                    new POINT() { x = 0, y = 0 },//左上角
                    new POINT() { x = 0, y = ScrHeight },//左下角
                    new POINT() { x = ScrWidth, y = ScrHeight },//右下角
                };
                IntPtr hRgn = CreatePolygonRgn(pt.ToArray(), pt.Count, 2);
                IntPtr hOldRgn = (IntPtr)SelectClipRgn(hdc, hRgn);
                StretchBlt(hdc, 0, 0, ScrWidthHalf, ScrHeightHalf, hMemDC, 0, 0, ScrWidth, ScrHeight, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, ScrHeightHalf, ScrWidthHalf, ScrHeightHalf, hMemDC, 0, 0, ScrWidth, ScrHeight, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, ScrWidthHalf, ScrHeightHalf, ScrWidthHalf, ScrHeightHalf, hMemDC, 0, 0, ScrWidth, ScrHeight, TernaryRasterOperations.SRCCOPY);
                SelectClipRgn(hdc, hOldRgn);
                DeleteObject(hRgn);
                SelectObject(hMemDC, hOldBitMap);
                DeleteObject(hBitMap);
                DeleteDC(hMemDC);
                ReleaseDC(dsk, hdc);
                Sleep(10);
            }
        }
        public static void GDI11()
        {
            int w = 18;
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                IntPtr hBrush = CreateSolidBrush((uint)RandColor());
                IntPtr hOldBrush = SelectObject(hdc, hBrush);
                PatBlt(hdc, 0, 0, ScrWidth, ScrHeight, TernaryRasterOperations.PATINVERT);
                SelectObject(hdc, hOldBrush);
                DeleteObject(hBrush);
                IntPtr hMemDC = CreateCompatibleDC(hdc);
                IntPtr hBitMap = CreateCompatibleBitmap(hdc, ScrWidth, ScrHeight);
                IntPtr hOldBitMap = SelectObject(hMemDC, hBitMap);
                BitBlt(hMemDC, 0, 0, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                BitBlt(hdc, -w, -w, ScrWidth, ScrHeight, hMemDC, 0, 0, TernaryRasterOperations.SRCCOPY);
                BitBlt(hdc, ScrWidth - w, -w, ScrWidth, ScrHeight, hMemDC, 0, 0, TernaryRasterOperations.SRCCOPY);
                BitBlt(hdc, -w, ScrHeight - w, ScrWidth, ScrHeight, hMemDC, 0, 0, TernaryRasterOperations.SRCCOPY);
                BitBlt(hdc, ScrWidth - w, ScrHeight - w, ScrWidth, ScrHeight, hMemDC, 0, 0, TernaryRasterOperations.SRCCOPY);
                SelectObject(hMemDC, hOldBitMap);
                DeleteObject(hBitMap);
                DeleteDC(hMemDC);
                SetTextColor(hdc, RandColor());
                SetBkColor(hdc,RandColor());
                IntPtr hFont = CreateFont(Randint(ScrHeight / 10, ScrHeight / 5), 0, 0, 0, 700, 0, 0, 0, 134, 0, 0, 4, 0, "Segoe UI");
                IntPtr hOldFont = SelectObject(hdc, hFont);
                string text = "I think you are very panicked.";
                TextOut(hdc, (int)(RandX() / 2), RandY(), text, text.Length);
                SelectObject(hdc, hOldFont);
                DeleteObject(hFont);
                ReleaseDC(dsk, hdc);
                Sleep(5);
            }
        }
        public static void GDI12()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                SetROP2(hdc, 7);
                IntPtr hBrush = CreateSolidBrush((uint)RandColor());
                IntPtr hOldBrush = SelectObject(hdc, hBrush);
                Ellipse(hdc, RandX(), RandY(), ScrWidthHalf, ScrHeightHalf);
                SelectObject(hdc, hOldBrush);
                DeleteObject(hBrush);
                ReleaseDC(dsk, hdc);
                Sleep(10);
            }
        }
        public static void GDI13()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                StretchBlt(hdc, 0, 0, ScrWidth, ScrHeight, hdc, ScrWidth, 0, -ScrWidth, ScrHeight, TernaryRasterOperations.SRCCOPY);
                ReleaseDC(dsk, hdc);
                RedScreen();
                Sleep(10);
            }
        }
        public static void GDI14()
        {
            int w = 3;
            int h = 2;
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                IntPtr hMemDC = CreateCompatibleDC(hdc);
                IntPtr hBitMap = CreateCompatibleBitmap(hdc, ScrWidth, ScrHeight);
                IntPtr hOldBitMap = SelectObject(hMemDC, hBitMap);
                BitBlt(hMemDC, 0, 0, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                for (int y = 0; y < ScrHeight; y+=h)
                {
                    BitBlt(hMemDC, Randint(-w, w), y, ScrWidth, h, hMemDC, 0, y, TernaryRasterOperations.SRCCOPY);
                }
                BitBlt(hdc, 0, 0, ScrWidth, ScrHeight, hMemDC, 0, 0, TernaryRasterOperations.SRCCOPY);
                SelectObject(hMemDC, hOldBitMap);
                DeleteObject(hBitMap);
                DeleteDC(hMemDC);
                ReleaseDC(dsk, hdc);
                Sleep(10);
            }
        }
        public static void GDI15()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                IntPtr hMemDC = CreateCompatibleDC(hdc);
                IntPtr hBitMap = CreateCompatibleBitmap(hdc, ScrWidth, ScrHeight);
                IntPtr hOldBitMap = SelectObject(hMemDC, hBitMap);
                IntPtr hMemDC2 = CreateCompatibleDC(hdc);//备份
                IntPtr hBitMap2 = CreateCompatibleBitmap(hdc, ScrWidth, ScrHeight);
                IntPtr hOldBitMap2 = SelectObject(hMemDC2, hBitMap2);
                BitBlt(hMemDC, 0, 0, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                BitBlt(hMemDC2, 0, 0, ScrWidth, ScrHeight, hMemDC, 0, 0, TernaryRasterOperations.SRCCOPY);
                for (int i = 0;i < ScrHeight; i++)
                {
                    int value = (int)(Math.Sin(i * Math.PI / ScrHeight) * 200);
                    BitBlt(hMemDC, value, i, ScrWidth, 1, hMemDC2, 0, i, TernaryRasterOperations.SRCCOPY);
                    BitBlt(hMemDC, -ScrWidth + value, i, ScrWidth, 1, hMemDC2, 0, i, TernaryRasterOperations.SRCCOPY);
                }
                BitBlt(hdc, 0, 0, ScrWidth, ScrHeight, hMemDC, 0, 0, TernaryRasterOperations.SRCCOPY);
                SelectObject(hMemDC2, hOldBitMap2);
                DeleteObject(hBitMap2);
                DeleteDC(hMemDC2);
                SelectObject(hMemDC, hOldBitMap);
                DeleteObject(hBitMap);
                DeleteDC(hMemDC);
                ReleaseDC(dsk, hdc);
                Sleep(1000);
            }
        }
        public static void GDI16()
        {
            int w = 150;
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(20))
            {
                IntPtr hdc = GetWindowDC(dsk);
                IntPtr hMemDC = CreateCompatibleDC(hdc);
                IntPtr hBitMap = CreateCompatibleBitmap(hdc, ScrWidth, ScrHeight);
                IntPtr hOldBitMap = SelectObject(hMemDC, hBitMap);
                BitBlt(hMemDC, 0, 0, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                BitBlt(hdc, 0, -w, ScrWidth, ScrHeight, hMemDC, 0, 0, TernaryRasterOperations.SRCCOPY);
                BitBlt(hdc, 0, ScrHeight - w, ScrWidth, ScrHeight, hMemDC, 0, 0, TernaryRasterOperations.SRCCOPY);
                SelectObject(hMemDC, hOldBitMap);
                DeleteObject(hBitMap);
                DeleteDC(hMemDC);
                IntPtr hIcon = LoadIcon(IntPtr.Zero, Randint(IDI_APPLICATION, IDI_WINLOGO));
                for (int _ = 0;_<10;_++)
                    DrawIcon(hdc, RandX(), RandY(), hIcon);
                IntPtr hCursor = LoadCursor(IntPtr.Zero, Randint(IDC_ARROW, 32633));
                for (int _ = 0; _ < 10; _++)
                    DrawIcon(hdc, RandX(), RandY(), hCursor);
                BitBlt(hdc, 0, 0, ScrWidth, ScrHeight, hdc, 0, 0, TernaryRasterOperations.NOTSRCCOPY);
                ReleaseDC(dsk, hdc);
                Sleep(100);
            }
        }
    }
}
