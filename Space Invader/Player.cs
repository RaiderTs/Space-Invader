using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public class Player
{
    private const float PLAYER_SPEED = 4f;
    private Sprite _sprite;
    private readonly ShootingManager _shootingManager;
    private readonly Keyboard.Key _shootingButton;

    public Player(ShootingManager shootingManager, Keyboard.Key shootingButton, GameConfiguration gameConfiguration)
    {
        _sprite = new Sprite(TextureManager.PlayerTexture);
        _sprite.Texture = TextureManager.PlayerTexture;
        var spriteSize = new Vector2f(_sprite.TextureRect.Width, _sprite.TextureRect.Height);
        var screenCenter = new Vector2f(gameConfiguration.Width / 2f, gameConfiguration.Height / 2f);
        var startPosition = screenCenter - spriteSize / 2f;
        _sprite.Position = startPosition;

        _shootingManager = shootingManager;
        _shootingButton = shootingButton;
    }


    private Vector2f GetBulletSpawnPosition()
    {
        var halfSpriteSizeX = new Vector2f(_sprite.TextureRect.Width / 2f, 0f);
        var bulletSpawnPosition = _sprite.Position + halfSpriteSizeX;
        return bulletSpawnPosition;
    }

    public void Draw(RenderWindow window)
    {
        window.Draw(_sprite);
        _shootingManager.Draw(window);
    }

    private void Move()
    {
        bool shouldMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
        bool shouldMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
        bool shouldMoveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
        bool shouldMoveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);
        bool shouldMove = shouldMoveLeft || shouldMoveRight || shouldMoveUp || shouldMoveDown;

        if (!shouldMove)
        {
            return;
        }

        var position = _sprite.Position;

        if (shouldMoveLeft)
        {
            position.X -= PLAYER_SPEED;
        }

        if (shouldMoveRight)
        {
            position.X += PLAYER_SPEED;
        }

        if (shouldMoveUp)
        {
            position.Y -= PLAYER_SPEED;
        }

        if (shouldMoveDown)
        {
            position.Y += PLAYER_SPEED;
        }

        _sprite.Position = position;
    }

    public void Update()
    {
        Move();
        if (Keyboard.IsKeyPressed(_shootingButton))
        {
            var bulletSpawnPosition = GetBulletSpawnPosition();
            _shootingManager.TryShoot(bulletSpawnPosition);
        }

        _shootingManager.Update();
    }
}