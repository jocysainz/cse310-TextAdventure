using System;

class Program
{
    static void Main()
    {
        // Player Initialization
        Player player = new Player();
        Console.WriteLine("Enter your name:");
        player.Name = Console.ReadLine() ?? "Unnamed Hero";
        player.Health = 100;

        Console.WriteLine("Choose your character type: Warrior or Mage");
        string charType = Console.ReadLine()?.ToLower() ?? "warrior";
        Character character = charType == "warrior" ? new Warrior() : new Mage();
        character.DisplayType();

        int progress = 0;
        int victoryThreshold = 5;
        Random random = new Random();

        // Gameplay Loop
        while (player.Health > 0)
        {
            StoryScene scene = SceneGenerator.GenerateScene(random);
            scene.DisplayScene();

            Console.WriteLine("Choose an option (1 or 2):");
            string? choice = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(choice) && scene.Choices.ContainsKey(choice))
            {
                int healthChange = choice == "1" ? -10 : +10;
                player.Health += healthChange;
                Console.WriteLine($"Your health is now {player.Health}");

                progress += choice == "1" ? 1 : 0;

                if (progress >= victoryThreshold)
                {
                    Console.WriteLine("Congratulations! You've braved the challenges and emerged victorious!");
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
            }
        }
    }
}