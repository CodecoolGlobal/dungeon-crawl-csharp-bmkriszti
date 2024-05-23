using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles
{
    public class Hydra : Monster
    {
        public Hydra(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.Red, Color.Moccasin, 'H'), position, hostingSurface, 25, 10)
        {
        }
    }
}    