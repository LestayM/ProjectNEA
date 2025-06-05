using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectGame;

public class Game1 : Game
{
    private readonly GraphicsDeviceManager _phics;
    private SpriteBatch _batch;
    
    private readonly Vector2 _resolution = new Vector2(800, 800);
    private readonly bool _isFullScreen = false;
    private ScreenResolution _screenResolution;

    public Game1()
    {
        _phics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void Initialize()
    {
        base.Initialize();
    }
    protected override void LoadContent()
    {
        _batch = new SpriteBatch(GraphicsDevice);
        
        //PURPOSE: change resolution of the screen
        _screenResolution = new ScreenResolution(_phics, _resolution, _isFullScreen);
    }
    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        
        _batch.Begin();
        
        
        
        _batch.End();
        
        base.Draw(gameTime);
    }
}