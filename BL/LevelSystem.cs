using System;

namespace WW_WPF.BL
{
    /// <summary>
    /// ��������� ���������, ������� �������� �� ������ � �������
    /// </summary>
    public class LevelSystem
    {
        // ���������, ������� ����� ����������� ����������� ���-�� ����� ��� ��������� ������
        // ��������, ���� ��������� ����� 1.5, �� �� ������ ������ ������ ����� ������� 100 �����, � �� 
        // ������ ��� 150 �����
        protected double _xpToLevelUpMultiplier = 1.5;
        // ������� ���������
        protected int _level = 1;
        // ������� ����
        protected int _xp = 0;
        // ������� ����� ����� ��� ��������� ������
        protected int _xpToLevelUp = 100;
        public int LevelValue => _level;
        public int XP => _xp;
        public int XPToLevelUp => _xpToLevelUp;
        public event Action? levelUp;


        public LevelSystem(int level = 1)
        {
            _level = level;
        }
        // ���� ����� ���������� ��� �������� ����������� ��� ��������� ������
        public virtual void LevelUp()
        {
            _xp = 0;
            _xpToLevelUp = (int)Math.Round(_xpToLevelUp * _xpToLevelUpMultiplier);
            _level++;
            levelUp?.Invoke();
        }

        // ��������� ��������� �������� ����
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