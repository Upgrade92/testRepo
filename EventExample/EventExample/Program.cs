using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EventExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var player = new Player
            {
                Name = "Bob",
                Health = 200
            };

            player.OnHealthChanged += PlayerOnHealthChanged;
          //  player.Health = 200; // <--  Eine erneute Zuweisung ist hier nicht nötig, da die Werte für Health bereits bei der der Objekterstellung zugewiesen wurden (Zeile 16)

            for(int i = 0; i < 10; i++)
            {
                player.Health -= 20;
            }
            Console.ReadLine();

        }
        private static void PlayerOnHealthChanged(object sender, int e)
        {
            var player = (Player)sender;
            Console.WriteLine(player.Health);
        }
        
        
    }
}

/* Gut gemacht, trauen Sie sich bitte mehr zu und schreiben Sie mit eigenen Ideen, ihre eigenen Programme.
   Das umschreiben von bereits besteheneden Beispielen entspricht sicher nicht dem was sie Können. ;-)
*/


