using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WW_WPF.BL
{
    public abstract class Character : Entity, INotifyPropertyChanged
    {
        protected LevelSystem _level = new LevelSystem();
        protected Armor? _armor;
        public Armor? Armor
        {
            get { return _armor; }
            set
            {
                _armor = value;
                OnPropertyChanged("Armor");
            }
        }
        protected Weapon? _weapon;

        public Weapon? Weapon
        {
            get { return _weapon; }
            set
            {
                _weapon = value;
                OnPropertyChanged("Weapon");
            }
        }
        protected int _weaponDamage = 0;
        protected int _armorBonus = 0;

        protected ObservableCollection<IItem> _inventory = new ObservableCollection<IItem>();

        public ObservableCollection<IItem> Inventory
        {
            get { return _inventory; }
            set
            {
                _inventory = value;
                OnPropertyChanged("Inventory");
            }
        }

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
            Level.levelUp += OnLevelUp;
        }

        public override void ApplyDamage(int amount)
        {
            amount -= _armorBonus;
            //amount = Math.Min(amount, 0);
            Armor?.OnTakenDamage(amount);
            base.ApplyDamage(amount);
        }

        // ���� ����� ��������� ������� ���������� ������
        public override void Hit(IHitable hitable)
        {
            base.Hit(hitable);
            if (hitable is Enemy)
            {
                Enemy enemy = (Enemy)hitable;
                Weapon?.OnHit(enemy);
                if (!enemy.IsAlive)
                    Level.AddXp(enemy.Health.MaxHealth);
            }
        }

        public void Equip(IEquipable item)
        {
            if (item is Weapon)
            {
                if (Weapon is not null)
                    Unequip(_weapon);
                Weapon = (Weapon)item;
            }

            if (item is Armor)
            {
                if (_armor is not null)
                    Unequip(_armor);
                Armor = (Armor)item;
            }
            _armorBonus += item.ArmorBonus;
            _weaponDamage += item.DamageBonus;
        }

        public void Unequip(IEquipable item)
        {
            Inventory.Add(item);
            _armorBonus -= item.ArmorBonus;
            _weaponDamage -= item.DamageBonus;
        }

        public virtual void OnLevelUp() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}