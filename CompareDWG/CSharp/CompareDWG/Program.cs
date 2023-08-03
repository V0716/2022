using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // devDept.LicenseManager.Unlock(""); // For more details see 'Product Activation' topic in the documentation.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CustomSynchronizationContext.Install(); Application.Run(new Form1());
        }
    }
}