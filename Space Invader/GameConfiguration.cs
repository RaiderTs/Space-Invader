using Newtonsoft.Json;
using SFML.Window;

namespace Space_Invaders;

public class GameConfiguration
{
    public int Height { get; init; }
    public int Width { get; init; }
    public string Title { get; init; }

    public float PlayerSpeed { get; init; }
    public Keyboard.Key PlayerMovingLeftButton { get; init; }
    public Keyboard.Key PlayerMovingRightButton { get; init; }
    public Keyboard.Key PlayerMovingUpButton { get; init; }
    public Keyboard.Key PlayerMovingDownButton { get; init; }
    public Keyboard.Key PlayerShootingButton { get; init; }
    public float PlayerShootingCooldown { get; init; }
    public float BulletSpeed { get; init; }
    public float BulletRadius { get; init; }

    public GameConfiguration(string jsonPath)
    {
        string jsonString = File.ReadAllText(jsonPath);
        JsonConvert.PopulateObject(jsonString, this);
    }
}