using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS_Verleih
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            VHS.AddItems();
            while (true)
            {
                if (VHS.sorted == false)
                {
                    VHS.ListSpecific(VHS.collection);
                }
                else
                {
                    VHS.ListSpecific(VHS.SortByPrice());
                }
                Helper.PrintMenu();
                Helper.MakeChoice(Helper.GetIntInput());
                Helper.PrintMessage("\nPress any key to refresh...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}