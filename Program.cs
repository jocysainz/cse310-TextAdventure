﻿#nullable enable
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
        while (character.Health > 0)
        {
            StoryScene? scene = SceneGenerator.GenerateScene(random);
            if (scene == null)
            {
                Console.WriteLine(":)");
                break;
            }

            scene.DisplayScene();

            Console.WriteLine("Choose an option (1 or 2):");
            string? choice = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(choice) && int.TryParse(choice, out int choiceIndex) && choiceIndex >= 1 && choiceIndex <= scene.Choices.Count)
            {
                Choice selectedChoice = scene.Choices[choiceIndex - 1];
                character.Health += selectedChoice.HealthImpact;
                Console.WriteLine($"Your health is now {character.Health}");

                if (!string.IsNullOrEmpty(scene.ItemReward))
                {
                    Console.WriteLine($"You found a {scene.ItemReward}!");
                }

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
            if (character.Health <= 0)
            {
                Console.WriteLine("Game over! You ran out of health.");
                break;
            }
        }
    }
}