using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;
using Console = System.Console;

namespace DungeonCrawl.Tiles
{
    public class Sword : Item
    {
        public Sword(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.Gray, Color.SandyBrown, 'S'), position, hostingSurface)
        {
        }
        // protected override bool Touched(GameObject source, Map map)
        // {
        //     // Is the player the one that touched us?
        //     if (source == map.UserControlledObject)
        //     {
        //         source.AttackDamage += 5;
        //         Inventory.Add(this);
        //         foreach (var item in Inventory)
        //         {
        //             Console.WriteLine($"{item}");
        //         }
        //         
        //         map.RemoveMapObject(this);
        //         return true;
        //     }
        //
        //     return false;
        // }
    }
}