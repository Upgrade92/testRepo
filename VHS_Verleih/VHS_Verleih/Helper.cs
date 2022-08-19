using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("");
        }

        public static void MakeChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please key in the VHS-Index you want to borrow");
                    VHS.BorrowByIndex(Convert.ToInt32(Console.ReadLine()));
                    break;

                case 2:
                    Console.WriteLine("Please key in the VHS-Index you want to return");
                    VHS.ReturnByIndex(Convert.ToInt32(Console.ReadLine()));
                    break;

                case 3:
                    VHS.ListAll();
                    break;
            }
        }


    }
}
