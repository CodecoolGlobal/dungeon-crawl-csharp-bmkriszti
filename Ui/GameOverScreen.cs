using SadConsole;
using SadConsole.Input;
using SadRogue.Primitives;

namespace DungeonCrawl.Ui
{
    public class GameOverScreen : ScreenObject
    {
        private SadConsole.Console _gameOverConsole;

        public GameOverScreen()
        {
            // Create a console to display the game over message
            _gameOverConsole = new SadConsole.Console(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY);

            // Set up the game over message
            string gameOverMessage = "Game Over";
            int centerX = (_gameOverConsole.Width - gameOverMessage.Length) / 2;
            int centerY = _gameOverConsole.Height / 2;
            _gameOverConsole.Print(centerX, centerY, gameOverMessage);

            // Add the game over console to the screen
            Children.Add(_gameOverConsole);
        }

        public override bool ProcessKeyboard(Keyboard keyboard)
        {
            // Check for user input to restart or quit the game
            if (keyboard.IsKeyPressed(Keys.Enter))
            {
                // Restart the game
                RestartGame();
                return true;
            }

            return false;
        }

        private void RestartGame()
        {
            // Reset the game state and restart the game
            // For example, you might reset player stats, clear the map, etc.
            // Then, remove the game over screen from the children
            Parent.Children.Remove(this);
        }
    }
}