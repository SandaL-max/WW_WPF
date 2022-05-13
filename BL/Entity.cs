using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace WW_WPF.BL
{
    /// <summary>
    /// ����� �������� (����� ����� ��� ���� �������)
    /// </summary>
    public abstract class Entity : IHitable, INotifyPropertyChanged
    { 
        private HealthSystem health = new HealthSystem(100, 100);
        public HealthSystem Health
        {
            get { return health; }
            protected set
            {
                health = value;
                OnPropertyChanged("Health");
            }
        }
        protected int _baseDamage = 4;

        private string imageName;
        public string ImageName
        {
            get { return imageName; }
            set
            {
                imageName = value;
                OnPropertyChanged("ImageName");
            }
        }
        public virtual int Damage
        {
            get
            {
                return _baseDamage;
            }
        }
        // ������� � ���, ���� �� ��������
        public bool IsAlive => Health.HealthValue > 0;

        public virtual void ApplyDamage(int amount)
        {
            Health.ApplyDamage(amount);
        }

        public virtual void Hit(IHitable hitable)
        {
            hitable.ApplyDamage(Damage);
        }

        public abstract string GetEntityInfo();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}