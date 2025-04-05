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

        // Story Scene Initialization
        StoryScene scene = new StoryScene
        {
            Description = "You stand at a crossroads. Do you take the path to the forest or the mountain?",
            Choices = new Dictionary<string, int>
            {
                { "1", -10 }, // Simplified keys for easier input handling
                { "2", -20 }
            }
        };

        // Gameplay Loop
        while (player.Health > 0)
        {
            scene.DisplayScene();
            Console.WriteLine("Choose an option (1 or 2):");
            string? choice = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(choice) && scene.Choices.TryGetValue(choice, out int healthChange))
            {
                player.Health += healthChange;
                Console.WriteLine($"Your health is now {player.Health}");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("Game over! You ran out of health.");
            }
        }
    }
}