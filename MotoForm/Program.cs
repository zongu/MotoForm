﻿
namespace MotoForm
{
    using System;
    using System.Windows.Forms;
    using MotoForm.App;

    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Applibs.AutoFacConfig.RegisterContainer();
            if (new Login().ShowDialog() == DialogResult.OK)
            {
                Application.Run(new BaseForm());
            }
        }
    }
}
