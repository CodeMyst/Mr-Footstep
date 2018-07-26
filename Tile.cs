using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Mr_Footstep
{
    public class Tile : Entity
    {
        public Texture2D Sprite;
        public Texture2D HoverSprite;
        public Texture2D FootprintSprite;

        public Footprint Footprint;

        public bool IsFinish = false;

        private float footprintRotation = 0.0f;

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

        public void PlaceFootprint (Footprint fp)
        {
            if (fp == null) return;

            FootprintSprite = fp.Sprite;
            
            switch (fp.Direction)
            {
                case Direction.Down:
                    footprintRotation = 3.1f;
                    break;
                case Direction.Right:
                    footprintRotation = 1.6f;
                    break;
                case Direction.Up:
                    footprintRotation = 0f;
                    break;
                case Direction.Left:
                    footprintRotation = 4.7f;
                    break;
            }

            Footprint = fp;
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (IsFinish)
                color = Color.Green;

            spriteBatch.Draw
            (
                Sprite,
                Position,
                null,
                color,
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

            if (FootprintSprite != null)
            {
                spriteBatch.Draw
                (
                    FootprintSprite,
                    Position + (new Vector2 (FootprintSprite.Width / 2, FootprintSprite.Height / 2) * 0.75f),
                    null,
                    Color.White,
                    footprintRotation,
                    new Vector2 (FootprintSprite.Width / 2, FootprintSprite.Height / 2),
                    new Vector2 (0.75f),
                    SpriteEffects.None,
                    0f
                );
            }
        }
    }
}