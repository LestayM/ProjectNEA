using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectGame;

public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _batch;

    private tileGrid _tileGrid;

    #region ScreenResolution
    private readonly Vector2 _resolution = new Vector2(500, 500);
    private readonly bool _isFullScreen = false;
    private ScreenResolution _screenResolution;
    #endregion

    private Texture2D _tileTex;
    private Texture2D _pixelTex;
    
    public Tile[,] Tiles;

    #region Game1
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    #endregion
    #region Initalize
    protected override void Initialize()
    {
        _tileGrid = new tileGrid(50, new Vector2(0, 0), 10, 10);
        base.Initialize();
    }
    #endregion
    #region LoadContent
    protected override void LoadContent()
    {
        _batch = new SpriteBatch(GraphicsDevice);
        
        //PURPOSE: change resolution of the screen
        _screenResolution = new ScreenResolution(_graphics, _resolution, _isFullScreen);
        
        //PURPOSE: loads the texture for the node
        _tileTex = Content.Load<Texture2D>("squareTex");
        
        //PURPOSE: creates a pixel of screen that can be used to be coloured
        _pixelTex = new Texture2D(GraphicsDevice, 1, 1);
        _pixelTex.SetData(new Color[] { Color.White });
    }
    #endregion
    #region Update
    protected override void Update(GameTime gameTime)
    {
        if(Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
        
        base.Update(gameTime);
    }
    #endregion 
    #region Draw
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _batch.Begin();
        
        _tileGrid.Draw(_batch,_pixelTex, _pixelTex);
        
        _batch.End();
        
        base.Draw(gameTime);
    }
    #endregion
}