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
        protected string Name { get; set; }
        public int MaxHp { get; internal set; }
        protected int Level { get; set; }
        public int Hp { get; internal set; }
        public int DMG { get; internal set; }
        public int DEF { get; internal set; }
        public int Healing { get; internal set; }
        public Entity(string n, int hp, int lvl, int def, int dmg, int heal = 0)
        {
            this.Name = n;
            this.MaxHp = hp;
            this.Hp = hp;
            this.DMG = dmg;
            this.DEF = def;
            this.Healing = heal;
            this.Level = 1;
        }

        public virtual void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"Name: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(this.Name);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"Health: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(this.Hp);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"Level: ");
            Console.WriteLine(this.Level);
        }

    }
    class Player : Entity
    {

        public int MP { get; internal set; }
        public int Xp { get; internal set; }
        public int MaxMP { get; internal set; }
        public string Cast { get; internal set; }
        public Armor[] Armour { get; internal set; } = { null, null, null, null };
        public Jewellery[] Accessories { get; internal set; } = { null, null, null, null };
        // itt a geteket írd át hogy működjön a kiiratás és a hands lehetne egy class meg a többi is
        public Weapon[] Hands { get; internal set; } = { null, null };
        public List<Item> Inventory { get; internal set; } = new List<Item>();
        private Dictionary<string, int> Materials = new Dictionary<string, int>()
        {
            ["Leather"] = 0,
            ["Wood"] = 1,
            ["Stone"] = 0,
            ["Iron"] = 0,
            ["Gold"] = 0
        };
        public Player(int hp = 100, int mp = 110, string n = "Palyer", int lvl = 1, string cast = "bandit", int sHeal = 0, int dmg = 8, int def = 4) : base(n:n.ToUpper(), hp:hp, lvl:lvl, def:def, heal:sHeal, dmg:dmg)
        {
            this.MP = mp;
            this.MaxMP = this.MP;
            this.Xp = 0;
            this.Cast = cast;
        }
        public override void Print()
        {
            base.Print();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write($"Mana: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(this.MP);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Cast: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(this.Cast);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"DMG: {this.DMG}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"DEF: {this.DEF}");
            Console.ResetColor();

            Console.WriteLine(Inventory.Count == 0 ? "\nInventory is empty." : "\nInventory:");
            if (this.Inventory.Count > 0) 
            { 
                Console.Write("\t");
                for (int i = 0; i < this.Inventory.Count(); i++) 
                { 
                    if (i % 9 == 0 && i != 0 || this.Inventory.Count() - 1 == i) Console.WriteLine("\t" + this.Inventory[i].rarity + this.Inventory[i].itemName); 
                    else Console.Write(this.Inventory[i].rarity + $"{this.Inventory[i].itemName}, "); 
                } 
            }
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
            this.Level += lvl;
            this.MaxHp += hp;
            this.Hp = this.MaxHp;
            this.MaxMP += mp;
            this.MP = this.MaxMP;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n\nCongratulations! You have reached ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(this.Level);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" level!\n\n");
            Console.ResetColor();
        }



    }

    class Spider : Entity
    {
        public Spider(int hp = 200, string n = "Spider", int lvl = 1, int def = 30, int dmg = 25) : base(n:n, hp:hp, lvl:lvl, def:def, dmg:dmg)
        {

        }
    }


}
