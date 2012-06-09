using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EngineMVC.Controller
{
  public abstract class Controller
  {
    public abstract void Control(GameTime gameTime);
  }
}
