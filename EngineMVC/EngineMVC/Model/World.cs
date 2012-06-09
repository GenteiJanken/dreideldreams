using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EngineMVC.Model
{
  public class World
  {
    public World()
    {
      // Object Instantiation
      player1 = new PlayerModel(this, new Vector2(100, 100), 100, 100);

      int w = 64, h = 64, space = 1;

      for (int x = 0; x < 12; x++)
        for (int y = 0; y < 12; y++)
          tiles.Add(new TileModel(this, (w + space) * x, (h + space) * y, w, h));
    }

    public void Update(GameTime gameTime)
    {
      // Object Updates
      player1.Update(gameTime);

      foreach (TileModel item in tiles)
        item.Update(gameTime);
    }

    // Objects Variables
    public PlayerModel player1;
    public List<TileModel> tiles = new List<TileModel>();
  }
}
