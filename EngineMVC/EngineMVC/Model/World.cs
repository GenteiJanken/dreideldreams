using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DreidelDreams.Model
{
  public class World
  {
    public World()
    {
      // Object Instantiation
      random = new Random();
      player1 = new PlayerModel(this, new Vector2(100, 100), 100, 100);
      ball = new BallModel(this, 200, 200, 10, 10);

      Vector2 randomDirection = new Vector2(
        (float)(random.NextDouble() * (random.NextDouble() * 2 - 1)),
        (float)(random.NextDouble() * (random.NextDouble() * 2 - 1))
        );
      
      ball.setInitialDirection(randomDirection);

      int w = 64, h = 64, space = 1;

      tiles.Add(new TileModel(this, (w + space) * 0, (h + space) * 0, w, h));
      tiles.Add(new TileModel(this, (w + space) * 1, (h + space) * 0, w, h));
      tiles.Add(new TileModel(this, (w + space) * 2, (h + space) * 0, w, h));
      tiles.Add(new TileModel(this, (w + space) * 3, (h + space) * 0, w, h));
    }

    public void AddTile(int mx, int my, int w, int h, int space)
    {
      int x = mx / (w + space);
      int y = my / (h + space);
      tiles.Add(new TileModel(this, (w + space) * x, (h + space) * y, w, h));
    }

    public void Update(GameTime gameTime)
    {
      delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
      GameTime = gameTime.TotalGameTime;

      // Object Updates
      player1.Update(gameTime);
      ball.Update(gameTime);

      foreach (TileModel item in tiles)
        item.Update(gameTime);
    }

    // Objects Variables
    public PlayerModel player1;
    public BallModel ball;
    public Random random;
    public List<TileModel> tiles = new List<TileModel>();
    public float delta;
    public static TimeSpan GameTime;
  }

  public enum WorldAction 
  {
    AddBall, AddTile
  }
}
