using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace WChallenge
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
            
        }

        private void I4_Click(object sender, RoutedEventArgs e)
        {
            I4.BorderBrush = new SolidColorBrush( Colors.Green );
            I1.BorderBrush = new SolidColorBrush(Colors.Transparent);
            I2.BorderBrush = new SolidColorBrush(Colors.Transparent);
            I3.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }

        private void I3_Click(object sender, RoutedEventArgs e)
        {
            I4.BorderBrush = new SolidColorBrush(Colors.Transparent);
            I1.BorderBrush = new SolidColorBrush(Colors.Transparent);
            I2.BorderBrush = new SolidColorBrush(Colors.Transparent);
            I3.BorderBrush = new SolidColorBrush(Colors.Purple);
        }

        private void I2_Click(object sender, RoutedEventArgs e)
        {
            I4.BorderBrush = new SolidColorBrush(Colors.Transparent);
            I1.BorderBrush = new SolidColorBrush(Colors.Transparent);
            I2.BorderBrush = new SolidColorBrush(Colors.Cyan);
            I3.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }

        private void I1_Click(object sender, RoutedEventArgs e)
        {
            I4.BorderBrush = new SolidColorBrush(Colors.Transparent);
            I1.BorderBrush = new SolidColorBrush(Colors.Yellow);
            I2.BorderBrush = new SolidColorBrush(Colors.Transparent);
            I3.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }

       
    }
}