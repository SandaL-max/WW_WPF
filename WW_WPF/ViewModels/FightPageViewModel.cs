using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media;
using WW_WPF.BL;
using System.Windows.Media.Imaging;

namespace WW_WPF.ViewModels
{
    public class FightPageViewModel : INotifyPropertyChanged
    {
        private AppState appState;
        #region characterHealth
        public int MaxHealth
        {
            get { return appState.Character!.Health.MaxHealth; }
            set
            {
                OnPropertyChanged("MaxHealth");
            }
        }
        public int Health
        {
            get { return appState.Character!.Health.HealthValue; }
            set
            {
                appState.Character!.Health.HealthValue = value;
                OnPropertyChanged("Health");
            }
        }
        #endregion;
        #region characterImage
        private string ResorcesPath = "pack://application:,,,/WW_WPF;component/resources/";
        private ImageSource characterImage;
        public ImageSource CharacterImage
        {
            get
            {
                return characterImage;
            }
            set
            {
                characterImage = value;
                OnPropertyChanged("CharacterImage");
            }
        }
        #endregion;

        #region enemyHealth
        public int EnemyMaxHealth
        {
            get { return appState.Enemy!.Health.MaxHealth; }
            set
            {
                OnPropertyChanged("MaxHealth");
            }
        }
        public int EnemyHealth
        {
            get { return appState.Enemy!.Health.HealthValue; }
            set
            {
                appState.Enemy!.Health.HealthValue = value;
                OnPropertyChanged("Health");
            }
        }
        #endregion;
        #region characterLevelAndDamage
        public string CharacterLevel
        {
            get
            {
                return "Уровень: " + appState.Character!.Level.LevelValue;
            }
            set
            {
                OnPropertyChanged("CharacterLevel");
            }
        }
        public string CharacterDamage
        {
            get
            {
                return "Урон: " + appState.Character!.Damage;
            }
            set
            {
                OnPropertyChanged("CharacterDamage");
            }
        }
        #endregion;
        #region enemyLevelAndDamage
        public string EnemyLevel
        {
            get
            {
                return "Уровень: " + appState.Enemy!.Level.LevelValue;
            }
            set
            {
                OnPropertyChanged("EnemyLevel");
            }
        }
        public string EnemyDamage
        {
            get
            {
                return "Урон: " + appState.Enemy!.Damage;
            }
            set
            {
                OnPropertyChanged("EnemyDamage");
            }
        }
        #endregion;
        #region AttackAndHealButtons
        private RelayCommand _btnAttack;
        public RelayCommand btnAttack
        {
            get
            {
                return _btnAttack ??
                  (_btnAttack = new RelayCommand(obj =>
                  {
                      appState.Character!.Hit(appState.Enemy!);
                      appState.Enemy!.Hit(appState.Character!);
                  }));
            }
        }
        private RelayCommand _btnHeal;
        public RelayCommand btnHeal
        {
            get
            {
                return _btnHeal ??
                  (_btnHeal = new RelayCommand(obj =>
                  {
                      appState.Character!.Health.HealthValue += 20;
                  }));
            }
        }
        #endregion

        public FightPageViewModel()
        {
            appState = new AppState();
            appState.Enemy = new Barbarian();
            var bitMapImage = new BitmapImage();
            bitMapImage.BeginInit();
            if (appState.Character is Warrior)
            {
                bitMapImage.UriSource = new Uri(ResorcesPath + "pngwing.com.png");
            }
            else
            {
                bitMapImage.UriSource = new Uri(ResorcesPath + "pngwing.com(1).png");
            }
            bitMapImage.EndInit();

            var tbm = new TransformedBitmap();
            tbm.BeginInit();
            tbm.Source = bitMapImage;
            if (appState.Character is Wizard)
                tbm.Transform = new ScaleTransform(-1, 1, 0, 0);
            tbm.EndInit();
            CharacterImage = tbm;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
