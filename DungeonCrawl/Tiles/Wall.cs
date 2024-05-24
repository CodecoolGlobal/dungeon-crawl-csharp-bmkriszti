using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles;

/// <summary>
/// Class <c>Monster</c> models a hostile object in the game.
/// </summary>
public class Wall : GameObject
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="hostingSurface"></param>
    public Wall(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.White, Color.Black, '#'), position, hostingSurface,1,1)
    {
    }
}