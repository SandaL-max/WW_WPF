using System;

namespace WW_WPF.BL
{
    /// <summary>
    /// ќтдельный компонент, который отвечает за работу с уровнем
    /// </summary>
    public class LevelSystem
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
        public int LevelValue => _level;
        public int XP => _xp;
        public int XPToLevelUp => _xpToLevelUp;
        public event Action? levelUp;


        public LevelSystem(int level = 1)
        {
            _level = level;
        }
        // Ётот метод производит все действи€ необходимые дл€ повышени€ уровн€
        public virtual void LevelUp()
        {
            _xp = 0;
            _xpToLevelUp = (int)Math.Round(_xpToLevelUp * _xpToLevelUpMultiplier);
            _level++;
            levelUp?.Invoke();
        }

        // ѕозвол€ет персонажу получить опыт
        public void AddXp(int amount)
        {
            while (amount > 0)
            {
                _xp += amount;
                if (_xp >= _xpToLevelUp)
                {
                    amount = _xp - _xpToLevelUp;
                    LevelUp();
                }
                else
                {
                    amount = 0;
                }
            }
        }
    }
}