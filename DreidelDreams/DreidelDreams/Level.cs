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

namespace DreidelDreams
{
  class Level
  {
    public List<Dreidel> players = new List<Dreidel>();
    public Texture2D Sprite;
    KeyboardState keyboard = Keyboard.GetState();
    KeyboardState prevKeyboard = Keyboard.GetState();

    public Level() {
      players.Add(new Dreidel(0, 0));
    }

    public void LoadSprite(Texture2D sprite) {
      Sprite = sprite;
    }

    public void Update(GameTime gameTime) {
      // Keyboard Input
      prevKeyboard = keyboard;
      keyboard = Keyboard.GetState();

      bool keyUp = keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.W);
      bool keyDown = keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S);
      bool keyLeft = keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A);
      bool keyRight = keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D);

      if (keyUp)
        players[0].Direction.Y = -1;
      if (keyDown)
        players[0].Direction.Y = 1 ;
      if (keyLeft)
        players[0].Direction.X = -1;
      if (keyRight)
        players[0].Direction.X = 1;

      if (!keyUp && !keyDown && !keyLeft && !keyRight)
        players[0].Direction = Vector2.Zero;

      foreach (Dreidel item in players)
        item.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch) {
      foreach (Dreidel item in players)
        item.Draw(spriteBatch, Sprite);
    }
  }
}
