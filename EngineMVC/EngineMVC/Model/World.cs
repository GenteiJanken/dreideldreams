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
    }
    
    public void Update(GameTime gameTime)
    {
      // Object Updates
      player1.Update(gameTime);
    }

    // Objects Variables
    public PlayerModel player1;
  }
}
