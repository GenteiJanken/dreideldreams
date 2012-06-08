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
  class Dreidel
  {
    public Vector2 Position;
    public Vector2 Velocity;
    public Vector2 Direction;
    public Rectangle DestRect;
    public Rectangle SourceRect;
    public Color Colour;
    public bool Clockwise;
    public float RotateSpeed;

    public Dreidel(int x, int y)
    {
      Position = new Vector2(x, y);
      Velocity = new Vector2(10, 10);
      RotateSpeed = 7f;
      Clockwise = true;
      Colour = Color.White;
      DestRect = new Rectangle(x, y, 147/2, 180/2);
      SourceRect = new Rectangle(0, 0, 147, 180);
    }

    public void Update(GameTime gameTime)
    {
      // Player collides with wall, slows down
      // Player collides clockwise whirly thing, if player clockwise then = terminalClockwiseSpeed else, slow down rotation speed
      // Player collides counter-clockwise whirly thing, if player counter-clockwise then = -terminalClockwiseSpeed, slow down rotation speed
      // Player collides travelator, player direction must = travelator direction
      // 

      Velocity.X = 5 * Direction.X;
      Velocity.Y = 5 * Direction.Y;

      Position.X += Velocity.X;
      Position.Y += Velocity.Y;

      DestRect.X = (int)Math.Round(Position.X);
      DestRect.Y = (int)Math.Round(Position.Y);
    }
    public void Draw(SpriteBatch spriteBatch, Texture2D sprite)
    {
      spriteBatch.Draw(sprite, DestRect, SourceRect, Colour);
    }
  }
}
