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
    public class InventoryPageViewModel : INotifyPropertyChanged
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
        private IItem selectedItem;
        public IItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        private Page page;

        public Page Page
        {
            get { return page; }
            set { page = value; }
        }
        public InventoryPageViewModel(Page _page)
        {
            Page = _page;
            appState = new AppState();
        }

        private RelayCommand _btnReturn;
        public RelayCommand btnReturn
        {
            get
            {
                return _btnReturn ??
                  (_btnReturn = new RelayCommand(obj =>
                  {
                      Page.NavigationService.Navigate(AppState.FightPage);
                  }));
            }
        }
        private RelayCommand _btnUse;
        public RelayCommand btnUse
        {
            get
            {
                return _btnUse ??
                  (_btnUse = new RelayCommand(obj =>
                  {
                      IItem? _selectedItem = obj as IItem;
                      if (_selectedItem is not null)
                      {
                          _selectedItem.OnUse(appState.Character!);
                      }
                  },
                  (obj) => appState.Character!.Inventory.Count > 0));
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
