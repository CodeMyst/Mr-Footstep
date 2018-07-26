using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mr_Footstep
{
    public class Room : Entity
    {
        private const int Width = 12;
        private const int Height = 12;

        protected Tile [,] Tiles = new Tile [Width, Height];
        protected Footprint [,] Footprints = new Footprint [Width, Height];

        public Room (ContentManager content)
        {
            Texture2D hoverSprite = content.Load<Texture2D> ("Sprites/Tiles/TileHover");

            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                Tiles [x, y] = new Tile ();
                Tiles [x, y].Sprite = content.Load<Texture2D> ("Sprites/Tiles/Floor1");
                Tiles [x, y].HoverSprite = hoverSprite;
                Tiles [x, y].X = x;
                Tiles [x, y].Y = y;
                int spriteWidth = Tiles [x, y].Sprite.Width;
                int spriteHeight = Tiles [x, y].Sprite.Height;
                Tiles [x, y].Position = new Vector2 (x * spriteWidth / 2, y * spriteHeight / 2 );
            }
        }

        protected void PlaceFootprints ()
        {
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                Tiles [x, y].PlaceFootprint (Footprints [x, y]);
            }
        }

        protected void SetFinishTile (Tile tile)
        {
            tile.IsFinish = true;
        }

        public Vector2 GetTileWorldPosition (int x, int y)
        {
            Tile tile = Tiles [x, y];

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
                if (Tiles [x, y].Rectangle.Contains (position))
                    return Tiles [x, y];
            }

            return null;
        }

        public override void Update (float deltaTime)
        {
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                Tiles [x, y].Update (deltaTime);
            }
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                Tiles [x, y].Draw (spriteBatch);
            }
        }
    }
}