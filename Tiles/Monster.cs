using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;
using Console = System.Console;

namespace DungeonCrawl.Tiles;

/// <summary>
/// Class <c>Monster</c> models a hostile object in the game.
/// </summary>
public class Monster : GameObject
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="hostingSurface"></param>
    public Monster(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.Red, Color.SandyBrown, 'M'), position, hostingSurface,30,2)
    {
    }
    protected override bool Touched(GameObject source, Map map)
    {
        // Is the player the one that touched us?
        if (source == map.UserControlledObject)
        {
            if (Hp > 0)
            {
                
                Hp -= source.AttackDamage;
      
                Console.WriteLine($"{Hp}");
                return false;
            }

            if (Hp <= 0)
            {
                map.RemoveMapObject(this);
                return true;
            }
        }
        return false;
    }
}