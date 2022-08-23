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
            Console.WriteLine("<------------------------->");
            Console.WriteLine(" | [1] Borrow              ");
            Console.WriteLine(" | [2] Return              ");
            if (VHS.sorted == false) 
            {
                Console.WriteLine(" | [3] Sort by Price       ");
            }
            else 
            { 
            Console.WriteLine(" | [3] Sort by Index       "); 
            }
            Console.WriteLine(" |                         ");
            Console.WriteLine(" | [9] export Data         ");
            Console.WriteLine(" | [0] EXIT \n             ");
        }

        public static void MakeChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please key in the VHS-Index you want to borrow");
                    VHS.BorrowByIndex(GetIntInput()-1);
                    break;

                case 2:
                    Console.WriteLine("Please key in the VHS-Index you want to return");
                    VHS.ReturnByIndex(GetIntInput()-1);
                    break;

                case 3:
                    if(VHS.sorted == false)
                    {
                        VHS.sorted = true;
                    }
                    else
                    {
                        VHS.sorted = false;
                    }
                    break;

                case 9:
                    string status;
                    if (VHS.sorted == true)
                    {
                        status = SaveFile(VHS.SortByPrice());
                    }
                    else
                    {
                        status = SaveFile(VHS.collection);
                    }
                    Console.WriteLine(status);
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("no valid choice!");
                    break;
            }
        }

        public static void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
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

        public static string SaveFile(List<VHS> exportList)
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
                    for (int i = 0; i < exportList.Count;i++)
                    {
                        content.Append($"\n [{VHS.collection.IndexOf(exportList[i])}] \t {exportList[i].Title,-40} \t {exportList[i].Price,-5} \t\t {exportList[i].Genre,-10} \t\t{exportList[i].Borrowed,-10}");
                    }
                    writer.WriteLine(content);
                    

                    writer.Dispose();
                    writer.Close();
                }
                return "successfully saved!";
            }
            else
            {
                return "saving failed!";
            }
        }
    }
}