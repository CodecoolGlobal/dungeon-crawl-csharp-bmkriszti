using SadConsole;
using SadRogue.Primitives;


namespace DungeonCrawl.Tiles
{
    public abstract class Item : GameObject
    {
        protected Item(ColoredGlyph appearance, Point position, IScreenSurface hostingSurface)
            : base(appearance, position, hostingSurface,1,1)
        {
        }
    }
}
    