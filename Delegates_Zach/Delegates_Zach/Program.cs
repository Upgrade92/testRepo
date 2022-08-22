using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*          Delegate in C#
 *  
 *          In C# werden häufig Delegates verwendet, um Rückrufe in der ereignisgesteuerten Programmierung zu implementieren. 
 *          Beispielsweise kann ein Delegat verwendet werden, um anzugeben, welche Methode aufgerufen werden soll, 
 *          wenn der Benutzer auf eine Schaltfläche klickt.
 *          Beim Aufruf des Delegaten werden alle an den Delegaten gebundenen Funktionen aufgerufen.
 *          Delegates erlauben dem Programmierer, mehrere Methoden vom Eintreten eine Ereignisses zu benachrichtigen.
 *          
 *          Man könnte sie auch als Methodenzeiger bezeichnen.
 *          
 *          
 *          Delegat Typen
 *          --------------
 *              Single Delegate
 *                  verweist auf eine Methode
 *                  
 *              Multicast Delegate 
 *                  verweist auf mehrerere Methoden
 *                  
 *              Generic Delegate
 *                  wenn mehrere Events ausgelöst werden sollen,
 *                  ermöglicht eine Bedingung mit where zu formulieren
 *          
*/


namespace Delegates_Zach
{
    internal class Program
    {
        public delegate string WriteMessage(string text);
        public delegate string WriteMessage2(string text1, string text2);

        static void Main(string[] args)
        {
            WriteMessage wm = new WriteMessage(Text);
            WriteMessage wm1 = new WriteMessage(Text);
            WriteMessage wm3 = new WriteMessage(Text);

            WriteMessage2 wm2 = new WriteMessage2(TextText);
            
            Console.WriteLine(wm("miau"));
            Console.WriteLine(wm2("wuff","wuff"));          // Single Delegate


            Console.WriteLine(wm3(wm("lol")+wm1("rofl")));  //Multicast Delegate

            Console.ReadKey();
        }
        static string Text(string text)
        {
            return text;
        }

        static string TextText(string text1,string text2)
        {
            return (text1 + text2);
        }
        
    }
}
