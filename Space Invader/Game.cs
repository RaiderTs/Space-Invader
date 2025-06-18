using Newtonsoft.Json;
using SFML.Graphics;
using SFML.Window;

namespace Space_Invaders;

public class Game
{
    private readonly RenderWindow _window;
    private readonly Sprite _background;
    private readonly Player _player;

    public Game(GameConfiguration gameConfiguration)
    {
        var mode = new VideoMode((uint)gameConfiguration.Width, (uint)gameConfiguration.Height);
        _window = new RenderWindow(mode, gameConfiguration.Title);

        _window.SetVerticalSyncEnabled(true);
        _window.Closed += (_, _) => _window.Close();

        _background = new Sprite();
        _background.Texture = TextureManager.BackgroundTexture;

        var shootingManager = new ShootingManager(0.5f, 20f, 3f);
        _player = new Player(shootingManager, Keyboard.Key.Space, gameConfiguration);
    }

    public void Run()
    {
        while (_window.IsOpen)
        {
            HandleEvents();
            Update();
            Draw();
        }
    }

    private void HandleEvents()
    {
        _window.DispatchEvents();
    }

    private void Update()
    {
        _player.Update();
    }

    private void Draw()
    {
        _window.Draw(_background);
        _player.Draw(_window);
        _window.Display();
    }
}