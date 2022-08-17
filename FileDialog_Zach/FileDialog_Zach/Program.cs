﻿using System;
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
                Console.WriteLine(sr.ReadToEnd());

                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "DefaultOutputName.txt";
                save.Filter = "Text File | *.txt";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(save.OpenFile());

                    writer.Write(sr.ReadToEnd());
                    writer.Write("\n\n This is additional!");
                    writer.Dispose();
                    writer.Close();

                }
                sr.Dispose();
                sr.Close();
            }

            Console.ReadLine();
        }
    }
}