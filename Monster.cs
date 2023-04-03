using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Monster
    {
        int health;
        int damage;
        int bonusHp;
        int bonusDmg;
        int lvl;
        Random rnd = new Random();
        string[] monsterTypes = new String[] { "Goblin", "Troll", "Orc" };
        string type;

        public Monster(int CurrentLevel, int Type)
        {
            bonusHp = rnd.Next(0, CurrentLevel * 150);
            bonusDmg = rnd.Next(0, CurrentLevel * 15);
            health = 250 + (CurrentLevel * 100) + bonusHp;
            damage = (CurrentLevel * 15) + bonusDmg;
            type = monsterTypes[Type];
            lvl = CurrentLevel;
        }

        public void Attacked(int playerDmg)
        {
            health -= playerDmg;
            if (health > 0)
                Console.WriteLine("The level {0} {1} has {2} health remaining.", lvl, type, health);
            else
                Console.WriteLine("The {0} has been killed!", type);
        }

        public int Attack(int heroArmor)
        {
            int dmgMultiplier = rnd.Next(0, 10);
            //Console.WriteLine("Multiplier {0}", dmgMultiplier);

            if (((damage + dmgMultiplier) - heroArmor) > 0)
            {
                Console.WriteLine("The level {0} {1} attacks for {2} damage.", lvl, type, (damage + dmgMultiplier) - heroArmor);
                return (damage + dmgMultiplier) - heroArmor;
            }
            else
            {
                Console.WriteLine("The level {0} {1} attacks but your armor blocks it!", lvl, type);
                return 0;
            }
            // return damage done
        }

        public bool Alive()
        {
            return (health > 0) ? true : false;
        }

        public string Type()
        {
            return type;
        }

        public int Level()
        {
            return lvl;
        }

        public int Damage()
        {
            return damage;
        }

        public int HP()
        {
            return health;
        }
    }
}
