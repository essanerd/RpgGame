namespace Rpg
{
    public class Enemy : Character
    {
        public int ExperienceReward { get; set; }
        public Weapon Weapon { get; set; }

        private Random random = new Random();

        public Enemy(string name, int health, int experienceReward, Weapon weapon)
            : base(name, health)
        {
            ExperienceReward = experienceReward;
            Weapon = weapon;
        }

        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} attacks!");
            target.TakeDamage(Weapon.Damage);
        }

        public void ChooseAction(Character target)
        {
            int choice = random.Next(1, 3);

            if (choice == 1)
            {
                IsDodging = false;
                Attack(target);
            }
            else
            {
                IsDodging = true;
                Console.WriteLine($"{Name} prepares to dodge!");
            }
        }
    }
}
