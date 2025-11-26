using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Adventure
{
    class Item
    {
        public string itemName { get; set; }
        public int Required { get; set; }
        public int Hands { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public Rarity rarity { get; set; }

        public Item(string n, int lvlr = 0, int hand = 0 , string type = "Potion", int lvl = 1, string rare = "common")
        {
            this.itemName = n;
            this.Required = lvlr;
            this.Hands = hand;
            this.Type = type;
            this.Level = lvl;
            this.rarity = new Rarity(rare);
        }
        public virtual void Print()
        {
            Console.WriteLine(itemName);
            Console.Write(this.Required != 0 ? this.Required + "\n": "");
        }
        


    }
    class Weapon : Item
    {
        public int damage { get; set; }
        
        public int minlevel { get; set; }
        public int durability { get; set; }
        public int maxDurability { get; set; }
        public Weapon(string iName = "Sword", int d = 23, int minl = 1, int lvlr = 1, int dura = 200, int maxDura = 0, int hand = 1, int lvl = 1, string rare = "common") : base(iName, lvlr, hand, "Weapon", lvl, rare)
        {
            this.damage = d;
            this.minlevel = minl;
            if (maxDura == 0) this.maxDurability = dura;
            else this.maxDurability = maxDura;
        }
    }
    class Armor : Item
    {
        // Helmet, Chestplate, Gauntlets, Leggings, Boots
        public int defense { get; set; }
        public int durability { get; set; }
        public int maxDurability { get; set; }
        public Armor(string iName = "Chestplate", int def = 5, int lvl = 1, int lvlr = 1, int dura = 200, int maxDura = 0, string rare = "common") : base(iName, lvlr, lvl: lvl, type: "Armor", rare: rare)
        {
            this.defense = def;
            this.durability = dura;
            if (maxDura == 0) this.maxDurability = dura;
            else this.maxDurability = maxDura;
        }
    }
    class Potion : Item
    {
        string effect { get; set; }
        int degEff { get; set; }
        public Potion(string iName = "Heal", string eff = "Heal", int degEff = 15, int lvl = 1) : base(iName, lvl)
        {
            this.effect = eff;
            this.degEff = degEff;
        }
    }
}
