using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_MonsterkampfSimulator
{
    internal class Monster
    {
        public string Race { get; set; }
        public float Health { get; set; }
        public float AttackPoints { get; set; }
        public float DefensePoints { get; set; }
        public float AttackSpeed { get; set; }

        public Monster(string race, float health, float attackPoints, float defensePoints, float attackSpeed)
        {
            this.Race = race;
            this.Health = health;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.AttackSpeed = attackSpeed;
        }

        public virtual void TakeDamage(Monster other)
        {
            float damage = 0;
            //Errechne den Schaden indem du die Verteidigungspunkte von den Angriffspunkten des Angreifenden Monsters abziehst
            damage = other.AttackPoints - DefensePoints;
            if(damage > 0)
            {
                Health -= damage;
                if(Health < 0)
                {
                    Health = 0;
                }
            }
            
        }
        public virtual void Attack(Monster other)
        {
            
             other.TakeDamage(this);
           
        }
        public void ShowStats()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Race: " + Race);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + Health);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("AttackPoints: " + AttackPoints);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("DefensePoints: " + DefensePoints);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("AttackSpeed: " + AttackSpeed);
            Console.ForegroundColor = ConsoleColor.White;
        }        
        public void FindItem()
        {
            Random rnd = new Random();

            switch (rnd.Next(3))
            {
                //Waffe finden : Angriffspunkte erhöhen
                case 0:
                    AttackPoints += 3;
                    Console.WriteLine();
                    Console.WriteLine($"{Race} hat eine Waffe gefunden. Die Angriffspunkte werden um 3 erhöht");
                    break;
                //Armor finden : Verteidigung erhöhen
                case 1:
                    DefensePoints += 2;
                    Console.WriteLine();
                    Console.WriteLine($"{Race} hat eine Rüstung gefunden. Die Verteidigungspunkte werden um 2 erhöht");
                    break;
                //Heiltrank finden : Lebenspunkte erhöhen
                case 2:
                    Health += 10;
                    Console.WriteLine();
                    Console.WriteLine($"{Race} hat einen Heiltrank gefunden. Die Lebenspunkte werden um 10 erhöht");
                    break;
            }
        }
    }
}
