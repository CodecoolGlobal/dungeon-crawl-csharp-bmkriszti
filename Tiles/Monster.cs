using System;
using DungeonCrawl.Maps;
using SadConsole;
using SadRogue.Primitives;

namespace DungeonCrawl.Tiles
{
    public abstract class Monster : GameObject
    {
        public int Hp { get; protected set; }
        public int AttackDamage { get; protected set; }

        public Monster(ColoredGlyph appearance, Point position, IScreenSurface hostingSurface, int hp, int attackDamage)
            : base(appearance, position, hostingSurface,hp,attackDamage)
        {
            Hp = hp;
            AttackDamage = attackDamage;
        }

        protected override bool Touched(GameObject source, Map map)
        {
            if (source == map.UserControlledObject)
            {
                if (Hp > 0)
                {
                    // Player and monster take damage
                    Hp -= source.AttackDamage;
                    source.Hp -= AttackDamage;

                    // Notify subscribers that the monster's state has changed
                    OnMonsterStateChanged();
                    
                    // Check if monster is still alive
                    return false;
                }

                if (Hp <= 0)
                {
                    map.RemoveMapObject(this);

                    // Notify subscribers that the monster's state has changed
                    OnMonsterStateChanged();
                    
                    return true;
                }
            }
            return false;
        }

        // Define an event to notify when the monster's state changes
        public static event EventHandler MonsterStateChanged;

        // Method to raise the MonsterStateChanged event
        protected virtual void OnMonsterStateChanged()
        {
            MonsterStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}