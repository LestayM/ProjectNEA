using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectGame;

public class Tile
{
    public Rectangle _bounds;
    public bool Start = false;
    public bool End = false;
    public bool isWalkable = true;
    public int pathCost = 1;
    
    
    
    
    public Tile(int x, int y, int size)
    {
        if (isWalkable && Start)
        {
            pathCost = 0;
        }
        _bounds = new Rectangle(x * size, y * size, size, size);
    }
    
    
}