using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{
    class Encounters
    {
        
        public Encounters() { }
        public void Market(Shop shop, Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You arrive at the bustling market square, filled with vendors and shoppers.");
            Console.WriteLine("Would you like to go in and buy sth? (y/n)");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine(shop);
                Console.WriteLine("Hey Dear Tourist!\nI'm happy to see you. What would you like to buy?");
            }
            else shop.GoAway(player);
        }
        

    }
}
