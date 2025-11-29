using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{
    class Inventory<T> : List<Item>
    {
        public override string ToString()
        {
            Console.WriteLine(this.Count == 0 ? "\nInventory is empty." : "\nInventory:");
            if (this.Count > 0)
            {
                Console.Write("\t");
                for (int i = 0; i < this.Count(); i++)
                {
                    if (i % 9 == 0 && i != 0 || this.Count() - 1 == i) Console.WriteLine(this[i].rarity + this[i].itemName);
                    else Console.Write(this[i].rarity + $"{this[i].itemName}, ");
                }
            }
            return "";
        }
    }
}
