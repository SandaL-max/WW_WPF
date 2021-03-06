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
using System.Windows.Media.Imaging;
using WW_WPF.BL;

namespace WW_WPF.ViewModels
{
    public class FightPageViewModel : INotifyPropertyChanged
    {
        private AppState _appState;
        public AppState appState
        {
            get { return _appState; }
            set
            {
                _appState = value;
                OnPropertyChanged("appState");
            }
        }
        private Page page;

        public Page Page
        {
            get { return page; }
            set { page = value; }
        }
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
        #region enemyImage
        private ImageSource enemyImage;
        public ImageSource EnemyImage
        {
            get
            {
                return enemyImage;
            }
            set
            {
                enemyImage = value;
                OnPropertyChanged("EnemyImage");
            }
        }
        #endregion;
        #region Barricade
        private string barricadeVisibility;
        public string BarricadeVisibility
        {
            get { return barricadeVisibility; }
            set
            {
                barricadeVisibility = value;
                OnPropertyChanged("BarricadeVisibility");
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
                      if (appState.Enemy!.Barricade is not null && appState.Enemy.Barricade.IsAlive)
                      {
                          appState.Character!.Hit(appState.Enemy.Barricade);
                          if (!appState.Enemy.Barricade.IsAlive)
                              BarricadeVisibility = "Hidden";
                      }
                      else
                          appState.Character!.Hit(appState.Enemy!);
                      appState.Enemy!.Hit(appState.Character!);
                      if (!appState.Enemy!.IsAlive)
                      {
                          var enemyDrop = appState.Enemy.GetDrop();
                          foreach (var item in enemyDrop)
                          {
                              appState.Character.Inventory.Add(item);
                          }
                          Random rnd = new Random();
                          if (rnd.Next(0, 101) >= 50) 
                              appState.Enemy = new Barbarian(new LevelSystem(rnd.Next(1, appState.Character.Level.LevelValue + 1)));
                          else
                              appState.Enemy = new Slime(new LevelSystem(rnd.Next(1, appState.Character.Level.LevelValue + 1)));
                          EnemyImage = AppState.GetImageFromSources(appState.Enemy.ImageName);
                          if (rnd.Next(0, 101) >= 50)
                          {
                              appState.Enemy!.Barricade = new Barricade(50);
                              BarricadeVisibility = "Visible";
                          }
                      }
                      if (!appState.Character!.IsAlive)
                      {
                          var GameOverPage = new GameOver();
                          Page.NavigationService.Navigate(AppState.GameOverPage);
                      }
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
        private RelayCommand _btnInventory;
        public RelayCommand btnInventory
        {
            get
            {
                return _btnInventory ??
                  (_btnInventory = new RelayCommand(obj =>
                  {
                      Page.NavigationService.Navigate(AppState.InventoryPage);
                  }));
            }
        }
        public FightPageViewModel(Page _page)
        {
            appState = new AppState();
            Page = _page;
            appState.Enemy = new Barbarian();
            appState.Enemy.Barricade = new Barricade(50);
            BarricadeVisibility = "Visible";

            CharacterImage = AppState.GetImageFromSources(appState.Character!.ImageName);
            EnemyImage = AppState.GetImageFromSources(appState.Enemy!.ImageName);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
