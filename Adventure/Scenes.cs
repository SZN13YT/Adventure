using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{
    class Scenes
    {
        public List<string> Options { get; set; }
        public List<Scene> Sn { get; set; }
        public Scenes(List<string> opts = null, Scene sc = null, List<string> opt = null)
        {
            this.Options = opt ?? new List<string> { "Forest", "Town",  };
            if (sc != null)
            {
                sc.Options = opts ?? new List<string> { "Look around", "Move forward", "Check inventory" };
                this.Sn = new List<Scene> { sc };
            }
            else
            {
                this.Sn = new List<Scene> { new Scene(n: "Starting Point", description: "You find yourself at the beginning of your adventure.", x: 0, y: 0, sceneId: 0, options: opts) };
            }
        }
        private Scene SelectScene(int x = 0, int y = 0)   
        {
            foreach (Scene sc in this.Sn)
            {
                if (sc.X == x && sc.Y == y)
                {
                    return sc;
                }
            }
            return null;
        }
        public void GoAway(Player player, string direct = null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Scene curr = this.SelectScene(player.X, player.Y);
            Console.WriteLine($"You decide to leave the {curr.Name} and continue your adventure elsewhere.");
            if (direct == null)
            {
                Console.WriteLine("Where would you like to go next?");
                Console.WriteLine($"{this.Left(player)} {this.Right(player)} {this.Up(player)} {this.Down(player)}"); 
            }
            else
            {
                string Message = direct.ToLower() switch
                {
                    "left" => this.Left(player, Go: true),
                    "right" => this.Right(player, Go: true),
                    "up" => this.Up(player, Go: true),
                    "down" => this.Down(player, Go: true),
                    _ => "You stand still, unsure of where to go."
                };
                Console.WriteLine(Message);
                        
            }
        }
        public string Left(Player player, bool Go = false)
        {
            Scene s = this.SelectScene(player.X - 1, player.Y);
            if (s != null)
            {
                if (Go)
                {
                    player.X -= 1;
                    return "You went to the " + s.Name;
                }
                return s.Name;
            }
            return "You can't go that way.";
        }
        public string Right(Player player, bool Go = false)
        {
            Scene s = SelectScene(player.X + 1, player.Y);
            if (s == null)
            {
                this.NewScene(x: player.X + 1, y: player.Y);
                s = SelectScene(player.X + 1, player.Y);
            }
            if (Go)
            {
                player.X += 1;
                return "You went to the " + s.Name;
            }
            return s.Name;
        }
        public string Up(Player player, bool Go = false)
        {
            Scene s = SelectScene(player.X, player.Y + 1);
            if (s == null)
            {
                this.NewScene(x: player.X, y: player.Y + 1);
                s = SelectScene(player.X, player.Y + 1);
            }
            if (Go)
            {
                player.Y += 1;
                return "You went to the " + s.Name;
            }
            return s.Name;
        }
        public string Down(Player player, bool Go = false)
        {
            Scene s = SelectScene(player.X, player.Y - 1);
            if (s == null)
            {
                this.NewScene(x: player.X, y: player.Y - 1);
                s = SelectScene(player.X, player.Y - 1);
            }
            if (Go)
            {
                player.Y -= 1;
                return "You went to the " + s.Name;
            }
            return s.Name;
        }
        public void NewScene(string n = null, string desc = null, int x = 0, int y = 0)
        {
            Random ran = new Random();
            Scene random = ;
            if (n == null)
            {
                n = random.Name;
            }
            if (desc == null)
            {
                desc = random.Description;
            }
            this.Sn.Add(new Scene(n: n, description: desc, x: x, y: y, sceneId: Sn[Sn.Count() - 1].SceneId + 1));
        }
    }
}
