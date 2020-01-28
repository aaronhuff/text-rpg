using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Weapon
    {
        Random rnd3 = new Random();
        private int damage;
        private string name;

        private string[] type = new string[] { "Sword", "Axe", "Spear" };
        private string[] effect = new string[] { "Poison", "Fire", "Ice" };
        private string[] originator = new string[] { "Kyle's", "Stu's", "Max's" };

        public Weapon(int CurrentLevel)
        {
            damage = (rnd3.Next(0, 10) * CurrentLevel) + 5;
            name = originator[rnd3.Next(0, 3)] + " " + effect[rnd3.Next(0, 3)] + " " + type[rnd3.Next(0, 3)];
            Console.WriteLine("You found " + name + " with a weapon damage of " + damage);
            Console.WriteLine();
        }

        public string Name()
        {
            return name;
        }

        public int Damage()
        {
            return damage;
        }
    }
}
