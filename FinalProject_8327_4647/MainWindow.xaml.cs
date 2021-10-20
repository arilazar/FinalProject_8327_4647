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
using FinalProject_8327_4647.UserControls;

namespace FinalProject_8327_4647
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UIElement currentUserControl = null;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            DoStuff1();
        }
        public RelayCommand Cmd1 => new RelayCommand(DoStuff1);
        public RelayCommand Cmd2 => new RelayCommand(DoStuff2);
        public RelayCommand CmdTest => new RelayCommand(DoStuff3);

        private void DoStuff1()
        {
            DoStuff(new ImageDayUserControl());
        }

        private void DoStuff2()
        {
            DoStuff(new MainMenu());
        }

        private void DoStuff3()
        {
            DoStuff(new ImageSearchUC());
        }

        private void DoStuff(UIElement uc)
        {
            if (currentUserControl != null)
                myGrid.Children.Remove(currentUserControl);
            currentUserControl = uc;
            Grid.SetColumn(currentUserControl, 0);
            myGrid.Children.Add(currentUserControl);
        }
    }
}
