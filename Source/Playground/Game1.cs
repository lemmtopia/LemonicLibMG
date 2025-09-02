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
    TextureRegion Player;

    public Game1() : base(800, 600, "Vida lokaaa", false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here

        TextureAtlas atlas = TextureAtlas.FromFile(Content, "Images/Atlas-Definitions.xml");

        Player = atlas.GetRegion("Slime-1");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        Player.Draw(SpriteBatch, new Vector2(40, 40), Color.White, 0, Vector2.Zero, new Vector2(4, 4), SpriteEffects.None, 1);
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
