using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WChallenge
{
    public partial class BrowserPage : PhoneApplicationPage
    {
        private String link = null;


        public BrowserPage()
        {
            InitializeComponent();
            //Loaded += BrowserPage_Loaded;
        }

        //void BrowserPage_Loaded(object sender, RoutedEventArgs e)
        //{

        //}

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.ContainsKey("EncryptedLink"))
            {
                string encryptedLink = NavigationContext.QueryString["EncryptedLink"];
                link = HttpUtility.HtmlDecode(encryptedLink);
                webBrowser.Navigate(new Uri(link, UriKind.Absolute));
                
                //Browse_Tap(null, null);
            }
        }

        //private void Browse_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    if (link != null && link != "")
        //    {
        //        //string encryptedLink = NavigationContext.QueryString["EncryptedLink"];
        //        //link = HttpUtility.HtmlDecode(encryptedLink);
        //        webBrowser.Navigate(new Uri(link, UriKind.Absolute));

        //    }
        //}

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/FightNCourses.xaml", UriKind.Relative));
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}