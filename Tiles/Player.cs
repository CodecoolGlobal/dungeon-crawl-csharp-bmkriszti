﻿using System.Collections.Generic;
using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;
using System;
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
        : base(new ColoredGlyph(Color.Green, Color.Transparent, 2), position, hostingSurface, 50, 5)
    {
        Inventory = new List<GameObject>();

    }


    public void DisplayInventory()
    {
        Console.WriteLine("Inventory:");
        foreach (var item in Inventory)
        {
            Console.WriteLine("- " + item.GetType().Name);
        }
    }

}
    // protected override bool Touched(GameObject source, Map map)
    // {
    //     // If a Player touches an item, pick it up
    //     if (source is Key || source is Treasure)
    //     {
    //         
    //         Inventory.Add(source);
    //         map.RemoveMapObject(source);
    //         
    //         return true; 
    //     }
    //
    //     if (source is Sword sword)
    //     {
    //         // Increment attack damage
    //         AttackDamage += 2;
    //
    //         // Add the sword to inventory
    //         Inventory.Add(sword);
    //
    //         // Remove the sword from the map
    //         map.RemoveMapObject(sword);
    //
    //         // Optionally, display a message indicating the sword was picked up
    //         Console.WriteLine("You picked up a sword!");
    //
    //         // Optionally, display the updated attack damage
    //         Console.WriteLine($"New attack damage: {AttackDamage}");
    //
    //         return true;
    //     }
    //     return base.Touched(source, map);
    // }
