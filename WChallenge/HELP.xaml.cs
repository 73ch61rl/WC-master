using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;


namespace WChallenge
{
    public partial class HELP : PhoneApplicationPage
    {
        public HELP()
        {
            InitializeComponent();
        }

        private void emergency_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }


        private void WomenWelfareNrTB_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock number = (TextBlock)sender;
            String numberString = number.Text;
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            phoneCallTask.PhoneNumber = numberString;
            //phoneCallTask.DisplayName = "Gage";

            phoneCallTask.Show();

        }

        private void PoliceNrTB_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock number = (TextBlock)sender;
            String numberString = number.Text;
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            phoneCallTask.PhoneNumber = numberString;
            //phoneCallTask.DisplayName = "Gage";

            phoneCallTask.Show();
        }


    }
}