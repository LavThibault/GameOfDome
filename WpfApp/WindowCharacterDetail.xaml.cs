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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Logique d'interaction pour WindowCharacterDetail.xaml
    /// </summary>
    public partial class WindowCharacterDetail : Window
    {
        public WindowCharacterDetail()
        {
            InitializeComponent();
            DataContext = new GeneralObservable(4, "jean", "pierre");
        }
    }
}
