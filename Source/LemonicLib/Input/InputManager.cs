using System;

using Microsoft.Xna.Framework;

namespace LemonicLib.Input;

public class InputManager
{
    public KeyboardInfo Keyboard;

    public InputManager()
    {
        Keyboard = new KeyboardInfo();
    }

    public void Update(GameTime gameTime)
    {
        Keyboard.Update();
    }
}
