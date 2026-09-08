namespace Rpg
{
    public class Inventory
    {
        private List<Weapon> weapons = new List<Weapon>();

        public void AddWeapon(Weapon weapon)
        {
            weapons.Add(weapon);
        }

        public void ShowWeapons()
        {
            Console.WriteLine("Inventory Weapons:");

            foreach (Weapon weapon in weapons)
            {
                Console.WriteLine($"- {weapon.Name}");
            }
        }
    }
}
