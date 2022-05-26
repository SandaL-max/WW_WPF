using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WW_WPF.BL
{
    /// <summary>
    /// ќтдельный компонент, который отвечает за работу с уровнем
    /// </summary>
    public class LevelSystem : INotifyPropertyChanged
    {
        // ћножитель, который будет увеличивать необходимое кол-во опыта дл€ повышени€ уровн€
        // Ќапример, если множитель равен 1.5, то на первом уровне игроку нужно набрать 100 опыта, а на 
        // втором уже 150 опыта
        protected double _xpToLevelUpMultiplier = 1.5;
        // ”ровень персонажа
        protected int _level = 1;
        // “екущий опыт
        protected int _xp = 0;
        // —колько нужно опыта дл€ повышени€ уровн€
        protected int _xpToLevelUp = 100;
        public int LevelValue
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("LevelValue");
            }
        }
        public int XP
        {
            get { return _xp; }
            set
            {
                _xp = value;
                OnPropertyChanged("XP");
            }
        }
        public int XPToLevelUp
        {
            get { return _xpToLevelUp; }
            set
            {
                _xpToLevelUp = value;
                OnPropertyChanged("XPToLevelUp");
            }
        }
        public event Action? levelUp;


        public LevelSystem(int level = 1)
        {
            LevelValue = level;
        }
        // Ётот метод производит все действи€ необходимые дл€ повышени€ уровн€
        public virtual void LevelUp()
        {
            XP = 0;
            XPToLevelUp = (int)Math.Round(XPToLevelUp * _xpToLevelUpMultiplier);
            LevelValue++;
            levelUp?.Invoke();
        }

        // ѕозвол€ет персонажу получить опыт
        public void AddXp(int amount)
        {
            while (amount > 0)
            {
                XP += amount;
                if (XP >= XPToLevelUp)
                {
                    amount = XP - XPToLevelUp;
                    LevelUp();
                }
                else
                {
                    amount = 0;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}