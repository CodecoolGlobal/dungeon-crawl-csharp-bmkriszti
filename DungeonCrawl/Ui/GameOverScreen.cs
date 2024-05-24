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
            
            _gameOverConsole = new SadConsole.Console(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY);

            
            string gameOverMessage = "Game Over";
            int centerX = (_gameOverConsole.Width - gameOverMessage.Length) / 2;
            int centerY = _gameOverConsole.Height / 2;
            _gameOverConsole.Print(centerX, centerY, gameOverMessage);

            
            Children.Add(_gameOverConsole);
        }

        public override bool ProcessKeyboard(Keyboard keyboard)
        {
            
            if (keyboard.IsKeyPressed(Keys.Enter))
            {
                
                RestartGame();
                return true;
            }

            return false;
        }

        private void RestartGame()
        {
            
            Parent.Children.Remove(this);
        }
    }
}