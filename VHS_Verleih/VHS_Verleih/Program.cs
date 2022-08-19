using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS_Verleih
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VHS.AddItems();
            //VHS.ListAll();

            while (true)
            {
                Helper.PrintMenu();
                Helper.MakeChoice(Helper.GetIntInput());
                
            }
            Console.ReadLine();
        }
    }
}
