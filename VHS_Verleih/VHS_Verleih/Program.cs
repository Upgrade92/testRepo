using System;

namespace VHS_Verleih
{
    internal class Program
    {

        public delegate void OnEscPressed(object sender);
        [STAThread]
        static void Main(string[] args)
        {

            VHS.AddItems();
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);


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
        protected static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Event fired!");
            Console.WriteLine("Colsing in 3 seconds");
            System.Threading.Thread.Sleep(3000);


            Environment.Exit(0);
        }
    }
}