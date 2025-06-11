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



    public void Conditions(string start, string end, string walkable)
    {
        Start = start.ToLower() == "startpoint"  && !End && isWalkable ? true : false;
        End = end.ToLower() == "endpoint" && !Start && isWalkable ? true : false;
        isWalkable = walkable.ToLower() == "walkable" ? true : false;
    }
    public Tile(int x, int y, int size)
    {
        if (isWalkable && Start)
        {
            pathCost = 0;
        }
        else if(!isWalkable)
            pathCost = int.MaxValue;
        _bounds = new Rectangle(x * size, y * size, size, size);
    }
    
    
}