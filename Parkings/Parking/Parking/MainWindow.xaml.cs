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

namespace Parking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.WindowStartupLocation=WindowStartupLocation.CenterScreen;
            home.ShowDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            string j = dateTime.ToString("t");
            MessageBox.Show(j);
        }
    }
}
