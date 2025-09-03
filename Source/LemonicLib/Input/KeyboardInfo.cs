using System;

using Microsoft.Xna.Framework.Input;

namespace LemonicLib.Input;
public class KeyboardInfo
{
    private KeyboardState _previousState;
    private KeyboardState _currentState;

    public void KeyboatdInfo()
    {
        _previousState = new KeyboardState();
        _currentState = new KeyboardState();
    }

    public void Update()
    {
        _previousState = _currentState;
        _currentState = Keyboard.GetState();
    }

    public bool IsKeyDown(Keys key)
    {
        return _currentState.IsKeyDown(key);
    }

    public bool IsKeyUp(Keys key)
    {
        return _currentState.IsKeyUp(key);
    }

    public bool IsKeyPressed(Keys key)
    {
        return (_currentState.IsKeyDown(key) && _previousState.IsKeyUp(key));
    }

    public bool IsKeyReleased(Keys key)
    {
        return (_currentState.IsKeyUp(key) && _previousState.IsKeyDown(key));
    }
}
