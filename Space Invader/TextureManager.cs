using SFML.Graphics;

namespace Space_Invaders;

public static class TextureManager
{
    private const string ASSETS_PATH = @"G:\C#\Проекты\Space Invader\Space Invader\Assets";
    private const string BACKGROUND_TEXTURE_PATH = "/Backgrounds/blueBG.png";
    private const string PLAYER_TEXTURE_PATH = "/Ships/playerShip2_red.png";
    
    public static Texture BackgroundTexture;
    public static Texture PlayerTexture;
    
    static TextureManager()
    {
        BackgroundTexture = new Texture(ASSETS_PATH + BACKGROUND_TEXTURE_PATH);
        PlayerTexture = new Texture(ASSETS_PATH + PLAYER_TEXTURE_PATH);
    } 
}