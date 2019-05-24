using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace PhotoRename.ClassLib
{
    public class Utils
    {

        //we init this once so that if the function is repeatedly called
        //it isn't stressing the garbage man
        private static Regex r = new Regex(":");

        public Utils()
        {

        }
        
        public static string GetFileNameTakenFromImage(string fullPath, Int32 offset)
        {
            return string.Format("{0:yyyyMMdd_HHmmss}",GetDateTakenFromImage(fullPath, offset));
        }

        //retrieves the datetime WITHOUT loading the whole image
        public static DateTime GetDateTakenFromImage(string fullPath, Int32 offset)
        {
            if (string.IsNullOrEmpty(fullPath))
            {
                throw new ArgumentException("Mandatory", nameof(fullPath));
            }
            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            using (Image img = Image.FromStream(fs, false, false))
            {
                DateTime date = DateTime.MinValue;
                //Date Time Original
                PropertyItem propertyItem = img.GetPropertyItem(0x9003);                
                if (propertyItem != null)
                {
                    string dateTaken = r.Replace(Encoding.UTF8.GetString(propertyItem.Value), "-", 2);
                    date = DateTime.Parse(dateTaken).AddHours(offset);
                }
                return date;
            }
        }  
    }
}
