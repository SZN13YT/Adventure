using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{
    class Jewelry: Item
    {
        // Ring, Necklace, Bracelet
        public string BonusTypes { get; private set; }
        public int[] Bonuses { get; private set; }
        public Jewelry(int[] b, string iName = "Ring", string t = "DMG", int lvl = 1, int lvlr = 1, string rare = "common") : base(n: iName + "Lvl " +  lvl, type: "Jewelry", lvlr: lvlr, rare: rare)
        {
            this.BonusTypes = t;
            this.Bonuses = b;
        }
    }
}
