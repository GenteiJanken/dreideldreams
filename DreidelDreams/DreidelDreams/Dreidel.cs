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
    Vector2 Position;
    Vector2 Velocity;
    Rectangle DestRect;
    Rectangle SourceRect;
    Color Colour;
    bool Clockwise;
    float RotateSpeed;

    public Dreidel(int x, int y)
    {
      Position = new Vector2(x, y);
      Velocity = Vector2.Zero;
      RotateSpeed = 7f;
      Clockwise = true;
      Colour = Color.White;
    }

    public void Update(GameTime gameTime)
    {
    }
    public void Draw(SpriteBatch spriteBatch, Texture2D sprite)
    {
      spriteBatch.Draw(sprite, DestRect, SourceRect, Colour);
    }
  }
}
