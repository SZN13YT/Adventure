using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.Swift;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Adventure
{   
    internal class Game
    {
        static void Main(string[] args)
        {
            
            
            List<Item> baseicItems = [new Weapon(), new Chestplate(), new Helmet(), new Potion(), new Ring(), new Ring(), new Ring()];
            Player player = new Player(hp:150, n:"Hero");
            player.Append([ new Weapon(iName:"Sword", d:25, lvlr:1, dura:100, maxDura:100) , new Chestplate()]);
            player.Append(baseicItems);
            // polimorfizmus nézz utána

            player.Equipp(player.Inventory[0]);
            player.Print();
            player.LevelUp(lvl:2, hp:30, mp:15);

            int n;
            do
            {
                player.Print();
                player.Equipp();
                n = int.Parse(Console.ReadLine());
            } while (n != 0);
            player.Print();
            Console.WriteLine(player.Inventory[2].itemName);
            player.Equipp(player.Inventory[2]);
            player.Print();
        }
    }
}
