using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mr_Footstep
{
    public class Tile : Entity
    {
        public Texture2D Sprite;

        public override void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw
            (
                Sprite,
                Position,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                new Vector2 (0.5f, 0.5f),
                SpriteEffects.None,
                0f
            );
        }
    }
}