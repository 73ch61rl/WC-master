using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections;
using System.ComponentModel;

namespace WChallenge
{
    public partial class SelfDefenceTactics : PhoneApplicationPage
    {
        ApplicationBarIconButton select;
        ApplicationBarIconButton add;
        int width;

        public SelfDefenceTactics()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
           
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            select = new ApplicationBarIconButton();
            select.IconUri = new Uri("/BarIcons/ApplicationBar.Select.png", UriKind.RelativeOrAbsolute);
            select.Text = "select";
            select.Click += select_fights_Click;

            add = new ApplicationBarIconButton();
            add.IconUri = new Uri("/BarIcons/ApplicationBar.Check.png", UriKind.RelativeOrAbsolute);
            add.Text = "add";
            add.Click += add_Click;
        }


        void add_Click(object sender, EventArgs e)
        {
            IList source = FightList.ItemsSource as IList;
            while (FightList.SelectedItems.Count > 0)
            {
                //save list/oc in isolated storage
            }
        }


        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }


        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            MultiselectList target = (MultiselectList)sender;
            ApplicationBarIconButton i = (ApplicationBarIconButton)ApplicationBar.Buttons[0];

            if (target.IsSelectionEnabled)
            { 
                if (target.SelectedItems.Count > 0)
                {
                    i.IsEnabled   = true;
                }
                else
                {
                    i.IsEnabled  = false;
                }
            }
            else
            {
                i.IsEnabled = true;
            }
        }

        

        private void select_fights_Click(object sender, EventArgs e)
        {
            FightList.IsSelectionEnabled = true;
            FightList.Width = FightList.Width - 100;
        }

        private void IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            while (ApplicationBar.Buttons.Count > 0)
            {
                ApplicationBar.Buttons.RemoveAt(0);
            }
 
            if ((bool)e.NewValue)
            {
                ApplicationBar.Buttons.Add(add);
                ApplicationBarIconButton i = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                i.IsEnabled = false;
            }

            else
            {
                ApplicationBar.Buttons.Add(select);
            }
        }


        private void fight_man_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This page shows you all the defence techniques you can use to defend yourself from attacks. Choose the ones you want to learn and track your progress from the main page.", "About", MessageBoxButton.OK);

        }
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            if (FightList.IsSelectionEnabled)
            {
                FightList.IsSelectionEnabled = false;
                FightList.Width = FightList.Width + 100;
                e.Cancel = true;
            }
          
        }
      
    }
}