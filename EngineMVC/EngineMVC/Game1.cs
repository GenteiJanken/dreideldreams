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
using EngineMVC.Model;
using EngineMVC.View;
using EngineMVC.Controller;

namespace EngineMVC
{
  public class Game1 : Microsoft.Xna.Framework.Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Texture2D blockTexture;

    World world;

    // Views
    PlayerView playerView;

    // Controllers
    PlayerController player1Controller;

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
      blockTexture = Content.Load<Texture2D>("block");

      world = new World();

      // Views
      playerView = new PlayerView(world.player1, blockTexture);

      // Controllers
      player1Controller = new PlayerController(world.player1, InputType.Keyboard, PlayerIndex.One);
    }

    protected override void UnloadContent()
    {
      // TODO: Unload any non ContentManager content here
    }

    protected override void Update(GameTime gameTime)
    {
      world.Update(gameTime);

      // Controller .Control
      player1Controller.Control(gameTime);

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.Black);

      spriteBatch.Begin();

      // View .Draw(spriteBatch)
      playerView.Draw(spriteBatch);

      spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
