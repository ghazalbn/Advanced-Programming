using System;
using System.IO;

namespace AW12_cs
{
    public class Fighter
    {
        public string Name;
        public int Health;
        private event Action<Fighter> endGAME;
        public Fighter(string name, int health)
        {
            (Health, Name) = (health, name);
            onNoHealth();
        }
        private void onNoHealth()
        {
            endGAME += f1 => System.Console.WriteLine($"{this.Name} Won {f1.Name}!");    
        }
        
        public void Attack(Fighter other)
        {
            Random r = new Random();
            int defence = r.Next(2);
            if(defence == 1)
            {

                other.Health -= r.Next(1,11);
            }
            if(other.Health <= 0)
            {
                endGAME(other);
                Environment.Exit(0);
            }
        }
    }
}
