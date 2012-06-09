using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EngineMVC.Model
{
  public abstract class Model
  {
    public Model(World world) {
      this.world = world;
    }

    public abstract void Update(GameTime gameTime);

    public virtual Vector2 Position { get; set; }
    protected World world;
  }
}
