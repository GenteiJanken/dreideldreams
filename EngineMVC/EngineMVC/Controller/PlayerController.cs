using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using DreidelDreams.Model;

namespace DreidelDreams.Controller
{
  public class PlayerController : Controller
  {
    private InputManager inputManager;
    private PlayerModel player;
    private Dictionary<PlayerAction, Inputs> keyMap;

    public PlayerController(PlayerModel player, InputType type, PlayerIndex playerIndex)
    {
      this.player = player;
      inputManager = new InputManager(type, playerIndex);
      keyMap = new Dictionary<PlayerAction, Inputs>();

      // Map actions to keys
      keyMap.Add(PlayerAction.MoveUp, Inputs.Up);
      keyMap.Add(PlayerAction.MoveDown, Inputs.Down);
      keyMap.Add(PlayerAction.MoveLeft, Inputs.Left);
      keyMap.Add(PlayerAction.MoveRight, Inputs.Right);
    }

    public override void Control(GameTime gameTime)
    {
      inputManager.Update();

      if (inputManager.IsInputDown(keyMap[PlayerAction.MoveUp]))
        player.MoveUp(gameTime);
      if (inputManager.IsInputDown(keyMap[PlayerAction.MoveDown]))
        player.MoveDown(gameTime);
      if (inputManager.IsInputDown(keyMap[PlayerAction.MoveLeft]))
        player.MoveLeft(gameTime);
      if (inputManager.IsInputDown(keyMap[PlayerAction.MoveRight]))
        player.MoveRight(gameTime);

      if (inputManager.IsInputUp(Inputs.Up) 
        && inputManager.IsInputUp(Inputs.Down))
        player.Stop(1, 0);

      if (inputManager.IsInputUp(Inputs.Left)
        && inputManager.IsInputUp(Inputs.Right))
        player.Stop(0, 1);
    }
  }
}
