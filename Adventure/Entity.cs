using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Adventure
{

    class Entity
    {
        protected string[] Access = { "Necklace", "Bracelet", "Ring", "Ring" };
        protected string[] Armors = { "Helmet", "Chestplate", "Leggings", "Boots" };
        protected string Name { get; set; }
        protected int MaxHp { get; set; }
        protected int Level { get; set; }
        protected int Hp { get; set; }
        protected int DMG { get; set; }
        protected int DEF { get; set; }
        protected int Healing { get; set; }
        protected Entity(string n, int hp, int lvl, int def, int dmg, int heal = 0)
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

        private int MP { get; set; }
        private int Xp { get; set; }
        private int MaxMP { get; set; }
        private string Cast { get; set; }
        private Armor[] Armour = { null, null, null, null };
        private Jewelry[] Accessories = { null, null, null, null };
        private Weapon[] Hands = { null, null };
        public List<Item> Inventory { get; private set; } = new List<Item>();
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
        private void Changer(string type, int bonusValue)
        {
            switch (type)
            {
                case "DMG":
                    this.DMG += bonusValue;
                    break;

                case "DEF":
                    this.DEF += bonusValue;
                    break;

                case "HP":
                    this.MaxHp += bonusValue;
                    this.Hp += bonusValue;
                    break;

                case "MP":
                    this.MaxMP += bonusValue;
                    this.MP += bonusValue;
                    break;

                case "HEAL":
                    this.Healing += bonusValue;
                    break;

                case "ALL":
                    this.DMG += bonusValue;
                    this.DEF += bonusValue;

                    this.MaxHp += bonusValue;
                    this.Hp += bonusValue;

                    this.MaxMP += bonusValue;
                    this.MP += bonusValue;

                    this.Healing += bonusValue;
                    break;
            }
        }
        public void ApplyBonus(Jewelry item)
        {
            string[] bonus = item.BonusTypes.Trim().Split();
            for (int i = 0; i < bonus.Length; i++)
            {
                Changer(bonus[i], item.Bonuses[i]);
            }
        }
        public void RemoveBonus(Jewelry item)
        {
            string[] bonus = item.BonusTypes.Trim().Split();
            for (int i = 0; i < bonus.Length; i++)
            {
                Changer(bonus[i], -item.Bonuses[i]);
            }
        }


        public void Equipp(Item item)
        {
            if (this.Inventory.Contains(item))
            {
                switch (item.Type)
                {
                    case "Weapon":
                        Weapon weapon = (Weapon)item;
                        this.DMG += weapon.damage;
                        switch (item.Hands)
                        { 
                            case 1:
                                // one handed
                                if (this.Hands[0] == null)
                                {
                                    this.Hands[0] = weapon;
                                }
                                else if (this.Hands[1] == null)
                                {
                                    this.Hands[1] = weapon;
                                }
                                else 
                                {
                                    Console.WriteLine("Wich hand do you want to replace? (1, 2)");
                                    int choice = Convert.ToInt32(Console.ReadLine());
                                    this.Unequipp(choice == 1 ? "hand1" : "hand2");
                                    if (choice == 1) this.Hands[0] = weapon;
                                    else this.Hands[1] = weapon;
                                }
                                break;
                                
                            case 2:
                                this.Hands[0] = weapon;
                                this.Hands[1] = weapon;
                                break;

                        }
                        break;
                    
                    case "Armor":
                        Armor armor = (Armor)item;
                        this.DEF += armor.defense;
                        switch (item.itemName)
                        {
                            case "Helmet":
                                this.Armour[0] = armor;
                                break;
                            case "Chestplate":
                                this.Armour[1] = armor;
                                break;
                            case "Leggings":
                                this.Armour[2] = armor;
                                break;
                            case "Boots":
                                this.Armour[3] = armor;
                                break;
                        }
                        break;

                    case "Jewelry":
                        Jewelry jewelry = (Jewelry)item;
                        this.ApplyBonus(jewelry);
                        switch (item.itemName)
                        {
                            
                            case "Necklace":
                                if (this.Accessories[0] != null)
                                {
                                    this.RemoveBonus(jewelry);
                                    this.Unequipp("neklace");
                                }
                                this.Accessories[0] = jewelry;
                                break;
                            case "Bracelet":
                                this.RemoveBonus(jewelry);
                                this.Unequipp("bracelet");
                                this.Accessories[1] = jewelry;
                                break;
                            case "Rings":
                                if (this.Accessories[2] == null)
                                {
                                    this.Accessories[2] = jewelry;
                                }
                                else if (this.Accessories[3] == null)
                                {
                                    this.Accessories[3] = jewelry;
                                }
                                else
                                {
                                    Console.WriteLine("Wich ring slot do you want to replace? (1, 2)");
                                    int choice = Convert.ToInt32(Console.ReadLine());
                                    this.Unequipp(choice == 1 ? "ring1" : "ring2");
                                    this.Accessories[choice + 1] = jewelry;
                                }
                                break;
                        }
                        break;
                }
                this.Inventory.Remove(item);
            }

        }

        public void Unequipp(string slot = "ring1")
        {
            switch (slot.ToLower())
            {
                case "hand1":
                    if (this.Hands[0] != null)
                    {
                        this.DMG -= this.Hands[0].damage;
                        this.Inventory.Add(this.Hands[0]);
                        this.Hands[0] = null;
                    }
                    break;
                case "hand2":
                    if (this.Hands[1] != null)
                    {
                        this.DMG -= this.Hands[1].damage;
                        this.Inventory.Add(this.Hands[1]);
                        this.Hands[1] = null;
                    }
                    break;
                case "helmet":
                    if (this.Armour[0] != null)
                    {
                        this.DEF -= this.Armour[0].defense;
                        this.Inventory.Add(this.Armour[0]);
                        this.Armour[0] = null;
                    }
                    break;
                case "chestplate":
                    if (this.Armour[1] != null)
                    {
                        this.DEF -= this.Armour[1].defense;
                        this.Inventory.Add(this.Armour[1]);
                        this.Armour[1] = null;
                    }
                    break;
                case "leggings":
                    if (this.Armour[2] != null)
                    {
                        this.DEF -= this.Armour[2].defense;
                        this.Inventory.Add(this.Armour[2]);
                        this.Armour[2] = null;
                    }
                    break;
                case "boots":
                    if (this.Armour[3] != null)
                    {
                        this.DEF -= this.Armour[3].defense;
                        this.Inventory.Add(this.Armour[3]);
                        this.Armour[3] = null;
                    }
                    break;
                case "necklace":
                    if (this.Accessories[0] != null)
                    {
                        this.RemoveBonus(this.Accessories[0]);
                        this.Inventory.Add(this.Accessories[0]);
                        this.Accessories[0] = null;
                    }
                    break;
                case "bracelet":
                    if (this.Accessories[1] != null)
                    {
                        this.RemoveBonus(this.Accessories[1]);
                        this.Inventory.Add(this.Accessories[1]);
                        this.Accessories[1] = null;
                    }
                    break;
                case "ring1":
                    if (this.Accessories[2] != null)
                    {
                        this.RemoveBonus(this.Accessories[2]);
                        this.Inventory.Add(this.Accessories[2]);
                        this.Accessories[2] = null;
                    }
                    break;
                case "ring2":
                    if (this.Accessories[3] != null)
                    {
                        this.RemoveBonus(this.Accessories[3]);
                        this.Inventory.Add(this.Accessories[3]);
                        this.Accessories[3] = null;
                    }
                    break;
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
