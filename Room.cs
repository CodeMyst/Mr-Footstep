using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mr_Footstep
{
    public class Room : Entity
    {
        private const int Width = 12;
        private const int Height = 12;

        private Tile [,] tiles = new Tile [Width, Height];

        public Room (ContentManager content)
        {
            for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                tiles [x, y] = new Tile ();
                tiles [x, y].Sprite = content.Load<Texture2D> ("Sprites/Tiles/Floor1");
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