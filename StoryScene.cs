using System;
using System.Collections.Generic;

//Structure for storing a choice in a scene
public struct Choice
{
    public string ChoiceText { get; }
    public int ChoiceNumber { get; }

    //Constructor to initialize the choice text and number
    public Choice(string choiceText, int choiceNumber)
    {
        ChoiceText = choiceText;
        ChoiceNumber = choiceNumber;
    }
}

//Structure for storing item rewards
public struct ItemReward
{
    public string Name { get; }
    public string Effect { get; }

    //Constructor to initialize item name and effect
    public ItemReward(string name, string effect)
    {
        Name = name;
        Effect = effect;
    }
}

//Class representing a story scene with choices and rewards
public class StoryScene
{
    public string Description { get; set; } = string.Empty;//Scene description
    public List<Choice> Choices { get; set; } = new List<Choice>();//Possible choices
    public int HealthImpact { get; set; } = -50;//Health change from the scene
    public ItemReward? Reward { get; set; } = null;// Optional reward

    //Display the scene description and choices
    public void DisplayScene()
    {
        Console.WriteLine(Description);
        foreach (var choice in Choices)
        {
            Console.WriteLine($"Option {choice.ChoiceNumber}: {choice.ChoiceText}");
        }

        if (Reward.HasValue)
        {
            Console.WriteLine($"You found a {Reward.Value.Name} that grants {Reward.Value.Effect}!");
        }
    }
}

//Static class responsible for generating story scenes
public static class SceneGenerator
{
    private static List<int> unusedScenes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };  //Available scene types
    private static int maxScenes = 5;  // Maximum number of scenes to generate

    // Generate a random scene
    public static StoryScene? GenerateScene(Random random)
    {
        //If no scenes are left or max scenes are exhausted return null
        if (unusedScenes.Count == 0 || maxScenes <= 0)
        {
            Console.WriteLine("You've completed your journey and emerged victorious!");
            return null; 
        }

        //Select a random scene and remove it from available scenes
        int index = random.Next(unusedScenes.Count);
        int sceneType = unusedScenes[index];
        unusedScenes.Remove(sceneType);

        //Create and configure the scene based on the selected type
        StoryScene scene = new StoryScene();
        switch (sceneType)
        {
            //Different case blocks for each scene type with descriptions and choices
            case 1:
                scene.Description = "You find yourself in a dense forest. Strange noises surround you.";
                scene.Choices.Add(new Choice("Investigate the source of the noises", 1));
                scene.Choices.Add(new Choice("Stay on the main path", 2));
                scene.HealthImpact = -50;
                break;
            case 2:
                scene.Description = "You approach a tall mountain. An icy wind breezes at you.";
                scene.Choices.Add(new Choice("Brave the treacherous climb", 1));
                scene.Choices.Add(new Choice("Take the safer path around", 2));
                scene.HealthImpact = -50;
                break;
            case 3:
                scene.Description = "You stumble upon an abandoned village. Shadows flicker in the dark.";
                scene.Choices.Add(new Choice("Search the village for supplies", 1));
                scene.Choices.Add(new Choice("Retreat to safety", 2));
                scene.HealthImpact = -50;
                break;
            case 4:
                scene.Description = "You enter a dark cave. The air is damp, and strange whispers fill the space.";
                scene.Choices.Add(new Choice("Explore deeper into the cave", 1));
                scene.Choices.Add(new Choice("Exit the cave before it's too late", 2));
                scene.HealthImpact = -20;
                break;
            case 5:
                scene.Description = "You come across a raging river blocking your path.";
                scene.Choices.Add(new Choice("Try to swim across the river", 1));
                scene.Choices.Add(new Choice("Look for a bridge upstream", 2));
                scene.HealthImpact = -30;
                break;
            case 6:
                scene.Description = "You find a mysterious glowing artifact on the ground.";
                scene.Choices.Add(new Choice("Pick up the artifact", 1));
                scene.Choices.Add(new Choice("Leave it and continue your journey", 2));
                scene.HealthImpact = 0;
                scene.Reward = new ItemReward("Mysterious Artifact", "Enhances your magical abilities");
                break;
            case 7:
                scene.Description = "You are ambushed by a pack of wild wolves!";
                scene.Choices.Add(new Choice("Fight the wolves", 1));
                scene.Choices.Add(new Choice("Run and escape", 2));
                scene.HealthImpact = -40;
                break;
            case 8:
                scene.Description = "You stumble upon a hidden treasure chest!";
                scene.Choices.Add(new Choice("Open the chest", 1));
                scene.Choices.Add(new Choice("Leave it unopened", 2));
                scene.HealthImpact = 0;
                scene.Reward = new ItemReward("Golden Necklace", "Grants you luck");
                break;
            default:
                throw new Exception("Invalid scene type generated");
        }

        maxScenes--;//Decrease the available scene count
        return scene;//Return the generated scene
    }
}