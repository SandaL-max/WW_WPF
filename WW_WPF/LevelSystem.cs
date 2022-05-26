using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WW_WPF.BL
{
    /// <summary>
    /// ��������� ���������, ������� �������� �� ������ � �������
    /// </summary>
    public class LevelSystem : INotifyPropertyChanged
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
        // ���� ����� ���������� ��� �������� ����������� ��� ��������� ������
        public virtual void LevelUp()
        {
            XP = 0;
            XPToLevelUp = (int)Math.Round(XPToLevelUp * _xpToLevelUpMultiplier);
            LevelValue++;
            levelUp?.Invoke();
        }

        // ��������� ��������� �������� ����
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