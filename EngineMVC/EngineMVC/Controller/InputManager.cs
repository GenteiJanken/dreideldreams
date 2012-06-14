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
    // Threshold for thumbsticks
    public float thumbStickDeadzone = 0.5f;

    private Dictionary<Inputs, Keys> inputToKeys;
    private Dictionary<Inputs, Buttons> inputToButtons;
    private Dictionary<Inputs, MouseButton> inputToMouse;

    private KeyboardState keyboard, prevKeyboard;
    private GamePadState gamepad, prevGamepad;
    private InputType inputType;
    private PlayerIndex playerIndex;
    private MouseState mouse, prevMouse;

    public int mouseX;
    public int mouseY;

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

      inputToMouse = new Dictionary<Inputs, MouseButton>();
      inputToMouse.Add(Inputs.A, MouseButton.Left);
      inputToMouse.Add(Inputs.B, MouseButton.Right);
      inputToMouse.Add(Inputs.X, MouseButton.Middle);
    }

    public bool IsInputPressed(Inputs input)
    {
      if (inputType == InputType.Keyboard)
        return (keyboard.IsKeyDown(inputToKeys[input]) && !prevKeyboard.IsKeyDown(inputToKeys[input]));
      else if (inputType == InputType.Gamepad)
        return (gamepad.IsButtonDown(inputToButtons[input]) && !prevGamepad.IsButtonDown(inputToButtons[input]));
      else if (inputType == InputType.Mouse)
      {
        // Done like this cuz mouse is dumb
        switch (inputToMouse[input])
        {
          case MouseButton.Left:
            return (mouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton != ButtonState.Pressed);
          case MouseButton.Right:
            return (mouse.RightButton == ButtonState.Pressed && prevMouse.RightButton != ButtonState.Pressed);
          case MouseButton.Middle:
            return (mouse.MiddleButton == ButtonState.Pressed && prevMouse.MiddleButton != ButtonState.Pressed);
        }        
      }

      return false;
    }

    public bool IsInputDown(Inputs input)
    {
      if (inputType == InputType.Keyboard)
        return keyboard.IsKeyDown(inputToKeys[input]);
      else if (inputType == InputType.Gamepad)
        return gamepad.IsButtonDown(inputToButtons[input]);
      else if (inputType == InputType.Mouse)
      {
        switch (inputToMouse[input])
        {
          case MouseButton.Left:
            return (mouse.LeftButton == ButtonState.Pressed);
          case MouseButton.Right:
            return (mouse.RightButton == ButtonState.Pressed);
          case MouseButton.Middle:
            return (mouse.MiddleButton == ButtonState.Pressed);
        }        
      }

      return false;
    }

    public bool IsInputUp(Inputs input)
    {
      if (inputType == InputType.Keyboard)
        return keyboard.IsKeyUp(inputToKeys[input]);
      else if (inputType == InputType.Gamepad)
        return gamepad.IsButtonUp(inputToButtons[input]);
      else if (inputType == InputType.Mouse)
      {
        switch (inputToMouse[input])
        {
          case MouseButton.Left:
            return (mouse.LeftButton == ButtonState.Released);
          case MouseButton.Right:
            return (mouse.RightButton == ButtonState.Released);
          case MouseButton.Middle:
            return (mouse.MiddleButton == ButtonState.Released);
        }
      }
      return false;
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
      else if (inputType == InputType.Mouse)
      {
        prevMouse = mouse;
        mouse = Mouse.GetState();
      }

      mouseX = mouse.X;
      mouseY = mouse.Y;
    }

  }

  public enum MouseButton
  {
    Left, Middle, Right
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
