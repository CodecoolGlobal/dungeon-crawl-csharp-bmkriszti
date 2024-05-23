using System.Collections.Generic;
using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles
{
    public abstract class GameObject
    {
        public Point Position { get; set; }
        public int Hp { get; set; }
        public int AttackDamage { get; set; }
        public static List<GameObject> Inventory { get; private set; } = new List<GameObject>();
        public void RestoreMap(Map map) => _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);
        public ColoredGlyph Appearance { get; set; }
        private ColoredGlyph _mapAppearance = new ColoredGlyph();
        protected Map map;

        protected GameObject(ColoredGlyph appearance, Point position, IScreenSurface hostingSurface,int hp,int attackDamage)
        {
            Appearance = appearance;
            Position = position;
            Hp = hp;
            AttackDamage = attackDamage;
            Inventory = new List<GameObject>();

            hostingSurface.Surface[position].CopyAppearanceTo(_mapAppearance);

            DrawGameObject(hostingSurface);
        }

        public bool Move(Point newPosition, Map map)
        {
            if (!map.SurfaceObject.Surface.IsValidCell(newPosition.X, newPosition.Y) || map.IsWall(newPosition)) 
                return false;

            if (map.TryGetMapObject(newPosition, out GameObject foundObject))
            {
                if (foundObject != null)
                {
                    if (foundObject.Touched(this, map))
                    {
                        return false;
                    }

                    if (this is Player player && (foundObject is Key || foundObject is Sword || foundObject is Treasure))
                    {
                        player.Inventory.Add(foundObject);
                        //player.DisplayInventory();
                        map.RemoveMapObject(foundObject);

                        if (foundObject is Sword)
                        {
                            player.AttackDamage += 5;
                        }

                        if (foundObject is Treasure)
                        {
                            player.Hp += 15;
                        }
                    }
                }
            }
            _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);
            map.SurfaceObject.Surface[newPosition].CopyAppearanceTo(_mapAppearance);
            
            //_mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);
            Position = newPosition;
            DrawGameObject(map.SurfaceObject);
            

            return true;
        }

        protected virtual bool Touched(GameObject source, Map map)
        {
            
            return false;
        }

        private void DrawGameObject(IScreenSurface screenSurface)
        {
            // Appearance.CopyAppearanceTo(screenSurface.Surface[Position]); 
            // screenSurface.IsDirty = true;
            // if (map != null && map.TryGetMapObject(Position, out GameObject existingObject) && existingObject != this)
            // {
            //     existingObject.DrawGameObject(screenSurface);
            // }
            // Appearance.CopyAppearanceTo(screenSurface.Surface[Position]);
            // screenSurface.IsDirty = true;
            if (map != null && map.TryGetMapObject(Position, out GameObject existingObject) && existingObject != this)
            {
                existingObject.Appearance.CopyAppearanceTo(screenSurface.Surface[Position]);
            }
            else
            {
                // Draw the current object's appearance.
                Appearance.CopyAppearanceTo(screenSurface.Surface[Position]);
            }

            // Mark the screen as dirty to indicate it needs to be redrawn.
            screenSurface.IsDirty = true;
        }
    }
}
