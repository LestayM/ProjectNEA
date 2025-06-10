using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectGame;

public class Tile
{
    private readonly Rectangle _bounds;
    
    public Tile(int x, int y, int size)
    {
        _bounds = new Rectangle(x * size, y * size, size, size);
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D texture, Texture2D pixel)
    {
        spriteBatch.Draw(texture, _bounds, Color.White);
        spriteBatch.Draw(pixel, new Rectangle(_bounds.X, _bounds.Y, _bounds.Width, 1), Color.Black); //Top
        spriteBatch.Draw(pixel,  new Rectangle(_bounds.X, _bounds.Y + (_bounds.Height - 1), _bounds.Width, 1), Color.Black);//Bottom
        spriteBatch.Draw(pixel,  new Rectangle(_bounds.X, _bounds.Y, 1, _bounds.Height), Color.Black);//Left
        spriteBatch.Draw(pixel,  new Rectangle(_bounds.X + (_bounds.Width - 1), _bounds.Y, 1, _bounds.Height), Color.Black);//Right
    }
}