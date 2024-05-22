using System.Collections.Generic;
using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;
using Console = System.Console;

namespace DungeonCrawl.Tiles;

/// <summary>
/// Class <c>Player</c> models a user controlled object in the game.
/// </summary>
public class Player : GameObject
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="hostingSurface"></param>
    ///
    public List<GameObject> Inventory { get; private set; } = new List<GameObject>();
    
    public Player(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.Green, Color.SandyBrown, 2), position, hostingSurface)
    {
        Inventory = new List<GameObject>();
    }
    
    protected override bool Touched(GameObject source, Map map)
    {
        // If a Player touches an item, pick it up
        if (source is Key || source is Sword || source is Treasure)
        {
            Inventory.Add(source);
            map.RemoveMapObject(source);
            
            return true; 
        }
        return base.Touched(source, map);
    }
    
}