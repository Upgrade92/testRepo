using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp_Zach
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int counter = 0; 
            int index = 0;
            

            string text = File.ReadAllText(@"C:\\Users\\14632\\Desktop\\testtext.txt");

            while (index < text.Length && char.IsWhiteSpace(text[index]))
                index++;

            while (index < text.Length)
            {
                while (index < text.Length && !char.IsWhiteSpace(text[index]))
                    index++;

                counter++;

                while (index < text.Length && char.IsWhiteSpace(text[index]))
                    index++;
            }

            Console.WriteLine("Number of words: " + counter);
            Console.ReadKey();

          //File.WriteAllLines(@"C:\\Users\\14632\\Desktop\\testtext2.txt",text);


        }
    }
}
