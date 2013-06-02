using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;
using WChallenge;


namespace WChallenge
{
    public class MainViewModel : INotifyPropertyChanged 
    {
        public ObservableCollection<TechnicViewModel> Items { get; private set; }
        public ObservableCollection<StepViewModel> Steps { get; private set; }

        public MainViewModel()
        {
            this.Items = new ObservableCollection<TechnicViewModel>();
            this.Steps = new ObservableCollection<StepViewModel>();
         }
         

        private string _sampleProperty = "Sample Runtime Property Value"; 
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

 
        public async void LoadData()
        {
            // Sample data; replace with real data
            this.Steps.Add(new StepViewModel() { Description="sfsfsfzsfsdfsdfsdfsdf", Done=false});
            this.Steps.Add(new StepViewModel() { Description = "sfsfsfzsfsdfsdfsdfsdf", Done = false });
            this.Items.Add(new TechnicViewModel() { Id=0, Name = "nose punch", Description = "Maecenas praesent accumsan bibendum", VideoLink = new Uri("http://youtu.be/IYjd0pTsqyw"), percentageDone = 20, ImageLink = new Uri("http://goo.gl/zDsV3") });           
          
            this.Items.Add(new TechnicViewModel() {Id=1,  Name = "groin attack", Description = "ggggDictumst eleifend facilisi faucibus", percentageDone = 54 });
            this.Items.Add(new TechnicViewModel() { Id=2,Name = "fist power", Description = "Habitant inceptos interdum lobortis", percentageDone = 60 });
            this.Items.Add(new TechnicViewModel() { Id=3,Name = "choke escape", Description = "Maecenas praesent accumsan bibendum", percentageDone = 80 });
      //      await App.MobileService.GetTable<TechnicViewModel>().InsertAsync(Items[1]);


              //Item item = new Item { Text = "Awesome item" }; 
            //await App.MobileService.GetTable<Item>().InsertAsync(item);
             
            this.IsDataLoaded = true;
        }

       // public class Item { public int Id { get; set; } public string Text { get; set; } }
       

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}