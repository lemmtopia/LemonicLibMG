using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LemonicLib.Input;
public class MouseInfo
{
    private MouseState _previousState;
    private MouseState _currentState;

    public Point Position
    {
        get => _currentState.Position;
        set => SetPosition(value.X, value.Y);
    }

    public float ScrollWheel => _currentState.ScrollWheelValue;
    public float ScrollWheelDelta => _currentState.ScrollWheelValue - _previousState.ScrollWheelValue;

    public Point DeltaPosition => _currentState.Position - _previousState.Position;
    public bool Moved => DeltaPosition != Point.Zero;

    public float DeltaX => _currentState.Position.X - _previousState.Position.X;
    public float DeltaY => _currentState.Position.Y - _previousState.Position.Y;

    public MouseInfo()
    {
        _previousState = new MouseState();
        _currentState = Mouse.GetState();
    }

    public void Update()
    {
        _previousState = _currentState;
        _currentState = Mouse.GetState();
    }

    public void SetPosition(int x, int y)
    {
        Mouse.SetPosition(x, y);
        _currentState = new MouseState(
            x,
            y,
            _currentState.ScrollWheelValue,
            _currentState.LeftButton,
            _currentState.MiddleButton,
            _currentState.RightButton,
            _currentState.XButton1,
            _currentState.XButton2
        );
    }
}