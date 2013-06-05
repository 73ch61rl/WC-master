using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell; 
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.ObjectModel; 


namespace WChallenge
{
    public partial class Technique : PhoneApplicationPage
    {
        public List<TechnicViewModel> Items { get; private set; }
        public IsolatedStorageSettings stepsStorage = IsolatedStorageSettings.ApplicationSettings;

        public string _techniqueId;
        public int techniqueId;

        public Technique()
        {
            InitializeComponent(); 
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.TryGetValue("TechniqueId", out _techniqueId))
            {
                techniqueId = Convert.ToInt16(_techniqueId);
                this.DataContext = App.ViewModel.Items[techniqueId];
                step1Stack.DataContext = App.ViewModel.Items[techniqueId].Steps[0];
                step2Stack.DataContext = App.ViewModel.Items[techniqueId].Steps[1];
                step3Stack.DataContext = App.ViewModel.Items[techniqueId].Steps[2];

                if (App.ViewModel.Items[techniqueId].Steps.Count() > 2)
                {
                    step4Stack.DataContext = App.ViewModel.Items[techniqueId].Steps[3];
                }
                else step4Stack.Visibility = Visibility.Collapsed;

                if (App.ViewModel.Items[techniqueId].Steps.Count() > 3)
                {
                      step5Stack.DataContext = App.ViewModel.Items[techniqueId].Steps[4];
                }
                else step5Stack.Visibility = Visibility.Collapsed;

          
            }

            //try
            //{
            //    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            //    {
            //        using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Hello.xml", FileMode.OpenOrCreate))
            //        {
            //            XmlSerializer serializer = new XmlSerializer(typeof(List<TechnicViewModel>));
            //            Items = (List<TechnicViewModel>)serializer.Deserialize(stream);
            //           // listseletor.ItemsSource = Items;


            //            if (Items.Count > 0)
            //            {
                             
            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    //add some code here
            //}
             
             
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            //xmlWriterSettings.Indent = true;
            //using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            //{

            //    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Steps.xml", FileMode.OpenOrCreate))
            //    {
            //        if (stream.Length > 0)
            //        {
            //            XmlSerializer serializer = new XmlSerializer(typeof(List<StepViewModel>));

            //            using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
            //            {
            //                serializer.Serialize(xmlWriter, Items);

            //            }
            //        }
            //    }
            //}
        }

    }


}