using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{
    class Helmet : Armor
    {
        public Helmet(int[] b, int def = 5, int lvl = 1, int lvlr = 1, int dura = 200, int maxDura = 0, string rare = "common") : base(b: b, iName: "Helmet", def: def, lvl: lvl, lvlr: lvlr, dura: dura, maxDura: maxDura, rare: rare)
        {
        }
        public override void Equipp(Player player)
        {
            if (player.Inventory.Contains(this))
            {
                this.ApplyBonus(player);
                if (player.Armour[0] == null)
                {
                    player.Armour[0] = this;
                }
                else
                {
                    player.Armour[0].Unequipp(player);
                    player.Armour[0] = this;
                }
            }
            else
            {
                Console.WriteLine("You don't have this armor in your inventory.");
            }
        }
        public override void Unequipp(Player player)
        {
            if (!player.Armour.Contains(this))
            {
                Console.WriteLine("This armor is not equipped.");
                return;
            }
            else
            {
                player.Inventory.Add(this);
                this.RemoveBonus(player);
                player.Armour[0] = null;
            }
        }
    }
    class Chestplate : Armor
    {
        public Chestplate(int[] b, int def = 10, int lvl = 1, int lvlr = 1, int dura = 200, int maxDura = 0, string rare = "common") : base(b: b, iName: "Chestplate", def: def, lvl: lvl, lvlr: lvlr, dura: dura, maxDura: maxDura, rare: rare)
        {
        }
        public override void Equipp(Player player)
        {
            if (player.Inventory.Contains(this))
            {
                this.ApplyBonus(player);
                if (player.Armour[1] == null)
                {
                    player.Armour[1] = this;
                }
                else
                {
                    player.Armour[1].Unequipp(player);
                    player.Armour[1] = this;
                }
            }
            else
            {
                Console.WriteLine("You don't have this armor in your inventory.");
            }
        }
        public override void Unequipp(Player player)
        {
            if (!player.Armour.Contains(this))
            {
                Console.WriteLine("This armor is not equipped.");
                return;
            }
            else
            {
                player.Inventory.Add(this);
                this.RemoveBonus(player);
                player.Armour[1] = null;
            }
        }
    }
    class Gauntlets : Armor
    {
        public Gauntlets(int[] b, int def = 3, int lvl = 1, int lvlr = 1, int dura = 200, int maxDura = 0, string rare = "common") : base(b: b, iName: "Gauntlets", def: def, lvl: lvl, lvlr: lvlr, dura: dura, maxDura: maxDura, rare: rare)
        {
        }
        public override void Equipp(Player player)
        {
            if (player.Inventory.Contains(this))
            {
                this.ApplyBonus(player);
                if (player.Armour[2] == null)
                {
                    player.Armour[2] = this;
                }
                else
                {
                    player.Armour[2].Unequipp(player);
                    player.Armour[2] = this;
                }
            }
            else
            {
                Console.WriteLine("You don't have this armor in your inventory.");
            }
        }
        public override void Unequipp(Player player)
        {
            if (!player.Armour.Contains(this))
            {
                Console.WriteLine("This armor is not equipped.");
                return;
            }
            else
            {
                player.Inventory.Add(this);
                this.RemoveBonus(player);
                player.Armour[2] = null;
            }
        }
    }
    class Leggings : Armor
    {
        public Leggings(int[] b, int def = 7, int lvl = 1, int lvlr = 1, int dura = 200, int maxDura = 0, string rare = "common") : base(b: b, iName: "Leggings", def: def, lvl: lvl, lvlr: lvlr, dura: dura, maxDura: maxDura, rare: rare)
        {
        }
        public override void Equipp(Player player)
        {
            if (player.Inventory.Contains(this))
            {
                this.ApplyBonus(player);
                if (player.Armour[3] == null)
                {
                    player.Armour[3] = this;
                }
                else
                {
                    player.Armour[3].Unequipp(player);
                    player.Armour[3] = this;
                }
            }
            else
            {
                Console.WriteLine("You don't have this armor in your inventory.");
            }
        }
        public override void Unequipp(Player player)
        {
            if (!player.Armour.Contains(this))
            {
                Console.WriteLine("This armor is not equipped.");
                return;
            }
            else
            {
                player.Inventory.Add(this);
                this.RemoveBonus(player);
                player.Armour[3] = null;
            }
        }
    }
    class Boots : Armor
    {
        public Boots(int[] b, int def = 4, int lvl = 1, int lvlr = 1, int dura = 200, int maxDura = 0, string rare = "common") : base(b: b, iName: "Boots", def: def, lvl: lvl, lvlr: lvlr, dura: dura, maxDura: maxDura, rare: rare)
        {
        }
        public override void Equipp(Player player)
        {
            if (player.Inventory.Contains(this))
            {
                this.ApplyBonus(player);
                if (player.Armour[4] == null)
                {
                    player.Armour[4] = this;
                }
                else
                {
                    player.Armour[4].Unequipp(player);
                    player.Armour[4] = this;
                }
            }
            else
            {
                Console.WriteLine("You don't have this armor in your inventory.");
            }
        }
        public override void Unequipp(Player player)
        {
            if (!player.Armour.Contains(this))
            {
                Console.WriteLine("This armor is not equipped.");
                return;
            }
            else
            {
                player.Inventory.Add(this);
                this.RemoveBonus(player);
                player.Armour[4] = null;
            }
        }
    }
}
