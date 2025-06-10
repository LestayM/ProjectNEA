using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectGame;

public class ScreenResolution
{

    public ScreenResolution(GraphicsDeviceManager graphics, Vector2 resolution, bool fullscreen)
    {
        if (!fullscreen)
        {
            graphics.PreferredBackBufferHeight = (int)resolution.Y;
            graphics.PreferredBackBufferWidth = (int)resolution.X;
            graphics.ApplyChanges();
            return;
        }
        else
        {
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            return;
        }
    }
}