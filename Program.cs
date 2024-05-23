using DungeonCrawl.Ui;
using SadConsole;

namespace DungeonCrawl;

/// <summary>
/// Class <c>Program</c> provides an entry point for the game.
/// </summary>
public static class Program
{
    
    private const int ViewPortWidth = 100;
    private const int ViewPortHeight = 30;

    /// <summary>
    /// The entry point of the program.
    /// </summary>
    public static void Main()
    {
        
        Game.Create(ViewPortWidth, ViewPortHeight);

        
        Game.Instance.OnStart = Init;

        
        Game.Instance.Run();
        Game.Instance.Dispose();
    }

    /// <summary>
    /// Initializes the game.
    /// </summary>
    private static void Init()
    {
        Game.Instance.Screen = new RootScreen();
        Game.Instance.Screen.IsFocused = true;

        
        Game.Instance.DestroyDefaultStartingConsole();
    }
}