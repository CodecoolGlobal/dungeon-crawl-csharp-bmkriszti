using DungeonCrawl.Maps;
using SadConsole;
using SadConsole.Input;
using SadRogue.Primitives;

namespace DungeonCrawl.Ui;

/// <summary>
/// Class <c>RootScreen</c> provides parent/child, components, and position.
/// </summary>
public class RootScreen : ScreenObject
{
    private Map _map;
    private SadConsole.Console _inventoryConsole;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RootScreen()
    {
        _map = new Map(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY - 5);

        Children.Add(_map.SurfaceObject);
        
        _inventoryConsole = new SadConsole.Console(Game.Instance.ScreenCellsX, 5);
        _inventoryConsole.Position = new Point(0, Game.Instance.ScreenCellsY - 5);
        _inventoryConsole.DefaultBackground = Color.Black;
        _inventoryConsole.Clear();

        Children.Add(_inventoryConsole);
    }
    
    public void UpdateInventoryDisplay()
    {
        _inventoryConsole.Clear();
        var items = _map.UserControlledObject.Inventory;
        for (int i = 0; i < items.Count; i++)
        {
            _inventoryConsole.Print(0, i, $"{items[i].GetType().Name}");
        }
        _inventoryConsole.IsDirty = true; 
    }

    /// <summary>
    /// Processes keyboard inputs.
    /// </summary>
    /// <param name="keyboard"></param>
    /// <returns></returns>
    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;

        if (keyboard.IsKeyPressed(Keys.Up))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Up, _map);
            handled = true;
        }
        else if (keyboard.IsKeyPressed(Keys.Down))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Down, _map);
            handled = true;
        }

        if (keyboard.IsKeyPressed(Keys.Left))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Left, _map);
            handled = true;
        }
        else if (keyboard.IsKeyPressed(Keys.Right))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Right, _map);
            handled = true;
        }

        return handled;
    }
}