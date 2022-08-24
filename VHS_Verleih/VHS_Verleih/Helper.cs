using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VHS_Verleih
{
    public delegate void WriteDelegate<Thing>(Thing thing);
    internal class Helper
    {
        static WriteDelegate<string> write = (msg) => PrintMessage(msg);     // Generic Delegate & Lambda Expression
        public static void PrintMenu()
        {
            write("\n Welcome to the VHS-Store!");
            write("<------------------------->");
            write(" | [1] Borrow              ");
            write(" | [2] Return              ");
            if (VHS.sorted == false) 
            {
                write(" | [3] Sort by Price   ");
            }
            else 
            {
                write(" | [3] Sort by Index   "); 
            }
            write(" |                         ");
            write(" | [9] export Data         ");
            write(" | [Crtl + C] EXIT \n      ");
        }

        public static void MakeChoice(int choice)
        {
            Button button = new Button();
            var key = choice;
            if (choice != 0)
            {
                try {
                    switch (choice)
                    {
                        case 1:
                            write("Please key in the VHS-Index you want to borrow");
                            VHS.BorrowByIndex(GetIntInput() - 1);
                            break;

                        case 2:
                            write("Please key in the VHS-Index you want to return");
                            VHS.ReturnByIndex(GetIntInput() - 1);
                            break;

                        case 3:
                            if (VHS.sorted == false)
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
                            write(status);
                            break;

                        default:
                            write("no valid choice!");
                            break;
                    }
                }
                finally
                {
                    write("\nPress any key to refresh...");
                }
            }
        }



        public static void PrintMessage<Thing>(Thing msg)           // Generic !!!
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
                write("only numbers please");
            }
            return input;
        }

        public static string TranslateBorrowed(bool borrowed)
        {
            if (borrowed == false)
            {
                return "in house";
            }
            else
            {
                return "not in house";
            }
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
                    for (int i = 0; i < 55; i++) { writer.Write("__"); };
                    for (int i = 0; i < exportList.Count;i++)
                    {
                        content.Append($"\n [{VHS.collection.IndexOf(exportList[i])+1}] \t {exportList[i].Title,-40} \t {exportList[i].Price,-5} " +
                                       $"\t\t {exportList[i].Genre,-10} \t\t{TranslateBorrowed(exportList[i].Borrowed),-10}");
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