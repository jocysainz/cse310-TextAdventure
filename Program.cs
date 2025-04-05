#nullable enable
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Player Initialization
        Player player = new Player();
        Console.WriteLine("Enter your name:");
        player.Name = Console.ReadLine() ?? "Unnamed Hero";

        //Ask the player if they want to be warrior or mage
        //Default is warrior if theres an error
        Console.WriteLine("Choose your character type: Warrior or Mage");
        string charType = Console.ReadLine()?.ToLower() ?? "warrior";

        while (charType != "warrior" && charType != "mage")
        {
            Console.WriteLine("Invalid character type. Please choose either Warrior or Mage.");
            charType = Console.ReadLine()?.ToLower() ?? "warrior";
        }

        Character character = charType == "warrior" ? new Warrior() : new Mage();
        character.DisplayType();
        //Set progress and victory conditions
        int progress = 0;
        int victoryThreshold = 3;
        Random random = new Random();

        // Gameplay Loop
        while (character.Health > 0)
        {
            StoryScene? scene = SceneGenerator.GenerateScene(random);//Generate scene
            if (scene == null)
            {
                Console.WriteLine(":)");//output if the scene is null
                break;
            }

            scene.DisplayScene();

            Console.WriteLine("Choose an option (1 or 2):");//Ask user to choose between 1 and 2
            string? choice = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(choice))//Validate the choice to make sure its working
            {
                var selectedChoice = scene.Choices.Find(c => c.ChoiceNumber.ToString() == choice);
                
                if (selectedChoice.Equals(default(Choice)))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }
                //Determine the impact on the health based on their choice 
                int healthChange = selectedChoice.ChoiceNumber == 1 ? scene.HealthImpact : 10;
                character.Health += healthChange;
                Console.WriteLine($"Your health is now {character.Health}");

                //If theres a reward, it will be displaye its name and effect
                if (scene.Reward.HasValue)
                {
                    Console.WriteLine($"You found a {scene.Reward.Value.Name} that grants {scene.Reward.Value.Effect}!");
                }

                progress += selectedChoice.ChoiceNumber == 1 ? 1 : 0;//indicates a positive choice

                if (progress >= victoryThreshold)
                {
                    Console.WriteLine("Congratulations! You've completed your journey and emerged victorious with health intact!");
                    break;
                }//If the user wins, it will display a victory message.
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");//If not valid it will show this
            }

            // Check for lose condition
            if (character.Health <= 0)
            {
                Console.WriteLine("Game over! You ran out of health.");//If the user reaches below zero, it will show this
                break;
            }
        }
    }
}