using System;
using DungeonCrawl.Tiles;
using SadConsole;
using SadRogue.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace DungeonCrawl.Maps;

/// <summary>
/// Class <c>Map</c> models a map for the game.
/// </summary>
public class Map
{
    public IReadOnlyList<GameObject> GameObjects => _mapObjects.AsReadOnly();
    public ScreenSurface SurfaceObject => _mapSurface;
    public Player UserControlledObject { get; private set; }
    private List<GameObject> _mapObjects;
    private ScreenSurface _mapSurface;
    private static readonly Point ZeroPoint = new Point(0, 0);

    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mapWidth"></param>
    /// <param name="mapHeight"></param>
    public Map(int mapWidth, int mapHeight)
    {
        _mapObjects = new List<GameObject>();
        _mapSurface = new ScreenSurface(mapWidth, mapHeight);
        _mapSurface.UseMouse = false;

        UserControlledObject = new Player(_mapSurface.Surface.Area.Center, _mapSurface);

        InitializeObjects();
    }

    private void InitializeObjects()
    {
        CreateMultipleObjects(5, CreateTreasure);
        CreateMultipleObjects(5, CreateMonster);
        CreateMultipleObjects(2, () => CreateItem(new Key(ZeroPoint, _mapSurface)));
        CreateMultipleObjects(2, () => CreateItem(new Sword(ZeroPoint, _mapSurface)));
    }

    private void CreateMultipleObjects(int count, Action createObject)
    {
        for (int i = 0; i < count; i++)
        {
            createObject();
        }
    }

    private void CreateItem(GameObject item)
    {
        for (int i = 0; i < 1000; i++)
        {
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));
            if (_mapObjects.All(obj => obj.Position != randomPosition))
            {
                item.Position = randomPosition;
                _mapObjects.Add(item);
                break;
            }
        }
    }

    /// <summary>
    /// Try to find a map object at that position.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public bool TryGetMapObject(Point position, out GameObject gameObject)
    {
        foreach (var otherGameObject in _mapObjects)
        {
            if (otherGameObject.Position == position)
            {
                gameObject = otherGameObject;
                return true;
            }
        }

        gameObject = null;
        return false;
    }

    /// <summary>
    /// Removes an object from the map.
    /// </summary>
    /// <param name="mapObject"></param>
    public void RemoveMapObject(GameObject mapObject)
    {
        if (_mapObjects.Contains(mapObject))
        {
            _mapObjects.Remove(mapObject);
            mapObject.RestoreMap(this);
        }
    }

    /// <summary>
    /// Creates a treasure on the map.
    /// </summary>
    private void CreateTreasure()
    {
        // Try 1000 times to get an empty map position
        for (int i = 0; i < 1000; i++)
        {
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            // If the code reaches here, we've got a good position, create the game object.
            GameObject treasure = new Treasure(randomPosition, _mapSurface);
            _mapObjects.Add(treasure);
            break;
        }
    }

    /// <summary>
    /// Creates a monster on the map.
    /// </summary>
    private void CreateMonster()
    {
        // Try 1000 times to get an empty map position
        for (int i = 0; i < 1000; i++)
        {
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            // If the code reaches here, we've got a good position, create the game object.
            GameObject monster = new Monster(randomPosition, _mapSurface);
            _mapObjects.Add(monster);
            break;
        }
    }
}