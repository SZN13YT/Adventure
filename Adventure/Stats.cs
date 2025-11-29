using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace Adventure
{
    class Stats
    {
        public int MaxHp { get; internal set; }
        public int MaxDEF { get; internal set; }
        public int MaxDMG { get; internal set; }
        public int MaxMP { get; internal set; }
        public int MaxXp { get; internal set; }

        public string Name { get; internal set; }
        public string Cast { get; internal set; }
        public int Level { get; internal set; }
        public int Xp { get; internal set; }

        public int Hp { get; internal set; }
        public int DMG { get; internal set; }
        public int DEF { get; internal set; }
        public int MP { get; internal set; }
        public int Healing { get; internal set; }
        public Stats(int hp, int mp, string n, int lvl, string cast, int sHeal, int dmg, int def, int xp) 
        {
            this.MaxHp = hp;
            this.MaxMP = mp;
            this.MaxDMG = dmg;
            this.MaxDEF = def;
            this.MaxXp = lvl * 100;

            this.Name = n;
            this.Cast = cast;
            this.Level = lvl;
            this.Xp = xp;

            this.Hp = hp;
            this.DEF = def;
            this.DMG = dmg;
            this.MP = mp;
            this.Healing = sHeal;
        }
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"Name: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(this.Name);
            this.Hp = 20;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"Health: ");
            Console.ForegroundColor = this.Hp > this.MaxXp*0.1? this.Hp > this.MaxHp * 0.7? ConsoleColor.Green: ConsoleColor.DarkYellow: ConsoleColor.DarkRed;
            Console.Write(this.Hp);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"/{this.MaxHp}");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"Level: ");
            Console.WriteLine(this.Level);

            if (this.MaxMP != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"Mana: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(this.MP);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"/{this.MaxMP}");
            }

            if (this.Cast != "None")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Cast: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(this.Cast);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"DMG: {this.DMG}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"DEF: {this.DEF}");
            Console.ResetColor();
        }
        public void LevelUp(int lvl = 1, int hp = 20, int mp = 10, int dmg = 10, int def = 7)
        {
            this.Level += lvl;
            this.MaxHp += hp;
            this.Hp = this.MaxHp;
            this.MaxMP += mp;
            this.MP = this.MaxMP;
            this.DMG += dmg;
            this.MaxXp = this.Level * 100;
            this.Xp = 0;
            this.DEF += def;
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n\nCongratulations! You have reached ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(this.Level);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" level!\n\n");
            Console.ResetColor();
        }
    }
}
