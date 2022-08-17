using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDialog_Zach
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string content;
            string pathfile;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Text File";
            ofd.Filter = "TXT files|*.txt";
            ofd.InitialDirectory = @"C:\";
          
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show(ofd.FileName.ToString());
                pathfile = ofd.FileName;
            }
            MessageBox.Show(ofd.FileName.ToString());

            using (StreamReader sr = new StreamReader(ofd.FileName))
            {
                content = sr.ReadToEnd();
                Console.WriteLine(content);
                sr.Dispose();
                sr.Close();
            }

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DefaultOutputName.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(save.OpenFile()))
                {
                    writer.WriteLine(content);
                    writer.WriteLine("\n\n This is additional!");

                    writer.Dispose();
                    writer.Close();
                }
            }             
            Console.ReadLine();
        }
    }
}
