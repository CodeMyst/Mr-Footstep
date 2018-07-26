using System;
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

        private Direction direction = Direction.Down;

        private Tile currentTile;

        public Action OnFinishLevel;

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

            if (tile.Footprint == null)
                return false;

            if (tile.X == currentTile.X - 1 && tile.Y == currentTile.Y)
                valid = true;

            if (tile.X == currentTile.X + 1 && tile.Y == currentTile.Y)
                valid = true;

            if (tile.Y == currentTile.Y - 1 && tile.X == currentTile.X)
                valid = true;

            if (tile.Y == currentTile.Y + 1 && tile.X == currentTile.X)
                valid = true;

            if (GetDirectionOfPossibleTile (tile) != tile.Footprint.Direction)
                valid = false;

            return valid;
        }

        private Direction GetDirectionOfPossibleTile (Tile tile)
        {
            Direction dir = Direction.Down;

            if (tile.X == currentTile.X + 1)
            {
                dir = Direction.Right;
            }
            else if (tile.Y == currentTile.Y + 1)
            {
                dir = Direction.Down;
            }
            else if (tile.Y == currentTile.Y - 1)
            {
                dir = Direction.Up;
            }
            else if (tile.X == currentTile.X - 1)
            {
                dir = Direction.Left;
            }

            return dir;
        }

        public void SetPositionToTile (Tile tile)
        {
            Position = Game1.CurrentRoom.GetTileWorldPosition (tile) + (new Vector2 (TopSprite.Width / 2, TopSprite.Height / 2) * new Vector2 (0.75f));

            if (currentTile != null)
            {
                if (tile.X == currentTile.X + 1)
                {
                    rotation = 1.6f;
                    direction = Direction.Right;
                }
                else if (tile.Y == currentTile.Y + 1)
                {
                    rotation = 3.1f;
                    direction = Direction.Down;
                }
                else if (tile.Y == currentTile.Y - 1)
                {
                    rotation = 0f;
                    direction = Direction.Up;
                }
                else if (tile.X == currentTile.X - 1)
                {
                    rotation = 4.7f;
                    direction = Direction.Left;
                }
            }

            currentTile = tile;

            if (tile.IsFinish)
            {
                currentTile = null;
                direction = Direction.Down;

                OnFinishLevel?.Invoke ();
            }
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