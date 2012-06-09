using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EngineMVC.Model
{
  public class PlayerModel : Model
  {
    public PlayerModel(World world, Vector2 position, int width, int height)
      : base(world)
    {
      this.Position = position;
      this.width = width;
      this.height = height;
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
