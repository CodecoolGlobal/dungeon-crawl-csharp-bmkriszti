using System;
using System.Collections.Generic;
using DungeonCrawl.Maps;
using DungeonCrawl.Tiles;
using SadConsole;
using SadConsole.Input;
using SadRogue.Primitives;

namespace DungeonCrawl.Ui
{
    public class RootScreen : ScreenObject
    {
        private Map _map;
        private SadConsole.Console _inventoryConsole;
        private SadConsole.Console _statsConsole; // Add a stats console
        private GameOverScreen _gameOverScreen;

        public RootScreen()
        {
            _map = new Map(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY - 5);
            _gameOverScreen = new GameOverScreen();

            Children.Add(_map.SurfaceObject);
            
            _inventoryConsole = new SadConsole.Console(Game.Instance.ScreenCellsX, 5);
            _inventoryConsole.Position = new Point(0, Game.Instance.ScreenCellsY - 5);
            _inventoryConsole.DefaultBackground = Color.Black;
            _inventoryConsole.Clear();

            Children.Add(_inventoryConsole);

            _statsConsole = new SadConsole.Console(Game.Instance.ScreenCellsX, 5); 
            _statsConsole.Position = new Point(0, Game.Instance.ScreenCellsY - 10); 
            _statsConsole.DefaultBackground = Color.Black;
            _statsConsole.Clear();

            Children.Add(_statsConsole); 

            
            Monster.MonsterStateChanged += OnMonsterStateChanged;
        }
        private void OnMonsterStateChanged(object sender, EventArgs e)
        {
            
            if (sender is Monster monster)
            {
                
                UpdateCharacterStatsDisplay(monster);
            }
        }
        
        public void UpdateInventoryDisplay()
        {
            _inventoryConsole.Clear();

            var items = _map.UserControlledObject.Inventory;
            Dictionary<string, int> itemCounts = new Dictionary<string, int>();
            foreach (var item in items)
            {
                string itemName = item.GetType().Name;
                if (itemCounts.ContainsKey(itemName))
                {
                    itemCounts[itemName]++;
                }
                else
                {
                    itemCounts[itemName] = 1;
                }
            }
            int row = 0;
            foreach (var kvp in itemCounts)
            {
                _inventoryConsole.Print(0, row++, $"{kvp.Key} x{kvp.Value}");
            }

            _inventoryConsole.IsDirty = true;
        }

        public void UpdateCharacterStatsDisplay(Monster monster)
        {
            _statsConsole.Clear();

            var player = _map.UserControlledObject;

            
            _statsConsole.Print(0, 0, $"Player HP: {player.Hp}");
            _statsConsole.Print(0, 1, $"Player Attack: {player.AttackDamage}");

            
            _statsConsole.Print(0, 3, $"Monster HP: {monster.Hp}");
            _statsConsole.Print(0, 4, $"Monster Attack: {monster.AttackDamage}");

            _statsConsole.IsDirty = true;
        }

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
            if (_map.UserControlledObject.Hp <= 0)
            {
                
                ShowGameOverScreen();
                handled = true; 
            }
            else if (keyboard.IsKeyPressed(Keys.Right))
            {
                _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Right, _map);
                handled = true;
            }

            return handled;
        }
        private void ShowGameOverScreen()
        {
            
            Children.Add(_gameOverScreen);
        }
    }
}