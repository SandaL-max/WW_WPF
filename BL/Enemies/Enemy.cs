namespace WW_WPF.BL
{
    public abstract class Enemy : Entity
    {
        protected LevelSystem _level = new LevelSystem();

        public LevelSystem Level => _level;

        public override int Damage => _baseDamage * (_level.LevelValue);

        public Enemy(LevelSystem level = null)
        {
            if(level is null)
                level = new LevelSystem();
            _level = level;
            _level.levelUp += OnLevelUp;
        }

        public virtual void OnLevelUp() { }
    }
}