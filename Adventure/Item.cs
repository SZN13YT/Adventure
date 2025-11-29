using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Adventure
{
    abstract class Item
    {
        public string itemName { get; protected set; }
        public int Required { get; protected set; }
        public int Hands { get; protected set; }
        public string Type { get; protected set; }
        public int Level { get; protected set; }
        public Rarity rarity { get; protected set; }
        public int[] Bonuses { get; protected set; }

        public Item(int[] bonuses, string n, int lvlr = 0, int hand = 0, string type = "HEAL", int lvl = 1, string rare = "common")
        {
            this.itemName = n;
            this.Required = lvlr;
            this.Hands = hand;
            this.Type = type;
            this.Level = lvl;
            this.rarity = new Rarity(rare);
            if (bonuses == null)
            {
                this.Bonuses = new int[] { 23 };
            }
            else this.Bonuses = bonuses;
        }
        public abstract void Equipp(Player player);
        public abstract void Unequipp(Player player);
        public virtual void Print()
        {
            Console.WriteLine(itemName);
            Console.Write(this.Required != 0 ? this.Required + "\n": "");
        }

        protected void Changer(string type, int bonusValue, Player player)
        {
            switch (type.ToUpper())
            {
                case "DMG":
                    player.DMG += bonusValue;
                    break;

                case "DEF":
                    player.DEF += bonusValue;
                    break;

                case "HP":
                    player.MaxHp += bonusValue;
                    player.Hp += bonusValue;
                    break;

                case "MP":
                    player.MaxMP += bonusValue;
                    player.MP += bonusValue;
                    break;

                case "HEAL":
                    player.Healing += bonusValue;
                    break;

                case "ALL":
                    player.DMG += bonusValue;
                    player.DEF += bonusValue;

                    player.MaxHp += bonusValue;
                    player.Hp += bonusValue;

                    player.MaxMP += bonusValue;
                    player.MP += bonusValue;

                    player.Healing += bonusValue;
                    break;
            }
        }
        protected void ApplyBonus(Player player)
        {
            string[] bonus = this.Type.Trim().Split();
            for (int i = 0; i < bonus.Length; i++)
            {
                Changer(bonus[i], this.Bonuses[i], player);
            }
        }
        protected void RemoveBonus(Player player)
        {
            string[] bonus = this.Type.Trim().Split();
            for (int i = 0; i < bonus.Length; i++)
            {
                Changer(bonus[i], -this.Bonuses[i], player);
            }
        }



    }
    class Weapon : Item
    {
        public int damage { get; private set; }
        public int durability { get; private set; }
        public int maxDurability { get; private set; }
        public Weapon(int[] b = null, string t = "DMG", string iName = "Sword", int d = 23, int lvlr = 1, int dura = 200, int maxDura = 0, int hand = 1, int lvl = 1, string rare = "common") : base(bonuses: b, n: iName, lvlr: lvlr, hand: hand, type: t, lvl: lvl, rare: rare)
        {
            this.damage = d;
            if (maxDura == 0) this.maxDurability = dura;
            else this.maxDurability = maxDura;
        }
        public override void Equipp(Player player)
        {
            if (!player.Inventory.Contains(this))
            {
                Console.WriteLine("You don't have this weapon in your inventory.");
                return;
            }
            else
            {
                this.ApplyBonus(player);
                switch (this.Hands)
                {
                    case 1:
                        if (player.Hands[0] == null)
                        {
                            player.Hands[0] = this;
                        }
                        else if (player.Hands[1] == null)
                        {
                            player.Hands[1] = this;
                        }
                        else
                        {
                            Console.WriteLine("Wich hand do you want to replace? (1, 2)");
                            Console.WriteLine(player.Hands);
                            int slot = Convert.ToInt32(Console.ReadLine());
                            switch (slot)
                            {
                                case 1:
                                    player.Hands[0].Unequipp(player);
                                    player.Hands[0] = this;
                                    break;
                                case 2:
                                    player.Hands[1].Unequipp(player);
                                    player.Hands[1] = this;
                                    break;
                                default:
                                    this.RemoveBonus(player);
                                    Console.WriteLine("Invalid slot. No changes made.");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        if (player.Hands[0] != null)
                        {
                            player.Hands[0].Unequipp(player);
                        }
                        if (player.Hands[1] != null)
                        {
                            player.Hands[1].Unequipp(player);
                        }
                        player.Hands[0] = this;
                        player.Hands[1] = this;
                        break;
                }
                if (player.Hands.Contains(this)) player.Inventory.Remove(this);
            }
        }
        public override void Unequipp(Player player)
        {
            player.Inventory.Add(this);
            this.RemoveBonus(player);
            if (player.Hands[0] == this)
            {
                player.Hands[0] = null;
            }
            else if (player.Hands[1] == this)
            {
                player.Hands[1] = null;
            }
            else
            {
                player.Inventory.Remove(this);
                this.ApplyBonus(player);
                Console.WriteLine("This weapon is not equipped.");
            }
        }
    }
    abstract class Armor : Item
    {
        // Helmet, Chestplate, Gauntlets, Leggings, Boots
        public int defense { get; private set; }
        public int durability { get; private set; }
        public int maxDurability { get; private set; }
        public Armor(int[] b = null, string t = "DEF", string iName = "Chestplate", int def = 5, int lvl = 1, int lvlr = 1, int dura = 200, int maxDura = 0, string rare = "common") : base(bonuses: b, n: iName, lvlr: lvlr, lvl: lvl, type: t, rare: rare)
        {
            this.defense = def;
            this.durability = dura;
            if (maxDura == 0) this.maxDurability = dura;
            else this.maxDurability = maxDura;
        }
    }
    abstract class Jewellery : Item
    {
        // Amulet, Bracelet, Rings
        public Jewellery(int[] bonuses, string n, string type = "DMG", int lvl = 1, int lvlr = 1, string rare = "common") : base(bonuses: bonuses, n: n, type: type, lvl: lvl, lvlr: lvlr, rare: rare)
        {
        }
    }
    class Potion : Item
    {
        // Heal, Mana,
        //
        // under development (Strength, Defense, All)
        public string effect { get; private set; }
        public int degEff { get; private set; }
        public Potion(int[] b = null, string iName = "Healing potion", string eff = "Heal", int degEff = 15, int lvl = 1) : base(b, iName, lvl)

        {
            this.effect = eff;
            this.degEff = degEff;
        }
        public override void Equipp(Player player)
        {
            Console.WriteLine("Potions cannot be equipped.");
        }
        public override void Unequipp(Player player)
        {
            Console.WriteLine("Potions cannot be unequipped.");
        }
        public void Use(Player player)
        {
            switch (this.effect.ToUpper())
            {
                case "HEAL":
                    player.Hp += this.degEff;
                    if (player.Hp > player.MaxHp) player.Hp = player.MaxHp;
                    Console.WriteLine($"You have healed {this.degEff} HP. Current HP: {player.Hp}/{player.MaxHp}");
                    break;
                case "MANA":
                    player.MP += this.degEff;
                    if (player.MP > player.MaxMP) player.MP = player.MaxMP;
                    Console.WriteLine($"You have restored {this.degEff} MP. Current MP: {player.MP}/{player.MaxMP}");
                    break;
                /*
                 * 
                 * Ehhez kéne valami timer hogy csak egy ideig tartson a buff
                 * 
                 * 
                    case "STRENGTH":
                        player.DMG += this.degEff;
                        Console.WriteLine($"You have increased your damage by {this.degEff}. Current DMG: {player.DMG}");
                        break;
                    case "DEFENSE":
                        player.DEF += this.degEff;
                        Console.WriteLine($"You have increased your defense by {this.degEff}. Current DEF: {player.DEF}");
                        break;
                    case "ALL":
                        player.DMG += this.degEff;
                        player.DEF += this.degEff;
                        player.Hp += this.degEff;
                        if (player.Hp > player.MaxHp) player.Hp = player.MaxHp;
                        player.MP += this.degEff;
                        if (player.MP > player.MaxMP) player.MP = player.MaxMP;
                        Console.WriteLine($"You have increased all your stats by {this.degEff}.");
                        break;
                */
                default:
                    Console.WriteLine("Unknown potion effect.");
                    break;
            }
        }
        
    }
}
