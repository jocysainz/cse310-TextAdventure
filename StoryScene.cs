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
    private static List<int> unusedScenes = new List<int> { 1, 2, 3 };
    public static StoryScene GenerateScene(Random random)
    {
        if (unusedScenes.Count == 0)
        {
            Console.WriteLine("Game over! No more scenes left.");
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
                scene.HealthImpact = -50; // Major health loss for investigating
                break;
            case 2:
                scene.Description = "You approach a tall mountain. An icy wind breezes at you.";
                scene.Choices = new Dictionary<string, string>
                {
                    { "1", "Brave the treacherous climb" },
                    { "2", "Take the safer path around" }
                };
                scene.HealthImpact = -50; // Major health loss for climbing
                break;
            case 3:
                scene.Description = "You stumble upon an abandoned village. Shadows flicker in the dark.";
                scene.Choices = new Dictionary<string, string>
                {
                    { "1", "Search the village for supplies" },
                    { "2", "Retreat to safety" }
                };
                scene.HealthImpact = -50; // Major health loss for searching
                break;
            default:
                throw new Exception("Invalid scene type generated");
        }

        return scene;
    }
}
