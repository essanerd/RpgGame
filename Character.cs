namespace Rpg
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Shield { get; set; }

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int amount)
        {
            if (!IsAlive())
            {
                return;
            }

            Health -= amount;

            if (Health < 0)
            {
                Health = 0;
            }

            if (!IsAlive())
            {
                Console.WriteLine($"{Name} has been defeated!");
            }
        }

        public void Heal(int amount)
        {
            Health += amount;

            if (Health > 100)
            {
                Health = 100;
            }
        }

        public int GetHealth()
        {
            return Health;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public abstract void Attack(Character target);

        public void BlockAttack(int amount)
        {
            if (Shield >= amount)
            {
                Shield -= amount;

                Console.WriteLine($"Shield absorbed {amount} damage! Remaining shield: {Shield}");
            }
            else
            {
                int remainingDamage = amount - Shield;

                Shield = 0;

                Health -= remainingDamage;

                Console.WriteLine($"Shield broke! {remainingDamage} damage reached {Name}.");
            }
        }
    }
}
