using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace PhotoRename
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Esegue applicazione
            Application.Run(new PhotoRename());
        }
    }   
}
