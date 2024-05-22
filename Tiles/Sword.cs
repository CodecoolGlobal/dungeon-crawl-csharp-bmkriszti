using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles
{
    public class Sword : Item
    {
        public Sword(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.Gray, Color.Transparent, 'S'), position, hostingSurface)
        {
        }
        protected override bool Touched(GameObject source, Map map)
        {
            // Is the player the one that touched us?
            if (source == map.UserControlledObject)
            {
                map.RemoveMapObject(this);
                return true;
            }

            return false;
        }
    }
}