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
            Console.WriteLine();

            Console.WriteLine($"Enemy: {orc.Name}");
            Console.WriteLine($"Health: {orc.Health}");
            Console.WriteLine();

            inventory.ShowWeapons();

            Console.WriteLine();
            Console.WriteLine("===== BATTLE START =====");

            // =========================
            // COMBAT LOOP
            // =========================

            while (joe.IsAlive() && orc.IsAlive())
            {
                Console.WriteLine();
                Console.WriteLine("===== YOUR TURN =====");
                Console.WriteLine($"Health: {joe.Health}");
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

                // =========================
                // PLAYER ACTION
                // =========================

                switch (choice)
                {
                    // ATTACK
                    case "1":

                        joe.Attack(orc);

                        Console.WriteLine($"Orc health: {orc.Health}");

                        break;

                    // POTION
                    case "2":

                        if (!joe.UsePotion())
                        {
                            // No potion was used.
                            // Give Joe another turn.
                            continue;
                        }

                        break;

                    // INVENTORY
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

                        // Inventory doesn't count as an attack.
                        continue;

                    // INVALID OPTION
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
                // ORC'S TURN
                // =========================

                Console.WriteLine();
                Console.WriteLine("===== ORC'S TURN =====");

                orc.Attack(joe);

                Console.WriteLine($"Joe health: {joe.Health}");
            }

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
