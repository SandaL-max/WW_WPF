using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WW_WPF.BL;

namespace WW_WPF.ViewModels
{
    public class SelectCharacterViewModel : INotifyPropertyChanged
    {
        private Character character;
        private Enemy enemy;

        public Character Character
        {
            get { return character; }
            set { character = value; }
        }
        public Enemy Enemy
        {
            get { return enemy; }
            set { enemy = value; }
        }

        public SelectCharacterViewModel()
        {
            character = new Warrior();
            enemy = new Barbarian();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
