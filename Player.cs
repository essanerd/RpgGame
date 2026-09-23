namespace Rpg
{
    public class Player : Character, IDamageable
    {
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Potions { get; set; }
        public int SpecialCooldown { get; set; }

        public Weapon Weapon { get; set; }
        public Inventory Inventory { get; set; }

        public Player(string name, int health, int level, Weapon weapon, Inventory inventory)
            : base(name, health)
        {
            Level = level;
            Weapon = weapon;
            Inventory = inventory;
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} attacks!");

            if (target.IsDodging)
            {
                Random random = new Random();
                int dodgeChance = random.Next(1, 101);

                if (dodgeChance <= 30) 
                {
                    Console.WriteLine($"{target.Name} dodged the attack!");
                    return;
                }

                else{
                Console.WriteLine($"{target.Name} failed to dodge!");
            }


        public void SpecialAttack(Character target)
{

        if (SpecialCooldown > 0)
{
    Console.WriteLine($"Special attack is on cooldown for {SpecialCooldown} more turns!");
    return;
}

    Console.WriteLine($"{Name} does a special attack!");

    if (target.IsDodging)
    {
        Random random = new Random();
        int dodgeChance = random.Next(1, 101);

        if (dodgeChance <= 30)
        {
            Console.WriteLine($"{target.Name} dodged the attack!");
            return;
        }
        else
        {
            Console.WriteLine($"{target.Name} failed to dodge!");
        }
    }

    int specialDamage = Weapon.Damage + Weapon.Damage / 2;
    target.TakeDamage(specialDamage);
    SpecialCooldown = 3;
}

            target.TakeDamage(Weapon.Damage);
            // Give XP if the player defeats an enemy
            if (!target.IsAlive())
            {
                if (target is Enemy enemy)
                {
                    int xpGained = enemy.ExperienceReward;

                    GainExperience(xpGained);
                }
            }
        }

        public void GainExperience(int xpGained)
        {
            Experience += xpGained;

            Console.WriteLine($"{Name} gained {xpGained} XP!");

            CheckLevelUp();
        }

        public void CheckLevelUp()
        {
            while (Experience >= 100)
            {
                Level += 1;
                Experience -= 100;

                Console.WriteLine($"{Name} leveled up to level {Level}!");
            }
        }

        public bool UsePotion()
        {
            if (Potions > 0)
            {
                Heal(20);
                Potions--;

                Console.WriteLine($"{Name} used a potion!");
                Console.WriteLine($"Potions remaining: {Potions}");
                Console.WriteLine($"Health: {Health}");

                return true;
            }
            else
            {
                Console.WriteLine("No potions left!");
                return false;
            }
        }
    }
}
