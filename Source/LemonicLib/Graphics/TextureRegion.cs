using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonicLib.Graphics;

public class TextureRegion
{
    public Texture2D Texture;
    public Rectangle SourceRectangle;

    public TextureRegion()
    {

    }

    public TextureRegion(Texture2D texture, int x, int y, int width, int height)
    {
        Texture = texture;
        SourceRectangle = new Rectangle(x, y, width, height);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, int depth)
    {
        spriteBatch.Draw(Texture, position, SourceRectangle, color, rotation, origin, scale, effects, depth);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
    {
        spriteBatch.Draw(Texture, position, SourceRectangle, color);
    }
}