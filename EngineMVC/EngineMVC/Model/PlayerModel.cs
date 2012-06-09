using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EngineMVC.Model
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
      Position += velocity;
    }

    // Methods for the controller
    public void MoveUp(GameTime gameTime)
    {
      velocity.Y = (float)gameTime.ElapsedGameTime.TotalSeconds * speed * -1;
    }

    public void MoveDown(GameTime gameTime)
    {
      velocity.Y = (float)gameTime.ElapsedGameTime.TotalSeconds * speed * 1;
    }

    public void MoveLeft(GameTime gameTime)
    {
      velocity.X = (float)gameTime.ElapsedGameTime.TotalSeconds * speed * -1;
    }

    public void MoveRight(GameTime gameTime)
    {
      velocity.X = (float)gameTime.ElapsedGameTime.TotalSeconds * speed * 1;
    }

    public void Stop(int x, int y)
    {
      velocity.X *= x;
      velocity.Y *= y;
    }

    public Rectangle GetRect() {
      return new Rectangle((int)Position.X, (int)Position.Y, width, height);
    }

    public bool Collides(Rectangle b) 
    {
      Rectangle a = new Rectangle((int)Position.X, (int)Position.Y, width, height);

      if (a.Intersects(b))
        return true;
      else
        return false;
    }

    public int width;
    public int height;
    public float speed = 200; // pixels per second
    public Vector2 velocity = Vector2.Zero;

  }

  public enum PlayerAction
  {
    Nothing, MoveUp, MoveDown, MoveLeft, MoveRight
  }
}
