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
        // public ObservableCollection<StepViewModel> Steps { get; private set; }

        public MainViewModel()
        {
            this.Items = new ObservableCollection<TechnicViewModel>();
            // this.Steps = new ObservableCollection<StepViewModel>();
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
            //this.Steps.Add(new StepViewModel() [{ Description="1", Done=false}, { Description="1", Done=false}]);
            //this.Steps.Add(new StepViewModel() { Description = "sfsfsfzsfsdfsdfsdfsdf", Done = false });
            var technic1Steps = new ObservableCollection<StepViewModel>();
            technic1Steps.Add(new StepViewModel() { Description = "Stand with your feet about 2 shoulder widths apart", Done = false });
            technic1Steps.Add(new StepViewModel() { Description = "Lift heels behind your toes", Done = false });
            technic1Steps.Add(new StepViewModel() { Description = "Come down, make sure that you keep your feet parallel and your upper body straight and vertical", Done = false });
            technic1Steps.Add(new StepViewModel() { Description = "Put your fists back next to your side", Done = false });
            technic1Steps.Add(new StepViewModel() { Description = "If you get a bear hug from behind do not panick, just drop in your horse stance to get free", Done = false });

            this.Items.Add(new TechnicViewModel()
            {
                Id = 0,
                Name = "Horse stance",
                Description = "Maecenas praesent accumsan bibendum",
                VideoLink = new Uri("http://www.youtube.com/watch?v=kTSgnaG3mhg"),
                percentageDone = 20,
                ImageLink = new Uri("http://goo.gl/zDsV3"),
                Thumb = new Uri("http://img.youtube.com/vi/kTSgnaG3mhg/0.jpg"),
                Step = technic1Steps
            });

            var technic2Steps = new ObservableCollection<StepViewModel>();
            technic2Steps.Add(new StepViewModel() { Description = "Get into a horse stance", Done = false });
            technic2Steps.Add(new StepViewModel() { Description = "Open your hands", Done = false });
            technic2Steps.Add(new StepViewModel() { Description = "Push you heels a little forward and pull fingers a little back", Done = false });
            technic2Steps.Add(new StepViewModel() { Description = "Hit an attacker to the nose with one hand", Done = false });
            technic2Steps.Add(new StepViewModel() { Description = "Hit with the ohther hand", Done = false });
            //technic1Steps.Add(new StepViewModel() { Description = "", Done = false });


            this.Items.Add(new TechnicViewModel()
            {
                Id = 1,
                Name = "Pulm heel strike to the nose",
                Description = "Maecenas praesent accumsan bibendum",
                VideoLink = new Uri("http://www.youtube.com/watch?v=SZO9iX1vRsM"),
                percentageDone = 20,
                ImageLink = new Uri("http://goo.gl/zDsV3"),
                Thumb = new Uri("http://img.youtube.com/vi/SZO9iX1vRsM/0.jpg"),
                Step = technic2Steps
            });
            this.Items.Add(new TechnicViewModel() { Id = 1, Name = "groin attack", Description = "ggggDictumst eleifend facilisi faucibus", percentageDone = 54 });
            this.Items.Add(new TechnicViewModel() { Id = 2, Name = "fist power", Description = "Habitant inceptos interdum lobortis", percentageDone = 60 });
            this.Items.Add(new TechnicViewModel() { Id = 3, Name = "choke escape", Description = "Maecenas praesent accumsan bibendum", percentageDone = 80 });

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