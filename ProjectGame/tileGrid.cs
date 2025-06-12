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

    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D texture, Texture2D pixel)
    {
        foreach (Tile tile in Tiles)
        {
            Color tileColor = Color.White;
            if(tile.Start)
                tileColor = Color.Green;
            if (tile.End)
                tileColor = Color.Red;
            if(!tile.isWalkable && !tile.End && !tile.Start)
                tileColor = Color.Black;
            spriteBatch.Draw(texture, tile._bounds, tileColor);
            spriteBatch.Draw(pixel, new Rectangle(tile._bounds.X, tile._bounds.Y, tile._bounds.Width, 1), Color.Black); //Top
            spriteBatch.Draw(pixel,  new Rectangle(tile._bounds.X, tile._bounds.Y + (tile._bounds.Height - 1), tile._bounds.Width, 1), Color.Black);//Bottom
            spriteBatch.Draw(pixel,  new Rectangle(tile._bounds.X, tile._bounds.Y, 1, tile._bounds.Height), Color.Black);//Left
            spriteBatch.Draw(pixel,  new Rectangle(tile._bounds.X + (tile._bounds.Width - 1), tile._bounds.Y, 1, tile._bounds.Height), Color.Black);//Right
        }
    }
}