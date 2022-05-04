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
    public class GameOverViewModel
    {
        private Page page;

        public Page Page
        {
            get { return page; }
            set { page = value; }
        }
        public GameOverViewModel(Page _page)
        {
            Page = _page;
        }
        private RelayCommand _btnRestart;
        public RelayCommand btnRestart
        {
            get
            {
                return _btnRestart ??
                  (_btnRestart = new RelayCommand(obj =>
                  {
                      var SelectCharacter = new SelectCharacter();
                      Page.NavigationService.Navigate(SelectCharacter);
                  }));
            }
        }
    }
}
