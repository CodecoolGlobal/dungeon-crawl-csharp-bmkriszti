using System;
using System.Collections.Generic;
using System.Linq;
using DungeonCrawl.Tiles;
using SadConsole;
using SadRogue.Primitives;
using Console = System.Console;
using Key = DungeonCrawl.Tiles.Key;

namespace DungeonCrawl.Maps
{
    public class Map
    {
        public IReadOnlyList<GameObject> GameObjects => _mapObjects.AsReadOnly();
        public ScreenSurface SurfaceObject => _mapSurface;
        public Player UserControlledObject { get; private set; }
        private List<GameObject> _mapObjects;
        private ScreenSurface _mapSurface;
        private static readonly Point ZeroPoint = new Point(0, 0);

        public Map(int mapWidth, int mapHeight)
        {
            _mapObjects = new List<GameObject>();
            _mapSurface = new ScreenSurface(mapWidth, mapHeight);
            _mapSurface.UseMouse = false;

            UserControlledObject = new Player(_mapSurface.Surface.Area.Center, _mapSurface);
            _mapObjects.Add(UserControlledObject);
            FillBackground();

            CreateMultipleObjects(mapWidth*mapHeight/10, CreateWall);
            InitializeObjects();
        }
        private void FillBackground()
        {
            Color[] colors = new[] { Color.SandyBrown, Color.SandyBrown, Color.SandyBrown, Color.SandyBrown };
            float[] colorStops = new[] { 0f, 0.35f, 0.75f, 1f };

            Algorithms.GradientFill(_mapSurface.FontSize,
                _mapSurface.Surface.Area.Center,
                _mapSurface.Surface.Width / 3,
                45,
                _mapSurface.Surface.Area,
                new Gradient(colors, colorStops),
                (x, y, color) => _mapSurface.Surface[x, y].Background = color);
        }

        private void InitializeObjects()
        {
            CreateMultipleObjects(5, CreateTreasure);
            CreateMultipleObjects(5, CreateMonster);
            CreateMultipleObjects(2, CreateKey); 
            CreateMultipleObjects(2, CreateSword);
            
        }

        private void CreateMultipleObjects(int count, Action createObject)
        {
            for (int i = 0; i < count; i++)
            {
                createObject();
            }
        }

        private void CreateKey()
        {
            for (int i = 0; i < 1000; i++)
            {
                Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                    Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

                bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
                if (foundObject) continue;

                GameObject key = new Key(randomPosition, _mapSurface);
                _mapObjects.Add(key);
                break;
            }
        }

        private void CreateSword()
        {
            for (int i = 0; i < 1000; i++)
            {
                Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                    Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

                bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
                if (foundObject) continue;

                GameObject sword = new Sword(randomPosition, _mapSurface);
                _mapObjects.Add(sword);
                break;
            }
        }

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

        public void RemoveMapObject(GameObject mapObject)
        {
            if (_mapObjects.Contains(mapObject))
            {
                _mapObjects.Remove(mapObject);
                mapObject.RestoreMap(this);
            }
        }

        private void CreateTreasure()
        {
            for (int i = 0; i < 1000; i++)
            {
                Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                    Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

                bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
                if (foundObject) continue;

                GameObject treasure = new Treasure(randomPosition, _mapSurface);
                _mapObjects.Add(treasure);
                break;
            }
        }

        private void CreateMonster()
        {
            for (int i = 0; i < 1000; i++)
            {
                Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                    Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

                bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
                if (foundObject) continue;

                GameObject monster = new Monster(randomPosition, _mapSurface);
                _mapObjects.Add(monster);
                break;
            }
        }
        
        private void CreateWall()
        {
            for (int i = 0; i < 1000; i++)
            {
                Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                    Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

                bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
                if (foundObject) continue;

                GameObject wall = new Wall(randomPosition, _mapSurface);
                _mapObjects.Add(wall);
                break;
            }
        }
        public bool IsWall(Point position)
        {
            var cell = _mapSurface.Surface[position];
            // Assume '#' represents a wall
            return cell.Glyph == '#';
        }
    }
}
