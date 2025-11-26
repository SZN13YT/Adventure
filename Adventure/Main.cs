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
            try
            {
                string p1 = Console.ReadLine();
                string[] Datas = File.ReadAllText(p1.Trim() + ".txt", Encoding.UTF8).Trim().Split("\n");

                

            }
            catch
            {
                File.Create("data.txt");

            }

            List<Item> baseicItems = [new Weapon(), new Armor(), new Armor(), new Potion()];
            Player player = new Player(hp:150, n:"Hero");
            player.Append([ new Weapon(iName:"Sword", d:25, minl:1, lvlr:1, dura:100, maxDura:100) , new Armor()]);
            // polimorfizmus nézz utána
            player.Equipp(player.inventory[0]);
            Console.WriteLine(player.inventory[0].itemName);
            player.Print();
        }
    }
}
