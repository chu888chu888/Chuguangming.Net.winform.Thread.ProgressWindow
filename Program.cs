using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProgressWindow
{
    public class Program
    {
        /// <summary>
        /// Mains this instance.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.Run(new ProgressWindowTest());
        }
    }
}
