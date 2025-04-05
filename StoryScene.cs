#nullable enable  
using System;
using System.Collections.Generic;
using System.Linq;

public struct Choice
{
    public string Option { get; set; }
    public string Description { get; set; }
    public int HealthImpact { get; set; }

    public Choice(string option, string description, int healthImpact)
    {
        Option = option;
        Description = description;
        HealthImpact = healthImpact;
    }
}

public class StoryScene
{
    public string Description { get; set; } = string.Empty;
    public List<Choice> Choices { get; set; } = new List<Choice>();
    public int HealthImpact { get; set; }
    public string? ItemReward { get; set; }

    public void DisplayScene()
    {
        Console.WriteLine(Description);
        foreach (var choice in Choices)
        {
            Console.WriteLine($"Option {choice.Option}: {choice.Description}");
        }
    }
}

public static class SceneGenerator
{
    private static List<int> unusedScenes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
    private static int maxScenes = 5;

    public static StoryScene? GenerateScene(Random random)
    {
        if (unusedScenes.Count == 0 || maxScenes <= 0)
        {
            Console.WriteLine("You've completed your journey and emerged victorious!");
            return null; 
        }

        int index = random.Next(unusedScenes.Count);
        int sceneType = unusedScenes[index];
        unusedScenes.Remove(sceneType);

        StoryScene scene = new StoryScene();
        switch (sceneType)
        {
            case 1:
                scene.Description = "You find yourself in a dense forest. Strange noises surround you.";
                scene.Choices.Add(new Choice("1", "Investigate the source of the noises", -50));
                scene.Choices.Add(new Choice("2", "Stay on the main path", 0));
                scene.HealthImpact = -50;
                break;
            case 2:
                scene.Description = "You approach a tall mountain. An icy wind breezes at you.";
                scene.Choices.Add(new Choice("1", "Brave the treacherous climb", -50));
                scene.Choices.Add(new Choice("2", "Take the safer path around", 0));
                scene.HealthImpact = -50;
                break;
            case 3:
                scene.Description = "You stumble upon an abandoned village. Shadows flicker in the dark.";
                scene.Choices.Add(new Choice("1", "Search the village for supplies", -30));
                scene.Choices.Add(new Choice("2", "Retreat to safety", 0));
                scene.HealthImpact = -30;
                break;
            case 4:
                scene.Description = "You enter a dark cave. The air is damp, and strange whispers fill the space.";
                scene.Choices.Add(new Choice("1", "Explore deeper into the cave", -20));
                scene.Choices.Add(new Choice("2", "Exit the cave before it's too late", 0));
                scene.HealthImpact = -20;
                break;
            case 5:
                scene.Description = "You come across a raging river blocking your path.";
                scene.Choices.Add(new Choice("1", "Try to swim across the river", -30));
                scene.Choices.Add(new Choice("2", "Look for a bridge upstream", 0));
                scene.HealthImpact = -30;
                break;
            case 6:
                scene.Description = "You find a mysterious glowing artifact on the ground.";
                scene.Choices.Add(new Choice("1", "Pick up the artifact", 0));
                scene.Choices.Add(new Choice("2", "Leave it and continue your journey", 0));
                scene.HealthImpact = 0;
                scene.ItemReward = "Mysterious Artifact";
                break;
            case 7:
                scene.Description = "You are ambushed by a pack of wild wolves!";
                scene.Choices.Add(new Choice("1", "Fight the wolves", -40));
                scene.Choices.Add(new Choice("2", "Run and escape", 0));
                scene.HealthImpact = -40;
                break;
            case 8:
                scene.Description = "You stumble upon a hidden treasure chest!";
                scene.Choices.Add(new Choice("1", "Open the chest", 0));
                scene.Choices.Add(new Choice("2", "Leave it unopened", 0));
                scene.HealthImpact = 0;
                scene.ItemReward = "Golden Necklace";
                break;
            default:
                throw new Exception("Invalid scene type generated");
        }

        maxScenes--;

        return scene;
    }
}