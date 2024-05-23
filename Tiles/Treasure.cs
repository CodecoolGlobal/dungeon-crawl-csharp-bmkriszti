using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;
using Console = System.Console;

namespace DungeonCrawl.Tiles;

/// <summary>
/// Class <c>Treasure</c> models a friendly object in the game.
/// </summary>
public class Treasure : GameObject
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="hostingSurface"></param>
    public Treasure(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.Orange, Color.Moccasin, 15), position, hostingSurface,1,1)
    {
    }

    
}