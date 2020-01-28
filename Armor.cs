using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Armor
    {
        Random rnd4 = new Random();
        private int armorValue;
        private string name;

        private string[] typeList = new string[] { "Helm", "Chestplate", "Boots" };
        private string[] materialList = new string[] { "Leather", "Plate", "Cloth" };
        private string[] characteristicList = new string[] { "Speed", "Protection", "Stealth" };

        private string type;
        private string material;
        private string characteristic;




        public Armor(int CurrentLevel)
        {
            armorValue = rnd4.Next(0, 20) + (CurrentLevel * 5);
            material = materialList[rnd4.Next(0, 3)];
            type = typeList[rnd4.Next(0, 3)];
            characteristic = characteristicList[rnd4.Next(0, 3)];
            name = material + " " + type + " of " + characteristic;
        }

        public string Name()
        {
            return name;
        }

        public int Value()
        {
            return armorValue;
        }

        public string Slot()
        {
            return type;
        }
    }
}
