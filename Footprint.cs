using Microsoft.Xna.Framework.Graphics;

namespace Mr_Footstep
{
    public class Footprint : Entity
    {
        public Texture2D Sprite;
        public FootprintDirection Direction;

        public Footprint (Texture2D sprite, FootprintDirection direction)
        {
            Sprite = sprite;
            Direction = direction;
        }
    }
}