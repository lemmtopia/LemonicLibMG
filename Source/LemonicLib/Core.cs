using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using LemonicLib.Input;


namespace LemonicLib;

public class Core : Game
{
    public static Core Instance;

    public GraphicsDeviceManager Graphics;
    public new GraphicsDevice GraphicsDevice;
    public SpriteBatch SpriteBatch;
    public new ContentManager Content;
    public InputManager Input;

    public bool ExitOnEscape;

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

        // InputManager
        Input = new InputManager();

        // ExitOnEscape
        ExitOnEscape = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        // GraphicsDevice.
        GraphicsDevice = base.GraphicsDevice;

        // SpriteBatch creation
        SpriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        Input.Update(gameTime);

        if (ExitOnEscape && Input.Keyboard.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Escape))
        {
            Exit();
        }
    }
}
