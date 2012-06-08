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
  class Wall
  {
    Rectangle DestRect;
    Rectangle SourceRect;

    public Wall(int x, int y, int w, int h) 
    {
      DestRect = new Rectangle(x, y, w, h);
      SourceRect = new Rectangle(0, 0, 147, 180);
    }

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D sprite)
    {
      spriteBatch.Draw(sprite, DestRect, SourceRect, Color.Red);
    }
  }
}
