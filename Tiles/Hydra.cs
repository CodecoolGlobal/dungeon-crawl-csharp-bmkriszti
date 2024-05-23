using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles
{
    public class Hydra : Monster
    {
        public Hydra(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.AnsiRedBright, Color.Black, 'H'), position, hostingSurface, 25, 10)
        {
        }
    }
}    