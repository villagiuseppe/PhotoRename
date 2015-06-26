using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PhotoRename
{
    public partial class PhotoRename : Form
    {
        //we init this once so that if the function is repeatedly called
        //it isn't stressing the garbage man
        private static Regex r = new Regex(":");

        public PhotoRename()
        {
            InitializeComponent();
        }

        private void btn_Source_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = txt_Source.Text;
            fbd.ShowDialog();

            if (!string.IsNullOrEmpty(fbd.SelectedPath))
                txt_Source.Text = fbd.SelectedPath;
        }

        private void btn_Rename_Click(object sender, EventArgs e)
        {
            prg_Image.Visible = true;            
            prg_Image.Minimum = 0;
            prg_Image.Step = 1;
            try
            {
                string error = Check();
                if (error == string.Empty)
                {
                    prg_Image.Maximum = System.IO.Directory.GetFiles(txt_Source.Text, "*.*").Length;
                    string newName = string.Empty;
                    foreach (string fileName in System.IO.Directory.GetFiles(txt_Source.Text, "*.*"))
                    {
                        try
                        {
                            prg_Image.PerformStep();
                            System.IO.FileInfo file = new System.IO.FileInfo(fileName);

                            DateTime dateTime = GetDateTakenFromImage(file.FullName);

                            if (dateTime == DateTime.MinValue)
                                continue;

                            newName = string.Format("{0:yyyyMMdd_HHmmss}{1}", dateTime, file.Extension);


                            if (file.Name == newName)
                                continue;

                            Console.WriteLine(file.Name + "-->" + newName);

                            string newFilePath = System.IO.Path.Combine(txt_Source.Text, newName);
                            file.MoveTo(newFilePath);
                        }
                        catch(Exception exc)
                        {
                            string msg = string.Format("{0:yyyyMMdd HH:mm:ss} - {1}-->{2} : {3}{4}", DateTime.Now, fileName, newName, exc.Message, Environment.NewLine);
                            File.AppendAllText("LOG.txt", msg);
                        }

                    }
                    MessageBox.Show("Operazione completata", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show(error, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                prg_Image.Visible = false;            
            }
        }

        private string Check()
        {
             string ret = string.Empty;
            if (txt_Source.Text == string.Empty)
                ret += "Selezionare " + lbl_Source.Text + Environment.NewLine;
            if (ret == string.Empty && !Directory.Exists(txt_Source.Text))
                ret += txt_Source.Text + " inesistente " + Environment.NewLine;

            return ret;
        }
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

        private void PhotoRename_Load(object sender, EventArgs e)
        {
            prg_Image.Visible = false;
        }


        public string newfileName { get; set; }
    }
}
