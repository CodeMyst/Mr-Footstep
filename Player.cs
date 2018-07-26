using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mr_Footstep
{
    public class Player : Entity
    {
        public Texture2D ShoesSprite;
        public Texture2D TopSprite;

        private float rotation = 3.1f;

        public void SetPositionToTile (Vector2 tilePosition)
        {
            Position = tilePosition + (new Vector2 (TopSprite.Width / 2, TopSprite.Height / 2) * new Vector2 (0.75f));
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw
            (
                ShoesSprite,
                Position,
                null,
                Color.White,
                rotation,
                new Vector2 (ShoesSprite.Width / 2f, ShoesSprite.Height / 2f),
                new Vector2 (0.75f),
                SpriteEffects.None,
                0.1f
            );

            spriteBatch.Draw
            (
                TopSprite,
                Position,
                null,
                Color.White,
                rotation,
                new Vector2 (TopSprite.Width / 2f, TopSprite.Height / 2f),
                new Vector2 (0.75f),
                SpriteEffects.None,
                0.1f
            );
        }
    }
}