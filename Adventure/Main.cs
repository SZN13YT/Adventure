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
            
            
            List<Item> baseicItems = [new Weapon(), new Armor(), new Armor("Helmet", def:2, dura:150), new Potion()];
            Player player = new Player(hp:150, n:"Hero");
            player.Append([ new Weapon(iName:"Sword", d:25, lvlr:1, dura:100, maxDura:100) , new Armor()]);
            // polimorfizmus nézz utána

            player.Equipp(player.Inventory[0]);
            player.Print();
            player.LevelUp(lvl:2, hp:30, mp:15);
            player.Unequipp("hand1");
            player.Print();
        }
    }
}
