using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD_MapEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new MD_MapEditor());
            MD_MapEditor Form1 = new MD_MapEditor();
            Form1.Show();

            Form1.Initialize();

            while( Form1.bRunning )
            {
                Form1.Update();
                Form1.Render();

                Application.DoEvents();
            }

            Form1.Terminate();

        }
    }
}
