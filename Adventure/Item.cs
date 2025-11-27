using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Adventure
{
    class Item
    {
        public string itemName { get; protected set; }
        public int Required { get; protected set; }
        public int Hands { get; protected set; }
        public string Type { get; protected set; }
        public int Level { get; protected set; }
        public Rarity rarity { get; protected set; }

        protected Item(string n, int lvlr = 0, int hand = 0 , string type = "Potion", int lvl = 1, string rare = "common")
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
        public int damage { get; private set; }
        public int durability { get; private set; }
        public int maxDurability { get; private set; }
        public Weapon(string iName = "Sword", int d = 23, int lvlr = 1, int dura = 200, int maxDura = 0, int hand = 1, int lvl = 1, string rare = "common") : base(iName, lvlr, hand, "Weapon", lvl, rare)
        {
            this.damage = d;
            if (maxDura == 0) this.maxDurability = dura;
            else this.maxDurability = maxDura;
        }
    }
    class Armor : Item
    {
        // Helmet, Chestplate, Gauntlets, Leggings, Boots
        public int defense { get; private set; }
        public int durability { get; private set; }
        public int maxDurability { get; private set; }
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
        public string effect { get; private set; }
        public int degEff { get; private set; }
        public Potion(string iName = "Heal", string eff = "Heal", int degEff = 15, int lvl = 1) : base(iName, lvl)
        {
            this.effect = eff;
            this.degEff = degEff;
        }
    }
}
