using System;
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

    // private Texture2D _tileTex;
    private Texture2D _pixelTex;
    
    public Tile[,] Tiles;
    // public Vector2 StartBoxPos = new Vector2(0, 0);
    // public Vector2 EndBoxPos = new Vector2(0,1);
    
    public static MouseState mouseState =  Mouse.GetState();
    public int mouseX = mouseState.X;
    public int mouseY = mouseState.Y;
    
    public static Point mousePoint;

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
        // _tileTex = Content.Load<Texture2D>("squareTex");
        
        //PURPOSE: creates a pixel of screen that can be used to be coloured
        _pixelTex = new Texture2D(GraphicsDevice, 1, 1);
        _pixelTex.SetData(new Color[] { Color.White });
        
        // _tileGrid.Tiles[(int)StartBoxPos.X,(int)StartBoxPos.Y].Start = true;
        // if (_tileGrid.Tiles[(int)StartBoxPos.X, (int)StartBoxPos.Y].Start)
        //     _tileGrid.Tiles[(int)StartBoxPos.X, (int)StartBoxPos.Y].isWalkable = false;
        //
        // _tileGrid.Tiles[(int)EndBoxPos.X,(int)EndBoxPos.Y].End = true;
        // if (_tileGrid.Tiles[(int)EndBoxPos.X, (int)EndBoxPos.Y].End)
        //     _tileGrid.Tiles[(int)EndBoxPos.X, (int)EndBoxPos.Y].isWalkable = false;
    }
    #endregion
    #region Update
    protected override void Update(GameTime gameTime)
    {
        if(Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
        
        mouseState = Mouse.GetState();
        mousePoint = new Point(mouseState.X, mouseState.Y);
        
        bool _startSelected = false;
        bool _endSelected = false;
        
        foreach(Tile tile in _tileGrid.Tiles)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (tile._bounds.Contains(mousePoint))
                {
                    if (!(Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.E)))
                    {
                        if (!tile.isWalkable)
                            tile.isWalkable = true;
                        else
                            tile.isWalkable = false;
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.S) && tile.isWalkable && !tile.End)
                    {
                        foreach(Tile t in _tileGrid.Tiles)
                        {
                            if (t.Start)
                            {
                                _startSelected = true;
                                continue;
                            }
                            t.Start = false;
                        }
                        if (!tile.Start && !_startSelected)
                        {
                            tile.Start = true;
                            _startSelected = true;
                        }
                        else if (tile.Start)
                        {
                            tile.Start = false;
                            _startSelected = false;
                        }
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.E) && tile.isWalkable && !tile.Start)
                    {
                        foreach(Tile t in _tileGrid.Tiles)
                        {
                            if (t.End)
                            {
                                _endSelected = true;
                                continue;
                            }
                            t.End = false;
                        }
                        if (!tile.End && !_endSelected)
                        {
                            tile.End = true;
                            _endSelected = true;
                        }
                        else if (tile.End)
                        {
                            tile.End = false;
                            _endSelected = false;
                        }
                    }
                    // if ((Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.E)))
                    //
                    //     if (!tile.Start && !tile.End)
                    //     {
                    //         if (Keyboard.GetState().IsKeyDown(Keys.S) && !_startSelected)
                    //         {
                    //             foreach (Tile t in _tileGrid.Tiles)
                    //             {
                    //                 if (t.End || !t.isWalkable) continue;
                    //                 t.isWalkable = true;
                    //             }
                    //
                    //             tile.Start = true;
                    //             tile.isWalkable = true;
                    //             _startSelected = true;
                    //         }
                    //
                    //         if (Keyboard.GetState().IsKeyDown(Keys.E) && !_endSelected)
                    //         {
                    //             foreach (Tile t in _tileGrid.Tiles)
                    //             {
                    //                 if (t.Start || !t.isWalkable) continue;
                    //                 t.isWalkable = true;
                    //                 t.Start = false;
                    //                 t.End = false;
                    //             }
                    //
                    //             tile.isWalkable = true;
                    //             tile.Start = false;
                    //             tile.End = true;
                    //             _endSelected = true;
                    //         }
                    //     }
                }
            }
        }
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