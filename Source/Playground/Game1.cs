using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using LemonicLib;
using LemonicLib.Graphics;
using LemonicLic.Graphics;
using System;

namespace Playground;

public class Game1 : Core
{
    private TextureRegion _player;
    private Vector2 _playerPosition;

    public Game1() : base(800, 600, "Vida lokaaa", false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();

        _playerPosition = new Vector2(40, 40);
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here

        TextureAtlas atlas = TextureAtlas.FromFile(Content, "Images/Atlas-Definitions.xml");

        _player = atlas.GetRegion("Slime-1");
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here

        base.Update(gameTime);

        if (Input.Keyboard.IsKeyDown(Keys.D))
        {
            _playerPosition.X += 5;
        }
        else if (Input.Keyboard.IsKeyDown(Keys.A))
        {
            _playerPosition.X -= 5;
        }
        else if (Input.Keyboard.IsKeyDown(Keys.S))
        {
            _playerPosition.Y += 5;
        }
        else if (Input.Keyboard.IsKeyDown(Keys.W))
        {
            _playerPosition.Y -= 5;
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _player.Draw(SpriteBatch, _playerPosition, Color.White, 0, Vector2.Zero, new Vector2(4, 4), SpriteEffects.None, 1);
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
