using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{
    class Amulet : Jewellery
    {
        public Amulet(int[] b, string iName = "Amulet", string t = "DMG", int lvl = 1, int lvlr = 1, string rare = "common") : base(bonuses: b, n: iName, type: t, lvl: lvl, lvlr: lvlr, rare: rare)
        {
        }
        public override void Equipp(Player player)
        {
            if (player.Inventory.Contains(this))
            {
                Console.WriteLine("You don't have an item like this. 404 error");
            }
            else
            {
                this.ApplyBonus(player);
                if (player.Accessories[0] != null)
                {
                    player.Accessories[0].Unequipp(player);

                }
                player.Accessories[0] = this;
                player.Inventory.Remove(this);
            }
        }
        public override void Unequipp(Player player)
        {
            if (player.Accessories[0] != this)
            {
                Console.WriteLine("This amulet is not equipped.");
                return;
            }
            else
            {
                this.RemoveBonus(player);
                player.Inventory.Add(this);
                player.Accessories[0] = null;
            }
        }
    }
    class Bracelet : Jewellery
    {
        public Bracelet(int[] b, string iName = "Bracelet", string t = "DMG", int lvl = 1, int lvlr = 1, string rare = "common") : base(bonuses: b, n: iName, type:t, lvl: lvl, lvlr:lvlr, rare:rare)
        {
        }
        public override void Equipp(Player player)
        {
            if (player.Inventory.Contains(this))
            {
                Console.WriteLine("You don't have an item like this. 404 error");
            }
            else
            {
                this.ApplyBonus(player);
                if (player.Accessories[1] != null)
                {
                    player.Accessories[1].Unequipp(player);
                }
                player.Accessories[1] = this;
                player.Inventory.Remove(this);
            }
        }
        public override void Unequipp(Player player)
        {
            if (player.Accessories[1] != this)
            {
                Console.WriteLine("This bracelet is not equipped.");
                return;
            }
            else
            {
                this.RemoveBonus(player);
                player.Inventory.Add(this);
                player.Accessories[1] = null;
            }
        }
    }
    class Ring : Jewellery
    {
        public Ring(int[] b, string iName = "Ring", string t = "DMG", int lvl = 1, int lvlr = 1, string rare = "common") : base(bonuses: b, n: iName, type:t, lvl: lvl, lvlr:lvlr, rare:rare)
        {
        }
        public override void Equipp(Player player)
        {
            this.ApplyBonus(player);
            switch (player.Accessories[2] == null)
            {
                case true:
                    player.Accessories[2] = this;
                    break;
                case false:
                    switch (player.Accessories[3] == null)
                    {
                        case true:
                            player.Accessories[3] = this;
                            break;
                        case false:
                            Console.WriteLine("Wich ring slot do you want to replace? (1, 2)");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice < 1 || choice > 2)
                            {
                                Console.WriteLine("Invalid choice. Operation cancelled.");
                                this.RemoveBonus(player);
                                return;
                            }
                            player.Accessories[choice + 1].Unequipp(player);
                            player.Accessories[choice + 1] = this;
                            break;
                    }
                    break;
            }
        }
        public override void Unequipp(Player player)
        {
            if (!player.Accessories.Contains(this))
            {
                Console.WriteLine("This ring is not equipped.");
                return;
            }
            else
            {
                this.RemoveBonus(player);
                player.Inventory.Add(this);
                switch (player.Accessories[2] == this)
                {
                    case true:
                        player.Accessories[2] = null;
                        break;
                    case false:
                        player.Accessories[3] = null;
                        break;
                }
            }
        }
    }
}