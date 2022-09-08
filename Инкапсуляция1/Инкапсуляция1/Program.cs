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
            Player player = new Player("Bob", 100);
            Weapon gun = new Weapon(1, 35);
            Bot bot = new Bot(gun);

            bot.OnSeePlayer(player);
        }
    }

    public class Weapon
    {
        private int _bullets;
        private int _damage;

        public Weapon(int bullets, int damage)
        {
            if (bullets <= 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _bullets = bullets;
            _damage = damage;
        }

        public void Fire(Player player)
        {
            if (_bullets <= 0)
                throw new InvalidOperationException("Нельзя стрелять без патрон в обойме!");

            _bullets--;
            Console.WriteLine($"Бах! В обойме осталось {_bullets} пуль");
            player.ApplyDamage(_damage);
        }
    }

    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }

        public Player(string name, int health)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            Name = name;
            Health = health;
        }

        public void ApplyDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            Health -= damage;
            Console.WriteLine($"{Name} получил {damage} ед. урона, у него осталось {Health} здоровья");
        }
    }

    public class Bot
    {
        private Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}
