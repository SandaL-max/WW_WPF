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
using WW_WPF.BL;

namespace WW_WPF.ViewModels
{
    public class SelectCharacterViewModel : INotifyPropertyChanged
    {
        private Page page;

        public Page Page
        {
            get { return page; }
            set { page = value; }
        }
        private RelayCommand selectWarrior;
        public RelayCommand SelectWarrior
        {
            get
            {
                return selectWarrior ??
                  (selectWarrior = new RelayCommand(obj =>
                  {
                      var appState = new AppState();
                      appState.Character = new Warrior();
                      var fight = new FightPage();
                      Page.NavigationService.Navigate(fight);
                  }));
            }
        }
        private RelayCommand selectWizard;
        public RelayCommand SelectWizard
        {
            get
            {
                return selectWizard ??
                  (selectWizard = new RelayCommand(obj =>
                  {
                      var appState = new AppState();
                      appState.Character = new Wizard();
                      var fight = new FightPage();
                      Page.NavigationService.Navigate(fight);
                  }));
            }
        }
        public SelectCharacterViewModel(Page _page) { Page = _page; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
