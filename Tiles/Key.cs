using DungeonCrawl.Maps;
using DungeonCrawl.Tiles;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles;
    public class Key : Item
    {
        public Key(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.Blue, Color.SandyBrown, 'K'), position, hostingSurface)
        {
        }
    //     protected override bool Touched(GameObject source, Map map)
    //     {
    //         // Is the player the one that touched us?
    //         if (source == map.UserControlledObject)
    //         {
    //             map.RemoveMapObject(this);
    //             return true;
    //         }
    //
    //         return false;
    //     }
    }
