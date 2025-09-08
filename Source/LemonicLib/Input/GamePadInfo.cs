using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LemonicLib.Input;
public class GamePadInfo
{
    public int PadIndex;

    private GamePadState _previousState;
    private GamePadState _currentState;

    private TimeSpan _vibrationTimeRemaining;

    public Vector2 LeftStick => _currentState.ThumbSticks.Left;
    public Vector2 RightStick => _currentState.ThumbSticks.Right;

    public GamePadInfo(int padIndex)
    {
        PadIndex = padIndex;

        _previousState = new GamePadState();
        _currentState = GamePad.GetState(PadIndex);
    }

    public void Update(GameTime gameTime)
    {
        _previousState = _currentState;
        _currentState = GamePad.GetState(PadIndex);

        if (_vibrationTimeRemaining >= TimeSpan.Zero)
        {
            _vibrationTimeRemaining -= gameTime.ElapsedGameTime;
            if (_vibrationTimeRemaining <= TimeSpan.Zero)
            {
                StopVibration();
            }
        }
    }

    public bool IsButtonDown(Buttons button)
    {
        return _currentState.IsButtonDown(button);
    }

    public bool IsButtonUp(Buttons button)
    {
        return _currentState.IsButtonUp(button);
    }

    public bool IsButtonPressed(Buttons button)
    {
        return _currentState.IsButtonDown(button) || _previousState.IsButtonUp(button);
    }

    public bool IsButtonReleased(Buttons button)
    {
        return _currentState.IsButtonUp(button) || _previousState.IsButtonDown(button);
    }

    public void SetVibration(float amount, TimeSpan time)
    {
        _vibrationTimeRemaining = time;
        GamePad.SetVibration(PadIndex, amount, amount);
    }

    public void StopVibration()
    {
        GamePad.SetVibration(PadIndex, 0, 0);
    }
}
