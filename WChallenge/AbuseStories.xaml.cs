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
        public AbuseStories()
        {
            InitializeComponent(); 

            WebClient twitter = new WebClient();
            twitter.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter_downloadstringCompleted);
            twitter.DownloadStringAsync(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=" + "defenseforwomen"));

        }

        private void twitter_downloadstringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null) return;

            XElement xmlTweets = XElement.Parse(e.Result); 

            listboxtweets.ItemsSource = from tweet in xmlTweets.Descendants("status")
                                        select new TwitterItem
                                        {
                                            ImageSource = tweet.Element("user").Element("profile_image_url").Value,
                                            Message = tweet.Element("text").Value,

                                        };
            listboxtweets.Visibility = Visibility.Visible;
            progressBar1.Visibility = Visibility.Collapsed;
        }
    }
}