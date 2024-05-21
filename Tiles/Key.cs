using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles;

public class Key : GameObject
{
    public Key(Point position, IScreenSurface hostingSurface) : base(new ColoredGlyph(Color.Cyan, Color.Transparent, 'K'), position, hostingSurface)
    {
        
    }
}