using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DreidelDreams.Model
{
  public class PlayerModel : Model
  {
    public PlayerModel(World world, Vector2 position, int w, int h)
      : base(world)
    {
      Position = position;
      width = w;
      height = h;
    }

    public override void Update(GameTime gameTime)
    {
      Position.X += velocity.X;
      ResolveX();

      Position.Y += velocity.Y;
      ResolveY();
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
        }
      }
    }

    // Methods for the controller
    public void MoveUp(GameTime gameTime)
    {
      velocity.Y = world.delta * speed * -1;
    }

    public void MoveDown(GameTime gameTime)
    {
      velocity.Y = world.delta * speed * 1;
    }

    public void MoveLeft(GameTime gameTime)
    {
      velocity.X = world.delta * speed * -1;
    }

    public void MoveRight(GameTime gameTime)
    {
      velocity.X = world.delta * speed * 1;
    }

    public void Stop(int x, int y)
    {
      velocity.X *= x;
      velocity.Y *= y;
    }

    public Rectangle GetRect()
    {
      return new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), width, height);
    }

    public int width;
    public int height;
    public float speed = 200; // pixels per second
    public Vector2 velocity = Vector2.Zero;
    public bool collision;
  }

  public enum PlayerAction
  {
    Nothing, MoveUp, MoveDown, MoveLeft, MoveRight
  }
}
