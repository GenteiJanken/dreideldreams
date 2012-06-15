using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DreidelDreams.Model
{
  public class TileModel : Model
  {
    public TileModel(World world, int x, int y, int w, int h)
      : base(world)
    {
      Position = new Vector2(x, y);
      width = w;
      height = h;
    }

    public override void Update(GameTime gameTime) { }

    public Rectangle GetRect()
    {
      return new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), width, height);
    }

    public int width;
    public int height;
  }
}
