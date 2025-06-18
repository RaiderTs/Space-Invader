using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
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

        _background = new Sprite(TextureManager.BackgroundTexture);

        _player = CreatePlayer(gameConfiguration);
    }

    private Player CreatePlayer(GameConfiguration gameConfiguration)
    {
        var shootingManager = new ShootingManager(gameConfiguration.PlayerShootingCooldown,
            gameConfiguration.BulletSpeed, gameConfiguration.BulletRadius);
        
        var playerSpawnPosition = GetPlayerSpawnPosition(gameConfiguration, TextureManager.PlayerTexture);
        var playerMovement = new PlayerMovement(gameConfiguration.PlayerSpeed, gameConfiguration.PlayerMovingLeftButton,
            gameConfiguration.PlayerMovingDownButton, gameConfiguration.PlayerMovingUpButton,
            gameConfiguration.PlayerMovingRightButton);
        return new Player(shootingManager, gameConfiguration.PlayerShootingButton, TextureManager.PlayerTexture,
            playerSpawnPosition, playerMovement);
    }


    private Vector2f GetPlayerSpawnPosition(GameConfiguration gameConfiguration, Texture texture)
    {
        var screenCenter = new Vector2f(gameConfiguration.Width / 2f, gameConfiguration.Height / 2f);
        var playerSpawnPosition = screenCenter - (Vector2f)texture.Size / 2f;
        return playerSpawnPosition;
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