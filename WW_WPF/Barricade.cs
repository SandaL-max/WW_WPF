using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace WW_WPF.BL
{
    /// <summary>
    /// ����� ���������
    /// </summary>
    public class Barricade : IHitable, INotifyPropertyChanged
    {
        // ��������� ���������
        private int durability = 50;

        public int Durability 
        { 
            get => durability;
            set
            {
                if (value >= 0 && value < MaxDurability)
                    durability = value;
                else if (value < 0)
                    durability = 0;
                else
                    durability = MaxDurability;
                OnPropertyChanged("Durability");
            }
        }
        private int maxDurability;
        public int MaxDurability
        {
            get => maxDurability;
            set
            {
                maxDurability = value;
                OnPropertyChanged("MaxDurability");
            }
        }
        public bool IsAlive => Durability > 0;
        public Barricade(int _durability)
        {
            MaxDurability = _durability;
            Durability = _durability;
        }
        public void ApplyDamage(int amount)
        {
            Durability -= amount;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}