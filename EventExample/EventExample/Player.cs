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
                this.OnHealthChanged?.Invoke(this, this.health);  // Kann OnHealthChanged auch null sein? 
            } 
        }
        public event EventHandler<int> OnHealthChanged;
    }
}

// Eventsbeispiel von der Microsoftseite od.?! 
