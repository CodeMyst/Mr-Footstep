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

        private MouseState currState;
        private MouseState prevState;

        private Tile currentTile;

        public override void Update (float deltaTime)
        {
            currState = Mouse.GetState ();

            Tile mouseTile = Game1.CurrentRoom.GetTileAtWorldPosition (currState.Position.ToVector2 ());
            if (mouseTile != null)
            {
                if (currState.LeftButton == ButtonState.Pressed && prevState.LeftButton == ButtonState.Released)
                {
                    if (CheckIfValidToMove (mouseTile))
                    {
                        SetPositionToTile (mouseTile);
                    }
                }
            }

            prevState = currState;
        }

        private bool CheckIfValidToMove (Tile tile)
        {
            bool valid = false;

            if (tile.X == currentTile.X - 1 && tile.Y == currentTile.Y)
                valid = true;

            if (tile.X == currentTile.X + 1 && tile.Y == currentTile.Y)
                valid = true;

            if (tile.Y == currentTile.Y - 1 && tile.X == currentTile.X)
                valid = true;

            if (tile.Y == currentTile.Y + 1 && tile.X == currentTile.X)
                valid = true;

            return valid;
        }

        public void SetPositionToTile (Tile tile)
        {
            Position = Game1.CurrentRoom.GetTileWorldPosition (tile) + (new Vector2 (TopSprite.Width / 2, TopSprite.Height / 2) * new Vector2 (0.75f));

            if (currentTile != null)
            {
                if (tile.X == currentTile.X + 1)
                    rotation = 1.6f;
                else if (tile.Y == currentTile.Y + 1)
                    rotation = 3.1f;
                else if (tile.Y == currentTile.Y - 1)
                    rotation = 0f;
                else if (tile.X == currentTile.X - 1)
                    rotation = 4.7f;
            }

            currentTile = tile;
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