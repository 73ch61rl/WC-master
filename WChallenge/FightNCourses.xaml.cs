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
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using Microsoft.Phone.Maps.Services;
using Microsoft.Phone.Controls.Maps.Platform;
using Microsoft.Phone.Maps.Controls;


namespace WChallenge
{
    public partial class FightNCourses : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
       
        public FightNCourses()
        {
            InitializeComponent();
            this.DataContext = App.ViewModel;
            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            watcher.MovementThreshold = 20;


            watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            watcher.Start();

            

        }


        private void linkTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock linkTextBlock = (TextBlock)sender;
            String linkString = linkTextBlock.Text;
            String encryptedLink = HttpUtility.HtmlEncode(linkString);
            NavigationService.Navigate(new Uri("/BrowserPage.xaml?EncryptedLink=" + encryptedLink, UriKind.Relative));
        }

       

        private void FightNCourses_Loaded(object sender, RoutedEventArgs e)
        {
             Microsoft.Phone.Maps.Controls.MapLayer layer = new Microsoft.Phone.Maps.Controls.MapLayer();
         Pushpin a = new Pushpin();
         Pushpin b = new Pushpin();
          Pushpin c = new Pushpin();
         Pushpin d = new Pushpin();
         Pushpin f = new Pushpin();
          Pushpin g = new Pushpin();
            
            a.Content = "FIGHT LIKE A GIRL!";
            a.Location = new GeoCoordinate(34.117241, -117.733572);
            a.Tap += a_Tap;

            b.Content = "Smart Girl Summit 2013";
            b.Location = new GeoCoordinate(39.766276, -86.164895);
            b.Tap += b_Tap;

            c.Content = "Women In Networking Meeting";
            c.Location = new GeoCoordinate(33.759919, -118.116613);
            c.Tap += C_Tap;

            d.Content = "Return to Work - How and Why it is a Win-Wins - Webinar By MentorHealth";
            d.Location = new GeoCoordinate(33.759919, -118.116613);
            d.Tap += d_Tap;

            //layer.AddChild(a, a.Location);
            //layer.AddChild(b, b.Location);
            //layer.AddChild(c, c.Location);
            //layer.AddChild(d, d.Location);  

        //MapOverlay mo = new MapOverlay();
            //mo.Content = a;
            //mo.Content = b;
            //mo.Content = c;
            //mo.Content = d;
             

            map1.Children.Add(a);
            map1.Children.Add(b); 
            map1.Children.Add(c);
            map1.Children.Add(d);
             
        }
        Color currentAccentColorHex = (Color)Application.Current.Resources["PhoneAccentColor"];

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {

            map1.Center = new GeoCoordinate(39.766276, -86.164895);
            map1.ZoomLevel = 2;

            Microsoft.Phone.Maps.Controls.MapLayer layer = new Microsoft.Phone.Maps.Controls.MapLayer();
            SolidColorBrush backColor = new SolidColorBrush(currentAccentColorHex);

            Pushpin a = new Pushpin(); a.Background = backColor;
            Pushpin b = new Pushpin();  
            Pushpin c = new Pushpin();c.Background = backColor;
            Pushpin d = new Pushpin();  
            Pushpin f = new Pushpin(); f.Background = backColor;
            Pushpin g = new Pushpin();  

            a.Content = "FIGHT LIKE A GIRL!";
            a.Location = new GeoCoordinate(34.117241, -117.733572);
            a.Tap += a_Tap;

            b.Content = "Smart Girl Summit 2013";
            b.Location = new GeoCoordinate(39.766276, -86.164895);
            b.Tap += b_Tap;

            c.Content = "Women In Networking Meeting";
            c.Location = new GeoCoordinate(33.759919, -118.116613);
            c.Tap += C_Tap;

            d.Content = "Return to Work - How and Why it is a Win-Wins - Webinar By MentorHealth";
            d.Location = new GeoCoordinate(33.759919, -118.116613);
            d.Tap += d_Tap;

            //layer.AddChild(a, a.Location);
            //layer.AddChild(b, b.Location);
            //layer.AddChild(c, c.Location);
            //layer.AddChild(d, d.Location);  

            //MapOverlay mo = new MapOverlay();
            //mo.Content = a;
            //mo.Content = b;
            //mo.Content = c;
            //mo.Content = d;


            map1.Children.Add(a);
            map1.Children.Add(b);
            map1.Children.Add(c);
            map1.Children.Add(d);

            if (e.Position.Location.IsUnknown)
            {
                MessageBox.Show("Please wait while your position is determined....");
                return;
            }
        }

        private void d_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "http://plancast.com/p/ib0i/return-work-win-wins-webinar-mentorhealth";
            task.Show();
        }

        private void C_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "http://plancast.com/p/i8pe/women-networking-meeting-long-beach";
            task.Show();
        }

        private void b_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "http://plancast.com/p/glo0/smart-girl-summit-2013";
            task.Show();

        }

        private void a_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "http://plancast.com/p/i3o0/fight-like-girl-womens-self-defense";
            task.Show();

        }

        private void map1_KeyDown(object sender, KeyEventArgs e)
        {
           // pivot1.IsLocked = !pivot1.IsLocked;
        }

        
    }
}