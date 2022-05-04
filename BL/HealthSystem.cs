using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WW_WPF.BL
{
    /// <summary>
    /// Отдельный компонент, который отвечает за работу со здоровьем
    /// </summary>
    public class HealthSystem : INotifyPropertyChanged
    {
        // Здоровье
        protected int _health = 100;
        // Максимальное возможное здоровье
        protected int _maxHealth = 100;

        public virtual int HealthValue
        {
            get => _health;
            set
            {
                if (value < 0)
                    _health = 0;
                else if (value > _maxHealth)
                    _health = _maxHealth;
                else
                    _health = value;
                OnPropertyChanged("HealthValue");
            }
        }
        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                OnPropertyChanged("MaxHelth");
            }
        }

        public HealthSystem(int health, int maxHealth)
        {
            _health = health;
            _maxHealth = maxHealth;
        }

        public void ApplyDamage(int amount)
        {
            HealthValue -= amount;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}