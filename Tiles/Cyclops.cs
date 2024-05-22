using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;
using Console = System.Console;


namespace DungeonCrawl.Tiles;

public class Cyclops : Monster
{
    public Cyclops(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.Blue, Color.SandyBrown, 'C'), position, hostingSurface, 15, 5)
    {
    }
}
