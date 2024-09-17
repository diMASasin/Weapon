namespace Weapon
{
    public class Weapon
    {
        private int _bullets;
        private readonly int _damage;
        private readonly int _bulletsPerShot;

        private bool CanShoot => _bullets < _bulletsPerShot;

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
            if(CanShoot == true)
                throw new ArgumentOutOfRangeException(nameof(_bullets));

            player.TakeDamage(_damage);
            _bullets -= _bulletsPerShot;
        }
    }

    public class Player
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

    public class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            if(weapon == null)
                throw new ArgumentNullException(nameof(weapon));
            
            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));
            
            _weapon.Fire(player);
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            Player player = new Player(1);
            Weapon weapon = new Weapon(2000, 100);
            Bot bot = new Bot(weapon);

            bot.OnSeePlayer(player);
        }
    }
}