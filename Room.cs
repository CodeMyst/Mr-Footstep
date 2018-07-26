using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Mr_Footstep
{
    public class Room : Entity
    {
        private const int Width = 12;
        private const int Height = 12;

        private Tile [,] tiles = new Tile [Width, Height];

        public Room (ContentManager content)
        {
            Texture2D hoverSprite = content.Load<Texture2D> ("Sprites/Tiles/TileHover");

            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                tiles [x, y] = new Tile ();
                tiles [x, y].Sprite = content.Load<Texture2D> ("Sprites/Tiles/Floor1");
                tiles [x, y].HoverSprite = hoverSprite;
                tiles [x, y].X = x;
                tiles [x, y].Y = y;
                int spriteWidth = tiles [x, y].Sprite.Width;
                int spriteHeight = tiles [x, y].Sprite.Height;
                tiles [x, y].Position = new Vector2 (x * spriteWidth / 2, y * spriteHeight / 2 );
            }
        }

        public Vector2 GetTileWorldPosition (int x, int y)
        {
            Tile tile = tiles [x, y];

            int spriteWidth = tile.Sprite.Width;
            int spriteHeight = tile.Sprite.Height;

            return new Vector2 (x * spriteWidth / 2, y * spriteHeight / 2);
        }

        public Vector2 GetTileWorldPosition (Tile tile)
        {
            return GetTileWorldPosition (tile.X, tile.Y);
        }

        public Tile GetTileAtWorldPosition (Vector2 position)
        {
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                if (tiles [x, y].Rectangle.Contains (position))
                    return tiles [x, y];
            }

            return null;
        }

        public override void Update (float deltaTime)
        {
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                tiles [x, y].Update (deltaTime);
            }
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                tiles [x, y].Draw (spriteBatch);
            }
        }
    }
}