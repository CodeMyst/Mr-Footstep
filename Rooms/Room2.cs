using Microsoft.Xna.Framework.Content;

namespace Mr_Footstep
{
    public class Room2 : Room
    {
        public Room2 (ContentManager content) : base (content)
        {
            SetFinishTile (Tiles [11, 11]);
        }
    }
}