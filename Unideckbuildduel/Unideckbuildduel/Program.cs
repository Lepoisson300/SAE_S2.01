using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unideckbuildduel.View;

namespace Unideckbuildduel
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller.GetControler.NumbersOfTurnsToGo = 5;
            Window w = Window.GetWindow;
            Controller.GetControler.StartEverything();
            Application.Run(w);
        }
    }
}
