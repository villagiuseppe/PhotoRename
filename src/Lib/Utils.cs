using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lib
{
    public class Utils
    {

        //we init this once so that if the function is repeatedly called
        //it isn't stressing the garbage man
        private static Regex r = new Regex(":");

        public Utils()
        {
        }

        //retrieves the datetime WITHOUT loading the whole image
        public static DateTime GetDateTakenFromImage(string path, Double offset)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Mandatory", nameof(path));
            }
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (Image myImage = Image.FromStream(fs, false, false))
            {
                DateTime date = DateTime.MinValue;
                //Date Time Original
                PropertyItem propertyItem = myImage.GetPropertyItem(0x9003);                
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
