using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using DreidelDreams.Model;

namespace DreidelDreams.Controller
{
  class MouseController : Controller
  {
    private InputManager inputManager;
    private Dictionary<WorldAction, Inputs> keyMap;
    private World world;

    public MouseController(World world, InputType type, PlayerIndex playerIndex)
    {
      this.world = world;
      inputManager = new InputManager(type, playerIndex);
      keyMap = new Dictionary<WorldAction, Inputs>();

      keyMap.Add(WorldAction.AddTile, Inputs.A);
      keyMap.Add(WorldAction.RemoveTile, Inputs.B);
    }

    public override void Control(GameTime gameTime)
    {
      inputManager.Update();

      if (inputManager.IsInputDown(keyMap[WorldAction.AddTile]))
        world.AddTile(inputManager.mouseX, inputManager.mouseY, 64, 64, 1);

      if (inputManager.IsInputDown(keyMap[WorldAction.RemoveTile]))
        world.RemoveTile(inputManager.mouseX, inputManager.mouseY, 64, 64, 1);
    }
  }
}
