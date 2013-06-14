/***************************************************************************
 * Class:       AbuseStories.xaml.cs
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
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq; 
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Threading;


namespace WChallenge
{
    public partial class AbuseStories : PhoneApplicationPage
    {
        List<Weight_per_Week> WW;
        public AbuseStories()
        {
            InitializeComponent();
            WW = new List<Weight_per_Week>();

            WW.Add(new Weight_per_Week { Weeks = "2001", Weight = 84 });
            WW.Add(new Weight_per_Week { Weeks = "2002", Weight = 75 });
            WW.Add(new Weight_per_Week { Weeks = "2003", Weight = 79 });
            WW.Add(new Weight_per_Week { Weeks = "2004", Weight = 78 });
            WW.Add(new Weight_per_Week { Weeks = "2005", Weight = 84 });
            WW.Add(new Weight_per_Week { Weeks = "2006", Weight = 98 });
            WW.Add(new Weight_per_Week { Weeks = "2007", Weight = 80 });
            WW.Add(new Weight_per_Week { Weeks = "2008", Weight = 81 });
            WW.Add(new Weight_per_Week { Weeks = "2009", Weight = 82 });
            WW.Add(new Weight_per_Week { Weeks = "2010", Weight = 75 });
            WW.Add(new Weight_per_Week { Weeks = "2011", Weight = 81 });
            WW.Add(new Weight_per_Week { Weeks = "2012", Weight = 75 }); 

            Chart.DataSource = WW;

          //  WebClient twitter = new WebClient(); 
         //   twitter.OpenReadCompleted += twitter_OpenReadCompleted;
           // twitter.DownloadReadCompleted += new DownloadStringCompletedEventHandler(twitter_downloadstringCompleted);
          //  twitter.OpenReadTaskAsync(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=" + "carnivalbug")); 
             
        }

        private void twitter_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(e.Error));


            //XElement xmlTweets = XElement.Parse(Convert.ToString(e.Result));
           
            //listboxtweets.ItemsSource = from tweet in xmlTweets.Descendants("status")
            //                            select new TwitterItem
            //                            {
            //                                ImageSource = tweet.Element("user").Element("profile_image_url").Value,
            //                                Message = tweet.Element("text").Value,

            //                            };

            //listboxtweets.Visibility = Visibility.Visible;
            //progressBar1.Visibility = Visibility.Collapsed;
        }

        //private void twitter_downloadstringCompleted(object sender, DownloadStringCompletedEventArgs e)
        //{
        //   // if (e.Error != null) return;

        //    MessageBox.Show(Convert.ToString(e.Error));
        //    XElement xmlTweets = XElement.Parse(e.Result);

        //    listboxtweets.ItemsSource = from tweet in xmlTweets.Descendants("status")
        //                                select new TwitterItem
        //                                {
        //                                    ImageSource = tweet.Element("user").Element("profile_image_url").Value,
        //                                    Message = tweet.Element("text").Value,

        //                                };

        //    listboxtweets.Visibility = Visibility.Visible;
        //    //progressBar1.Visibility = Visibility.Collapsed;
        //}
    }
}