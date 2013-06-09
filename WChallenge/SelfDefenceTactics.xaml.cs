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
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Xml;
using System.IO.IsolatedStorage;
using System.IO;

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
            ObservableCollection<TechniqueViewModel> Items = new ObservableCollection<TechniqueViewModel>();
            while (FightList.SelectedItems.Count > 0)
            {
                foreach (TechniqueViewModel t in FightList.SelectedItems)
                {
                   
                    Items.Add(t);
                }
            }
            SaveInIS(Items);
        }
      

        private void SaveInIS(ObservableCollection<TechniqueViewModel> items)
        {
            ObservableCollection<TechniqueViewModel> _list = new ObservableCollection<TechniqueViewModel>();

            //OPens the USerItem xml file 
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("UserItems.xml", FileMode.OpenOrCreate))
                    {
                        if (stream.Length > 0)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TechniqueViewModel>));
                            _list = (ObservableCollection<TechniqueViewModel>)serializer.Deserialize(stream);
                        }

                    }
                }
            }
            catch
            {
                //MessageBox.Show("nothing in the list");  
            }

            foreach(TechniqueViewModel t in items ){
            _list.Add(t);
            }

            MessageBox.Show(_list[3].Name);

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {

                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Hello.xml", FileMode.OpenOrCreate))
                {

                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TechniqueViewModel>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        serializer.Serialize(xmlWriter, _list);
                       
                    }


                }
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