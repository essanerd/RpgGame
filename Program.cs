```csharp
namespace Rpg
{
    class Program
    {
        static void Main(string[] args)
        {
            // =========================
            // WEAPONS
            // =========================

            Weapon mace = new Weapon("Mace", 30);
            Weapon axe = new Weapon("Axe", 20);
            Weapon sword = new Weapon("Sword", 40);

            // =========================
            // INVENTORY
            // =========================

            Inventory inventory = new Inventory();

            inventory.AddWeapon(mace);
            inventory.AddWeapon(axe);
            inventory.AddWeapon(sword);

            // =========================
            // PLAYER
            // =========================

            Player joe = new Player("Joe", 100, 5, mace, inventory);

            joe.Potions = 3;
            joe.Shield = 50;

            // =========================
            // ENEMY
            // =========================

            Enemy orc = new Enemy("Orc", 200, 25, axe);

            // =========================
            // STARTING INFORMATION
            // =========================

            Console.WriteLine("===== RPG GAME =====");
            Console.WriteLine();

            Console.WriteLine($"Player: {joe.Name}");
            Console.WriteLine($"Level: {joe.Level}");
            Console.WriteLine($"Health: {joe.Health}");
            Console.WriteLine($"Potions: {joe.Potions}");
            Console.WriteLine($"Shield: {joe.Shield}");
            Console.WriteLine();

            Console.WriteLine($"Enemy: {orc.Name}");
            Console.WriteLine($"Health: {orc.Health}");
            Console.WriteLine();

            inventory.ShowWeapons();

            Console.WriteLine();
            Console.WriteLine("===== BATTLE START =====");

            Random random = new Random();

            // =========================
            // COMBAT LOOP
            // =========================

            while (joe.IsAlive() && orc.IsAlive())
            {
                // =========================
                // JOE'S ACTION
                // =========================

                Console.WriteLine();
                Console.WriteLine("===== YOUR TURN =====");
                Console.WriteLine($"Health: {joe.Health}");
                Console.WriteLine($"Shield: {joe.Shield}");
                Console.WriteLine($"Level: {joe.Level}");
                Console.WriteLine($"XP: {joe.Experience}");
                Console.WriteLine($"Potions: {joe.Potions}");
                Console.WriteLine($"Equipped Weapon: {joe.Weapon.Name}");
                Console.WriteLine();

                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Potion");
                Console.WriteLine("3. Inventory");

                Console.Write("Choose an action: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    // =========================
                    // ATTACK
                    // =========================

                    case "1":

                        // Check if Orc is dodging
                        if (orc.IsDodging)
                        {
                            Console.WriteLine("The Orc dodged your attack!");
                            orc.IsDodging = false;
                        }
                        else
                        {
                            joe.Attack(orc);
                            Console.WriteLine($"Orc health: {orc.Health}");
                        }

                        break;

                    // =========================
                    // POTION
                    // =========================

                    case "2":

                        if (!joe.UsePotion())
                        {
                            continue;
                        }

                        break;

                    // =========================
                    // INVENTORY
                    // =========================

                    case "3":

                        Console.WriteLine();
                        Console.WriteLine("===== INVENTORY =====");

                        inventory.ShowWeapons();

                        Console.Write("Choose a weapon: ");
                        string weaponChoice = Console.ReadLine();

                        if (weaponChoice == "1")
                        {
                            joe.EquipWeapon(inventory.GetWeapon(0));
                            Console.WriteLine("Joe equipped the Mace!");
                        }
                        else if (weaponChoice == "2")
                        {
                            joe.EquipWeapon(inventory.GetWeapon(1));
                            Console.WriteLine("Joe equipped the Axe!");
                        }
                        else if (weaponChoice == "3")
                        {
                            joe.EquipWeapon(inventory.GetWeapon(2));
                            Console.WriteLine("Joe equipped the Sword!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid weapon choice!");
                        }

                        continue;

                    default:

                        Console.WriteLine("Invalid choice!");
                        continue;
                }

                // =========================
                // CHECK IF ORC DIED
                // =========================

                if (!orc.IsAlive())
                {
                    break;
                }

                // =========================
                // JOE'S DEFENSE
                // =========================

                Console.WriteLine();
                Console.WriteLine("===== CHOOSE YOUR DEFENSE =====");
                Console.WriteLine("1. Shield");
                Console.WriteLine("2. Dodge");
                Console.WriteLine("3. Nothing");

                Console.Write("Choose your defense: ");
                string defenseChoice = Console.ReadLine();

                if (defenseChoice == "1")
                {
                    joe.IsShielding = true;
                    joe.IsDodging = false;

                    Console.WriteLine("Joe raised his shield!");
                }
                else if (defenseChoice == "2")
                {
                    joe.IsDodging = true;
                    joe.IsShielding = false;

                    Console.WriteLine("Joe is ready to dodge!");
                }
                else if (defenseChoice == "3")
                {
                    joe.IsShielding = false;
                    joe.IsDodging = false;

                    Console.WriteLine("Joe chose no defense.");
                }
                else
                {
                    Console.WriteLine("Invalid defense choice!");
                    continue;
                }

                // =========================
                // ORC'S TURN
                // =========================

                Console.WriteLine();
                Console.WriteLine("===== ORC'S TURN =====");

                // Joe dodges
                if (joe.IsDodging)
                {
                    int dodgeChance = random.Next(1, 101);

                    if (dodgeChance <= 30)
                    {
                        Console.WriteLine("Joe dodged the Orc's attack!");
                    }
                    else
                    {
                        Console.WriteLine("Joe failed to dodge!");

                        orc.Attack(joe);
                    }
                }

                // Joe uses shield
                else if (joe.IsShielding)
                {
                    Console.WriteLine("Joe blocks the attack with his shield!");

                    joe.BlockAttack(orc.Weapon.Damage);
                }

                // Joe has no defense
                else
                {
                    orc.Attack(joe);
                }

                // Reset Joe's defense
                joe.IsDodging = false;
                joe.IsShielding = false;

                Console.WriteLine($"Joe health: {joe.Health}");

                // =========================
                // CHECK IF JOE DIED
                // =========================

                if (!joe.IsAlive())
                {
                    break;
                }

                // =========================
                // ORC CHOOSES DEFENSE
                // =========================
                
                orc.ChooseDefense();

            // =========================
            // BATTLE OVER
            // =========================

            Console.WriteLine();
            Console.WriteLine("===== BATTLE OVER =====");

            if (!joe.IsAlive())
            {
                Console.WriteLine("Joe has been defeated!");
            }
            else
            {
                Console.WriteLine("Orc has been defeated!");
                Console.WriteLine($"Joe's final level: {joe.Level}");
                Console.WriteLine($"Joe's remaining XP: {joe.Experience}");
            }
        }
    }
}
```

