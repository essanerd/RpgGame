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
            target.TakeDamage(Weapon.Damage);
        }

        public void ChooseDefense()
        {

            int OrcChoice = random.Next(1, 3);

            if(OrcChoice == 1){

                 IsDodging = false;
                    Console.WriteLine("The Orc does not defend.");
            }
            else{
                    IsDodging = true;
                    Console.WriteLine("The Orc prepares to dodge!");
            }
        }
    }
}
