using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using Microsoft.Phone.Tasks;

namespace WChallenge
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
       
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
              MessageBoxResult m =  MessageBox.Show("You arent connected to the internet to load the techniques. Want to connect now?", "No connection", MessageBoxButton.OKCancel);
                if(m==MessageBoxResult.OK){
                    ConnectionSettingsTask connectionSettingsTask = new ConnectionSettingsTask();
                    connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.WiFi;
                    connectionSettingsTask.Show();
                }
                if (m == MessageBoxResult.Cancel)
                {
                    
                }
               


            }
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }
         
        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData(); 
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
          

           //MessageBox.Show("MAINPAGE= "+Convert.ToString(App.ViewModel.Items[0].percentageDone));
        }


        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (TechnicListBox.SelectedIndex == -1)
                return;
                TechnicViewModel item = new TechnicViewModel();
                item = TechnicListBox.SelectedItem as TechnicViewModel;
                NavigationService.Navigate(new Uri("/Technique.xaml?TechniqueId=" + item.Id, UriKind.Relative));
            
            TechnicListBox.SelectedIndex = -1;

            
        }

        

        private void fight_manuervers_Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SelfDefenceTactics.xaml", UriKind.Relative));
        }

        private void abuse_feeds_Click_3(object sender, RoutedEventArgs e)
        {

        }




    }
}