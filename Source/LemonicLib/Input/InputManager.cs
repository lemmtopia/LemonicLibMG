using System;

using Microsoft.Xna.Framework;

namespace LemonicLib.Input;

public class InputManager
{
    public KeyboardInfo Keyboard;
    public GamePadInfo[] GamePads;

    public InputManager()
    {
        Keyboard = new KeyboardInfo();

        GamePads = new GamePadInfo[4];
        for (int i = 0; i < 4; i++)
        {
            GamePads[i] = new GamePadInfo(i);
        }
    }

    public void Update(GameTime gameTime)
    {
        Keyboard.Update();

        for (int i = 0; i < 4; i++)
        {
            GamePads[i].Update(gameTime);
        }
    }
}
