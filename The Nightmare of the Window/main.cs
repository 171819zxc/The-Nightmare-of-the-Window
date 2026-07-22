using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static The_Nightmare_of_the_Window.function;
using static The_Nightmare_of_the_Window.payloads;

namespace The_Nightmare_of_the_Window
{
    internal class main
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Background window = new Background();
            window.ShowDialog();
            if (!Variables.dontrun)
            {
                execute.Run();
            }
        }
    }
}
