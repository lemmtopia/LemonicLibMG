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

    public bool IsButtonDown(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return _currentState.LeftButton == ButtonState.Pressed;
            case MouseButton.Middle:
                return _currentState.MiddleButton == ButtonState.Pressed;
            case MouseButton.Right:
                return _currentState.RightButton == ButtonState.Pressed;
            case MouseButton.XButton1:
                return _currentState.XButton1 == ButtonState.Pressed;
            case MouseButton.XButton2:
                return _currentState.XButton2 == ButtonState.Pressed;
            default:
                return false;
        }
    }

    public bool IsButtonUp(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return _currentState.LeftButton == ButtonState.Released;
            case MouseButton.Middle:
                return _currentState.MiddleButton == ButtonState.Released;
            case MouseButton.Right:
                return _currentState.RightButton == ButtonState.Released;
            case MouseButton.XButton1:
                return _currentState.XButton1 == ButtonState.Released;
            case MouseButton.XButton2:
                return _currentState.XButton2 == ButtonState.Released;
            default:
                return false;
        }
    }

    public bool IsButtonPressed(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return _currentState.LeftButton == ButtonState.Pressed && _previousState.LeftButton == ButtonState.Released;
            case MouseButton.Middle:
                return _currentState.MiddleButton == ButtonState.Pressed && _previousState.MiddleButton == ButtonState.Released;
            case MouseButton.Right:
                return _currentState.RightButton == ButtonState.Pressed && _previousState.RightButton == ButtonState.Released;
            case MouseButton.XButton1:
                return _currentState.XButton1 == ButtonState.Pressed && _previousState.XButton1 == ButtonState.Released;
            case MouseButton.XButton2:
                return _currentState.XButton2 == ButtonState.Pressed && _previousState.XButton2 == ButtonState.Released;
            default:
                return false;
        }
    }

    public bool IsButtonReleased(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return _currentState.LeftButton == ButtonState.Released && _previousState.LeftButton == ButtonState.Pressed;
            case MouseButton.Middle:
                return _currentState.MiddleButton == ButtonState.Released && _previousState.MiddleButton == ButtonState.Pressed;
            case MouseButton.Right:
                return _currentState.RightButton == ButtonState.Released && _previousState.RightButton == ButtonState.Pressed;
            case MouseButton.XButton1:
                return _currentState.XButton1 == ButtonState.Released && _previousState.XButton1 == ButtonState.Pressed;
            case MouseButton.XButton2:
                return _currentState.XButton2 == ButtonState.Released && _previousState.XButton2 == ButtonState.Pressed;
            default:
                return false;
        }
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