using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;
using Console = System.Console;


namespace DungeonCrawl.Tiles;

public class Giant : Monster
{
    public Giant(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.Violet, Color.Moccasin, 'G'), position, hostingSurface, 50, 1)
    {
    }
}
