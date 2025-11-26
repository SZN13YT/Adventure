using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{
    class Jewelry: Item
    {
        // Ring, Necklace, Bracelet
        public string Type { get; set; }
        public int[] Bonuses { get; set; }
        public int Level { get; set; }
        public Jewelry(int[] b, string iName = "Ring", string t = "DMG", int lvl = 1, int lvlr = 1, string rare = "common") : base(n: iName + "Lvl " +  lvl, lvlr: lvlr, rare: rare)
        {
            this.Level = lvl;
            this.Type = t;
            this.Bonuses = b;
        }
    }
}
