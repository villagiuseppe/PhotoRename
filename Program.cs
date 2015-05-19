using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;



namespace PhotoRename
{
    class Program
    {
        //we init this once so that if the function is repeatedly called
        //it isn't stressing the garbage man
        private static Regex r = new Regex(":");


        //retrieves the datetime WITHOUT loading the whole image
        public static DateTime GetDateTakenFromImage(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image myImage = Image.FromStream(fs, false, false))
            {

                DateTime date = DateTime.MinValue;
                foreach (PropertyItem propItem in myImage.PropertyItems)
                {
                    if (propItem.Id == 36867)
                    {
                        string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                        date = DateTime.Parse(dateTaken); ;
                    }
                }

                return date;
            }
        }
        //MAIN
        static void Main(string[] args)
        {
            string path = ConfigurationManager.AppSettings["DirSource"];

            foreach (string item in System.IO.Directory.GetFiles(path, "*.*"))
            {
                try
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(item);

                    DateTime dateTime = GetDateTakenFromImage(file.FullName);

                    if (dateTime == DateTime.MinValue)
                        continue;

                    string newName = string.Format("{0:yyyyMMdd_HHmmss}{1}", dateTime, file.Extension);


                    if (file.Name == newName)
                        continue;

                    Console.WriteLine(file.Name + "-->" + newName);

                    string newFilePath = System.IO.Path.Combine(path, newName);
                    file.MoveTo(newFilePath);


                }
                catch
                {

                }
            }
            Console.WriteLine("Press Any Key to end");
            Console.ReadLine();
        }
    }
}
