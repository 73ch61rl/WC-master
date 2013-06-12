/***************************************************************************
 * Class:       Technique.xaml.cs
 * Made by:     Jalen Ins team (Maimuna Syed, Olga Shakurova, Irina Smirnova)
 * Country:     Finland
 * Year:        2013
 * -------------------------------------------------------------------------
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

namespace WChallenge
{
    public partial class Tips : PhoneApplicationPage
    {
       private TipViewModel selectedTip = null;
        public Tips()
        {
            InitializeComponent();
            this.DataContext = App.ViewModel;
            this.Loaded += Tips_Loaded;

        }

        void Tips_Loaded(object sender, RoutedEventArgs e)
        {
            //ListBoxTips.SelectedItem = selectedTip;
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (NavigationContext.QueryString.ContainsKey("Title"))
            {
                String encryptedTitle = NavigationContext.QueryString["Title"];
                String title = HttpUtility.HtmlDecode(encryptedTitle);

                TipViewModel foundTip = null;
                foreach (TipViewModel tip in App.ViewModel.Tips)
                {
                    if (tip.TipName == title)
                    {
                        foundTip = tip;
                        break;
                    }
                }

                if (foundTip != null)
                {
                    //ListBoxTips.SelectedItem = foundTip;
                    selectedTip = foundTip;
                }
            }
        }
    }
}