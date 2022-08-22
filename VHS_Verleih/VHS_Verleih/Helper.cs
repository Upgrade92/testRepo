using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VHS_Verleih
{
    internal class Helper
    {
        public static void PrintMenu()
        {
            Console.WriteLine("\n Welcome to the VHS-Store!");
            Console.WriteLine("___________________________");
            Console.WriteLine(" [1] for borrowing         ");
            Console.WriteLine(" [2] for returning         ");
            Console.WriteLine(" [3] for browsing          ");
            Console.WriteLine(" [4] for export Data       ");
            Console.WriteLine("");
        }

        public static void MakeChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please key in the VHS-Index you want to borrow");
                    VHS.BorrowByIndex(GetIntInput());
                    break;

                case 2:
                    Console.WriteLine("Please key in the VHS-Index you want to return");
                    VHS.ReturnByIndex(GetIntInput());
                    break;

                case 3:
                    VHS.ListAll();
                    break;
                case 4:
                    saveFile();
                    break;
            }
        }

        public static int GetIntInput()
        {
            int input=0;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException e)
            {
                Console.WriteLine("only numbers please");
            }
            return input;
        }

        public static void SaveFile()
        {
            StringBuilder content = new StringBuilder();

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "VHSList.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(save.OpenFile()))
                {
                    writer.WriteLine($"Index: \t Title:{null,-40}  Price:{null,-5} \t Genre:{null,-15} Borrowed?{null,-10}");
                    for (int i = 0; i < 53; i++) { writer.Write("__"); };
                    foreach (VHS vhs in VHS.collection)
                    {
                        content.Append($"\n [{VHS.collection.IndexOf(vhs) + 1}] \t {vhs.Title,-40} \t {vhs.Price,-5} \t\t {vhs.Genre,-10} \t\t{vhs.Borrowed,-10}");
                    }
                    writer.WriteLine(content);

                    writer.Dispose();
                    writer.Close();
                }
            }
        }
    }
}