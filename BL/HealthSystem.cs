namespace WW_WPF.BL
{
    /// <summary>
    /// ��������� ���������, ������� �������� �� ������ �� ���������
    /// </summary>
    public class HealthSystem
    {
        // ��������
        protected int _health = 100;
        // ������������ ��������� ��������
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
            }
        }
        public int MaxHealth => _maxHealth;

        public HealthSystem(int health, int maxHealth)
        {
            _health = health;
            _maxHealth = maxHealth;
        }

        public void ApplyDamage(int amount)
        {
            HealthValue -= amount;
        }
    }
}