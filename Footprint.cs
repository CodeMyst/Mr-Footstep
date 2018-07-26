using Microsoft.Xna.Framework.Graphics;

namespace Mr_Footstep
{
    public class Footprint : Entity
    {
        public Texture2D Sprite;
        public Direction Direction;

        public Footprint (Texture2D sprite, Direction direction)
        {
            Sprite = sprite;
            Direction = direction;
        }
    }
}