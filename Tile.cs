using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Mr_Footstep
{
    public class Tile : Entity
    {
        public Texture2D Sprite;
        public Texture2D HoverSprite;

        public int X;
        public int Y;

        public Rectangle Rectangle => new Rectangle ((int) Position.X, (int) Position.Y, 50, 50);

        private bool hover;

        public override void Update (float deltaTime)
        {
            MouseState ms = Mouse.GetState ();

            if (Rectangle.Contains (ms.Position))
                hover = true;
            else
                hover = false;
        }

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

            if (hover)
            {
                spriteBatch.Draw
                (
                    HoverSprite,
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
}