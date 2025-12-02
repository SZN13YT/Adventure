using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Adventure
{

    abstract class Entity
    {
        protected string[] Access = { "Necklace", "Bracelet", "Ring", "Ring" };
        protected string[] Armors = { "Helmet", "Chestplate", "Leggings", "Boots" };
        public Stats Stats { get; internal set; }

        public Entity(int hp = 100, int mp = 0, string n = "Palyer", int lvl = 1, string cast = "None", int sHeal = 0, int dmg = 8, int def = 4, int xp = 0)
        {
            this.Stats = new Stats(hp: hp, mp: mp, n: n, lvl: lvl, cast: cast, sHeal: sHeal, dmg: dmg, def: def, xp: xp);
        }
        public abstract void Print();
        public int Attack()
        {
            return this.Stats.DMG;
        }
        public void HpLoss(int DMG)
        {
            this.Stats.Hp -= DMG - (this.Stats.DEF/6);

        }
    }
    class Player : Entity
    {

        public Inventory<Item> Inventory { get; internal set; } = new Inventory<Item>();
        // itt a geteket írd át hogy működjön a kiiratás és a hands lehetne egy class meg a többi is
        public Armor[] Armour { get; internal set; } = { null, null, null, null };
        public Jewellery[] Accessories { get; internal set; } = { null, null, null, null };
        public Weapon[] Hands { get; internal set; } = { null, null };
        private Dictionary<string, int> Materials = new Dictionary<string, int>()
        {
            ["Leather"] = 0,
            ["Wood"] = 1,
            ["Stone"] = 0,
            ["Iron"] = 0,
            ["Gold"] = 0
        };
        public int X { get; internal set; } = 0;
        public int Y { get; internal set; } = 0;
        public Player(int hp = 100, int mp = 110, string n = "Palyer", int lvl = 1, string cast = "bandit", int sHeal = 0, int dmg = 8, int def = 4) : base(n:n.ToUpper(), hp:hp, mp: mp, cast: cast, lvl:lvl, def:def, sHeal:sHeal, dmg:dmg)
        {
        }
        public override void Print()
        {
            this.Stats.Print();
            Console.WriteLine(this.Inventory);
            Console.WriteLine();
            foreach (string i in this.Materials.Keys)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{i}: ");
                Console.ForegroundColor = this.Materials[i] == 0 ? ConsoleColor.DarkGray : ConsoleColor.Yellow;
                Console.WriteLine(this.Materials[i]);
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\nAccessories: \t\t Armors:");
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < this.Accessories.Count(); i++)
            {
                switch (this.Accessories[i] == null)
                {
                    case true:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case false:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                }
                Console.Write($"    ");
                Console.Write(this.Accessories[i] == null ? $"None\t      " : this.Accessories[i].itemName + "\t      \t"); ;
                switch (this.Armour[i] == null)
                {
                    case true:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case false:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                }
                Console.WriteLine(this.Armour[i] == null ? $"\tNone" : this.Armour[i].itemName);
                // Necklace, Bracelet, Ring1, Ring2
                //Healmet, Chestplate, Gauntlets, Leggings
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nHand1: \t \t   \t Hand2:");
            switch (this.Hands[0] == null)
            {
                case true:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case false:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
            }
            Console.Write(this.Hands[0] == null ? "    None \t\t      " : "    " + this.Hands[0].itemName + " " + this.Hands[0].rarity + this.Hands[0].Level + "\t\t");
            switch (this.Hands[1] == null)
            {
                case true:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case false:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
            }
            Console.WriteLine(this.Hands[1] == null ? "None" : this.Hands[1].itemName + " " + this.Hands[1].Level);
            Console.ResetColor();
        }
        public void Append(List<Item> items)
        {
            foreach (Item i in items)
            {
                this.Inventory.Add(i);
            }
        }      

        public void Equipp(Item item = null)
        {
            if (this.Inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
                return;
            }
            else if (item == null)
            {
                Console.WriteLine("Which item do you want to equip?:");
                for (int i = 0; i < this.Inventory.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"[{i}] ");
                    Console.ResetColor();
                    Console.WriteLine(this.Inventory[i].rarity);
                    Console.WriteLine(this.Inventory[i]);
                }
                this.Inventory[Console.ReadLine() is string s && int.TryParse(s, out int index) && index >= 0 && index < this.Inventory.Count ? index : -1].Equipp(this);
                Console.WriteLine("The equip was succesfull!");
            }
            else
            {
                item.Equipp(this);
                Console.WriteLine("The equip was succesfull!");
            }
        }
        public void LevelUp(int lvl = 1, int hp = 20, int mp = 10)
        {
            this.Stats.LevelUp();
        }
        



    }

    class Spider : Entity
    {
        public Spider(int hp = 200, string n = "Spider", int lvl = 1, int def = 30, int dmg = 25) : base(n:n, hp:hp, lvl:lvl, def:def, dmg:dmg)
        {

        }
        
        public override void Print()
        {
            Console.WriteLine(this.Stats);
        }
    }
    class Zombie : Entity
    {
        public Zombie(int hp = 200, string n = "Zombie", int lvl = 1, int def = 30, int dmg = 25) : base(n: n, hp: hp, lvl: lvl, def: def, dmg: dmg)
        {


        }
        public override void Print() 
        {
            this.Stats.Print();

        }
    }
}
