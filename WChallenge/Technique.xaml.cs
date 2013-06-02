using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;

namespace WChallenge
{
    public partial class Technique : PhoneApplicationPage
    {
        public ObservableCollection<TechnicViewModel> Items { get; private set; }

        public Technique()
        {
            InitializeComponent();
            Items=App.ViewModel.Items;
             
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string _techniqueId;
            int techniqueId;
            if (NavigationContext.QueryString.TryGetValue("TechniqueId", out _techniqueId))
            {
                techniqueId = Convert.ToInt16(_techniqueId);
                this.DataContext = Items[techniqueId];
            }
           

        }


    }
}