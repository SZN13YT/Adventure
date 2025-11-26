using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{

    class Entity
    {
        public string[] Access = { "Necklace", "Bracelet", "Ring", "Ring" };
        public string[] Armors = { "Helmet", "Chestplate", "Leggings", "Boots" };
        public string Name { get; set; }
        public int MaxHp { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public Entity(string n, int hp, int lvl)
        {
            this.Name = n;
            this.MaxHp = hp;
            this.Hp = hp;
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

        public int Hp { get; set; }
        public int MP { get; set; }
        public int Xp { get; set; }
        public int SelfHealing { get; set; }
        public int MaxMP { get; set; }
        public string Cast { get; set; }
        public Item[] Armour = { null, null, null, null };
        public Item[] Accessories = { null, null, null, null };
        public Item[] Hands = { null, null };
        public List<Item> inventory = new List<Item>();
        public Dictionary<string, int> Materials = new Dictionary<string, int>()
        {
            ["Leather"] = 0,
            ["Wood"] = 1,
            ["Stone"] = 0,
            ["Iron"] = 0,
            ["Gold"] = 0
        };
        public Player(int hp = 100, int mp = 110, string n = "Palyer", int lvl = 1, string cast = "bandit", int sHeal = 0) : base(n.ToUpper(), hp, lvl)
        {
            this.MP = mp;
            this.MaxMP = this.MP;
            this.Xp = 0;
            this.SelfHealing = sHeal;
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
            Console.WriteLine("\nInventory:");
            Console.Write("\t");
            if (this.inventory.Count > 0) 
            { 
                for (int i = 0; i < this.inventory.Count(); i++) 
                { 
                    if (i % 9 == 0 && i != 0 || this.inventory.Count() - 1 == i) Console.WriteLine("\t" + this.inventory[i].rarity + this.inventory[i].itemName); 
                    else Console.Write(this.inventory[i].rarity + $"{this.inventory[i].itemName}, "); 
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
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case false:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                }
                Console.Write($"    ");
                Console.Write(this.Accessories[i] == null ? $"Unequipped {Access[i]}\t      " : this.Accessories[i].itemName + "\t      \t"); ;
                switch (this.Armour[i] == null)
                {
                    case true:
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case false:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                }
                Console.WriteLine(this.Armour[i] == null ? $"Unequipped {Armors[i]}" : this.Armour[i].itemName);
                // Necklace, Bracelet, Ring1, Ring2
                //Healmet, Chestplate, Gauntlets, Leggings
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nHand1: \t \t   \t Hand2:");
            switch (this.Hands[0] == null)
            {
                case true:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case false:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
            }
            Console.Write(this.Hands[0] == null ? "    None \t\t      " : "    " + this.Hands[0].itemName + " " + this.Hands[0].rarity + this.Hands[0].Level + "\t\t");
            switch (this.Hands[1] == null)
            {
                case true:
                    Console.ForegroundColor = ConsoleColor.Black;
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
                this.inventory.Add(i);
            }
        }
        public void Equipp(Item item)
        {
            if (this.inventory.Contains(item))
            {
                switch (item.Type)
                {
                    case "Weapon":
                        switch (item.Hands)
                        { 
                            case 1:
                                // one handed
                                if (this.Hands[0] == null)
                                {
                                    this.Hands[0] = item;
                                }
                                else
                                {
                                    this.Hands[1] = item;
                                }
                                break;
                                
                            case 2:
                                this.Hands[0] = item;
                                this.Hands[1] = item;
                                break;
                            
                        }
                        break;
                    
                    case "Armor":
                        switch (item.itemName)
                        {
                            case "Helmet":
                                this.Armour[0] = item;
                                break;
                            case "Chestplate":
                                this.Armour[1] = item;
                                break;
                            case "Leggings":
                                this.Armour[2] = item;
                                break;
                            case "Boots":
                                this.Armour[3] = item;
                                break;
                        }
                        break;

                    case "Jewelry":
                        switch (item.itemName)
                        {
                            case "Necklace":
                                this.Accessories[0] = item;
                                break;
                            case "Bracelet":
                                this.Accessories[1] = item;
                                break;
                            case "Rings":
                                // one handed
                                if (this.Accessories[2] == null)
                                {
                                    this.Accessories[2] = item;
                                }
                                else
                                {
                                    this.Accessories[3] = item;
                                }
                                break;
                        }
                        break;
                }
            }

        }





    }
}
