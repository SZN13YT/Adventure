using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{
    class Scenes
    {
        string description;
        List<string> options;
        public Scenes(string desc = "You are in a dark room.", List<string> opts = null)
        {
            this.description = desc;
            this.options = opts ?? new List<string> { "Look around", "Move forward", "Check inventory" };
        }
        public void GoAway(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You decide to leave the market and continue your adventure elsewhere.");
            Console.WriteLine("Where would you like to go next?");
            Console.WriteLine(this.Left(player) + this.Right(player) + this.Up(player) + this.Down(player));
        }
        public void Left(Player player)
        {
            player.X -= 1;
        }
        public void Right(Player player)
        {
            player.X += 1;
        }
        public void Up(Player player)
        {
            player.Y += 1;
        }
        public void Down(Player player)
        {
            player.Y -= 1;
        }
    }
}
