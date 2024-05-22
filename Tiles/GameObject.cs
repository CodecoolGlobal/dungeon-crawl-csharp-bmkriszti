using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles
{
    public abstract class GameObject
    {
        public Point Position { get; set; }
        public void RestoreMap(Map map) => _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);
        private ColoredGlyph Appearance { get; set; }
        private ColoredGlyph _mapAppearance = new ColoredGlyph();
        protected Map map;

        protected GameObject(ColoredGlyph appearance, Point position, IScreenSurface hostingSurface)
        {
            Appearance = appearance;
            Position = position;

            hostingSurface.Surface[position].CopyAppearanceTo(_mapAppearance);

            DrawGameObject(hostingSurface);
        }

        public bool Move(Point newPosition, Map map)
        {
            if (!map.SurfaceObject.Surface.IsValidCell(newPosition.X, newPosition.Y) || map.IsWall(newPosition)) 
                return false;

            if (map.TryGetMapObject(newPosition, out GameObject foundObject))
            {
                if (!foundObject.Touched(this, map))
                {
                    return false;
                }
            }

            _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);
            map.SurfaceObject.Surface[newPosition].CopyAppearanceTo(_mapAppearance);

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
