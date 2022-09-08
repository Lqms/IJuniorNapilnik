using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Инкапсуляция1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Weapon
    {
        public int Damage;
        public int Bullets;

        public void Fire(Player player)
        {
            player.Health -= Damage;
            Bullets -= 1;
        }
    }

    class Player
    {
        public int Health;
    }

    class Bot
    {
        public Weapon Weapon;

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }
}
