using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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

        public static Page? SelectCharacterPage { get; set; }
        public static Page? FightPage { get; set; }
        public static Page? InventoryPage { get; set; }
        public static Page? GameOverPage { get; set; }

        private const string ResorcesPath = "pack://application:,,,/WW_WPF;component/resources/";
        public static TransformedBitmap GetImageFromSources(string name)
        {
            var bitMapImage = new BitmapImage();
            bitMapImage.BeginInit();
            bitMapImage.UriSource = new Uri(ResorcesPath + name);
            bitMapImage.EndInit();

            var tbm = new TransformedBitmap();
            tbm.BeginInit();
            tbm.Source = bitMapImage;
            tbm.EndInit();
            return tbm;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
