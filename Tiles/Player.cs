using System.Collections.Generic;
using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;
using System;
using DungeonCrawl.Ui;
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
        : base(new ColoredGlyph(Color.Lime, Color.Black, 2), position, hostingSurface, 50, 5)
    {
        Inventory = new List<GameObject>();

    }

    public bool Move(Point newPosition, Map map)
    {
        base.Move(newPosition, map);


        (Game.Instance.Screen as RootScreen)?.UpdateInventoryDisplay();
        return true;
    }

    protected override bool Touched(GameObject source, Map map)
    {
        base.Touched(source, map);


        if (source is Item item)
        {
            Inventory.Add(item);
            map.RemoveMapObject(item);
            (Game.Instance.Screen as RootScreen)?.UpdateInventoryDisplay();
        }

        return true;
    }
}
