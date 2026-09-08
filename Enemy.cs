namespace Rpg
{
    public class Enemy : Character
    {
        public int ExperienceReward { get; set; }
        public Weapon Weapon { get; set; }

        public Enemy(string name, int health, int experienceReward, Weapon weapon) 
            : base(name, health)
        {
            ExperienceReward = experienceReward;
            Weapon = weapon;
        }

        public override void Attack(Character target)
        {
            target.TakeDamage(Weapon.Damage);
        }
    }
}
