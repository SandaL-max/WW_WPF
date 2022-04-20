namespace WW_WPF.BL
{
    /// <summary>
    /// ����� �������� (����� ����� ��� ���� �������)
    /// </summary>
    public abstract class Entity : IHitable
    { 
        public HealthSystem Health { get; protected set; } = new HealthSystem(100, 100);
        protected int _baseDamage = 4;

        public virtual int Damage
        {
            get
            {
                return _baseDamage;
            }
        }
        // ������� � ���, ���� �� ��������
        public bool IsAlive => Health.HealthValue > 0;

        public void ApplyDamage(int amount)
        {
            Health.ApplyDamage(amount);
        }

        public virtual void Hit(IHitable hitable)
        {
            hitable.ApplyDamage(Damage);
        }

        public abstract string GetEntityInfo();
    }
}