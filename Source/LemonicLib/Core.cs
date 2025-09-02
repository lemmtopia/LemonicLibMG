using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonicLib;

public class Core : Game
{
    public static Core Instance;

    protected GraphicsDeviceManager Graphics;
    protected new GraphicsDevice GraphicsDevice;
    protected SpriteBatch SpriteBatch;
    protected new ContentManager Content;

    public Core(int width, int height, string title, bool fullScreen)
    {
        // Singleton stuff
        if (Instance != null)
        {
            throw new InvalidOperationException("There must be only one instance of Core.");
        }
        Instance = this;

        // Initialize graphics with our arguments.
        Graphics = new GraphicsDeviceManager(this);

        Graphics.PreferredBackBufferWidth = width;
        Graphics.PreferredBackBufferHeight = height;
        Graphics.IsFullScreen = fullScreen;
        Graphics.ApplyChanges();

        // Content.
        Content = base.Content;
        Content.RootDirectory = "Content";

        // Window title
        Window.Title = title;

        // Mouse is visible by default.
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        // GraphicsDevice.
        GraphicsDevice = base.GraphicsDevice;

        // SpriteBatch creation
        SpriteBatch = new SpriteBatch(GraphicsDevice);
    }
}
