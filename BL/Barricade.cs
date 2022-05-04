using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace WW_WPF.BL
{
    /// <summary>
    /// Класс баррикады
    /// </summary>
    public class Barricade : IHitable, INotifyPropertyChanged
    {
        // Прочность баррикады
        private int durability = 50;

        public int MaxDurability;
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
        public bool IsAlive => Durability > 0;
        public Barricade(int _durability)
        {
            Durability = _durability;
            MaxDurability = _durability;
            OnPropertyChanged("MaxDurability");
        }
        public void ApplyDamage(int amount)
        {
            durability -= amount;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}