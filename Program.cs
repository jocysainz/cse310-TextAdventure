#nullable enable
using System;

class Program
{
    static void Main()
    {
        // Player Initialization
        Player player = new Player();
        Console.WriteLine("Enter your name:");
        player.Name = Console.ReadLine() ?? "Unnamed Hero";

        Console.WriteLine("Choose your character type: Warrior or Mage");
        string charType = Console.ReadLine()?.ToLower() ?? "warrior";

        while (charType != "warrior" && charType != "mage")
        {
            Console.WriteLine("Invalid character type. Please choose either Warrior or Mage.");
            charType = Console.ReadLine()?.ToLower() ?? "warrior";
        }

        Character character = charType == "warrior" ? new Warrior() : new Mage();
        character.DisplayType();

        int progress = 0;
        int victoryThreshold = 3;
        Random random = new Random();

        // Gameplay Loop
        while (player.Health > 0)
        {
            StoryScene? scene = SceneGenerator.GenerateScene(random);
            if (scene == null)
            {
                Console.WriteLine("Game over! No more scenes left.");
                break;
            }

            scene.DisplayScene();

            Console.WriteLine("Choose an option (1 or 2):");
            string? choice = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(choice) && scene.Choices.ContainsKey(choice))
            {
                int healthChange = choice == "1" ? -50 : +10;
                player.Health += healthChange;
                Console.WriteLine($"Your health is now {player.Health}");

                progress += choice == "1" ? 1 : 0;

                if (progress >= victoryThreshold)
                {
                    Console.WriteLine("Congratulations! You've completed your journey and emerged victorious with health intact!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            // Check for lose condition
            if (player.Health <= 0)
            {
                Console.WriteLine("Game over! You ran out of health.");
                break;
            }
        }
    }
}