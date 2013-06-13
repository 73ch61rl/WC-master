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
    public partial class FightNCourses : PhoneApplicationPage
    {
        public FightNCourses()
        {
            InitializeComponent();
            this.DataContext = App.ViewModel;
        }


        private void linkTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock linkTextBlock = (TextBlock)sender;
            String linkString = linkTextBlock.Text;
            String encryptedLink = HttpUtility.HtmlEncode(linkString);
            NavigationService.Navigate(new Uri("/BrowserPage.xaml?EncryptedLink=" + encryptedLink, UriKind.Relative));
        }
    }
}