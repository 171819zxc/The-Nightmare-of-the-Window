using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static The_Nightmare_of_the_Window.function;

namespace The_Nightmare_of_the_Window
{
    public partial class Background : Form
    {
        public static Background Instance;
        public static bool close = false;
        public void Creating()
        {
            try
            {
                for (double opacity = 0; opacity <= 0.75; opacity += 0.01)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Opacity = opacity;
                    }
                    ));
                    Sleep(1);
                }
            }
            catch (Exception ex) { }
        }
        public void Close_this()
        {
            this.Invoke(new Action(() => 
            {
                close = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            ));
        }
        public Background()
        {
            Instance = this;
            InitializeComponent();
        }

        private void Background_Load(object sender, EventArgs e)
        {
            Left = 0;Top = 0;
            Width = function.ScrWidth;Height = function.ScrHeight;
            Warning w = new Warning();
            w.Show(this);
            NewThread(Creating);
        }

        private void Background_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!close)
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = false;
        }
    }
}
