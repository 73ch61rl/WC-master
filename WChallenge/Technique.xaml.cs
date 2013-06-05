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
using Microsoft.Phone.Tasks; 


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
        

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {

            TechnicViewModel result = App.ViewModel.Items[techniqueId];
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            //webBrowserTask.Uri = new Uri(result.VideoLink.ToString(), UriKind.Absolute);
            webBrowserTask.URL = "vnd.youtube:" + result.VideoLink.ToString().Substring(result.VideoLink.ToString().LastIndexOf("=") + 1);
            webBrowserTask.Show();

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /*Dynamic parsing to find the techniq id selected and bind data via data context*/
            if (NavigationContext.QueryString.TryGetValue("TechniqueId", out _techniqueId))
            {
                techniqueId = Convert.ToInt16(_techniqueId);
                this.DataContext = App.ViewModel.Items[techniqueId]; 
                StepsList.ItemsSource = App.ViewModel.Items[techniqueId].Steps; 
            }


            /*Reads user's previous checkbox manipulation and databinds it */
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
            /*Saves users checkboxes to isolated storage */
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