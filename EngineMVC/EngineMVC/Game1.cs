using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using DreidelDreams.Model;
using DreidelDreams.View;
using DreidelDreams.Controller;

namespace DreidelDreams
{
  public class Game1 : Microsoft.Xna.Framework.Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

    public static int ScreenWidth;
    public static int ScreenHeight;

    Texture2D blockTexture;
    SpriteFont font;

    World world;

    // Views
    PlayerView playerView;
    BallView ballView;
    PlayerViewText playerViewText;
    PlayerViewGrid playerViewGrid;
    TileView tileView;

    // Controllers
    PlayerController player1Controller;
    MouseController mouseController;

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
      IsMouseVisible = true;

      base.Initialize();
    }

    protected override void LoadContent()
    {
      spriteBatch = new SpriteBatch(GraphicsDevice);

      ScreenWidth = GraphicsDevice.Viewport.Width;
      ScreenHeight = GraphicsDevice.Viewport.Height;

      blockTexture = Content.Load<Texture2D>("block");
      font = Content.Load<SpriteFont>("genericFont");

      // World
      world = new World();

      // Controllers
      player1Controller = new PlayerController(world.player1, InputType.Keyboard, PlayerIndex.One);
      mouseController = new MouseController(world, InputType.Mouse, PlayerIndex.One);

      // Views
      playerView = new PlayerView(world.player1, blockTexture);
      playerViewText = new PlayerViewText(world.player1, font);
      playerViewGrid = new PlayerViewGrid(world.player1, blockTexture);
      tileView = new TileView(world.tiles, blockTexture);
      ballView = new BallView(world.ball, blockTexture);

    }

    protected override void UnloadContent()
    {
      // TODO: Unload any non ContentManager content here
    }

    protected override void Update(GameTime gameTime)
    {
      world.Update(gameTime);

      // Controllers .Control
      player1Controller.Control(gameTime);
      mouseController.Control(gameTime);

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.Black);

      spriteBatch.Begin();

      // Views .Draw(spriteBatch)
      tileView.Draw(spriteBatch);
      playerView.Draw(spriteBatch);
      playerViewGrid.Draw(spriteBatch);
      playerViewText.Draw(spriteBatch);
      ballView.Draw(spriteBatch);

      spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
