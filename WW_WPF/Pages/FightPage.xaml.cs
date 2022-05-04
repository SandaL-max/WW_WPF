﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WW_WPF.BL;
using WW_WPF.ViewModels;

namespace WW_WPF
{
    /// <summary>
    /// Логика взаимодействия для FightPage.xaml
    /// </summary>
    public partial class FightPage : Page
    {
        public FightPage()
        {
            InitializeComponent();
            DataContext = new FightPageViewModel(this);
        }
    }
}
