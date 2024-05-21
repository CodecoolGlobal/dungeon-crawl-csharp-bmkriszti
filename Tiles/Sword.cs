using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles;


public class Sword : GameObject
{
    public Sword(Point position, IScreenSurface hostingSurface) : base(new ColoredGlyph(Color.Gray, Color.Transparent, 'S'), position, hostingSurface)
    {
        
    }
}