using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectGame;

public class Tile
{
    private readonly Rectangle _bounds;
    
    public Tile(int x, int y, int size)
    {
        _bounds = new Rectangle(x, y, size, size);
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D texture)
    {
        spriteBatch.Draw(texture, _bounds, Color.White);
    }
}