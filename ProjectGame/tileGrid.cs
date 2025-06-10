using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectGame;

public class tileGrid
{
    public Tile[,] Tiles;
    public tileGrid(int tileSize, Vector2 startPos, int gridSizeX, int gridSizeY)
    {
        Tiles = new Tile[gridSizeX, gridSizeY];
        for (int x = (int)startPos.X; (x - (int)startPos.X) < gridSizeX; x++)
        {
            for (int y = (int)startPos.Y; (y - (int)startPos.Y) < gridSizeY; y++)
            {
                Tiles[x-(int)startPos.X, y-(int)startPos.Y] = new Tile(x, y, tileSize);
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D texture, Texture2D pixel)
    {
        foreach (Tile tile in Tiles)
        {
            tile.Draw(spriteBatch, texture, pixel);
        }
    }
}