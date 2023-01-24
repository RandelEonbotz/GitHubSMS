
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using testNo3.FORMS;
using testNo3.FORMS.MainForm;

namespace testNo3
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>s
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ModuleTemplate1());
        }
    }
}
