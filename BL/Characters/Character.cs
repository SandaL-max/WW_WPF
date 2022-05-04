using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WW_WPF.BL
{
    public abstract class Character : Entity
    {
        protected LevelSystem _level = new LevelSystem();

        public LevelSystem Level
        {
            get { return _level; }
            set 
            { 
                _level = value; 
                OnPropertyChanged("Level");
            }
        }

        public Character()
        {
            _level.levelUp += OnLevelUp;
        }

        // Этот метод позволяет ударить переданный объект
        public override void Hit(IHitable hitable)
        {
            base.Hit(hitable);
            if (hitable is Enemy)
            {
                Enemy enemy = (Enemy)hitable;
                if (!enemy.IsAlive)
                    _level.AddXp(enemy.Health.MaxHealth);
            }
        }

        public virtual void OnLevelUp() { }
    }
}