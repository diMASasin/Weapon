using System;

namespace Weapon
{
    class Weapon
    {
        private int _damage;
        private int _bullets;
        private int _bulletsPerShot;

        public Weapon(int damage, int bullets, int bulletsPerShot = 1)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            if (bullets < 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));
            if (bulletsPerShot < 1)
                throw new ArgumentOutOfRangeException(nameof(bulletsPerShot));

            _damage = damage;
            _bullets = bullets;
            _bulletsPerShot = bulletsPerShot; 
        }

        public void Fire(Player player)
        {
            if(_bullets < _bulletsPerShot)
                throw new ArgumentOutOfRangeException(nameof(_bullets));

            player.TakeDamage(_damage);
            _bullets -= _bulletsPerShot;
        }
    }

    class Player
    {
        private int _health;

        public Player(int health)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            _health = health;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _health -= damage;

            if (_health < 0)
                _health = 0;
        }
    }

    class Bot
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

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(1);
            Weapon weapon = new Weapon(2000, 100);
            Bot bot = new Bot(weapon);

            bot.OnSeePlayer(player);
        }
    }
}
