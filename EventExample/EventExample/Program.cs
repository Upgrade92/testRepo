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
            player.Health = 200;

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
