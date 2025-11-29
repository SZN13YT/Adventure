using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Adventure
{
    class Shop
    {
        public Inventory<Item> Items { get; set; } = new Inventory<Item>();

        public Shop(List<Item> items = null)
        {
            this.AddItemToShop(items == null ? null: items);

        }
        private void AddItemToShop(List<Item> items = null, int db = 3)
        {
            if (items != null)
            {
                foreach (Item item in items)
                {
                    this.Items.Add(item);
                }
            }
            else
            {
                string[] possible = { "Helmet", "Chestplate", "Gauntlets", "Leggings", "Boots", "Weapon", "Amulet", "Bracelet", "Ring" };
                Random num = new Random();
                for (int i = 0; i < db; i++)
                {
                    Item item = possible[num.Next(0, possible.Count())] switch
                    {
                        "Helmet" => new Helmet(),
                        "Chestplate" => new Chestplate(),
                        "Gauntlets" => new Gauntlets(),
                        "Leggings" => new Leggings(),
                        "Boots" => new Boots(),
                        "Weapon" => new Weapon(),
                        "Amulet" => new Amulet(),
                        "Bracelet" => new Bracelet(),
                        "Ring" => new Ring()

                    };
                    this.Items.Add(item);
                    Console.WriteLine(Items);
                }


            }
        }
    }
}
