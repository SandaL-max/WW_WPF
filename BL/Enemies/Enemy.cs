namespace WW_WPF.BL
{
    public abstract class Enemy : Entity
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
        private Barricade barricade;
        public Barricade Barricade
        {
            get => barricade;
            set
            {
                barricade = value;
                OnPropertyChanged("Barricade");
            }
        }
        public override int Damage
        {
            get { return _baseDamage * (_level.LevelValue); }
        }

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