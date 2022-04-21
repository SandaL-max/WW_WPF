using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WW_WPF.BL;
using WW_WPF.ViewModels;

namespace WW_WPF
{
    public class AppState : INotifyPropertyChanged
    {
        private static Character? character;
        public Character? Character
        {
            get
            {
                return character;
            }
            set
            {
                character = value;
                OnPropertyChanged("Character");
            }
        }
        private static Enemy? enemy;
        public Enemy? Enemy
        {
            get
            {
                return enemy;
            }
            set
            {
                enemy = value;
                OnPropertyChanged("Enemy");
            }
        }
        public static Window? MainWindow { get; set; }

        //public static event PropertyChangedEventHandler StaticPropertyChanged;
        //public static void OnStaticPropertyChanged(string pname)
        //{
        //    PropertyChangedEventArgs e = new PropertyChangedEventArgs(pname);
        //    PropertyChangedEventHandler h = StaticPropertyChanged;
        //    if (h != null)
        //        h(null, e);

        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
