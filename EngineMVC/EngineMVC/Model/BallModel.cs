using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EngineMVC.Model
{
  public class BallModel : Model
  {
    public BallModel(World world, int x, int y, int w, int h)
      : base(world)
    {
      this.world = world;
      Position = new Vector2(x, y);
      width = w;
      height = h;
    }

    public void setInitialDirection(Vector2 velocity){
      this.velocity = velocity;
    }

    public override void Update(GameTime gameTime)
    {
      Position.X += velocity.X * speed * world.delta;
      ResolveX();

      Position.Y += velocity.Y * speed * world.delta;
      ResolveY();

      // Collision with boundaries
      if (Position.X < 0 || Position.X + width > Game1.ScreenWidth)
      {
        Position.X += -velocity.X * speed * world.delta;
        velocity.X = -velocity.X;
      }
      if (Position.Y < 0 || Position.Y + height > Game1.ScreenHeight)
      {
        Position.Y += -velocity.Y * speed * world.delta;
        velocity.Y = -velocity.Y;
      }
    }

    public void ResolveX()
    {
      Rectangle a = GetRect();

      foreach (var item in world.tiles)
      {
        Rectangle b = item.GetRect();
        if (a.Intersects(b))
        {
          Rectangle intersect = Rectangle.Intersect(a, b);

          if (intersect.X == b.X)
            Position.X -= intersect.Width;
          else
            Position.X += intersect.Width;

          a.X = (int)Math.Round(Position.X);
          velocity.X = -velocity.X;
        }
      }
    }
    public void ResolveY()
    {
      Rectangle a = GetRect();

      foreach (var item in world.tiles)
      {
        Rectangle b = item.GetRect();
        if (a.Intersects(b))
        {
          Rectangle intersect = Rectangle.Intersect(a, b);

          if (intersect.Y == b.Y)
            Position.Y -= intersect.Height;
          else
            Position.Y += intersect.Height;

          a.Y = (int)Math.Round(Position.Y);
          velocity.Y = -velocity.Y;
        }
      }
    }

    public Rectangle GetRect()
    {
      return new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), width, height);
    }

    public int width;
    public int height;
    public float speed = 300; // pixels per second
    public Vector2 velocity = Vector2.Zero;
  }
}
