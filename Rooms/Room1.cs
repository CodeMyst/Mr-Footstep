using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mr_Footstep
{
    public class Room1 : Room
    {
        public Room1 (ContentManager content) : base (content)
        {
            Texture2D fp1 = content.Load<Texture2D> ("Sprites/Prints/Print1");

            Footprints [0, 1] = new Footprint (fp1, FootprintDirection.Down);
            Footprints [0, 2] = new Footprint (fp1, FootprintDirection.Down);
            Footprints [0, 3] = new Footprint (fp1, FootprintDirection.Down);
            Footprints [0, 4] = new Footprint (fp1, FootprintDirection.Down);
            Footprints [0, 5] = new Footprint (fp1, FootprintDirection.Down);
            Footprints [1, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [2, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [3, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [4, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [5, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [6, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [7, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [8, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [9, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [10, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [11, 5] = new Footprint (fp1, FootprintDirection.Right);
            Footprints [11, 6] = new Footprint (fp1, FootprintDirection.Down);
            Footprints [11, 7] = new Footprint (fp1, FootprintDirection.Down);
            Footprints [11, 8] = new Footprint (fp1, FootprintDirection.Down);
            Footprints [11, 9] = new Footprint (fp1, FootprintDirection.Down);
            Footprints [11, 10] = new Footprint (fp1, FootprintDirection.Down);
            Footprints [11, 11] = new Footprint (fp1, FootprintDirection.Down);
        
            PlaceFootprints ();
        }
    }
}