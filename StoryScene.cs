#nullable enable  
using System;
using System.Collections.Generic;

public class StoryScene
{
    public string Description { get; set; } = string.Empty;
    public Dictionary<string, string> Choices { get; set; } = new Dictionary<string, string>();
    public int HealthImpact { get; set; } = -50;
    public string? ItemReward { get; set; } = null;

    public void DisplayScene()
    {
        Console.WriteLine(Description);
        foreach (var choice in Choices)
        {
            Console.WriteLine($"Option {choice.Key}: {choice.Value}");
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
                scene.Choices = new Dictionary<string, string>
                {
                    { "1", "Investigate the source of the noises" },
                    { "2", "Stay on the main path" }
                };
                scene.HealthImpact = -50; 
                break;
            case 2:
                scene.Description = "You approach a tall mountain. An icy wind breezes at you.";
                scene.Choices = new Dictionary<string, string>
                {
                    { "1", "Brave the treacherous climb" },
                    { "2", "Take the safer path around" }
                };
                scene.HealthImpact = -50; 
                break;
            case 3:
                scene.Description = "You stumble upon an abandoned village. Shadows flicker in the dark.";
                scene.Choices = new Dictionary<string, string>
                {
                    { "1", "Search the village for supplies" },
                    { "2", "Retreat to safety" }
                };
                scene.HealthImpact = -50; 
                break;
            case 4:
                scene.Description = "You enter a dark cave. The air is damp, and strange whispers fill the space.";
                scene.Choices = new Dictionary<string, string>
                {
                    { "1", "Explore deeper into the cave" },
                    { "2", "Exit the cave before it's too late" }
                };
                scene.HealthImpact = -20; 
                break;
            case 5:
                scene.Description = "You come across a raging river blocking your path.";
                scene.Choices = new Dictionary<string, string>
                {
                    { "1", "Try to swim across the river" },
                    { "2", "Look for a bridge upstream" }
                };
                scene.HealthImpact = -30; 
                break;
            case 6:
                scene.Description = "You find a mysterious glowing artifact on the ground.";
                scene.Choices = new Dictionary<string, string>
                {
                    { "1", "Pick up the artifact" },
                    { "2", "Leave it and continue your journey" }
                };
                scene.HealthImpact = 0; 
                scene.ItemReward = "Mysterious Artifact"; 
                break;
            case 7:
                scene.Description = "You are ambushed by a pack of wild wolves!";
                scene.Choices = new Dictionary<string, string>
                {
                    { "1", "Fight the wolves" },
                    { "2", "Run and escape" }
                };
                scene.HealthImpact = -40; 
                break;
            case 8:
                scene.Description = "You stumble upon a hidden treasure chest!";
                scene.Choices = new Dictionary<string, string>
                {
                    { "1", "Open the chest" },
                    { "2", "Leave it unopened" }
                };
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