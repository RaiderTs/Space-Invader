using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public class PlayerMovement
{
    private readonly float _playerSpeed;
    private readonly Keyboard.Key _leftButton;
    private readonly Keyboard.Key _downButton;
    private readonly Keyboard.Key _upButton;
    private readonly Keyboard.Key _rightButton;

    public PlayerMovement(float playerSpeed, Keyboard.Key leftButton, Keyboard.Key downButton, Keyboard.Key upButton,
        Keyboard.Key rightButton)
    {
        _playerSpeed = playerSpeed;
        _leftButton = leftButton;
        _downButton = downButton;
        _upButton = upButton;
        _rightButton = rightButton;
    }

    public Vector2f GetNewPosition(Vector2f position)
    {
        if (Keyboard.IsKeyPressed(_leftButton))
        {
            position.X -= _playerSpeed;
        }

        if (Keyboard.IsKeyPressed(_rightButton))
        {
            position.X += _playerSpeed;
        }

        if (Keyboard.IsKeyPressed(_upButton))
        {
            position.Y -= _playerSpeed;
        }

        if (Keyboard.IsKeyPressed(_downButton))
        {
            position.Y += _playerSpeed;
        }

        return position;
    }
}