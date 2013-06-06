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
using System.Collections.ObjectModel;
using System.Xml;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml.Serialization;





namespace WChallenge
{
    public partial class Technique : PhoneApplicationPage
    {
        public ObservableCollection<TechnicViewModel> Items { get; private set; }

        public Technique()
        {
            InitializeComponent();
            Items = App.ViewModel.Items;

        }

        public int techniqueId = 0;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string _techniqueId;

            if (NavigationContext.QueryString.TryGetValue("TechniqueId", out _techniqueId))
            {
                techniqueId = Convert.ToInt16(_techniqueId);
            }

 
            if (IsolatedStorageSettings.ApplicationSettings.Contains("UserTechniques"))
            {
                this.DataContext = ((ObservableCollection<TechnicViewModel>)IsolatedStorageSettings.ApplicationSettings["UserTechniques"])[techniqueId];
            } 
            else 
            {
                this.DataContext = Items[techniqueId];
            } 
        } 
        

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            String technicName = tbTechnicName.Text.ToString();
            TechnicViewModel result = Items.Where(X => X.Name == technicName).FirstOrDefault();
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            //webBrowserTask.Uri = new Uri(result.VideoLink.ToString(), UriKind.Absolute);
            webBrowserTask.URL = "vnd.youtube:" + result.VideoLink.ToString().Substring(result.VideoLink.ToString().LastIndexOf("=") + 1);
            webBrowserTask.Show();  
        } 

        
        void SaveData()
        {
            IsolatedStorageSettings.ApplicationSettings.Clear();
            IsolatedStorageSettings.ApplicationSettings["UserTechniques"] = App.ViewModel.Items;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            SaveData(); 
        }


    }
}