using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EngineMVC.Controller
{
  class InputManager
  {
    public InputManager(InputType type, PlayerIndex player)
    {
      this.inputType = type;
      this.playerIndex = player;

      // Populate Dictionary Entries
      inputToKeys = new Dictionary<Inputs, Keys>();
      inputToKeys.Add(Inputs.A, Keys.A);
      inputToKeys.Add(Inputs.B, Keys.S);
      inputToKeys.Add(Inputs.Back, Keys.Escape);
      inputToKeys.Add(Inputs.Up, Keys.Up);
      inputToKeys.Add(Inputs.Down, Keys.Down);
      inputToKeys.Add(Inputs.Left, Keys.Left);
      inputToKeys.Add(Inputs.Right, Keys.Right);
      inputToKeys.Add(Inputs.Start, Keys.Enter);
      inputToKeys.Add(Inputs.X, Keys.Z);
      inputToKeys.Add(Inputs.Y, Keys.X);

      inputToButtons = new Dictionary<Inputs, Buttons>();
      inputToButtons.Add(Inputs.A, Buttons.A);
      inputToButtons.Add(Inputs.B, Buttons.B);
      inputToButtons.Add(Inputs.Back, Buttons.Back);
      inputToButtons.Add(Inputs.Up, Buttons.DPadUp);
      inputToButtons.Add(Inputs.Down, Buttons.DPadDown);
      inputToButtons.Add(Inputs.Left, Buttons.DPadLeft);
      inputToButtons.Add(Inputs.Right, Buttons.DPadRight);
      inputToButtons.Add(Inputs.Start, Buttons.Start);
      inputToButtons.Add(Inputs.X, Buttons.X);
      inputToButtons.Add(Inputs.Y, Buttons.Y);
    }

    public bool IsInputPressed(Inputs input)
    {
      if (inputType == InputType.Keyboard)
        return (keyboard.IsKeyDown(inputToKeys[input]) && !prevKeyboard.IsKeyDown(inputToKeys[input]));
      else // inputType == InputType.Gamepad
        return (gamepad.IsButtonDown(inputToButtons[input]) && !prevGamepad.IsButtonDown(inputToButtons[input]));

      // Mouse code for the future
      //else (inputType == InputType.Mouse)
      //  return false;

    }

    public bool IsInputDown(Inputs input)
    {
      if (inputType == InputType.Keyboard)
        return keyboard.IsKeyDown(inputToKeys[input]);
      else // inputType == InputType.Gamepad
        return gamepad.IsButtonDown(inputToButtons[input]);
    }

    public bool IsInputUp(Inputs input)
    {
      if (inputType == InputType.Keyboard)
        return keyboard.IsKeyUp(inputToKeys[input]);
      else // inputType == InputType.Gamepad
        return gamepad.IsButtonUp(inputToButtons[input]);
    }

    public bool InputIsDirection(Inputs input)
    {
      return (input == Inputs.Up || input == Inputs.Down || input == Inputs.Left || input == Inputs.Right);
    }

    public void Update()
    {
      // Refreshes the key/button states

      if (inputType == InputType.Keyboard)
      {
        prevKeyboard = keyboard;
        keyboard = Keyboard.GetState();
      }
      else if (inputType == InputType.Gamepad)
      {
        prevGamepad = gamepad;
        gamepad = GamePad.GetState(playerIndex);
      }
    }

    // Threshold for thumbsticks
    public float thumbStickDeadzone = 0.5f;

    private Dictionary<Inputs, Keys> inputToKeys;
    private Dictionary<Inputs, Buttons> inputToButtons;

    private KeyboardState keyboard, prevKeyboard;
    private GamePadState gamepad, prevGamepad;
    private InputType inputType;
    private PlayerIndex playerIndex;
  }

  public enum Inputs
  {
    A, B, X, Y, Left, Right, Up, Down, Start, Back
  }

  public enum InputType
  {
    Keyboard, Gamepad, Mouse
  }
}
