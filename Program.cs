using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logon Screen
            Console.Clear();
            Console.WriteLine("Welcome to Aaron's amazing medieval text adventure");
            Console.WriteLine("\n");
            Console.Write("Please Enter Your Heroes Name: ");

            //Init Players Hero
            string name = Console.ReadLine();
            Hero player = new Hero(name);

            //Output Hero stats
            Console.WriteLine("\n");
            player.status();

            Console.WriteLine("Press any key to begin your adventure...");
            Console.ReadKey();

            Console.Clear();

            Random rnd2 = new Random();

            while (player.Alive() == true)
            {
                int monsterType = rnd2.Next(0, 3);
                bool attackFirst = Convert.ToBoolean(rnd2.Next(0, 2));
                Monster enemy = new Monster(player.currentLevel(), monsterType);

                Console.Clear();

                if (attackFirst == true)
                {
                    Console.WriteLine("You attack a level {1} {0}", enemy.Type(), enemy.Level());
                    Console.WriteLine("HP: {0}\nSTR: {1}\n", enemy.HP(), enemy.Damage());
                    Console.WriteLine("Press to continue...\n");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You are attacked by a level {1} {0}", enemy.Type(), enemy.Level());
                    Console.WriteLine("HP: {0}\nSTR: {1}\n", enemy.HP(), enemy.Damage());
                    Console.WriteLine("Press to continue...\n");
                    Console.ReadKey();
                }

                while (enemy.Alive() && player.Alive())
                {
                    Console.Clear();

                    if (attackFirst == true)
                    {
                        enemy.Attacked(player.Attack());
                        Console.WriteLine();

                        if (enemy.Alive() == true)
                        {
                            player.Attacked(enemy.Attack(player.armor()));
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        player.Attacked(enemy.Attack(player.armor()));
                        Console.WriteLine();

                        if (player.Alive() == true)
                        {
                            enemy.Attacked(player.Attack());
                            Console.WriteLine();
                        }

                    }
                    Console.WriteLine("Press to continue...\n");
                    Console.ReadKey();
                }

                if (player.Alive() == false) { break; }

                Console.Clear();
                Console.WriteLine("Congratulations, you have won the battle");
                Console.WriteLine();

                player.winBattle();

                if (player.getExp() >= 1000 * player.currentLevel())
                {
                    player.levelUp();
                }

                Console.WriteLine("Press to continue...\n");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("Game over, you have died");
        }
    }
}
