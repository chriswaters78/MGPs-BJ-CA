using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BJ_CA
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // The INI, dealer probs files, results workbook and help file are all found relative to the
            // working directory, so run from the folder holding the executable.
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);

            ApplicationConfiguration.Initialize();
            // The forms were laid out for the .NET Framework default font.
            Application.SetDefaultFont(new Font("Microsoft Sans Serif", 8.25f));
            Application.Run(new BJCAMainForm());
        }
    }
}
