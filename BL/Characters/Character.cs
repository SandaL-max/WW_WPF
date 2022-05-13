namespace WW_WPF.BL
{
    public abstract class Character : Entity
    {
        protected LevelSystem _level = new LevelSystem();
        protected Armor? _armor;
        protected Weapon? _weapon;
        protected int _weaponDamage = 0;
        protected int _armorBonus = 0;

        protected List<IItem> _inventory = new List<IItem>();

        public List<IItem> Inventory => _inventory;

        public LevelSystem Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }

        public override int Damage => _baseDamage + _weaponDamage;

        public Character()
        {
            _level.levelUp += OnLevelUp;
        }

        public override void ApplyDamage(int amount)
        {
            amount -= _armorBonus;
            amount = Math.Min(amount, 0);
            _armor?.OnTakenDamage(amount);
            base.ApplyDamage(amount);
        }

        // ���� ����� ��������� ������� ���������� ������
        public override void Hit(IHitable hitable)
        {
            base.Hit(hitable);
            if (hitable is Enemy)
            {
                Enemy enemy = (Enemy)hitable;
                _weapon?.OnHit(enemy);
                if (!enemy.IsAlive)
                    _level.AddXp(enemy.Health.MaxHealth);
            }
        }

        public void Equip(IEquipable item)
        {
            if (item is Weapon)
            {
                if (_weapon is not null)
                    Unequip(_weapon);
                _weapon = (Weapon)item;
            }

            if (item is Armor)
            {
                if (_armor is not null)
                    Unequip(_armor);
                _armor = (Armor)item;
            }
            _armorBonus += item.ArmorBonus;
            _weaponDamage += item.DamageBonus;
        }

        public void Unequip(IEquipable item)
        {
            _inventory.Add(item);
            _armorBonus -= item.ArmorBonus;
            _weaponDamage -= item.DamageBonus;
        }

        public virtual void OnLevelUp() { }
    }
}