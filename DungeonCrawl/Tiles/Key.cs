using DungeonCrawl.Maps;
using DungeonCrawl.Tiles;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles;
    public class Key : Item
    {
        public Key(Point position, IScreenSurface hostingSurface)
            : base(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, 'K'), position, hostingSurface)
        {
        }
    
    }
