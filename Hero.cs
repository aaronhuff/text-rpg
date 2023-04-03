using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Hero
    {
        string name;
        int currentHealth = 1200;
        int maxHealth = 1200;
        int strength = 10;
        string helmet = "None";
        int helmetArmor = 0;
        string boots = "None";
        int bootsArmor = 0;
        string chestplate = "None";
        int chestArmor = 0;
        int weaponDamage = 0;
        string weaponName = "None";
        int exp = 0;
        int level = 1;
        Random rnd5 = new Random();
        int results = 0;

        public Hero(string Name)
        {
            name = Name;
        }

        public void status()
        {
            Console.WriteLine(
                "Hero: " + name + "\n"
                + "Level: " + level + "\n"
                + "Exp: " + exp + "\n"
                + "\n"
                + "Weapon: " + weaponName + " (" + weaponDamage + ")\n"
                + "Strength: " + strength + "\n"
                + "Attack Damage: " + (weaponDamage + strength) + "\n"
                + "\n"
                + "Armor\n"
                + "============\n"
                + "Helm: " + helmet + " (" + helmetArmor + ")\n"
                + "Chest: " + chestplate + " (" + chestArmor + ")\n"
                + "Boots: " + boots + " (" + bootsArmor + ")\n"
                + "Total Armor Defense: " + (helmetArmor + chestArmor + bootsArmor) + "\n"
                );
        }

        public void levelUp()
        {
            maxHealth += 100;
            currentHealth = maxHealth;
            strength += 5;
            exp = 0;
            level++;

            Console.WriteLine("Congratulations, you have leveled up!\n");
            status();
        }

        public int currentLevel()
        {
            return level;
        }

        public void Attacked(int monsterDmg)
        {
            //Console.WriteLine("Test ATK {0}", monsterDmg);
            //Console.WriteLine("Test HP {0}", currentHealth);

            if (monsterDmg > 0)
            {
                currentHealth -= monsterDmg;
                if (currentHealth > 0)
                    Console.WriteLine("You have {0} health remaining.", currentHealth);
                else
                    Console.WriteLine("You have died!");
            }
            else
            {
                Console.WriteLine("You have {0} health remaining.", currentHealth);
            }
        }

        public int Attack()
        {
            int dmgMultiplier = rnd5.Next(0, 10);
            //Console.WriteLine("Multiplier {0}", dmgMultiplier);

            Console.WriteLine("{0} attacks for {1} damage.", name, weaponDamage + strength + dmgMultiplier);
            return weaponDamage + strength + dmgMultiplier;
            // return damage done
        }

        public bool Alive()
        {
            return (currentHealth > 0) ? true : false;
        }

        public void winBattle()
        {
            currentHealth = maxHealth;
            exp += 100;
            results = rnd5.Next(0, 6);
            Console.WriteLine();

            if (results == 2)
            {
                Console.WriteLine("Congratulations, you found loot on the monster!");
                Armor armorLoot = new Armor(level);
                status();
                Console.WriteLine("Would you like to take \"{0}\"? (Armor: {1}) y/n \n", armorLoot.Name(), armorLoot.Value());

                char accept = Console.ReadKey().KeyChar;
                Console.Clear();

                if (accept == 'y')
                {
                    if (armorLoot.Slot() == "Chestplate") { chestplate = armorLoot.Name(); chestArmor = armorLoot.Value(); }
                    else if (armorLoot.Slot() == "Helm") { helmet = armorLoot.Name(); helmetArmor = armorLoot.Value(); }
                    else if (armorLoot.Slot() == "Boots") { boots = armorLoot.Name(); bootsArmor = armorLoot.Value(); }

                    Console.WriteLine("You have equiped the item!");
                    Console.WriteLine();
                    status();
                }
            }
            else if (results == 3)
            {
                Console.WriteLine("Congratulations, you found loot on the monster!");
                Console.WriteLine();

                Weapon weaponLoot = new Weapon(level);
                status();
                Console.WriteLine("Would you like to take \"{0}\"? (Damage: {1}) y/n \n", weaponLoot.Name(), weaponLoot.Damage());

                char accept = Console.ReadKey().KeyChar;
                Console.Clear();

                if (accept == 'y')
                {
                    weaponName = weaponLoot.Name();
                    weaponDamage = weaponLoot.Damage();


                    Console.WriteLine("You have equiped the item!");
                    status();
                }
            }
        }

        public int getExp()
        {
            return exp;
        }

        public int armor()
        {
            return helmetArmor + bootsArmor + chestArmor;
        }
    }
}
