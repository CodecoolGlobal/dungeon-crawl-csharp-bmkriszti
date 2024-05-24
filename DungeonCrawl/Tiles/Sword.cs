using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;
using Console = System.Console;

namespace DungeonCrawl.Tiles
{
    public class Sword : Item
    {
        public Sword(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.Pink, Color.Black, 'S'), position, hostingSurface)
        {
        }
        
    }
}