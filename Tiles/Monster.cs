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
                    
                    Hp -= source.AttackDamage;
                    source.Hp -= AttackDamage;

                    
                    OnMonsterStateChanged();
                    
                   
                    return false;
                }

                if (Hp <= 0)
                {
                    map.RemoveMapObject(this);

                    
                    OnMonsterStateChanged();
                    
                    return true;
                }
            }
            return false;
        }

        
        public static event EventHandler MonsterStateChanged;

       
        protected virtual void OnMonsterStateChanged()
        {
            MonsterStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}