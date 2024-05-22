using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;
using Console = System.Console;

namespace DungeonCrawl.Tiles
{
    public abstract class Monster : GameObject
    {
        public Monster(ColoredGlyph appearance, Point position, IScreenSurface hostingSurface, int hp, int attackDamage)
            : base(appearance, position, hostingSurface, hp, attackDamage)
        {
        }

        protected override bool Touched(GameObject source, Map map)
        {
            if (source == map.UserControlledObject)
            {
                if (Hp > 0)
                {
                    Hp -= source.AttackDamage;
                    source.Hp -= AttackDamage;
                    Console.WriteLine($"Player {source.Hp},{source.AttackDamage}");
                    Console.WriteLine($"Monster {Hp}");
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
}