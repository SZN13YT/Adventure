using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{
    class Rarity
    {
        public string rarity { get; set; }
        public Rarity(string rare = "common") 
        {
            this.rarity = rare;
        }
        public override string ToString()
        {
            switch (this.rarity.ToLower())
            {
                case "common":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "uncommon":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "rare":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "epic":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "legendary":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
            return "";

        }
    }
}
