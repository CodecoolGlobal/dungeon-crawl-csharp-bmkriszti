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
        : base(new ColoredGlyph(Color.Yellow, Color.SandyBrown, 15), position, hostingSurface,1,1)
    {
    }

    /// <param name="source"></param>
    /// <param name="map"></param>
    /// <returns></returns>
    protected override bool Touched(GameObject source, Map map)
    {
        // Is the player the one that touched us?
        if (source == map.UserControlledObject)
        {
            source.Hp += 12;
            Console.WriteLine($"+hp{source.Hp}");
            map.RemoveMapObject(this);
            return true;
        }

        return false;
    }
}