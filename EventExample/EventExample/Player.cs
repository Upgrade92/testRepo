using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    public class Player
    {
        private int health;

        public string Name { get; set; }
        public int Health 
        { 
            get { return health; } 
            set 
            {
                this.health = value;
                this.OnHealthChanged?.Invoke(this, this.health);
            } 
        }
        public event EventHandler<int> OnHealthChanged;
    }
}
