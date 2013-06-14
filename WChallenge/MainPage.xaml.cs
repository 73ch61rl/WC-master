/***************************************************************************
 * Class:       MainPage.xaml.cs
 * Made by:     Jalen Ins team (Maimuna Syed, Olga Shakurova, Irina Smirnova)
 * Country:     Finland
 * Year:        2013
 * ------------------------------------------------------------------------
 * Application: KIAI!
 * Description: Self-defence guide for women
 * Competition: Imagine Cup - Women's Athletic App Challenge
 * Category:    Sport
 * 
 ***************************************************************************/
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
                MessageBoxResult m = MessageBox.Show("You arent connected to the internet to load the techniques. Want to connect now?", "No connection", MessageBoxButton.OKCancel);
                if (m == MessageBoxResult.OK)
                {
                    ConnectionSettingsTask connectionSettingsTask = new ConnectionSettingsTask();
                    connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.WiFi;
                    connectionSettingsTask.Show();
                }
                if (m == MessageBoxResult.Cancel)
                {

                } 
            }

TreeHelper treeHelper = new TreeHelper();
 for (int i = 0; i < TechnicListBox.Items.Count(); i++)
{
 var currentSelectedListBoxItem = this.TechnicListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
CharacterProgressControl.WP8.CProgressControl cp = treeHelper.FindDescendant<CharacterProgressControl.WP8.CProgressControl>(currentSelectedListBoxItem);
cp.Value = 50;
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
            TechniqueViewModel item = new TechniqueViewModel();
            item = TechnicListBox.SelectedItem as TechniqueViewModel;
            NavigationService.Navigate(new Uri("/Technique.xaml?TechniqueId=" + item.Id, UriKind.Relative));

            TechnicListBox.SelectedIndex = -1;


        }



        private void fight_manuervers_Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SelfDefenceTactics.xaml", UriKind.Relative));
        }

        private void abuse_feeds_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AbuseStories.xaml", UriKind.Relative));
        }

        private void safety_tips_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Tips.xaml", UriKind.Relative));
        }

        private void hub_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            HubTile hubTileRandomTip = (HubTile)sender;
            String title = hubTileRandomTip.Title;
            String encryptedTitle = HttpUtility.HtmlEncode(title);
            NavigationService.Navigate(new Uri("/Tips.xaml?Title=" + encryptedTitle, UriKind.Relative));
        }

        private void Freeze_Over(object sender, MouseEventArgs e)
        {
            HubTileService.FreezeGroup("Freeze");
        }

        private void HubTile_MouseLeave(object sender, MouseEventArgs e)
        {
            HubTileService.UnfreezeGroup("Freeze");

        }

        private void courseNclass_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FightNCourses.xaml", UriKind.Relative));
        }

        private void header_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Kiai! (kee-yai) is an app that helps you to memorize self defence tactics that is vital for all to know. The tactics are optimized for females general body index.", "About Kiai", MessageBoxButton.OK);
        }

        private void settinsTap_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HELP.xaml", UriKind.Relative));
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }






    }
}