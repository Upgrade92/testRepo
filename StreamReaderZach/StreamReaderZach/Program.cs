using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamReaderZach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\\Users\\14632\\Desktop\\testtext.txt");

            using (StreamWriter sw = new StreamWriter(@"C:\\Users\\14632\\Desktop\\testtext4.txt"))
            {
                sw.Write(sr.ReadToEnd());
                sw.WriteLine("\nThis is additional");
            }

            MessageBox.Show("Done!");
        }
    }
}
