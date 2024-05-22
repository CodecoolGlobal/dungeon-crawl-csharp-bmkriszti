using DungeonCrawl.Ui;
using SadConsole;

namespace DungeonCrawl;

/// <summary>
/// Class <c>Program</c> provides an entry point for the game.
/// </summary>
public static class Program
{
    private const int ViewPortWidth = 30;
    private const int ViewPortHeight = 15;

    /// <summary>
    /// The entry point of the program.
    /// </summary>
    public static void Main()
    {
        // Setup the engine and create the main window.
        Game.Create(ViewPortWidth, ViewPortHeight);

        // Hook the start event so we can add consoles to the system.
        Game.Instance.OnStart = Init;

        // Start the game.
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

        // This is needed because we replaced the initial screen object with our own.
        Game.Instance.DestroyDefaultStartingConsole();
    }
}